using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eu.operando.interfaces.rapi.Model;

namespace Operando_AdministrationConsole.Models.RegulatorModels
{
    public class ComplianceReportModel
    {
        public string OspId { get; set; }

        public IList<Section> Sections { get; set; }

        public ComplianceReportModel(string ospId, ComplianceReport entity)
        {
            OspId = ospId;
            Sections = entity?.Privacypolicy.Policies.Select(_ => new Section(_)).ToList() ?? new List<Section>();
        }

        public class Section
        {
            public string User { get; set; }

            public string Subject { get; set; }

            public string DataType { get; set; }

            public string Reason { get; set; }

            public Section(AccessReason reason)
            {
                User = reason.Datauser;
                Subject = reason.Datasubjecttype;
                DataType = reason.Datatype;
                Reason = reason.Reason;
            }
        }
    }
}