using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Operando_AdministrationConsole.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;
using Operando_AdministrationConsole.Helper;
using System.Net;
using System.Text;
using eu.operando.common;
using eu.operando.common.Entities;
using eu.operando.common.Services;
using eu.operando.core.bda;
using eu.operando.core.bda.Model;
using Operando_AdministrationConsole.Models.PspAnalystModels;
using eu.operando.core.pdb.cli.Model;
using System.Configuration;
using System.Diagnostics;
using eu.operando.interfaces.aapi.Model;
using eu.operando.interfaces.aapi;
using eu.operando.core.ldb.Model;
using System.Globalization;

namespace Operando_AdministrationConsole.Controllers
{
    public class PspAnalystController : Controller
    {
        private OperandoWebServiceHelper helper = new OperandoWebServiceHelper();
        private readonly IAapiClient _aapiClient;
        private readonly Uri _regulationsRoot;

        private readonly IBdaClient _bdaClient;

        /// <summary>
        /// TODO where should this come from?
        /// </summary>
        private readonly string[] _availableOsps = {"OCC", "PDI", "ITI"};

        /// <summary>
        /// TODO where should this come from?
        /// </summary>
        private readonly Money.CurrencyCode[] _availablecurrencyCodes = Money.AvailableCurrencyCodes;

        public PspAnalystController()
        {
            _bdaClient = new BdaClient();
            _aapiClient = new AapiClient();
            var pdbRoot = new Uri(ConfigurationManager.AppSettings["pdbBasePath"]);
            _regulationsRoot = new Uri(
                pdbRoot,
                ConfigurationManager.AppSettings["pdbRegSId"]);
        }

        // GET: PspAnalyst
        public async Task<ActionResult> Regulations()
        {
            var searchAll = new Uri(_regulationsRoot, "?filter=");
            List<Regulation> regulations = await helper.get<List<Regulation>>(searchAll.ToString()); //= await getAllRegulations();
            return View(regulations);
        }

        [HttpPost]
        public async Task<ActionResult> NewRegulation(Regulation regulation)
        {
            using(HttpClient client = new HttpClient())
            {
                StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(regulation), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(_regulationsRoot, OperandoJson);
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRegulation(Regulation regulation)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(regulation), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(new Uri(_regulationsRoot, regulation.RegId), OperandoJson);
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRegulation(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.DeleteAsync(new Uri(_regulationsRoot, id));
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        public ActionResult DataExtracts()
        {
            return View();
        }

        public ActionResult OspCompliance()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult ReviewPolicy()
        {
            return View();
        }

        public ActionResult UppManagement()
        {
            return View();
        }

        public async Task<ActionResult> BigDataAnalyticsConfig()
        {
            var jobs = await _bdaClient.GetJobsAsync();
            BdaPageModel model = new BdaPageModel
            {
                Jobs = jobs.Select(_ => new BdaJob(_)).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult AddJob()
        {
            var model = new BigDataJobModel
            {
                AvailableCurrencies = _availablecurrencyCodes,
                AvailableOsps = _availableOsps
            };

            return PartialView("_addBigDataJobModal", model);
        }

        [HttpPost]
        public async Task<ActionResult> AddJob(BigDataJobModel model)
        {
            try
            {
                var job = new Job
                {
                    JobName = model.JobName,
                    Description = model.Description,
                    CurrentVersionNumber = model.CurrentVersionNumber,
                    DefinitionLocation = model.DefinitionLocation,
                    CostPerExecution = new Money
                    {
                        Currency = model.SelectedCurrency,
                        Value = model.CostPerExecution
                    },
                    Osps = model.SelectedOsps.ToList()
                };


                await _bdaClient.AddJobAsync(job);

                return RedirectToAction("BigDataAnalyticsConfig");
            }
            catch (Exception ex)
            {
                // TODO -- exception should be logged here
                return View("Error", new HandleErrorInfo(ex, "PspAnalyst", "AddJob"));
            }
        }

        [HttpGet]
        public async Task<ActionResult> EditJob(string jobId)
        {
            var job = await _bdaClient.GetJobByIdAsync(jobId);

            if (job == null)
            {
                return HttpNotFound();
            }

            var model = new BigDataJobModel
            {
                AvailableCurrencies = _availablecurrencyCodes,
                AvailableOsps = _availableOsps,

                JobId = job.Id,
                JobName = job.JobName,
                Description = job.Description,
                CurrentVersionNumber = job.CurrentVersionNumber,
                DefinitionLocation = job.DefinitionLocation,
                CostPerExecution = job.CostPerExecution.Value,
                SelectedCurrency = job.CostPerExecution.Currency,
                SelectedOsps = job.Osps.ToArray()
            };

            return PartialView("_editBigDataJobModal", model);
        }

        [HttpPost]
        public async Task<ActionResult> EditJob(BigDataJobModel model)
        {
            var job = await _bdaClient.GetJobByIdAsync(model.JobId);

            if (job == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Copy over fields
                job.JobName = model.JobName;
                job.Description = model.Description;
                job.CurrentVersionNumber = model.CurrentVersionNumber;
                job.DefinitionLocation = model.DefinitionLocation;
                job.CostPerExecution = new Money
                {
                    Currency = model.SelectedCurrency,
                    Value = model.CostPerExecution
                };
                job.Osps = model.SelectedOsps.ToList();

                await _bdaClient.UpdateJobAsync(job);

                return RedirectToAction("BigDataAnalyticsConfig");
            }
            catch (Exception ex)
            {
                // TODO -- exception should be logged here
                return View("Error", new HandleErrorInfo(ex, "PspAnalyst", "AddJob"));
            }
        }

        [HttpGet]
        public async Task<ActionResult> AddSchedule()
        {
            var jobs = await _bdaClient.GetJobsAsync();

            var model = new BigDataScheduleModel(new Schedule(), _availableOsps, jobs);

            return PartialView("_addBigDataScheduleModal", model);
        }

        [HttpPost]
        public async Task<ActionResult> AddSchedule(BigDataScheduleModel model)
        {
            try
            {
                var schedule = new Schedule
                {
                    JobId = model.JobId,
                    OspScheduled = model.OspScheduled,
                    StartTime = model.StartTime,
                    RepeatInterval = TimeSpan.FromDays(model.RepeatIntervalDays)
                };


                await _bdaClient.AddScheduleAsync(schedule);

                return RedirectToAction("BigDataAnalyticsConfig");
            }
            catch (Exception ex)
            {
                // TODO -- exception should be logged here
                return View("Error", new HandleErrorInfo(ex, "PspAnalyst", "AddSchedule"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditSchedule(BdaSchedule model)
        {
            var schedule = await _bdaClient.GetScheduleByIdAsync(model.Id);

            if (schedule == null)
            {
                // TODO -- log that schedule id was not valid
                return new HttpUnauthorizedResult();
            }

            schedule.StartTime = model.StartTime;
            schedule.RepeatInterval = TimeSpan.FromDays(model.RepeatIntervalDays);
            // changing the scheduled OSP is not allowed. It can be achieved by deleting a schedule and creating a new one. 

            await _bdaClient.UpdateScheduleAsync(schedule);

            return RedirectToAction("BigDataAnalyticsConfig");
        }

        public async Task<ActionResult> DeleteSchedule(string id)
        {
            var schedule = await _bdaClient.GetScheduleByIdAsync(id);

            if (schedule == null)
            {
                // TODO -- log that schedule id was not valid
                return new HttpUnauthorizedResult();
            }

            await _bdaClient.DeleteScheduleAsync(schedule);

            return RedirectToAction("BigDataAnalyticsConfig");
        }
        public List<OSPPrivacyPolicy> GetOspList()
        {
            string userBasePath = ConfigurationManager.AppSettings["userAapiBasePath"];
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);

            var instance = new eu.operando.core.pdb.cli.Api.GETApi(getConfiguration("pdbOSPSId"));

            List<OSPPrivacyPolicy> checkedOSPList = new List<OSPPrivacyPolicy>();
            try
            {
                OspList ospList = userInstance.OspListGet();
                Debug.Print("OSP LIST: " + ospList.ToString());


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
        private eu.operando.core.pdb.cli.Client.Configuration getConfiguration(string serviceIdKey)
        {
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];
            string pdbOSPSId = ConfigurationManager.AppSettings[serviceIdKey];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetUppServiceTicket(pdbOSPSId));

            return configuration;
        }
        private string GetUppServiceTicket(string serviceName)
        {
            var ticketGrantingTicket = Session["TGT"] as string;

            return _aapiClient.GetServiceTicket(ticketGrantingTicket, serviceName);
        }
        //method to show the Review Logs page
        public ActionResult ReviewLogs()
        {
            List<OSPPrivacyPolicy> ospList = GetOspList();
            ViewBag.ospList = ospList;
            return View();
        }
        /*Method created by IT Innovation Centre, Christopher Coles, 06/09/2017*/
        //This method returns a report for a particular OSP's logs, whether they are valid or not, and if not, returning which logs are not valid
        [HttpGet]
        public JsonResult ReportEvaluation(string ospUrl, string ospId, int startday, int startmonth, int startyear, int endday, int endmonth, int endyear)
        {
          

            string baseurl = ConfigurationManager.AppSettings["ldbBasePath"];
            //instance to get from the log database
            var instance = new eu.operando.core.ldb.LdbClient(baseurl);
            //gets the list of OSPs
            List<OSPPrivacyPolicy> ospList = GetOspList();

            //creates datetime objects for the start date and end date selected by the user on the html page
            DateTime startDate = new DateTime(startyear, startmonth, startday).Date;
            DateTime endDate = new DateTime(endyear, endmonth, endday, 23, 59, 59);
            //gets the OSPPolicyId from the string submitted from the HTML page
            //string[] ospStrings = OSPId.Split('/');
            string OspPolicyId = ospId; // ospStrings[1];
            string ospPolicyIdUrl = ospUrl; // ospStrings[0];
            string OSPId = ospUrl + '/' + ospId;

            
            OSPPrivacyPolicy matchingOsp = ospList.Where(o => o.OspPolicyId.Equals(OspPolicyId)).First();
            HashSet<String> roles = new HashSet<string>();

            foreach (AccessPolicy policy in matchingOsp.Policies)
            {
                roles.Add(policy.Subject);
            }
            //get the data access logs
            //IList<DataAccessLog> logs = instance.GetDataAccessOspLogs(ospPolicyIdUrl);
            IList<DataAccessLog> logs = instance.GetDataAccessOspLogs("");
            List<DataAccessLog> logsToCheck = new List<DataAccessLog>();
            //sorts by logs that fall within the region for the dates
            foreach (var log in logs)
            {
                if (log.logDate >= startDate && log.logDate <= endDate)
                {
                    logsToCheck.Add(log);
                }
            }
            //creates a report object
            Report report = new Report();
            //goes through each log that matches the dates
            foreach (var log in logsToCheck)
            {
                bool found = false;
                string matchedrole = "nothing";
                //checks if there is a role matching the role accesed according to the logs
                foreach (var role in roles)
                {
                    if (Regex.IsMatch(log.description, role, RegexOptions.IgnoreCase))
                    {
                        found = true;
                        matchedrole = role;
                        break;
                    }
                }
                //runs if there is a matching role
                if (found)
                {
                    //checks if there is a resource and role which matches (the policy for this log)
                    if (matchingOsp.Policies.Any(p => p.Subject.Equals(matchedrole) && p.Resource.Equals(log.title)))
                    {
                        report.validLogs.Add(log);
                    }
                    else
                    {
                        report.invalidLogs.Add(log);
                    }
                }
                else
                {
                    report.invalidLogs.Add(log);
                }
            }
            //builds a string to return based on the report outcome.
            String html = "<p>Status:<p> <ul>";
            if (report.checkValid())     
            {
                html = "<li>All logs for OSP " + ospPolicyIdUrl + " are valid for the selected date period</li>";
            }
            else
            {
                foreach (var log in report.invalidLogs)
                {
                    html += "<li>" + ospPolicyIdUrl + " has made an invalid request with the resource " + log.title + ". </li>";
                }
            }
            html += "</ul>";

            return Json(html, JsonRequestBehavior.AllowGet);
        }
    }
}