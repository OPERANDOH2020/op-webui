using eu.operando.core.pdb.cli.Model;
using Operando_AdministrationConsole.Helper;

namespace Operando_AdministrationConsole.Models
{
    public class AccessPolicyModel
    {
        // Properties
        public AccessPolicy.ActionEnum? RawAction { get;}
        public bool Permission { get; }
        public string RawResource { get; }
        public string RawSubject { get; }

        // "Nice" Properties
        public string Resource { get; }
        public string Action { get; }
        public string Subject { get; }

        // Attributes
        public string Category { get; }
        public string Tooltip { get; }
        public bool Fixed { get; }

        // Settable Properties
        public string Reason { get; set; }

        public AccessPolicyModel(AccessPolicy accessPolicy, INiceStringConverter stringConverter)
        {
            RawAction = accessPolicy.Action;
            Permission = accessPolicy.Permission ?? false;
            RawResource = accessPolicy.Resource;
            RawSubject = accessPolicy.Subject;

            Resource = stringConverter.NiceResourceNameOrDefault(RawResource);
            Action = stringConverter.NiceActionNameOrDefault(RawAction.ToString());
            Subject = stringConverter.NiceAccessorNameOrDefault(RawSubject);

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
                    case "friendly_name":
                        Resource = attribute.AttributeValue;
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