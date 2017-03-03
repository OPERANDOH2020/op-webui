using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eu.operando.interfaces.rapi.Model;

namespace eu.operando.interfaces.rapi.Stub
{
    public class StubRapiClient : IRapiClient
    {
        public Task<ComplianceReport> GetComplianceReportForOspAsync(string osp)
        {
            return Task.FromResult((ComplianceReport) null);
        }
    }
}
