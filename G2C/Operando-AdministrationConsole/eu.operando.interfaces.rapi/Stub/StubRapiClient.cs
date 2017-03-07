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
        public Task<IList<string>> GetOsps(string serviceTicket)
        {
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

        public Task<ComplianceReport> GetComplianceReportForOspAsync(string osp, string serviceTicket)
        {
            var policy1 = new AccessReason()
            {
                DataUser = "Receptionist",
                DataSubjectType = "Patient",
                DataType = "Contact",
                Reason = "to arrange appointments"
            };

            var policy2 = new AccessReason()
            {
                DataUser = "Doctor",
                DataSubjectType = "Patient",
                DataType = "Biometric",
                Reason = "to assess health risks"
            };

            var policy3 = new AccessReason()
            {
                DataUser = "Doctor",
                DataSubjectType = "Patient",
                DataType = "Medication",
                Reason = "to check for drug interaction"
            };

            var policy4 = new AccessReason()
            {
                DataUser = "Doctor",
                DataSubjectType = "Doctor",
                DataType = "Medical",
                Reason = "to ask a consultancy"
            };

            var policy5 = new AccessReason()
            {
                DataUser = "Receptionist",
                DataSubjectType = "Patient",
                DataType = "Contact",
                Reason = "to change appointments"
            };

            var policy6 = new AccessReason()
            {
                DataUser = "Receptionist 2",
                DataSubjectType = "Patient 2",
                DataType = "Contact 2",
                Reason = "to change appointments 2"
            };

            ComplianceReport result = new ComplianceReport()
            {
              PrivacyPolicy  = new OSPReasonPolicy()
              {
                  OspPolicyId = osp,
                  Policies = new List<AccessReason>()
                  {
                      policy1,
                      policy2,
                      policy3,
                      policy4,
                      policy5,
                      policy6
                  }
              }
            };

            return Task.FromResult(result);
        }
    }
}
