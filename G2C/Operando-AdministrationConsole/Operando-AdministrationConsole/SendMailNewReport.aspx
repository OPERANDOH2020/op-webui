<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="MySql.Data" %>
<%@ Import Namespace="MySql.Data.MySqlClient" %>

<script runat="server">

    public void Page_Load(Object o , EventArgs e)
    {
        var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        var message = new MailMessage();
        message.To.Add(new MailAddress("giulia@progettidiimpresa.it"));
        message.From = new MailAddress("daniele@progettidiimpresa.it");  // replace with valid value
        var nameRequest = Request.Form["name"];
        var emailRequest = Request.Form["email"];
        var descriptionRequest = Request.Form["description"];
        message.Subject = "Request for a new report";
        message.Body = string.Format(body, nameRequest, emailRequest,descriptionRequest);
        message.IsBodyHtml = true;

        try
        {

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "giulia",  // replace with valid value
                    Password = "bellabimba"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "mail.progettidiimpresa.it";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            connection.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;

            DateTime theDate = DateTime.Now;
            theDate.ToString("yyyy-MM-dd H:mm:ss");

            cmd.CommandText = "INSERT INTO t_report_mng_request (InsertDate, Name, Email, Description) VALUES ('" + theDate + "','" + nameRequest + "','" + emailRequest + "','" + descriptionRequest + "')";
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
            throw new SmtpException("Posta non inviata");
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
