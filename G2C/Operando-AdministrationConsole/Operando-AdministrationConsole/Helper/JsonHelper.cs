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
        private JsonSerializerSettings OperandoConventionSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new SnakeCaseContractResolver();
            
            // Enum values can be represented using an int "value" 
            // or as a string with the value name. Either way there needs
            // to be consistency between the Java and C# equivalent classes,
            // either in the numeric values&ordering or in the value names.
            //
            // The convention of representing using the Java name was chosen,
            // therefore each .AN_ENUM_VALUE must be present as 
            // .AnEnumValue in the C# equivalent enumeration.
            settings.Converters.Add(new EnumConverter());

            return settings;
        }

        public T DeserializeJsonFollowingOperandoConventions<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, OperandoConventionSettings());
        }

        public string SerializeJsonFollowingOperandoConventions(object obj)
        {
            return JsonConvert.SerializeObject(obj, OperandoConventionSettings());
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

        /// <summary>
        /// Represents enumeration values using their Java name,
        /// e.g. AnEnumValue <-> AN_ENUM_VALUE
        /// </summary>
        private class EnumConverter : JsonConverter
        {
            // Based on Json.NET StringEnumConverter

            public override bool CanConvert(Type objectType)
            {
                if (objectType == null)
                {
                    return false;
                }
                else
                {
                    if(objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        objectType = Nullable.GetUnderlyingType(objectType);
                    }

                    return objectType.IsEnum;
                }
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if(reader.TokenType == JsonToken.Null)
                {
                    return null;
                }

                if(reader.TokenType == JsonToken.String)
                {
                    string enumText = reader.Value.ToString();

                    enumText = enumText.Replace("_", "");

                    return Enum.Parse(objectType, enumText, true);
                }

                if(reader.TokenType == JsonToken.Integer)
                {
                    object value = reader.Value;
                    if(objectType == value.GetType())
                    {
                        return value;
                    }

                    return Enum.ToObject(objectType, value);
                }

                return null;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if(value == null)
                {
                    writer.WriteNull();
                    return;
                }

                Enum e = value as Enum;

                string enumName = e.ToString("G");

                enumName = Regex.Replace(enumName, "([a-z0-9])([A-Z])", "$1_$2").ToUpperInvariant();

                writer.WriteValue(enumName);
            }
        }

    }
}