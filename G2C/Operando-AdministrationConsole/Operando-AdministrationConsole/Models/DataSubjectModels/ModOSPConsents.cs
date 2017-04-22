using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eu.operando.core.pdb.cli.Model;
using System.ComponentModel;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class ModOSPConsents
    {
        public string OspId { get; set; }
        public List<GroupAccessPolicies> map { get; set; }
        [DefaultValue(false)]
        public bool selected  {get; set;}

    }

    public class GroupAccessPolicies
    {
        public string groupKey { get; set; }
        public List<AccessPolicy> gap { get; set; }
    }
}