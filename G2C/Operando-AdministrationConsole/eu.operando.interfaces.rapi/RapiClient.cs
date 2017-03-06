using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eu.operando.interfaces.rapi.Api;
using eu.operando.interfaces.rapi.Model;

namespace eu.operando.interfaces.rapi
{
    public class RapiClient : IRapiClient
    {
        public RapiClient()
        {
            _api = new ReportsApi("");
        }

        public Task<IList<string>> GetOsps()
        {
            //TODO use proper implementation
            IList<string> result = new List<string>()
            {
                "OSP-A",
                "OSP-B",
                "OSP-C",
                "OSP-D",
                "OSP-E"
            };

            return Task.FromResult(result);
        }

        public Task<ComplianceReport> GetComplianceReportForOspAsync(string osp)
        {
            var result = _api.OspsOspIdComplianceReportGetAsync("", osp);

            return result;
        }

        private readonly IReportsApi _api;
    }
}
