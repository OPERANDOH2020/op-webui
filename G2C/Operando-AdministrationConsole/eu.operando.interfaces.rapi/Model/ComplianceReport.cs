using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eu.operando.interfaces.rapi.Model
{
    public class ComplianceReport
    {
        public ReasonPolicy PrivacyPolicy { get; set; }
    }

    public class ReasonPolicy
    {
        public string OspPolicyId { get; set; }

        public IList<AccessReason> Policies { get; set; }
    }

    public class AccessReason
    {
        public string ReasonId { get; set; }

        public string DataUser { get; set; }

        public string DataSubjectType { get; set; }

        public string DataType { get; set; }

        public string Reason { get; set; }
    }
}
