using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Operando_AdministrationConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Operando_AdministrationConsole.Helper
{
    public class JsonHelper
    {
        public T DeserializeJsonFollowingOperandoConventions<T>(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new SnakeCaseContractResolver();
            T obj = JsonConvert.DeserializeObject<T>(json, settings);
            return obj;
        }

        private class SnakeCaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                string propertNameWithUnderscores = Regex.Replace(propertyName, "([a-z0-9])([A-Z])", "$1_$2");
                string propertNameWithUnderscoresLowerCase = propertNameWithUnderscores.ToLowerInvariant();
                string resolvedName = propertNameWithUnderscoresLowerCase;

                return resolvedName;
            }
        }
    }
}