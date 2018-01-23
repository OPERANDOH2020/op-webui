using eu.operando.core.pdb.cli.Model;
using Operando_AdministrationConsole.Helper;

namespace Operando_AdministrationConsole.Models
{
    public class AccessPolicyModel
    {
        // Properties
        public AccessPolicy.ActionEnum? RawAction { get; set; }
        public bool Permission { get; set; }
        public string RawResource { get; set; }
        public string RawSubject { get; set; }
        public string Id { get; set; }
        public string OspPolicyId { get; set; }

        // "Nice" Properties
        public string Resource { get; set; }
        public string Action { get; set; }
        public string Subject { get; set; }

        // Attributes
        public string Category { get; set; }
        public string Tooltip { get; set; }
        public string TooltipReason { get; set; }
        public bool Fixed { get; set; }

        // Settable Properties
        public string Reason { get; set; }

        public AccessPolicyModel()
        {
        }
        public AccessPolicyModel(AccessPolicy accessPolicy, INiceStringConverter stringConverter)
        {
            RawAction = accessPolicy.Action;
            Permission = accessPolicy.Permission ?? false;
            RawResource = accessPolicy.Resource;
            RawSubject = accessPolicy.Subject;

            Resource = stringConverter.NiceResourceNameOrDefault(RawResource);
            Action = stringConverter.NiceActionNameOrDefault(RawAction.ToString());
            Subject = stringConverter.NiceAccessorNameOrDefault(RawSubject);

            Id = (RawSubject + RawResource + RawAction).GetHashCode().ToString();

            Category = "";
            Tooltip = "";

            foreach (PolicyAttribute attribute in accessPolicy.Attributes)
            {
                switch (attribute.AttributeName)
                {
                    case "category":
                    case "Category":
                        Category = attribute.AttributeValue;
                        break;
                    case "tooltip":
                        Tooltip = attribute.AttributeValue;
                        break;
                    case "fixed":
                        bool result;
                        bool success = bool.TryParse(attribute.AttributeValue, out result);
                        Fixed = success ? result : false;
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
}