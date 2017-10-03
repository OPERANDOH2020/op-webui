using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Operando_AdministrationConsole.Models;
using System.Diagnostics;
using System.Web.UI.WebControls;
using eu.operando.interfaces.aapi;
using eu.operando.interfaces.aapi.Model;
using eu.operando.core.pdb.cli.Model;

namespace Operando_AdministrationConsole.Controllers
{
    public class PspAdminController : Controller
    {
        ReportManager reportManager = new ReportManager();

        public ActionResult ControllerAction(string location)
        {
            AapiClient aapiClient = new AapiClient();
            
            //Response.Headers.Add(ConfigurationManager.AppSettings["stHeaderName"], aapiClient.GetServiceTicket(Session["TGT"].ToString(), ConfigurationManager.AppSettings["reportId"]));
            Response.Redirect(HttpUtility.UrlDecode(location));
            return View();
            //.....
        }

        public ActionResult ControllerDownloadAction(string fileName)
        {
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.Clear();
            Response.WriteFile(Server.MapPath("../" + ConfigurationManager.AppSettings["reportSavePath"] + "/" + fileName));
            Response.Flush();
            Response.End();
            return View();
        }

        // GET: PspAdmin
        public ActionResult ReportsConfig()
        {
            // creo gli oggetti per popolare la pagina
            reportManager.reportsObj = new Reports();
            reportManager.reportsObjNotScheduled = new Reports(); 
            reportManager.resultsObj = new Results();
            reportManager.schedulesObj = new Schedules();

            
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
                            report.OSPs = new String[0];

                        if (reader.IsDBNull(6) == false)
                            report.ID = reader.GetInt32(6);
                        else
                            report.ID = 0;

                        report.OSPsOption = "ASLBG-GASLINI".Split('-');
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


            // report non schedulati
            reportManager.reportsObjNotScheduled.ReportList = new List<Reports>();
            try
            {

                connection.Open();

                cmd.CommandText = "select * from t_report_mng_list where Report not IN (Select DISTINCT report FROM t_report_mng_schedules)";

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

                        report.OSPsOption = "ASLBG-GASLINI".Split('-');
                        for (int i = 0; i < report.OSPsOption.Length; i++)
                        {
                            string selected = "";
                            for (int r = 0; r < report.OSPs.Length; r++)
                            {
                                if (report.OSPsOption[i] == report.OSPs[r])
                                    selected = "selected";
                            }
                            report.OSPsOption[i] = "<option " + selected + ">" + report.OSPsOption[i] + "</option>";
                        }

                        reportManager.reportsObjNotScheduled.ReportList.Add(report);
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
            reportManager.resultsObj.ResultList = new List<Results>();

            try
            {

                connection.Open();

                cmd.CommandText = "select * from t_report_mng_results ";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Results results = new Results();

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
                            results.OSPs = new String[0];

                        if (reader.IsDBNull(6) == false)
                        {
                            results.FileName = reader.GetString(6); 
                            //results.FileName = "../reportSavePath/" + results.FileName;
                        }
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

            // creo la lista degli schedules breve
            reportManager.schedulesObj.ScheduleList = new List<Schedules>();

            try
            {

                connection.Open();

                cmd.CommandText = @"select A.Report, LR.Lastrun, NS.NextScheduled 
                from t_report_mng_schedules A
                join (select report, MAX(Lastrun) as Lastrun from t_report_mng_schedules Group By Report) LR ON LR.report = A.report
                join (select report, MIN(NextScheduled) as NextScheduled from t_report_mng_schedules Group By Report) NS ON NS.report = A.report
                Group By A.Report";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Schedules schedule = new Schedules();

                        if (reader.IsDBNull(0) == false)
                            schedule.Report = reader.GetString(0);
                        else
                            schedule.Report = null;

                        schedule.OSPsOption = "ASLBG-GASLINI".Split('-');
                        for (int i = 0; i < schedule.OSPsOption.Length; i++)
                        {
                            schedule.OSPsOption[i] = "<option >" + schedule.OSPsOption[i] + "</option>";
                        }

                        schedule.RepeatEveryTypeOption = "DAY(s)-WEEK(s)-MONTH(s)-YEAR(s)".Split('-');

                        for (int i = 0; i < schedule.RepeatEveryTypeOption.Length; i++)
                        {
                            schedule.RepeatEveryTypeOption[i] = "<option >" + schedule.RepeatEveryTypeOption[i] + "</option>";
                        }
                         
                        schedule.DayOfWeekOption = "Mon-Tue-Wed-Thu-Fri-Sat-Sun".Split('-');

                        for (int i = 0; i < schedule.DayOfWeekOption.Length; i++)
                        {
                            schedule.DayOfWeekOption[i] = "<option >" + schedule.DayOfWeekOption[i] + "</option>";
                        }

                        schedule.StoragePeriodTypeOption = "DAY(s)-WEEK(s)-MONTH(s)-YEAR(s)".Split('-');

                        for (int i = 0; i < schedule.StoragePeriodTypeOption.Length; i++)
                        {
                            schedule.StoragePeriodTypeOption[i] = "<option >" + schedule.StoragePeriodTypeOption[i] + "</option>";
                        }

                        if (reader.IsDBNull(1) == false)
                            schedule.LastRun = reader.GetDateTime(1);
                        else
                            schedule.LastRun = DateTime.MinValue;

                        if (reader.IsDBNull(2) == false)
                            schedule.NextScheduled = reader.GetDateTime(2);
                        else
                            schedule.NextScheduled = DateTime.MinValue;

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


            // creo la lista degli schedules dettaglio
            reportManager.schedulesObj.ScheduleDetailsList = new List<Schedules>();

            try
            {

                connection.Open();

                cmd.CommandText = "select * from t_report_mng_schedules";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Schedules schedule = new Schedules();
                        Reports report = new Reports();

                        if (reader.IsDBNull(0) == false)
                            schedule.ID = reader.GetInt32(0);
                        else
                            schedule.ID = 0;

                        if (reader.IsDBNull(1) == false)
                            schedule.OSPs = reader.GetString(1).Split(',');
                        else
                            schedule.OSPs = new String[0];

                        schedule.OSPsOption = "ASLBG-GASLINI".Split('-');
                        for (int i = 0; i < schedule.OSPsOption.Length; i++)
                        {
                            string selected = "";
                            for (int r = 0; r < schedule.OSPs.Length; r++)
                            {
                                if (schedule.OSPsOption[i] == schedule.OSPs[r])
                                    selected = "selected";
                            }
                            schedule.OSPsOption[i] = "<option " + selected + ">" + schedule.OSPsOption[i] + "</option>";
                        }

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

                        schedule.RepeatEveryTypeOption = "DAY(s)-WEEK(s)-MONTH(s)-YEAR(s)".Split('-');

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
                            schedule.DayOfWeek = new String[0];

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

                        schedule.StoragePeriodTypeOption = "DAY(s)-WEEK(s)-MONTH(s)-YEAR(s)".Split('-');

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

                        if (reader.IsDBNull(10) == false)
                            schedule.Description = reader.GetString(10);
                        else
                            schedule.Description = null;

                        if (reader.IsDBNull(11) == false)
                            schedule.Version = reader.GetString(1);
                        else
                            schedule.Version = null;

                        if (reader.IsDBNull(12) == false)
                            schedule.LastRun = reader.GetDateTime(12);
                        else
                            schedule.LastRun = DateTime.MinValue;

                        if (reader.IsDBNull(13) == false)
                            schedule.NextScheduled = reader.GetDateTime(13);
                        else
                            schedule.NextScheduled = DateTime.MinValue;

                        if (reader.IsDBNull(14) == false)
                            schedule.GiornoMese = reader.GetInt32(14);
                        else
                            schedule.GiornoMese = 0;

                        if (reader.IsDBNull(15) == false)
                            schedule.GiornoAnno = reader.GetDateTime(15);
                        else
                            schedule.GiornoAnno = DateTime.MinValue;

                        reportManager.schedulesObj.ScheduleDetailsList.Add(schedule);
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


        // ----------------------------------
        // ------ USERS MANAGEMENT ----------
        // ----------------------------------
        
        public ActionResult UsersManagement()
        {
            List<ViewUser> users = new List<ViewUser>();

            var dataSubject = new DataSubjectController();

            List<OSPPrivacyPolicy> availableOSPs = dataSubject.GetAuthorisedOspList();
            ViewBag.ospList = availableOSPs;

            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, dataSubject.GetServiceTicket());
            var getInstance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            string userBasePath = ConfigurationManager.AppSettings["userAapiBasePath"];
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);

            try
            {
                // get whole list of UPP from PDB in order to get the list of users
                var filter = "{\"userId\" : \"\"}";
                var uppUsersList = getInstance.UserPrivacyPolicyGet(filter);

                foreach(var upp in uppUsersList)
                {
                    // get user profile from AAPI
                    var usr = userInstance.UserUsernameGet(upp.UserId);
                    ViewUser user = new ViewUser();
                    Newtonsoft.Json.Linq.JObject jProfile = Newtonsoft.Json.Linq.JObject.Parse(usr.ToJson());
                    foreach (var attr in jProfile["optionalAttrs"])
                    {
                        if (attr["attrName"].ToString() == "user_type")
                        {
                            user.userType = attr["attrValue"].ToString();
                        }
                        if (attr["attrName"].ToString() == "email")
                        {
                            user.email = attr["attrValue"].ToString();
                        }
                    }
                    user.userName = upp.UserId;
                    users.Add(user);
                }
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling: " + e.Message);
            }

            return View(users);
        }

        [HttpPut]
        public ActionResult UsersManagementEdit(ViewUser userIn)
        {
            Debug.Print("EDIT USER: ");

            string userBasePath = ConfigurationManager.AppSettings["aapiBasePath"];
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);
            try
            {
                User user = convertUser(userIn);

                // register user
                var usr = userInstance.UserUsernamePut(user.Username, user);
                Debug.Print("USER edit sesponse: " + usr.ToJson());
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling: " + e.Message);
            }
            ViewBag.Message = userIn.userName + " successfully edit profile";

            return View();
        }

        private User convertUser(ViewUser userIn)
        {
            User user = new User(userIn.userName, "operando");
            List<eu.operando.interfaces.aapi.Model.Attribute> optAttributes = new List<eu.operando.interfaces.aapi.Model.Attribute>();
            optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("user_type", userIn.userType));
            optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("fullname", userIn.fullName));
            optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("email", userIn.email));
            optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("address", userIn.address));
            optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("city", userIn.city));
            optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("country", userIn.country));
            user.OptionalAttrs = optAttributes;

            List<eu.operando.interfaces.aapi.Model.PrivacySetting> privacySettings = new List<eu.operando.interfaces.aapi.Model.PrivacySetting>();
            privacySettings.Add(new eu.operando.interfaces.aapi.Model.PrivacySetting("string", "string"));
            user.PrivacySettings = privacySettings;

            List<eu.operando.interfaces.aapi.Model.Attribute> requiredAttributes = new List<eu.operando.interfaces.aapi.Model.Attribute>();
            requiredAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("string", "string"));
            user.RequiredAttrs = requiredAttributes;

            Debug.Print("USER added: " + user.ToJson());

            return user;
        }

        [HttpPut]
        public ActionResult UsersManagementAdd(ViewUser userIn)
        {
            string userBasePath = ConfigurationManager.AppSettings["aapiBasePath"];
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);
            try
            {
                User user = convertUser(userIn);

                // register user
                var usr = userInstance.AapiUserRegisterPost(user);
                Debug.Print("USER add sesponse: " + usr.ToJson());
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling: " + e.Message);
            }
            ViewBag.Message = userIn.userName + " successfully added";

            return View();
        }

        [HttpDelete]
        public ActionResult UsersManagementDelete(ViewUser userIn)
        {
            string userBasePath = ConfigurationManager.AppSettings["aapiBasePath"];
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);
            try
            {
                // delete user
                var usr = userInstance.UserUsernameDelete(userIn.userName);
                Debug.Print("USER delete response: " + usr.ToJson());
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling: " + e.Message);
            }
            ViewBag.Message = userIn.userName + " successfully deleted";

            return View();
        }
        // ----------------------------------
        // ------ MODULES SETTINGS ----------
        // ----------------------------------

        public ActionResult ModulesSettings()
        {
            return View();
        }

        // ----------------------------------
        // ------ SERVICE MONITORING ----------
        // ----------------------------------

        public ActionResult ServiceMonitoring()
        {
            return View();
        }
    }

}