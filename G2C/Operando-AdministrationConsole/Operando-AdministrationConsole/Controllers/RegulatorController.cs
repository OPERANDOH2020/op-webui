using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using eu.operando.interfaces.aapi;
using eu.operando.interfaces.rapi;
using eu.operando.interfaces.rapi.Client;
using eu.operando.interfaces.rapi.Model;
using Operando_AdministrationConsole.Models.RegulatorModels;

namespace Operando_AdministrationConsole.Controllers
{
    public class RegulatorController : Controller
    {
        private readonly IAapiClient _aapiClient;
        private readonly IRapiClient _rapiClient;

        public RegulatorController()
        {
            _rapiClient = new RapiClient();
            _aapiClient = new AapiClient();
        }

        [HttpGet]
        public async Task<ActionResult> ComplianceReports()
        {
            var serviceTicket = GetServiceTicket();

            string userBasePath = ConfigurationManager.AppSettings["userAapiBasePath"];
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);

            var osps = userInstance.OspListGet().osps;

            var reports = new List<ComplianceReportModel>();

            foreach (var osp in osps)
            {
                ComplianceReport entity;
                try
                {
                    entity = await _rapiClient.GetComplianceReportForOspAsync(osp, serviceTicket);
                }
                catch (ApiException ex)
                {
                    entity = null;
                    Debug.Print("Exception failed to make API call to RapiComplianceReportGet: " + ex.Message);
                }
                reports.Add(new ComplianceReportModel(osp, entity));
            }

            var model = new ReportsModel()
            {
                Reports = reports
            };

            return View(model);
        }

        public ActionResult PolicyStatements()
        {
            return View();
        }

        private string GetServiceTicket()
        {
            string rapiComplianceReportId = ConfigurationManager.AppSettings["rapiComplianceReportId"];

            string ticketGrantingTicket = Session["TGT"] as string;

            return _aapiClient.GetServiceTicket(ticketGrantingTicket, rapiComplianceReportId);
        }

    }
}