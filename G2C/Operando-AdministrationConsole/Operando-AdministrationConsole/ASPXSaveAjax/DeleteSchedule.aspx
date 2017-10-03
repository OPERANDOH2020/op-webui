<%@ Page Language="C#" AutoEventWireup="true"  %>
<%@ Import Namespace="SharpConnect.MySql" %>
<%@ Import Namespace="SharpConnect.MySql.SyncPatt" %>

<script runat="server">

    public void Page_Load(Object o , EventArgs e)
    {
        string ID = Request.Form["ID"];

        MySqlConnection connection = new MySqlConnection( ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);

        connection.Open();

        String sql = "DELETE FROM t_report_mng_schedules WHERE ID=" + ID;

        MySqlCommand cmd = new MySqlCommand(sql,connection);
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
