<%@ Page Language="C#" AutoEventWireup="true"  %>
<%@ Import Namespace="MySql.Data" %>
<%@ Import Namespace="MySql.Data.MySqlClient" %>
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
        
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        connection.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connection;

        if (ID=="0")
        {
            cmd.CommandText = "INSERT INTO t_report_mng_list (Report, Description, Version, Location, Parameters, OSPs) VALUES ('" + Report + "','" + Description + "','" + Version + "','" + Location + "','" + Parameters + "','" + OSPs + "')";
        }
        else
        {
            cmd.CommandText = "UPDATE t_report_mng_list SET Report='" + Report + "',Description='" + Description + "',Version='" + Version + "',Location='" + Location + "',Parameters='" + Parameters + "',OSPs='" + OSPs + "' WHERE ID= " + ID;
        }

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
