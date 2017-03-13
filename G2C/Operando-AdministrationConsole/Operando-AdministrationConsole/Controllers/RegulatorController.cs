using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using eu.operando.interfaces.rapi;
using eu.operando.interfaces.rapi.Client;
using eu.operando.interfaces.rapi.Model;
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
        public async Task<ActionResult> ComplianceReports()
        {
            var serviceTicket = GetServiceTicket();

            var osps = await _rapiClient.GetOsps(serviceTicket);

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
                reports.Add(new ComplianceReportModel()
                {
                    OspId = osp,
                    Sections = entity?.Privacypolicy.Policies.Select(p => new ComplianceReportModel.Section()
                    {
                        User = p.Datauser,
                        Subject = p.Datasubjecttype,
                        DataType = p.Datatype,
                        Reason = p.Reason
                    }).ToList() ?? new List<ComplianceReportModel.Section>()
                });
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

        // copied and modified from DataSubjectController
        private string GetServiceTicket()
        {
            string st = "";
            string rapiComplianceReportId = ConfigurationManager.AppSettings["rapiComplianceReportId"];

            // get OSP service ticket
            string aapiBasePath = ConfigurationManager.AppSettings["aapiBasePath"];
            var aapiInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(aapiBasePath);

            try
            {
                // OSP service ticket call
                st = aapiInstance.AapiTicketsTgtPost(Session["TGT"]?.ToString(), rapiComplianceReportId);
                Debug.Print("Got RAPI Service Ticket: " + st);
            }
            catch (eu.operando.interfaces.aapi.Client.ApiException ex)
            {
                Debug.Print("Exception failed to make API call to AapiTicketsTgtPost: " + ex.Message);
            }

            return st;
        }

    }
}