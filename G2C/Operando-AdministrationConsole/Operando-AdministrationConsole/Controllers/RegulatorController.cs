﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
            var serviceTicket = GetServiceTicket();

            var osps = await _rapiClient.GetOsps(serviceTicket);

            var reports = new List<ComplianceReportModel>();

            foreach (var osp in osps)
            {
                var entity = await _rapiClient.GetComplianceReportForOspAsync(osp, serviceTicket);

                reports.Add(new ComplianceReportModel()
                {
                    OspId = osp,
                    Sections = entity?.PrivacyPolicy.Policies.Select(p => new ComplianceReportModel.Section()
                    {
                        User = p.DataUser,
                        Subject = p.DataSubjectType,
                        DataType = p.DataType,
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