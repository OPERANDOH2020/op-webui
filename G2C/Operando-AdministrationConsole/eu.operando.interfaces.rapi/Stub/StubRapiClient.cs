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

        public Task<ComplianceReport> GetComplianceReportForOspAsync(string osp, string serviceTicket)
        {
            var policy1 = new AccessReason()
            {
                Datauser = "Receptionist",
                Datasubjecttype = "Patient",
                Datatype = "Contact",
                Reason = "to arrange appointments"
            };

            var policy2 = new AccessReason()
            {
                Datauser = "Doctor",
                Datasubjecttype = "Patient",
                Datatype = "Biometric",
                Reason = "to assess health risks"
            };

            var policy3 = new AccessReason()
            {
                Datauser = "Doctor",
                Datasubjecttype = "Patient",
                Datatype = "Medication",
                Reason = "to check for drug interaction"
            };

            var policy4 = new AccessReason()
            {
                Datauser = "Doctor",
                Datasubjecttype = "Doctor",
                Datatype = "Medical",
                Reason = "to ask a consultancy"
            };

            var policy5 = new AccessReason()
            {
                Datauser = "Receptionist",
                Datasubjecttype = "Patient",
                Datatype = "Contact",
                Reason = "to change appointments"
            };

            var policy6 = new AccessReason()
            {
                Datauser = "Receptionist 2",
                Datasubjecttype = "Patient 2",
                Datatype = "Contact 2",
                Reason = "to change appointments 2"
            };

            ComplianceReport result = new ComplianceReport()
            {
              Privacypolicy = new OSPReasonPolicy()
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
