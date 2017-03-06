/* 
 * Regulator API
 *
 * API specification for OPERANDO's Regulator API
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace eu.operando.interfaces.rapi.Model
{
    /// <summary>
    /// A privacy rule that reflects a given privacy legislation as described by a particular set of laws in a given jurisdiction. 
    /// </summary>
    [DataContract]
    public partial class PrivacyRegulation :  IEquatable<PrivacyRegulation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacyRegulation" /> class.
        /// </summary>
        [JsonConstructor]
        protected PrivacyRegulation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacyRegulation" /> class.
        /// </summary>
        /// <param name="RegId">RegId.</param>
        /// <param name="LegislationSector">The identifier of the set of legislation rules this rule belongs to e.g. the UK data protection act.  (required).</param>
        /// <param name="Reason">The purpose for performing an action on data e.g. medical care, marketing, admin.</param>
        /// <param name="PrivateInformationType">The type of private information; e.g. is it information that identifies the user (e.g. id number)? is it location information about the user? Is it about their activities? .</param>
        /// <param name="Action">The action being carried out on the data.</param>
        /// <param name="RequiredConsent">The type of consent that must be followed.</param>
        public PrivacyRegulation(string RegId = default(string), string LegislationSector = default(string), string Reason = default(string), string PrivateInformationType = default(string), string Action = default(string), string RequiredConsent = default(string))
        {
            // to ensure "LegislationSector" is required (not null)
            if (LegislationSector == null)
            {
                throw new InvalidDataException("LegislationSector is a required property for PrivacyRegulation and cannot be null");
            }
            else
            {
                this.LegislationSector = LegislationSector;
            }
            this.RegId = RegId;
            this.Reason = Reason;
            this.PrivateInformationType = PrivateInformationType;
            this.Action = Action;
            this.RequiredConsent = RequiredConsent;
        }
        
        /// <summary>
        /// Gets or Sets RegId
        /// </summary>
        [DataMember(Name="reg_id", EmitDefaultValue=false)]
        public string RegId { get; set; }
        /// <summary>
        /// The identifier of the set of legislation rules this rule belongs to e.g. the UK data protection act. 
        /// </summary>
        /// <value>The identifier of the set of legislation rules this rule belongs to e.g. the UK data protection act. </value>
        [DataMember(Name="legislation_sector", EmitDefaultValue=false)]
        public string LegislationSector { get; set; }
        /// <summary>
        /// The purpose for performing an action on data e.g. medical care, marketing, admin
        /// </summary>
        /// <value>The purpose for performing an action on data e.g. medical care, marketing, admin</value>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public string Reason { get; set; }
        /// <summary>
        /// The type of private information; e.g. is it information that identifies the user (e.g. id number)? is it location information about the user? Is it about their activities? 
        /// </summary>
        /// <value>The type of private information; e.g. is it information that identifies the user (e.g. id number)? is it location information about the user? Is it about their activities? </value>
        [DataMember(Name="private_information_type", EmitDefaultValue=false)]
        public string PrivateInformationType { get; set; }
        /// <summary>
        /// The action being carried out on the data
        /// </summary>
        /// <value>The action being carried out on the data</value>
        [DataMember(Name="action", EmitDefaultValue=false)]
        public string Action { get; set; }
        /// <summary>
        /// The type of consent that must be followed
        /// </summary>
        /// <value>The type of consent that must be followed</value>
        [DataMember(Name="required_consent", EmitDefaultValue=false)]
        public string RequiredConsent { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PrivacyRegulation {\n");
            sb.Append("  RegId: ").Append(RegId).Append("\n");
            sb.Append("  LegislationSector: ").Append(LegislationSector).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  PrivateInformationType: ").Append(PrivateInformationType).Append("\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  RequiredConsent: ").Append(RequiredConsent).Append("\n");
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
            return this.Equals(obj as PrivacyRegulation);
        }

        /// <summary>
        /// Returns true if PrivacyRegulation instances are equal
        /// </summary>
        /// <param name="other">Instance of PrivacyRegulation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PrivacyRegulation other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.RegId == other.RegId ||
                    this.RegId != null &&
                    this.RegId.Equals(other.RegId)
                ) && 
                (
                    this.LegislationSector == other.LegislationSector ||
                    this.LegislationSector != null &&
                    this.LegislationSector.Equals(other.LegislationSector)
                ) && 
                (
                    this.Reason == other.Reason ||
                    this.Reason != null &&
                    this.Reason.Equals(other.Reason)
                ) && 
                (
                    this.PrivateInformationType == other.PrivateInformationType ||
                    this.PrivateInformationType != null &&
                    this.PrivateInformationType.Equals(other.PrivateInformationType)
                ) && 
                (
                    this.Action == other.Action ||
                    this.Action != null &&
                    this.Action.Equals(other.Action)
                ) && 
                (
                    this.RequiredConsent == other.RequiredConsent ||
                    this.RequiredConsent != null &&
                    this.RequiredConsent.Equals(other.RequiredConsent)
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
                if (this.RegId != null)
                    hash = hash * 59 + this.RegId.GetHashCode();
                if (this.LegislationSector != null)
                    hash = hash * 59 + this.LegislationSector.GetHashCode();
                if (this.Reason != null)
                    hash = hash * 59 + this.Reason.GetHashCode();
                if (this.PrivateInformationType != null)
                    hash = hash * 59 + this.PrivateInformationType.GetHashCode();
                if (this.Action != null)
                    hash = hash * 59 + this.Action.GetHashCode();
                if (this.RequiredConsent != null)
                    hash = hash * 59 + this.RequiredConsent.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
