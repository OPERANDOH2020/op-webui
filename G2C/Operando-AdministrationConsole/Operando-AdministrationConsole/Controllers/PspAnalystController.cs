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

namespace Operando_AdministrationConsole.Controllers
{
    public class PspAnalystController : Controller
    {
        private OperandoWebServiceHelper helper = new OperandoWebServiceHelper();

        private static readonly Uri RegulationsRoot = new Uri("http://localhost:8080/stub-pdb/api/regulations/");

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
        }

        // GET: PspAnalyst
        public async Task<ActionResult> Regulations()
        {
            List<Regulation> regulations = await helper.get<List<Regulation>>(RegulationsRoot.ToString()); //= await getAllRegulations();
            return View(regulations);
        }

        [HttpPost]
        public async Task<ActionResult> NewRegulation(Regulation regulation)
        {
            using(HttpClient client = new HttpClient())
            {
                StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(regulation), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(RegulationsRoot, OperandoJson);
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
                var result = await client.PutAsync(new Uri(RegulationsRoot, regulation.RegId), OperandoJson);
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRegulation(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.DeleteAsync(new Uri(RegulationsRoot, id));
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
    }
}
