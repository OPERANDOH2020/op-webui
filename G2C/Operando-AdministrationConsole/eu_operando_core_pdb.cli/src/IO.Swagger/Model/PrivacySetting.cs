/* 
 * Policy DB
 *
 * The Policy Database that stores three types of documents in dedicated collections.   1) User Privacy Policy. Each OPERANDO user has one UPP document describing their privacy policies for each of the OSP services they are subscribed to. The UPP contains the current B2C privacy settings for a subscribed to OSP. The UPP contains the users privacy preferences. The UPP contains the G2C access policies for the OSP with justification for access.   2) The legislation policies. The regulations entered into OPERANDO using the OPERANDO regulation API.   3) The OSP descriptions and data requests. For each OSP its privacy policy, its access control rules, and the data it requests (as a workflow). For B2C, the set of privacy settings is stored. 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: support@operando.eu
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace eu.operando.core.pdb.cli.Model
{
    /// <summary>
    /// PrivacySetting
    /// </summary>
    [DataContract]
    public partial class PrivacySetting :  IEquatable<PrivacySetting>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacySetting" /> class.
        /// </summary>
        /// <param name="Id">PrivacySetting Unique Identifier.</param>
        /// <param name="Description">Description of the setting.</param>
        /// <param name="Name">Short name of the setting(e.g. visibility).</param>
        /// <param name="SettingKey">Targeted setting key.</param>
        /// <param name="SettingValue">Targeted setting value.</param>
        public PrivacySetting(long? Id = default(long?), string Description = default(string), string Name = default(string), string SettingKey = default(string), string SettingValue = default(string))
        {
            this.Id = Id;
            this.Description = Description;
            this.Name = Name;
            this.SettingKey = SettingKey;
            this.SettingValue = SettingValue;
        }
        
        /// <summary>
        /// PrivacySetting Unique Identifier
        /// </summary>
        /// <value>PrivacySetting Unique Identifier</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public long? Id { get; set; }
        /// <summary>
        /// Description of the setting
        /// </summary>
        /// <value>Description of the setting</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Short name of the setting(e.g. visibility)
        /// </summary>
        /// <value>Short name of the setting(e.g. visibility)</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Targeted setting key
        /// </summary>
        /// <value>Targeted setting key</value>
        [DataMember(Name="setting_key", EmitDefaultValue=false)]
        public string SettingKey { get; set; }
        /// <summary>
        /// Targeted setting value
        /// </summary>
        /// <value>Targeted setting value</value>
        [DataMember(Name="setting_value", EmitDefaultValue=false)]
        public string SettingValue { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PrivacySetting {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SettingKey: ").Append(SettingKey).Append("\n");
            sb.Append("  SettingValue: ").Append(SettingValue).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as PrivacySetting);
        }

        /// <summary>
        /// Returns true if PrivacySetting instances are equal
        /// </summary>
        /// <param name="other">Instance of PrivacySetting to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PrivacySetting other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.SettingKey == other.SettingKey ||
                    this.SettingKey != null &&
                    this.SettingKey.Equals(other.SettingKey)
                ) && 
                (
                    this.SettingValue == other.SettingValue ||
                    this.SettingValue != null &&
                    this.SettingValue.Equals(other.SettingValue)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.SettingKey != null)
                    hash = hash * 59 + this.SettingKey.GetHashCode();
                if (this.SettingValue != null)
                    hash = hash * 59 + this.SettingValue.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
