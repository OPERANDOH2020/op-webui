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
        public List<GroupAccessPolicies> groupAPBySubject { get; set; }
        [DefaultValue(false)]
        public bool selected  {get; set;}

    }

    public class GroupAccessPolicies
    {
        public string groupSubject { get; set; }
        public List<Category> categoryAPList { get; set; }
    }

    public class Category
    {
        public string category { get; set; }
        public List<AccessPolicyWithReason> categoryAPList { get; set; }
    }

    public class AccessPolicyWithReason
    {
        [DefaultValue("empty")]
        public string reason { get; set; }
        public AccessPolicy accessPolicy { get; set; }
    }
}