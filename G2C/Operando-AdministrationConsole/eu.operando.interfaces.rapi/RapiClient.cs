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
            _api = new ReportsApi(basePath);
        }

        public Task<IList<string>> GetOsps(string serviceTicket)
        {
            //TODO use proper implementation
            IList<string> result = new List<string>()
            {
                "built-in",
                "Ami",
                "OSP-C",
                "OSP-D",
                "OSP-E"
            };

            return Task.FromResult(result);
        }

        public Task<ComplianceReport> GetComplianceReportForOspAsync(string osp, string serviceTicket)
        {

            var result = _api.OspsOspIdComplianceReportGetAsync(serviceTicket, osp);

            return result;
            
        }

        private readonly IReportsApi _api;
    }
}
