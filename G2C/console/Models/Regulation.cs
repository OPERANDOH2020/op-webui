using Operando_AdministrationConsole.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class Regulation
    {
        public string RegId { get; set; }
        public string LegislationSector { get; set; }
        public string PrivateInformationSource { get; set; }
        public PrivateInformationTypeEnum PrivateInformationType { get; set; }
        public string Action { get; set; }
        public RequiredConsentEnum RequiredConsent { get; set; }
    }

    public enum PrivateInformationTypeEnum
    {
        Identification,
        SharedIdentification,
        Geographic,
        Temporal,
        NetworkAndRelationships,
        Objects,
        Behavioural,
        Beliefs,
        Measurements
    }

    public enum RequiredConsentEnum
    {
        In,
        Out
    }
}