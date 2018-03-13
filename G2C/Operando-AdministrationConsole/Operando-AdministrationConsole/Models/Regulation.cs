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

    public enum RequiredConsentEnum
    {
        In,
        Out
    }
}