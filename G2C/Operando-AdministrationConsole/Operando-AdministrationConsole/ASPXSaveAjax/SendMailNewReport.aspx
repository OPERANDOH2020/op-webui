<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="SharpConnect.MySql" %>
<%@ Import Namespace="SharpConnect.MySql.SyncPatt" %>
<%@ Import Namespace="RestSharp" %>
<%@ Import Namespace="System.Diagnostics" %>

<script runat="server">

    public void Page_Load(Object o , EventArgs e)
    {
        var nameRequest = Request.Form["name"];
        var emailRequest = Request.Form["email"];
        var descriptionRequest = Request.Form["description"];


        try
        {
            if (String.IsNullOrEmpty(Request.Form["email"]))
            {
                throw new SmtpException("Email Error");
            }
            var client = new RestClient("https://api.mailgun.net/v3/mg.operando.eu");
            var request = new RestRequest("messages", Method.POST);
            //request.AddParameter("from", "gilad@mg.operando.eu");
            request.AddParameter("from", Request.Form["email"].ToString());

            var to = "daniele.detecterror@progettidiimpresa.it, giulia.detecterror@progettidiimpresa.it, federico.dibernardo@progettidiimpresa.it";
            request.AddParameter("to", to.Replace("'", ""));

            var subject = "Request for a new report";
            request.AddParameter("subject", subject.Replace("'", ""));

            var text = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            text = string.Format(text, nameRequest, emailRequest,descriptionRequest);
            request.AddParameter("html", text.Replace("'", ""));

            client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator("api", "key-f28ca9730862959738de8b244678e4f9");

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
                                            //Debug.Assert(content.IndexOf("Queued. Thank you.")>=0, "Error on send mail");

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);

            connection.Open();

            String Sql = "INSERT INTO t_report_mng_request (InsertDate, Name, Email, Description) VALUES ('" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "','" + nameRequest + "','" + emailRequest + "','" + descriptionRequest + "')";

            MySqlCommand cmd = new MySqlCommand(Sql,connection);

            DateTime theDate = DateTime.Now;
            
            try
            {
                cmd.ExecuteNonQuery(); 
            }
            catch (Exception exc)
            {
                connection.Close();

                throw new Exception(exc.Message);
            }
            connection.Close();
        }
        catch (SmtpException exc)
        {
            throw new SmtpException("Mail not send");
        }




    }



</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
