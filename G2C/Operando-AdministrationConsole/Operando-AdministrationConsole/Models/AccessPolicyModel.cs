using eu.operando.core.pdb.cli.Model;
using Operando_AdministrationConsole.Helper;

namespace Operando_AdministrationConsole.Models
{
    public class AccessPolicyModel
    {
        public AccessPolicy.ActionEnum? Action { get; set; }
        public bool? Permission { get; set; }
        public string RawResource { get; set; }
        public string Subject { get; set; }

        public string Resource { get; set; }

        public string Category { get; set; }
        public string Tooltip { get; set; }
        public bool Fixed { get; set; }

        public AccessPolicyModel(AccessPolicy accessPolicy, INiceStringConverter stringConverter)
        {
            Action = accessPolicy.Action;
            Permission = accessPolicy.Permission;
            RawResource = accessPolicy.Resource;
            Subject = accessPolicy.Subject;

            Resource = RawResource; // TODO stringConverter.NiceResourceNameOrDefault(RawResource);

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