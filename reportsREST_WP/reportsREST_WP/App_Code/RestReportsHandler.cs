using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

public class RestReportsHandler : IHttpHandler
{
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

    private string ReadHtmlBase64(string url)
    {
        var httpRequest = WebRequest.Create(url) as HttpWebRequest;
        HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

        string htmlData = "";
        if (httpResponse.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = httpResponse.GetResponseStream();
            StreamReader readStream = null;

            if (httpResponse.CharacterSet == null)
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
            throw new Exception(httpResponse.StatusDescription);

        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(htmlData);
        return System.Convert.ToBase64String(plainTextBytes);
    }

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

    private string GetReportFileName(int idReport, MySqlTransaction transaction)
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
    }

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            context.Response.ContentType = "application/json";
            var appSettings = ConfigurationManager.AppSettings;
            Report report = new Report();

            //if (appSettings["BirtUrl"] != null)
            //{
            //string url = appSettings["BirtUrl"] + "?";

            if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["_reportid"]))
                throw new Exception("Missing parameter _reportid");

            int idReport;
            if (!Int32.TryParse(HttpContext.Current.Request.QueryString["_reportid"], out idReport))
                throw new Exception("_reportId must be interger value");

            string reportFormat="pdf";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["_format"]))
                reportFormat = HttpContext.Current.Request.QueryString["_format"].ToLower();

            if (!reportFormat.Equals("html") &&
                !reportFormat.Equals("htm") &&
                !reportFormat.Equals("pdf"))
                throw new Exception("Unsupported format");

            string reportName = "";
            string reportFileName = "";
            string reportDescription = "";
            string reportLocation = "";

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            connection.Open();
            MySqlTransaction transaction = connection.BeginTransaction();
            try
            {
                reportLocation = GetReportLocation(idReport, transaction);
                reportLocation = reportLocation.Replace("/frameset", "/preview");

                reportFileName = GetReportFileName(idReport, transaction);
                reportName = GetReportName(idReport, transaction);
                reportDescription = GetReportDescription(idReport, transaction);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
            finally
            {
                connection.Close();
            }

            if (string.IsNullOrEmpty(reportName))
                throw new Exception("No report found for this ID");

            reportLocation += "?__format="+ reportFormat;
            reportLocation += "&__report=" + HttpUtility.UrlEncode(reportFileName);

            foreach (string param in HttpContext.Current.Request.QueryString.AllKeys)
            {
                if (param != null)
                {
                    if (!param.ToLower().Equals("_reportid"))
                        reportLocation += "&" + HttpUtility.UrlEncode(param) + "=" + HttpUtility.UrlEncode(HttpContext.Current.Request.QueryString[param]);
                }
            }

            report.ID = idReport;
            report.Name = reportName;
            report.Description = reportDescription;

            if (reportFormat.Equals("html") || reportFormat.Equals("htm"))
                report.Base64 = ReadHtmlBase64(reportLocation);
            else
                report.Base64 = ReadPdfBase64(reportLocation);

            /*byte[] bytes = System.Convert.FromBase64String(report.Base64);
            FileStream fs = File.OpenWrite(@"C:\Users\federico.dibernardo\Desktop\Lavoro\Operando\Sorgente\op-webui\reportsREST_WP\reportsREST_WP\test.pdf");
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();*/
      
            context.Response.Write(JsonConvert.SerializeObject(report));
        }
        catch (Exception e)
        {
            Error error = new Error();
            error.ErrorType = e.GetType().ToString();
            error.ErrorDescription = e.Message;
            error.ErrorUrl = HttpContext.Current.Request.RawUrl;
            error.ErrorStackTrace = e.StackTrace;
            context.Response.Write(JsonConvert.SerializeObject(error));
        }
    }

    public class Report
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Base64 { get; set; }
        public Report() { }
    }

    public class Error
    {
        public string ErrorType { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorStackTrace { get; set; }
        public string ErrorUrl { get; set; }
        public Error() { }
    }
}