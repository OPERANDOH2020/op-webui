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
using eu.operando.interfaces.rapi;
using Operando_AdministrationConsole.Helper;
using Operando_AdministrationConsole.Models.RegulatorModels;

namespace Operando_AdministrationConsole.Controllers
{
    public class RegulatorController : Controller
    {

        private readonly IRapiClient _rapiClient;

        public RegulatorController()
        {
            _rapiClient = new RapiClient();
        }

        [HttpGet]
        public async Task<ActionResult> Reports(string ospId)
        {
            var complianceReport = await _rapiClient.GetComplianceReportForOspAsync(ospId);

            var model = new ReportsModel();

            return View(model);
        }

        public ActionResult RegulationCompliance()
        {
            return View();
        }

        public ActionResult RegulationComplianceDetail()
        {
            return View();
        }

        public ActionResult PolicyStatements()
        {
            return View();
        }

    }
}