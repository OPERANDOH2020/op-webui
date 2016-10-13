using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Operando_AdministrationConsole.Models;

namespace Operando_AdministrationConsole.Controllers
{
    public class PspAdminController : Controller
    {
        ReportManager reportManager = new ReportManager();

        // GET: PspAdmin
        public ActionResult ReportsConfig()
        {
            // creo gli oggetti per popolare la pagina
            reportManager.reportsObj = new Reports(); 
            reportManager.resultsObj = new Results();
            reportManager.schedulesObj = new Schedules ();

            
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            
            // creo la lista dei report
            Reports reports = new Reports();
            reportManager.reportsObj.ReportList = new List<Reports>();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;

            try
            {

                connection.Open();

                cmd.CommandText ="select * from t_report_mng_list ";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Reports report = new Reports();

                        if (reader.IsDBNull(0) == false)
                            report.Report = reader.GetString(0);
                        else
                            report.Report = null;

                        if (reader.IsDBNull(1) == false)
                            report.Description = reader.GetString(1);
                        else
                            report.Description = null;

                        if (reader.IsDBNull(2) == false)
                            report.Version = reader.GetString(2);
                        else
                            report.Version = null;

                        if (reader.IsDBNull(3) == false)
                            report.Location = reader.GetString(3);
                        else
                            report.Location = null;

                        if (reader.IsDBNull(4) == false)
                            report.Parameters = reader.GetString(4);
                        else
                            report.Parameters = null;

                        if (reader.IsDBNull(5) == false)
                            report.OSPs = reader.GetString(5).Split(',');
                        else
                            report.OSPs = null;

                        if (reader.IsDBNull(6) == false)
                            report.ID = reader.GetInt32(6);
                        else
                            report.ID = 0;

                        report.OSPsOption = "ITI-OCC".Split('-');
                        for (int i=0; i<report.OSPsOption.Length; i++)
                        {
                            string selected = "";
                            for (int r = 0; r < report.OSPs.Length; r++)
                            { 
                                if (report.OSPsOption[i] == report.OSPs[r])
                                    selected = "selected";
                            }
                            report.OSPsOption[i] = "<option "+selected+">" + report.OSPsOption[i] + "</option>";
                        }

                        reportManager.reportsObj.ReportList.Add(report);
                    }
                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                }
            }
            catch (MySqlException e)
            {
                throw e;
            }
            connection.Close();


            // creo la lista dei result
            Results results = new Results(); 
            reportManager.resultsObj.ResultList = new List<Results>();

            try
            {

                connection.Open();

                cmd.CommandText = "select * from T_report_mng_results ";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Reports report = new Reports();

                        if (reader.IsDBNull(0) == false)
                            results.ID = reader.GetInt32(0);
                        else
                            results.ID = 0;

                        if (reader.IsDBNull(1) == false)
                            results.ExecutionDate = reader.GetDateTime(1);
                        else
                            results.ExecutionDate = DateTime.MinValue;

                        if (reader.IsDBNull(2) == false)
                            results.Report = reader.GetString(2);
                        else
                            results.Report = null;

                        if (reader.IsDBNull(3) == false)
                            results.ReportDescription = reader.GetString(3);
                        else
                            results.ReportDescription = null;

                        if (reader.IsDBNull(4) == false)
                            results.ReportVersion = reader.GetString(4);
                        else
                            results.ReportVersion = null;

                        if (reader.IsDBNull(5) == false)
                            results.OSPs = reader.GetString(5).Split(',');
                        else
                            results.OSPs = null;

                        if (reader.IsDBNull(6) == false)
                            results.FileName = reader.GetString(6);
                        else
                            results.FileName = null;

                        reportManager.resultsObj.ResultList.Add(results);
                    }
                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                }
            }
            catch (MySqlException e)
            {
                throw e;
            }
            connection.Close();

            // creo la lista dei result
            Schedules schedule = new Schedules();
            reportManager.schedulesObj.ScheduleList = new List<Schedules>();

            try
            {

                connection.Open();

                cmd.CommandText = "select * from T_report_mng_schedules ";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Reports report = new Reports();

                        if (reader.IsDBNull(0) == false)
                            schedule.ID = reader.GetInt32(0);
                        else
                            schedule.ID = 0;

                        if (reader.IsDBNull(1) == false)
                            schedule.OSPs = reader.GetString(1).Split(',');
                        else
                            schedule.OSPs = null;

                        if (reader.IsDBNull(2) == false)
                            schedule.Report = reader.GetString(2);
                        else
                            schedule.Report = null;

                        if (reader.IsDBNull(3) == false)
                            schedule.StartDate = reader.GetDateTime(3);
                        else
                            schedule.StartDate = DateTime.MinValue;

                        if (reader.IsDBNull(4) == false)
                            schedule.RepeatEveryNumb = reader.GetInt32(4);
                        else
                            schedule.RepeatEveryNumb = 0;

                        if (reader.IsDBNull(5) == false)
                            schedule.RepeatEveryType = reader.GetString(5);
                        else
                            schedule.RepeatEveryType = null;

                        schedule.RepeatEveryTypeOption = "DAY-WEEK-MONTH-YEAR".Split('-');

                        for (int i = 0; i < schedule.RepeatEveryTypeOption.Length; i++)
                        {
                            string selected = "";
                            if (schedule.RepeatEveryTypeOption[i] == schedule.RepeatEveryType)
                                selected = "selected";
                            schedule.RepeatEveryTypeOption[i] = "<option " + selected + ">" + schedule.RepeatEveryTypeOption[i] + "</option>";
                        }


                        if (reader.IsDBNull(6) == false)
                            schedule.DayOfWeek = reader.GetString(6).Split(',');
                        else
                            schedule.DayOfWeek = null;

                        schedule.DayOfWeekOption = "Mon-Tue-Wed-Thu-Fri-Sat-Sun".Split('-');

                        for (int i = 0; i < schedule.DayOfWeekOption.Length; i++)
                        {
                            string selected = "";
                            for (int r = 0; r < schedule.DayOfWeek.Length; r++)
                            {
                                if (schedule.DayOfWeekOption[i] == schedule.DayOfWeek[r])
                                    selected = "selected";
                            }
                            schedule.DayOfWeekOption[i] = "<option " + selected + ">" + schedule.DayOfWeekOption[i] + "</option>";
                        }


                        if (reader.IsDBNull(7) == false)
                            schedule.StoragePeriodNumb = reader.GetInt32(7);
                        else
                            schedule.StoragePeriodNumb = 0;

                        if (reader.IsDBNull(8) == false)
                            schedule.StoragePeriodType = reader.GetString(8);
                        else
                            schedule.StoragePeriodType = null;

                        schedule.StoragePeriodTypeOption = "DAY-WEEK-MONTH-YEAR".Split('-');

                        for (int i = 0; i < schedule.StoragePeriodTypeOption.Length; i++)
                        {
                            string selected = "";

                            if (schedule.StoragePeriodTypeOption[i] == schedule.StoragePeriodType)
                                selected = "selected";

                            schedule.StoragePeriodTypeOption[i] = "<option " + selected + ">" + schedule.StoragePeriodTypeOption[i] + "</option>";
                        }

                        if (reader.IsDBNull(9) == false)
                            schedule.DescriptionSchedules = reader.GetString(9);
                        else
                            schedule.DescriptionSchedules = null;

                        reportManager.schedulesObj.ScheduleList.Add(schedule);
                    }
                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                }
            }
            catch (MySqlException e)
            {
                throw e;
            }
            connection.Close();

            
            return View(reportManager);
        }

    }

}