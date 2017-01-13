using Operando_AdministrationConsole.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class PrivacyPolicy
    {
        public string OspPolicyId { get; set; }
        public List<AccessPolicy> Policies { get; set; }
    }

    public class AccessPolicy
    {
        public string Datauser { get; set; }
        public string Datasubjecttype { get; set; }
        public string Datatype { get; set; }
        public string Reason { get; set; }
    }
}