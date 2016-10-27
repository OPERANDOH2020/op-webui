<%@ Page Language="C#" AutoEventWireup="true"  %>
<%@ Import Namespace="MySql.Data" %>
<%@ Import Namespace="MySql.Data.MySqlClient" %>
<script runat="server">

    public void Page_Load(Object o , EventArgs e)
    {
        string ID = Request.Form["ID"]; 
        
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        connection.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connection;

        cmd.CommandText = "DELETE FROM t_report_mng_schedules WHERE ID=" + ID;

        cmd.ExecuteNonQuery();
        connection.Close();
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
