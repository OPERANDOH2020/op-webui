using System.Collections.Generic;

namespace Operando_AdministrationConsole.Helper
{
    public class ResourceCachingNiceStringConverter : INiceStringConverter
    {
        private readonly ResourceFriendlyNameCache _resourceCache;

        private static readonly IDictionary<string, string> Accessors = new Dictionary<string, string>
        {
            {"WebsiteAdmins", "WebsiteAdmin"},
            {"ASL Bergamo - IL - Inspector", "Inspector"},
            {"ASL Bergamo - IL - Accountant", "Accountant"},
            {"Gaslini - Tutor", "Tutor"},
            {"Gaslini - Doctor", "Doctor"},
            {"VolunteerOrganisationAdmin", "Volunteer Organisation Admin"}
        };

        private static readonly IDictionary<string, string> Resources = new Dictionary<string, string>
        {

        };

        private static readonly IDictionary<string, string> Actions = new Dictionary<string, string>()
        {

        };

        public ResourceCachingNiceStringConverter(ResourceFriendlyNameCache resourceCache)
        {
            _resourceCache = resourceCache;
        }

        public string NiceAccessorNameOrDefault(string accessor)
        {
            return Accessors.ContainsKey(accessor) ? Accessors[accessor] : accessor;
        }

        public string NiceResourceNameOrDefault(string resource)
        {
            var cached = _resourceCache.Get(resource);
            return cached ?? (Resources.ContainsKey(resource) ? Resources[resource] : resource);
        }

        public string NiceActionNameOrDefault(string action)
        {
            return Actions.ContainsKey(action) ? Actions[action] : action;
        }
    }
}