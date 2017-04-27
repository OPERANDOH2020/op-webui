using Operando_AdministrationConsole.Helper;
using Operando_AdministrationConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Net.Http;
using System.Text;
using eu.operando.common.Services;
using eu.operando.core.bda;
using eu.operando.core.bda.Model;
using Operando_AdministrationConsole.Models.OspAdminModels;
using System.Diagnostics;
using eu.operando.core.pdb.cli.Model;
using Newtonsoft.Json;
using eu.operando.interfaces.aapi;
using eu.operando.interfaces.aapi.Model;

namespace Operando_AdministrationConsole.Controllers
{
    public class OspAdminController : Controller
    {
        private OperandoWebServiceHelper helper = new OperandoWebServiceHelper();
        ReportManagerOSP reportManagerOSP = new ReportManagerOSP();


        private readonly IBdaClient _bdaClient;
        private readonly IAapiClient _aapiClient;

        public OspAdminController()
        {
            _bdaClient = new BdaClient();
            _aapiClient = new AapiClient();
        }

        private Uri OSPRoot(string id)
        {
            //return new Uri($"http://localhost:8080/stub-pdb/api/OSP/{id}/privacy-policy");
            return new Uri($"http://10.136.24.87:8080/pdb/OSP/587f80549e86b2c3b0a43eaa/privacy-policy");
        }

        public ActionResult ControllerDownloadAction(string fileName)
        {
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment;filename="+ fileName);
            Response.Clear();
            Response.WriteFile(Server.MapPath("../" + ConfigurationManager.AppSettings["reportSavePath"] + "/" + fileName));
            Response.Flush();
            Response.End();
            return View();
        }

        private eu.operando.core.pdb.cli.Client.Configuration getConfiguration(string serviceIdKey)
        {
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];
            string pdbOSPSId = ConfigurationManager.AppSettings[serviceIdKey];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetUppServiceTicket(pdbOSPSId));

            return configuration;
        }
        public List<OSPPrivacyPolicy> GetOspList()
        {
            string userBasePath = ConfigurationManager.AppSettings["userAapiBasePath"];
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);
            OspList ospList = userInstance.OspListGet();
            Debug.Print("OSP LIST: " + ospList.ToString());
            
            var instance = new eu.operando.core.pdb.cli.Api.GETApi(getConfiguration("pdbOSPSId"));

            List<OSPPrivacyPolicy> checkedOSPList = new List<OSPPrivacyPolicy>();
            try
            {
                // OSP call to get the list of service providers
                var filter = "{\"policy_text\" : \"\"}";
                var response = instance.OSPGet(filter);

                foreach (string ospItem in ospList.osps)
                {
                    foreach (OSPPrivacyPolicy ospInstance in response)
                    {
                        if ((ospInstance.PolicyUrl == ospItem) || (ospInstance.PolicyText == ospItem))
                        {
                            checkedOSPList.Add(ospInstance);
                            break;
                        }
                    }
                }
                if (checkedOSPList.Count == 0)
                {
                    checkedOSPList = response;
                }
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSP list: " + e.Message);
            }
            return checkedOSPList;
        }
        public ActionResult PrivacyPolicy()
        {
            var instance = new eu.operando.core.pdb.cli.Api.GETApi(getConfiguration("pdbOSPSId"));

            List<OSPPrivacyPolicy> ospList = GetOspList();
            List<OSPReasonPolicy> reasonPolicyList = new List<OSPReasonPolicy>();
            foreach (OSPPrivacyPolicy osp in ospList)
            {
                OSPReasonPolicy ospReasonPolicy = null;
                try
                {                    
                    ospReasonPolicy = instance.OSPOspIdPrivacyPolicyGet(osp.PolicyUrl);
                }
                catch (eu.operando.core.pdb.cli.Client.ApiException e)
                {
                    ospReasonPolicy = new OSPReasonPolicy();
                    ospReasonPolicy.OspPolicyId = osp.PolicyUrl; // ospId;
                    ospReasonPolicy.Policies = new List<AccessReason>();
                }

                reasonPolicyList.Add(ospReasonPolicy);
            }
            return View(reasonPolicyList);
            //return View();
        }

        [HttpPost]
        public ActionResult NewPrivacyPolicy(OSPReasonPolicy policy)
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            OSPReasonPolicyInput ospRPI = new OSPReasonPolicyInput();
            ospRPI.Policies = policy.Policies;

            instance.OSPOspIdPrivacyPolicyPut(policy.OspPolicyId, ospRPI);

            return View(policy);
        }

        [HttpPut]
        public ActionResult UpdatePrivacyPolicy(OSPReasonPolicy policy)
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            OSPReasonPolicyInput ospRPI = new OSPReasonPolicyInput();
            ospRPI.Policies = policy.Policies;

            instance.OSPOspIdPrivacyPolicyPut(policy.OspPolicyId, ospRPI);

            return Content(policy.ToString());
        }
        

        [HttpDelete]
        public async Task<ActionResult> DeletePrivacyPolicy(OSPReasonPolicy policy)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(policy), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(OSPRoot(policy.OspPolicyId), OperandoJson);
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRegulation(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.DeleteAsync(OSPRoot(id));
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        public ActionResult Reports()
        {
            // creo gli oggetti per popolare la pagina
            reportManagerOSP.reportsObj = new ReportsOSP();
            reportManagerOSP.resultsObj = new ResultsOSP();
            reportManagerOSP.schedulesObj = new SchedulesOSP();


            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            // creo la lista dei report
            ReportsOSP reports = new ReportsOSP();
            reportManagerOSP.reportsObj.ReportList = new List<ReportsOSP>();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;

            try
            {

                connection.Open();

                cmd.CommandText = "select * from t_report_mng_list ";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        ReportsOSP report = new ReportsOSP();

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

                        reportManagerOSP.reportsObj.ReportList.Add(report);
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
            reportManagerOSP.resultsObj.ResultList = new List<ResultsOSP>();

            try
            {

                connection.Open();

                cmd.CommandText = "select * from t_report_mng_results ";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        ResultsOSP results = new ResultsOSP();

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
                            results.FileName = reader.GetString(6);
                        else
                            results.FileName = null;

                        reportManagerOSP.resultsObj.ResultList.Add(results);
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
            reportManagerOSP.schedulesObj.ScheduleList = new List<SchedulesOSP>();

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
                        SchedulesOSP schedule = new SchedulesOSP();

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

                        reportManagerOSP.schedulesObj.ScheduleList.Add(schedule);
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
            reportManagerOSP.schedulesObj.ScheduleDetailsList = new List<SchedulesOSP>();

            try
            {

                connection.Open();

                cmd.CommandText = "select * from t_report_mng_schedules";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        SchedulesOSP schedule = new SchedulesOSP();
                        ReportsOSP report = new ReportsOSP();

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

                        if (reader.IsDBNull(14) == false)
                            schedule.GiornoMese = reader.GetInt32(14);
                        else
                            schedule.GiornoMese = 0;

                        if (reader.IsDBNull(15) == false)
                            schedule.GiornoAnno = reader.GetDateTime(15);
                        else
                            schedule.GiornoAnno = DateTime.MinValue;

                        reportManagerOSP.schedulesObj.ScheduleDetailsList.Add(schedule);
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


            return View(reportManagerOSP);
        }

        public ActionResult DataExtracts()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> UserQuestionnaireGenerator()
        {
            using (HttpClient client = new HttpClient())
            {
                Uri qUri = new Uri("http://192.9.206.106:8080/operandocpcu/cpcu/robbie/0/0/");
                //StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(policy), Encoding.UTF8, "application/json");
                var result = await client.GetAsync(qUri);
                Response.StatusCode = (int)result.StatusCode;
                var content = await result.Content.ReadAsStringAsync();
                //QGetQuestionnaire qGet = JsonConvert.DeserializeObject<QGetQuestionnaire>(content);
                return View();
            }
        }
        public ActionResult UserQuestionnaireGenerator1()
        {
            return View();
        }

        /* Method modified by IT Innovation Centre 2017 */
        private string GetUppServiceTicket(string serviceName)
        {
            var ticketGrantingTicket = Session["TGT"] as string;

            return _aapiClient.GetServiceTicket(ticketGrantingTicket, serviceName);
        }

        /* Method modified by IT Innovation Centre 2017 */
        public ActionResult UppManagementTool()
        {
            string ospId = "587f7eb56e157a10eece95d3"; // local for http://10.136.24.87:8080/pdb
            ospId = "YellowPages";
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];
            string pdbUPPSId = ConfigurationManager.AppSettings["pdbUPPSId"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetUppServiceTicket(pdbUPPSId));

            var instance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            try
            {
                // UPP call to get the list of upp entries
                //var filter = "filter=\"%7B%27subscribed_osp_policies.osp_id%27:%27" + ospId + "%27%7D\"";
                var filter = "{\"subscribed_osp_policies.osp_id\":\"" + ospId + "\"}";
                List<UserPrivacyPolicy> response = instance.UserPrivacyPolicyGet(filter);

                /* response is a list of UserPrivacyPolicy we need to filter those for
                 * OSPConsents that match the ospId. we create a new list of OSPConsent type
                 * HOWEVER just for display purposes the ospId will contain the userId from UPP
                 */
                List<OSPConsents> modOspConsents = new List<OSPConsents>();
                Dictionary<string, UppTab2> uppStats = new Dictionary<string, UppTab2>();
                foreach(UserPrivacyPolicy upp in response)
                {
                    Debug.Print("upp found: " + upp.ToString());
                    OSPConsents ospConsents = new OSPConsents();                    
                    foreach(OSPConsents ospCons in upp.SubscribedOspPolicies)
                    {
                        if (ospCons.OspId == ospId)
                        {
                            // overwriting ospId with userId
                            ospConsents.OspId = upp.UserId;
                            ospConsents.AccessPolicies = ospCons.AccessPolicies;
                            modOspConsents.Add(ospConsents);
                            foreach(eu.operando.core.pdb.cli.Model.AccessPolicy ap in ospCons.AccessPolicies)
                            {
                                string key = ap.Subject + ap.Action + ap.Resource;
                                if (!uppStats.ContainsKey(key))
                                {
                                    UppTab2 tmpUpp = new UppTab2();
                                    tmpUpp.key = key;
                                    tmpUpp.action = ap.Action.ToString();
                                    tmpUpp.role = ap.Subject.ToString();
                                    tmpUpp.apType = ap.Resource.ToString();
                                    tmpUpp.stats = new List<bool>(new bool[] { (bool)ap.Permission });
                                    if(ap.Permission == true)
                                    {
                                        tmpUpp.yes = 1;
                                        tmpUpp.no = 0;
                                    }
                                    else
                                    {
                                        tmpUpp.yes = 0;
                                        tmpUpp.no = 1;
                                    }
                                    uppStats.Add(key, tmpUpp);
                                }
                                else
                                {
                                    uppStats[key].stats.Add((bool)ap.Permission);                                    
                                    if(ap.Permission == true)
                                    {
                                        uppStats[key].yes++;
                                    }
                                    else
                                    {
                                        uppStats[key].no++;
                                    }
                                }
                            }
                        }
                    }
                }

                Debug.Print("UPP response:" + response.ToString());

                ViewBag.modOspConsents = modOspConsents;
                ViewBag.uppStats = uppStats;

                return View();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserPrivacyPolicy GET: " + e.Message);
            }

            return View();
        }

        public async Task<ActionResult> BigDataAnalytics()
        {
            ICollection<Job> jobs = await _bdaClient.GetJobsAsync();

            var executions = jobs.Select(_ => new BdaJob(_)).ToList();

            return View(executions);
        }

        [HttpGet]
        public ActionResult RequestNewBdaExtract()
        {
            return View("RequestNewBdaExtraction");
    }

        [HttpPost]
        public async Task<ActionResult> RequestNewBdaExtract(RequestNewBdaExtractModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("RequestNewBdaExtraction", model);
            }

            try
            {
                var request = new ExtractionRequest
                {
                    RequesterName = model.RequesterName,
                    ContactEmail = model.ContactEmail,
                    RequestSummary = model.RequestSummary,
                    Osp = OspForCurrentUser,
                    RequestDate = DateTime.UtcNow
                };

                await _bdaClient.RequestNewBdaExtractionAsync(request);

                return RedirectToAction("BigDataAnalytics");
            }
            catch (Exception ex)
            {
                // TODO -- exception should be logged here
                return View("Error", new HandleErrorInfo(ex, "OspAdmin", "RequestNewBdaExtract"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddSchedule(BdaSchedule model)
        {
            var schedule = new Schedule
            {
                JobId = model.JobId,
                StartTime = model.StartTime,
                RepeatInterval = TimeSpan.FromDays(model.RepeatIntervalDays),
                OspScheduled = OspForCurrentUser
            };

            await _bdaClient.AddScheduleAsync(schedule);

            return RedirectToAction("BigDataAnalytics");
        }

        [HttpPost]
        public async Task<ActionResult> EditSchedule(BdaSchedule model)
        {
            var schedule = await _bdaClient.GetScheduleByIdAsync(model.Id);

            if (schedule == null || schedule.OspScheduled != OspForCurrentUser)
            {
                return new HttpUnauthorizedResult();
            }

            schedule.StartTime = model.StartTime;
            schedule.RepeatInterval = TimeSpan.FromDays(model.RepeatIntervalDays);

            await _bdaClient.UpdateScheduleAsync(schedule);

            return RedirectToAction("BigDataAnalytics");
        }

        public async Task<ActionResult> DeleteSchedule(string id)
        {
            var schedule = await _bdaClient.GetScheduleByIdAsync(id);

            if (schedule == null || schedule.OspScheduled != OspForCurrentUser)
            {
                return new HttpUnauthorizedResult();
            }

            await _bdaClient.DeleteScheduleAsync(schedule);

            return RedirectToAction("BigDataAnalytics");
        }

        /// <summary>
        /// TODO -- how to get the OSP the current user (an OSP admin) works for
        /// </summary>
        private string OspForCurrentUser { get; } = "OCC";
    }
}