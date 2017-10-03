using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using SharpConnect.MySql;
using SharpConnect.MySql.SyncPatt;

public class RestReportsHandler : IHttpHandler
{
    private bool _bypassAuth = false;

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

    private byte[] turnImageToByteArray(System.Drawing.Image img)
    {
        MemoryStream ms = new MemoryStream();
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms.ToArray();
    }

    /// <summary>
    /// Replace all 'src' of 'img' tag with encoded version of image file
    /// </summary>
    /// <param name="url"></param>
    /// <param name="cookies"></param>
    /// <param name="htmlData"></param>
    /// <returns></returns>
    private string replaceHtmlTagImg(string url, CookieContainer cookies, string htmlData)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(htmlData);
        var imgs = doc.DocumentNode.SelectNodes("//img");

        foreach (var img in imgs)
        {
            string orig = img.Attributes["src"].Value;

            if (orig.IndexOf("__sessionid", StringComparison.InvariantCultureIgnoreCase) >= 0 &&
                orig.IndexOf("__imageid", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                Uri uri = new Uri(url);
                string host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                host = host + HttpUtility.HtmlDecode(orig);

                HttpWebRequest imgRequest = (HttpWebRequest)WebRequest.Create(host);
                imgRequest.CookieContainer = cookies;
                HttpWebResponse imgResponse = (HttpWebResponse)imgRequest.GetResponse();


                if (imgResponse.StatusCode == HttpStatusCode.OK)
                {
                    Image imgObj = Image.FromStream(imgResponse.GetResponseStream());
                    byte[] imgBytes = turnImageToByteArray(imgObj);
                    string imgBase64String = Convert.ToBase64String(imgBytes);
                    imgResponse.Close();
                    img.SetAttributeValue("src", "data:image/png;base64," + imgBase64String);
                }
                //else
                //{
                //    throw new Exception(imgResponse.StatusDescription);
                //}
            }
        }

        return doc.DocumentNode.OuterHtml;
    }

    /// <summary>
    /// Call Birt and obtain report in HTML format
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private string ReadHtmlBase64(string url)
    {
        CookieContainer cookies = new CookieContainer();
        var httpRequest = WebRequest.Create(url) as HttpWebRequest;
        httpRequest.CookieContainer = cookies;
        HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

        string htmlData = "";
        if (httpResponse.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = httpResponse.GetResponseStream();
            StreamReader readStream = null;

            if (httpResponse.CharacterSet == null && httpResponse.CharacterSet == "")
            {
                readStream = new StreamReader(receiveStream);
            }
            else
            {
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(httpResponse.CharacterSet));
            }

            htmlData = readStream.ReadToEnd();

            httpResponse.Close();
            readStream.Close();
        }
        else
        {
            throw new Exception(httpResponse.StatusDescription);
        }

        htmlData = replaceHtmlTagImg(url, cookies, htmlData);
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(htmlData);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    /// <summary>
    /// Call Birt and obtain report in PDF format
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private string ReadPdfBase64(string url)
    {
        var httpRequest = WebRequest.Create(url) as HttpWebRequest;
        var httpResponse = httpRequest.GetResponse();
        MemoryStream memoryStream = new MemoryStream();
        httpResponse.GetResponseStream().CopyTo(memoryStream);

        byte[] bytedata = memoryStream.ToArray();
        String base64 = Convert.ToBase64String(bytedata);

        httpResponse.Close();
        return base64;
    }

    /*private string GetReportFileName(int idReport, MySqlTransaction transaction)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = transaction.Connection;
        cmd.Transaction = transaction;
        cmd.CommandText = "select Parameters from t_report_mng_list where id=" + idReport;

        MySqlDataReader reader = cmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                string parametri = reader["Parameters"].ToString();
                string[] arrayParametri = parametri.Split('&');
                foreach (string parametro in arrayParametri)
                    if (parametro.ToLower().StartsWith("__report"))
                        return parametro.Split('=')[1];
            }
        }
        finally
        {
            reader.Close();
        }

        return string.Empty;
    }

    private string GetReportName(int idReport, MySqlTransaction transaction)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = transaction.Connection;
        cmd.Transaction = transaction;
        cmd.CommandText = "select Report from t_report_mng_list where id=" + idReport;
        MySqlDataReader reader = cmd.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                return reader["Report"].ToString();
            }
        }
        finally
        {
            reader.Close();
        }

        return string.Empty;
    }

    private string GetReportLocation(int idReport, MySqlTransaction transaction)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = transaction.Connection;
        cmd.Transaction = transaction;
        cmd.CommandText = "select Location from t_report_mng_list where id=" + idReport;
        MySqlDataReader reader = cmd.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                return reader["Location"].ToString();
            }
        }
        finally
        {
            reader.Close();
        }

        return string.Empty;
    }

    private string GetReportDescription(int idReport, MySqlTransaction transaction)
    {
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = transaction.Connection;
        cmd.Transaction = transaction;
        cmd.CommandText = "select Description from t_report_mng_list where id=" + idReport;
        MySqlDataReader reader = cmd.ExecuteReader();

        try
        {
            while (reader.Read())
            {
                return reader["Description"].ToString();
            }
        }
        finally
        {
            reader.Close();
        }

        return string.Empty;
    }*/

    public void ProcessRequest(HttpContext context)
    {
        var appSettings = ConfigurationManager.AppSettings;

        if (_bypassAuth == false)
        {
            string stHeaderName = appSettings["stHeaderName"];

            #region Check if ticket exists
            if (context.Request.Headers[stHeaderName] == null)
            {
                context.Response.StatusCode = 401;
                context.Response.StatusDescription = "Missing "+ stHeaderName;
                context.Response.Flush(); // Sends all currently buffered output to the client.
                context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                context.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                return;
            }
            #endregion

            #region Validate ticket
            string ticketId = context.Request.Headers[stHeaderName].ToString();
            string userAapiBasePath = appSettings["userAapiBasePath"];
            string serviceId = appSettings["serviceId"];

            HttpWebRequest ticketValidationRequest = (HttpWebRequest)WebRequest.Create(userAapiBasePath + "/tickets/" + ticketId + "/validate?serviceId=" + serviceId);
            //HttpWebRequest ticketValidationRequest = (HttpWebRequest)WebRequest.Create("http://integration.operando.esilab.org:8135/operando/interfaces/aapi/aapi/tickets/ST-153-IdpicdDveXntfoZiR0Jz-casdotoperandodoteu/validate?serviceId=GET/osp/reports/.*");
            try
            {
                var response = (HttpWebResponse)ticketValidationRequest.GetResponse();
            }
            catch (WebException ex)
            {
                /*HttpWebResponse errResponse = (HttpWebResponse)ex.Response;
                context.Response.StatusCode = (int)errResponse.StatusCode;
                context.Response.StatusDescription = errResponse.StatusDescription;
                context.Response.Flush(); // Sends all currently buffered output to the client.
                context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                context.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                return;*/
                context.Response.StatusCode = 401;
                context.Response.StatusDescription = "service ticket (ST) is invalid";
                context.Response.Flush(); // Sends all currently buffered output to the client.
                context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                context.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                return;
            }
            #endregion
        }

        #region Validate query string param
        if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["_reportid"]))
        {
            context.Response.StatusCode = 400;
            context.Response.StatusDescription = "Missing _reportId";
            context.Response.Flush(); // Sends all currently buffered output to the client.
            context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            context.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            return;
        }

        int idReport = -1;
        if (!Int32.TryParse(HttpContext.Current.Request.QueryString["_reportid"], out idReport))
        {
            context.Response.StatusCode = 400;
            context.Response.StatusDescription = "_reportid must be integer value";
            context.Response.Flush(); // Sends all currently buffered output to the client.
            context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            context.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            return;
        }

        if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["_format"]))
        {
            context.Response.StatusCode = 400;
            context.Response.StatusDescription = "Missing _format";
            context.Response.Flush(); // Sends all currently buffered output to the client.
            context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            context.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            return;
        }

        string reportFormat = HttpContext.Current.Request.QueryString["_format"].ToLower();
        if (!reportFormat.Equals("html") &&
            !reportFormat.Equals("htm") &&
            !reportFormat.Equals("pdf"))
        {
            context.Response.StatusCode = 400;
            context.Response.StatusDescription = "Invalid _format";
            context.Response.Flush(); // Sends all currently buffered output to the client.
            context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            context.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            return;
        }
        #endregion

        
        MySqlConnection connection = null;
        MySqlDataReader reader = null;

        try
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
            connection.Open();

            string query = "SELECT * FROM t_report_mng_list where id = " + idReport;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            reader = cmd.ExecuteReader();

            /*DataTable dt = new DataTable();
            dt.Load(reader);*/

            if (!reader.HasRows)
            {
                context.Response.StatusCode = 404;
                context.Response.StatusDescription = "Report not found";
                context.Response.Flush(); // Sends all currently buffered output to the client.
                context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                context.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                return;
            }
            else
            {
                reader.Read();

                string reportLocation = reader.GetString("Location"); // dt.Rows[0]["Location"].ToString();
                string reportFileName = "";

                string parametri = reader.GetString("Parameters"); //dt.Rows[0]["Parameters"].ToString();
                string[] arrayParametri = parametri.Split('&');
                foreach (string parametro in arrayParametri)
                {
                    if (parametro.ToLower().StartsWith("__report"))
                        reportFileName = parametro.Split('=')[1];
                }

                string reportName = reader.GetString("Report"); //dt.Rows[0]["Report"].ToString();
                string reportDescription = reader.GetString("Description"); //dt.Rows[0]["Description"].ToString();

                reportLocation = reportLocation.Replace("/frameset", "/preview");
                reportLocation += "?__format=" + reportFormat;
                reportLocation += "&__report=" + HttpUtility.UrlEncode(reportFileName);

                foreach (string param in HttpContext.Current.Request.QueryString.AllKeys)
                {
                    if (param != null)
                    {
                        if (!param.ToLower().Equals("_reportid"))
                            reportLocation += "&" + HttpUtility.UrlEncode(param) + "=" + HttpUtility.UrlEncode(HttpContext.Current.Request.QueryString[param]);
                    }
                }

                Report report = new Report();
                report.ID = idReport;
                report.Name = reportName;
                report.Description = reportDescription;

                if (reportFormat.Equals("html") || reportFormat.Equals("htm"))
                    report.Base64 = ReadHtmlBase64(reportLocation);
                else
                    report.Base64 = ReadPdfBase64(reportLocation);

                /* USA SEMPRE QUESTO PER STAMPARE IN HTM O PDF
                byte[] bytes = System.Convert.FromBase64String(report.Base64);
                FileStream fs = File.OpenWrite(@"C:\Users\federico.dibernardo\Desktop\Lavoro\Operando\Sorgente\op-webui\reportsREST_WP\reportsREST_WP\test.htm");
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();*/

                context.Response.Write(JsonConvert.SerializeObject(report));
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }

            if (connection != null)
            {
                connection.Close();
            }
        }

        return;
    }

    public class Report
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Base64 { get; set; }
        public Report() { }
    }

    /*public class Error
    {
        public string ErrorType { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorStackTrace { get; set; }
        public string ErrorUrl { get; set; }
        public Error() { }
    }*/
}