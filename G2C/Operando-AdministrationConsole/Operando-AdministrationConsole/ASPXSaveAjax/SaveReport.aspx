<%@ Page Language="C#" AutoEventWireup="true"  %>
<%@ Import Namespace="SharpConnect.MySql" %>
<%@ Import Namespace="SharpConnect.MySql.SyncPatt" %>

<script runat="server">

    public void Page_Load(Object o , EventArgs e)
    {
        string ID = Request.Form["ID"];
        string Report = Request.Form["Report"].Replace("'","''");
        string Description = Request.Form["Description"].Replace("'", "''");
        string Version = Request.Form["Version"].Replace("'", "''");
        string Location = Request.Form["Location"].Replace("'", "''");
        string Parameters = Request.Form["Parameters"].Replace("'", "''");
        string OSPs = Request.Form["OSPs"].Replace("'", "''").Remove(0,1);

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);

        connection.Open();
        MySqlCommand cmd = null;
        String sql = "";

        if (ID=="0")
        {
            sql = "INSERT INTO t_report_mng_list (Report, Description, Version, Location, Parameters, OSPs) VALUES ('" + Report + "','" + Description + "','" + Version + "','" + Location + "','" + Parameters + "','" + OSPs + "')";
            cmd = new MySqlCommand(sql,connection);
            cmd.ExecuteNonQuery();
        }
        else
        {
            sql = "UPDATE t_report_mng_list SET Report='" + Report + "',Description='" + Description + "',Version='" + Version + "',Location='" + Location + "',Parameters='" + Parameters + "',OSPs='" + OSPs + "' WHERE ID= " + ID;
            cmd = new MySqlCommand(sql,connection);
            cmd.ExecuteNonQuery();

            sql = "UPDATE t_report_mng_results R SET R.Report='" + Report + "' WHERE IDreport= " + ID;
            cmd = new MySqlCommand(sql,connection);
            cmd.ExecuteNonQuery();

            sql = "UPDATE t_report_mng_schedules R SET R.Report='" + Report + "' WHERE IDreport= " + ID;
            cmd = new MySqlCommand(sql,connection);
            cmd.ExecuteNonQuery();
        }


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
