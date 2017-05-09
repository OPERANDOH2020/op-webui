using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eu.operando.interfaces.rapi.Api;
using eu.operando.interfaces.rapi.Client;
using eu.operando.interfaces.rapi.Model;

namespace eu.operando.interfaces.rapi
{
    public class RapiClient : IRapiClient
    {
        public RapiClient()
        {
            var basePath = ConfigurationManager.AppSettings["rapiBasePath"];
            _api = new ComplianceReportsApi(basePath);
        }

        public Task<ComplianceReport> GetComplianceReportForOspAsync(string osp, string serviceTicket)
        {

            var result = _api.OspsOspIdComplianceReportGetAsync(serviceTicket, osp);

            return result;
            
        }

        private readonly IComplianceReportsApi _api;
    }
}
