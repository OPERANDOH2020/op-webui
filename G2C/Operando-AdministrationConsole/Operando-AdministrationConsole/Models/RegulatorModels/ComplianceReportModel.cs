using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models.RegulatorModels
{
    public class ComplianceReportModel
    {
        public string OspId { get; set; }

        public IList<Section> Sections { get; set; }

        public class Section
        {
            public string User { get; set; }

            public string Subject { get; set; }

            public string DataType { get; set; }

            public string Reason { get; set; }
        }
    }
}