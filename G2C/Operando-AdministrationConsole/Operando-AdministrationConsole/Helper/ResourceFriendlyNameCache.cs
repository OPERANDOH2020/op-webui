using System.Collections.Generic;
using System.Linq;
using eu.operando.core.pdb.cli.Model;

namespace Operando_AdministrationConsole.Helper
{
    public class ResourceFriendlyNameCache
    {
        private readonly IDictionary<string, string> _cache;

        public ResourceFriendlyNameCache(IList<AccessPolicy> policies)
        {
            _cache = new Dictionary<string, string>();

            foreach (var policy in policies)
            {
                var friendlyName = policy.Attributes
                    .SingleOrDefault(a => a.AttributeName == "friendly_name")
                    ?.AttributeValue;
                if (friendlyName != null)
                {
                    _cache[policy.Resource] = friendlyName;
                }
            }
        }

        public string Get(string resource)
        {
            return _cache.ContainsKey(resource) ? _cache[resource] : null;
        }
    }
}