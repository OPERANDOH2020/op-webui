﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Globalization;


namespace ExecuteSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime StartTime = Process.GetCurrentProcess().StartTime;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;


            // creo la lista dei report
            Reports reports = new Reports();
            List<Reports> ReportList = new List<Reports>();
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
                            report.OSPs = new String[0];

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

                        ReportList.Add(report);
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

            List<Schedules> ScheduleDetailsList = new List<Schedules>();

            try
            {

                connection.Open();

                cmd.CommandText = "select * from T_report_mng_schedules";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Schedules schedule = new Schedules();

                        if (reader.IsDBNull(0) == false)
                            schedule.ID = reader.GetInt32(0);
                        else
                            schedule.ID = 0;

                        if (reader.IsDBNull(1) == false)
                            schedule.OSPs = reader.GetString(1).Split(',');
                        else
                            schedule.OSPs = new String[0];

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

                        if (reader.IsDBNull(6) == false)
                            schedule.DayOfWeek = reader.GetString(6).Split(',');
                        else
                            schedule.DayOfWeek = new String[0];

                        if (reader.IsDBNull(7) == false)
                            schedule.StoragePeriodNumb = reader.GetInt32(7);
                        else
                            schedule.StoragePeriodNumb = 0;

                        if (reader.IsDBNull(8) == false)
                            schedule.StoragePeriodType = reader.GetString(8);
                        else
                            schedule.StoragePeriodType = null;

                        if (reader.IsDBNull(9) == false)
                            schedule.DescriptionSchedules = reader.GetString(9);
                        else
                            schedule.DescriptionSchedules = null;
                        
                        if (reader.IsDBNull(12) == false)
                            schedule.Lastrun = reader.GetDateTime(12);
                        else
                            schedule.Lastrun = DateTime.MinValue;

                        if (reader.IsDBNull(13) == false)
                            schedule.NextScheduled = reader.GetDateTime(13);
                        else
                            schedule.NextScheduled = DateTime.MinValue;

                        ScheduleDetailsList.Add(schedule);

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

            foreach (Schedules item in ScheduleDetailsList)
            {
                if (item.StartDate<=StartTime.Date)
                {
                    if (item.StartDate.Hour <= StartTime.Date.Hour)
                    {
                        if (item.StartDate.Minute <= StartTime.Date.Minute)
                        {
                            bool execute = false;

                            // valuto la data di prossima schedulazione
                            if (!(item.Lastrun==DateTime.MinValue))
	                        {
                                if (item.NextScheduled!=DateTime.MinValue
                                    && item.NextScheduled <= StartTime.Date)
	                            {
                                    execute = true;
	                            }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                execute = true;
                            }

                            if (item.DayOfWeek.Length>0)
                            {
                                String[] dayOfWeek = item.DayOfWeek;
                                foreach (String dayof in dayOfWeek)
                                {
                                    if (string.IsNullOrEmpty(dayof))
                                    {
                                        continue;
                                    }
                                    switch (dayof)
                                    {
                                        case "Mon":
                                            if (StartTime.DayOfWeek == DayOfWeek.Monday)
                                            {
                                                execute = true;
                                            }
                                            break;
                                        case "Tue":
                                            if (StartTime.DayOfWeek == DayOfWeek.Tuesday)
                                            {
                                                execute = true;
                                            }
                                            break;
                                        case "Wed":
                                            if (StartTime.DayOfWeek == DayOfWeek.Wednesday)
                                            {
                                                execute = true;
                                            }
                                            break;
                                        case "Thu":
                                            if (StartTime.DayOfWeek == DayOfWeek.Thursday)
                                            {
                                                execute = true;
                                            }
                                            break;
                                        case "Fri":
                                            if (StartTime.DayOfWeek == DayOfWeek.Friday)
                                            {
                                                execute = true;
                                            }
                                            break;
                                        case "Sat":
                                            if (StartTime.DayOfWeek == DayOfWeek.Saturday)
                                            {
                                                execute = true;
                                            }
                                            break;
                                        case "Sun":
                                            if (StartTime.DayOfWeek == DayOfWeek.Sunday)
                                            {
                                                execute = true;
                                            }
                                            break;
                                        default:
                                            execute = false;
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                execute = true;
                            }

                            if (execute)
                            {
                                foreach (Reports report in ReportList)
	                            {
		                            if (report.Report==item.Report)
	                                {
                                        ExecuteScheduleReport(item, report, StartTime);
                                        break;
	                                }
	                            }
                            }
                        }
                    }
                }
            }

        }

        private static void ExecuteScheduleReport(Schedules item, Reports report, DateTime StartTime)
        {
            String url = report.Location + "?" + report.Parameters+"&__format=pdf";
            String filePath = ConfigurationManager.AppSettings["pathSave"];
            String fileName = report.Report + "_" + item.ID + "_" + StartTime.Year + "" + StartTime.Month + "" + StartTime.Day + ".pdf";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, filePath + "\\" + fileName );
            }
            SaveNextScheduled(item, report, StartTime);
            SaveResult(item, report, StartTime, fileName);
            RemoveOldFile(item, report, StartTime);
        }

        private static void SaveResult(Schedules item, Reports report, DateTime StartTime, String fileName)
        {
            string ExecutionDate = StartTime.ToString();
            string Report = report.Report;
            string ReportDescription = report.Description;
            string ReportVersion = report.Version;
            string OSP = "";
            foreach (var opsItem in report.OSPs)
            {
                OSP += "-"+opsItem;
            }
            OSP = OSP.Remove(0, 1);
            string FileName = fileName;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "INSERT INTO t_report_mng_results (ExecutionDate, Report, ReportDescription, ReportVersion, OSP, FileName) VALUES ('" + Convert.ToDateTime(ExecutionDate).ToString("yyyy-MM-dd HH:mm:ss") + "','" + Report + "','" + ReportDescription + "','" + ReportVersion + "','" + OSP + "','" + FileName + "')";


            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private static void SaveNextScheduled(Schedules item, Reports report, DateTime StartTime)
        {
            int repeatEveryNumb = item.RepeatEveryNumb;
            String repeatEveryType = item.RepeatEveryType;
            DateTime NextScheduled = new DateTime();
            switch (repeatEveryType)
            {
                case "DAY(s)":
                    NextScheduled = StartTime.AddDays(repeatEveryNumb);
                    break;
                case "WEEK(s)":
                    NextScheduled = StartTime.AddDays(repeatEveryNumb * 7);
                    break;
                case "MONTH(s)":
                    NextScheduled = StartTime.AddMonths(repeatEveryNumb);
                    break;
                case "YEAR(s)":
                    NextScheduled = StartTime.AddYears(repeatEveryNumb);
                    break;
                default:
                    break;
            }


            int ID = item.ID;

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "UPDATE t_report_mng_schedules SET Lastrun ='" + Convert.ToDateTime(StartTime).ToString("yyyy-MM-dd HH:mm:ss") +"',NextScheduled='" + Convert.ToDateTime(NextScheduled).ToString("yyyy-MM-dd HH:mm:ss") +"' WHERE ID=" + ID;

            cmd.ExecuteNonQuery();
            connection.Close();

        }

        private static void RemoveOldFile(Schedules item, Reports report, DateTime StartTime)
        {
            String filePath = ConfigurationManager.AppSettings["pathSave"];
            DirectoryInfo dir = new DirectoryInfo(filePath);
            FileInfo[] files = dir.GetFiles(""+report.Report+"_"+item.ID+"*.pdf");
            int storagePeriodNumb = item.StoragePeriodNumb;
            String storagePeriodType = item.StoragePeriodType;

            foreach (var file in files)
	        {
		        String[] fileNameArray  = file.Name.Split('_');
                DateTime fileDate = DateTime.ParseExact(fileNameArray[2].Replace(".pdf", ""), "yyyyMMdd", CultureInfo.InvariantCulture);

                switch (storagePeriodType)
                {
                    case "DAY(s)":
                        double days = (item.Lastrun - fileDate ).TotalDays ;
                        if (days>storagePeriodNumb)
	                    {
		                    File.Delete(file.FullName);
	                    }
                        break;
                    case "WEEK(s)":
                        double weeks = (item.Lastrun - fileDate).TotalDays / 7;
                        if (weeks>storagePeriodNumb)
	                    {
		                    File.Delete(file.FullName);
	                    }
                        break;
                    case "MONTH(s)":
                        double month = item.Lastrun.Subtract(fileDate).Days / (365.25 / 12);
                        if (month>storagePeriodNumb)
	                    {
		                    File.Delete(file.FullName);
	                    }
                        break;
                    case "YEAR(s)":
                        double year = item.Lastrun.Year - fileDate.Year;
                        if (year > storagePeriodNumb)
	                    {
		                    File.Delete(file.FullName);
	                    }
                        break;
                    default:
                        break;
                }
	        }

           
        }
    }
}
