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
        public List<IGrouping<string, IGrouping<string, AccessPolicyModel>>> AccessPoliciesBySubjectThenCategory
        {
            get;
            set;
        }

        [DefaultValue(false)]
        public bool selected  {get; set;}

    }
}