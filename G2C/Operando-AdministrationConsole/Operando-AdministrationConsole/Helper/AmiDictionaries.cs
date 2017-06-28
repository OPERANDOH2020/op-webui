using System.Collections.Generic;

namespace Operando_AdministrationConsole.Helper
{
    public static class AmiDictionaries
    {
        public static readonly Dictionary<string, string> Accessors = new Dictionary<string, string>
        {
            {"volunteer_linkup", "Volunteer Linkup"},
            {"abingdon_good_neighbour_scheme", "Abingdon Good Neighbour Scheme"}
        };

        public static readonly Dictionary<string, string> Resources = new Dictionary<string, string>
        {
            {"odata.metadata", "Odata Metadata"},
            {"ConfidentialNote", "Confidential Note"},
            {"VolunteerUnsuccessfulReason", "Volunteer Unsuccessful Reason"},
            {"VolunteerChecklistItems", "Volunteer Checklist Items"},
            {"FirstName", "First Name"},
            {"LastName", "Last Name"},
            {"RegistrationDate", "Registration Date"}
        };

        public static string NiceAccessorNameOrDefault(string accessor)
        {
            return Accessors.ContainsKey(accessor) ? Accessors[accessor] : accessor;
        }

        public static string NiceResourceNameOrDefault(string resource)
        {
            return Resources.ContainsKey(resource) ? Resources[resource] : resource;
        }
    }
}