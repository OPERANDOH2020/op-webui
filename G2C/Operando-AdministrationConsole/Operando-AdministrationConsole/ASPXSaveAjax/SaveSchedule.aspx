<%@ Page Language="C#" AutoEventWireup="true"  %>
<%@ Import Namespace="MySql.Data" %>
<%@ Import Namespace="MySql.Data.MySqlClient" %>
<script runat="server">

    public void Page_Load(Object o , EventArgs e)
    {
        string ID = Request.Form["ID"]; 
        string Report = Request.Form["Report"].Replace("'","''");
        string StartDate = Request.Form["StartDate"].Replace("'", "''");
        StartDate = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");
        string RepeatEveryNumb = Request.Form["RepeatEveryNumb"].Replace("'", "''");
        string RepeatEveryType = Request.Form["RepeatEveryType"].Replace("'", "''");
        string StoragePeriodNumb = Request.Form["StoragePeriodNumb"].Replace("'", "''");
        string StoragePeriodType = Request.Form["StoragePeriodType"].Replace("'", "''");
        string OSPs = Request.Form["OSPs"].Replace("'", "''").Remove(0,1);
        string DayOfWeek = "";
        if (!String.IsNullOrEmpty(Request.Form["DayOfWeek"]))
        {
            DayOfWeek = Request.Form["DayOfWeek"].Replace("'", "''").Remove(0, 1);
        }
        string DescriptionSchedules = "";
        String NextScheduled = "";
        DateTime NextScheduledDate = new DateTime();
        switch (RepeatEveryType)
        {
            case "DAY(s)":
                NextScheduledDate = Convert.ToDateTime(StartDate).AddDays(Convert.ToInt32(RepeatEveryNumb));
                break;
            case "WEEK(s)":
                NextScheduledDate = Convert.ToDateTime(StartDate).AddDays(Convert.ToInt32(RepeatEveryNumb) * 7);
                break;
            case "MONTH(s)":
                NextScheduledDate = Convert.ToDateTime(StartDate).AddMonths(Convert.ToInt32(RepeatEveryNumb));
                break;
            case "YEAR(s)":
                NextScheduledDate = Convert.ToDateTime(StartDate).AddYears(Convert.ToInt32(RepeatEveryNumb));
                break;
            default:
                break;
        }
        NextScheduled = NextScheduledDate.ToString("yyyy-MM-dd HH:mm:ss");
        
        
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        connection.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connection;

        if (ID=="0")
        {
            cmd.CommandText = "INSERT INTO t_report_mng_schedules(OSPs, Report, StartDate, RepeatEveryNumb, RepeatEveryType, DayOfWeek, StoragePeriodNumb, StoragePeriodType, DescriptionSchedules,NextScheduled,Lastrun) VALUES ('" + OSPs + "','" + Report + "', '" + StartDate + "','" + RepeatEveryNumb + "','" + RepeatEveryType + "','" + DayOfWeek + "','" + StoragePeriodNumb + "','" + StoragePeriodType + "','" + DescriptionSchedules + "','" + NextScheduled + "',null)";
        }
        else
        {
            cmd.CommandText = "UPDATE t_report_mng_schedules SET OSPs='" + OSPs + "',Report='" + Report + "',StartDate='" + StartDate + "',RepeatEveryNumb='" + RepeatEveryNumb + "',RepeatEveryType='" + RepeatEveryType + "',DayOfWeek='" + DayOfWeek + "',StoragePeriodNumb='" + StoragePeriodNumb + "',StoragePeriodType='" + StoragePeriodType + "',DescriptionSchedules='" + DescriptionSchedules + "',NextScheduled='" + NextScheduled + "' WHERE ID=" + ID;
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
