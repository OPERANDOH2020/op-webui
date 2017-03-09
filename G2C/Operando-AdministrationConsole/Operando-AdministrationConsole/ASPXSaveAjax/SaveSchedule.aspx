<%@ Page Language="C#" AutoEventWireup="true" Debug="true"%>

<%@ Import Namespace="MySql.Data" %>
<%@ Import Namespace="MySql.Data.MySqlClient" %>

<script runat="server">

    public void Page_Load(Object o, EventArgs e)
    {
        string ID = Request.Form["ID"];
        string Report = Request.Form["Report"].Replace("'","''");
        string StartDate = Request.Form["StartDate"].Replace("'", "''");
        string Time = Request.Form["Time"];
        if (String.IsNullOrEmpty(StartDate))
        {

            if (String.IsNullOrEmpty(Time))
            {
                StartDate = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            }
            else
            {
                TimeSpan orario = new TimeSpan(Convert.ToDateTime(Time).Hour, Convert.ToDateTime(Time).Minute, Convert.ToDateTime(Time).Second);

                StartDate = DateTime.Today.Add(orario).ToString("yyyy-MM-dd H:mm:ss");
            }
        }
        else
        {
            int step = 0;
            try
            {
                
                StartDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                //StartDate = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");

                if (String.IsNullOrEmpty(Time))
                {
                    step = 1;
                    StartDate = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    step = 2;
                    TimeSpan orario = new TimeSpan(Convert.ToDateTime(Time).Hour, Convert.ToDateTime(Time).Minute, Convert.ToDateTime(Time).Second);

                    StartDate = Convert.ToDateTime(StartDate).Date.Add(orario).ToString("yyyy-MM-dd H:mm:ss");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex + " StartDate: "+StartDate+" step: "+step);
            }
        }
        string RepeatEveryNumb = Request.Form["RepeatEveryNumb"].Replace("'", "''");
        if(String.IsNullOrEmpty(RepeatEveryNumb))
        {
            RepeatEveryNumb = "1";
        }
        string RepeatEveryType = Request.Form["RepeatEveryType"].Replace("'", "''");
        if( RepeatEveryType.StartsWith(","))
        {
            RepeatEveryType = Request.Form["RepeatEveryType"].Replace("'", "''").Remove(0, 1);
        }
        string StoragePeriodNumb = Request.Form["StoragePeriodNumb"].Replace("'", "''");
        string StoragePeriodType = Request.Form["StoragePeriodType"].Replace("'", "''");
        string OSPs = Request.Form["OSPs"].Replace("'", "''");
        if( OSPs.StartsWith(","))
        {
            OSPs = OSPs.Remove(0, 1);
        }
        string DayOfWeek = "";
        if (!String.IsNullOrEmpty(Request.Form["DayOfWeek"]))
        {
            if (Request.Form["DayOfWeek"].Replace("'", "''").StartsWith(","))
            {
                DayOfWeek = Request.Form["DayOfWeek"].Replace("'", "''").Remove(0, 1);
            }
            else
            {
                DayOfWeek = Request.Form["DayOfWeek"].Replace("'", "''");
            }

        }
        string DescriptionSchedules = "";
        string DayOfMonth = "";
        if (Request.Form["DayOfMonth"]!=null)
        {
            DayOfMonth = Request.Form["DayOfMonth"].Replace("'", "''");
        }
        string DayOfYear = "";
        if (Request.Form["DayOfYear"] != null)
        {
            DayOfYear = Request.Form["DayOfYear"].Replace("'", "''");
        }

        if (String.IsNullOrEmpty(DayOfYear))
        {
            DayOfYear = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
        }
        else
        {
            DayOfYear = Convert.ToDateTime(DayOfYear).ToString("yyyy-MM-dd HH:mm:ss");
        }
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
            cmd.CommandText = "INSERT INTO t_report_mng_schedules(OSPs, Report, StartDate, RepeatEveryNumb, RepeatEveryType, DayOfWeek, StoragePeriodNumb, StoragePeriodType, DescriptionSchedules,NextScheduled,Lastrun,GiornoMese, GiornoAnno) VALUES ('" + OSPs + "','" + Report + "', '" + StartDate + "','" + RepeatEveryNumb + "','" + RepeatEveryType + "','" + DayOfWeek + "','" + StoragePeriodNumb + "','" + StoragePeriodType + "','" + DescriptionSchedules + "','" + NextScheduled + "',null ,'" + DayOfMonth + "','" + DayOfYear + "')";
        }
        else
        {
            cmd.CommandText = "UPDATE t_report_mng_schedules SET OSPs='" + OSPs + "',Report='" + Report + "',StartDate='" + StartDate + "',RepeatEveryNumb='" + RepeatEveryNumb + "',RepeatEveryType='" + RepeatEveryType + "',DayOfWeek='" + DayOfWeek + "',StoragePeriodNumb='" + StoragePeriodNumb + "',StoragePeriodType='" + StoragePeriodType + "',DescriptionSchedules='" + DescriptionSchedules + "',NextScheduled='" + NextScheduled +"', GiornoMese='" + DayOfMonth + "', GiornoAnno='" + DayOfYear + "' WHERE ID=" + ID;
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
