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
        public async Task<ActionResult> Reports()
        {

            //TODO get ospIds

            var model = new ReportsModel()
            {
                OspIds = new List<string>()
                {
                    "OSP-A",
                    "OSP-B",
                    "OSP-C",
                    "OSP-D",
                    "OSP-E"
                }
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> _ComplianceReport(string ospId)
        {
            var complianceReport = await _rapiClient.GetComplianceReportForOspAsync(ospId);

            var sections = complianceReport?.PrivacyPolicy.Policies.Select(p => new ComplianceReportModel.Section()
            {
                User = p.DataUser,
                Subject = p.DataSubjectType,
                DataType = p.DataType,
                Reason = p.Reason
            }).ToList();

            var model = new ComplianceReportModel()
            {
                OspId = ospId,
                Sections = sections
            };

            return PartialView(model);
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