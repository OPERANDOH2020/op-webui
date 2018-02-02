<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="SharpConnect.MySql" %>
<%@ Import Namespace="SharpConnect.MySql.SyncPatt" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="RestSharp" %>
<%@ Import Namespace="Newtonsoft.Json" %>
<%@ Import Namespace="Newtonsoft.Json.Linq" %>

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

            DateTime theDate = DateTime.Now;

            String Sql = "INSERT INTO t_report_mng_request (InsertDate, Name, Email, Description) VALUES ('" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "','" + nameRequest + "','" + emailRequest + "','" + descriptionRequest + "')";

            MySqlCommand cmd = new MySqlCommand(Sql,connection);
                       

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

        //logDB
        string Username = Session["Username"].ToString();
        LogDbInsert(Username);
    }

    public class LogObject
    {
        public enum RequesterType { PROCESS, MODULE }
        public enum LogLevel { INFO, WARN, ERROR, FATAL }
        public enum LogType { DATA_ACCESS, SYSTEM, NOTIFICATION, OTHER }

        public string userId { get; set; }
        public string requesterType;
        public string requesterId { get; set; }
        public string logPriority { get; set; }
        public string logLevel;
        public string title { get; set; }
        public string description { get; set; }
        public List<string> keywords { get; set; }
        public string logType;
        public string affectedUserId { get; set; }
        public string osp { get; set; }
        public List<string> requestedFields { get; set; }
        public List<string> grantedFields { get; set; }
    }

    private static void LogDbInsert(String Username)
    {
        string userId = Username;

        LogObject _LogObject = new LogObject();
        _LogObject.userId = "RG REQUEST";
        _LogObject.requesterType = LogObject.RequesterType.PROCESS.ToString();
        _LogObject.requesterId = userId;
        _LogObject.logPriority = "LOW";
        _LogObject.logLevel = LogObject.LogLevel.INFO.ToString();
        _LogObject.title =  "Report Request";
        _LogObject.description = "Report has been requested";

        string keyword = "Report";
        _LogObject.keywords = new List<string>();
        _LogObject.keywords.Add(keyword);

        _LogObject.logType = LogObject.LogType.NOTIFICATION.ToString();
        _LogObject.affectedUserId = "";
        _LogObject.osp =userId;

        string requestedFields = "";
        _LogObject.requestedFields = new List<string>();
        _LogObject.requestedFields.Add(requestedFields);

        string grantedFields = "";
        _LogObject.grantedFields = new List<string>();
        _LogObject.grantedFields.Add(grantedFields);


        string _LogObjectSerialized = JsonConvert.SerializeObject(_LogObject);

        var client = new RestClient(ConfigurationManager.AppSettings["ldbBasePathInsert"]);

        var request = new RestRequest("log", Method.POST);
        request.AddParameter("application/json", _LogObjectSerialized, ParameterType.RequestBody);


        // execute the request
        IRestResponse response = client.Execute(request);
        var content = response.Content; // raw content as string

        JToken token = JObject.Parse(content);
        string code = "";
        string type = "";
        string message = "";

        code = (string)token.SelectToken("code");
        type = (string)token.SelectToken("type");
        message = (string)token.SelectToken("message");

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
