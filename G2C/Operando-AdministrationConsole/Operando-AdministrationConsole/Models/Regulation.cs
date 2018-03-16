using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Operando_AdministrationConsole.Models
{
    public class Regulation
    {
        public string RegId { get; set; }
        public string LegislationSector { get; set; }
        public string Reason { get; set; }
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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequiredConsentEnum
    {
        [EnumMember(Value = "opt-in")]
        In,
        [EnumMember(Value = "opt-out")]
        Out
    }
}