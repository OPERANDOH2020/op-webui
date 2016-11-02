/* 
 * OSP Enforcement (OSE)
 *
 *  The OSP enforcement component provides a set of functions that manage the interaction of OSP behaviour with the user's private data. The OSE component is largely in charge of ensuring that an OSP follows both privacy regulations and policies put in place by the user (i.e. in the OPERANDO UPPs). There are a set of events that trigger the usage of this API.  1) When a new G2C OSP registers with OPERANDO via the OPERANDO console. The management console informs the OSE, which then checks that an OSP conforms with existing privacy regulations; if it breaches the regulations, the OSE returns via the management console a report describing the breaches.  2) When a change of OSP privacy policy or of the OSP's privacy settings are detected by the watchdog component. The watchdog component sends a message to a privacy analyst who reviews any changes. The privacy analyst may then inform the OSE of the new OSP information (to be checked for compliance with regulations and users' UPPs.  3) When a privacy legislation is entered (or changed) via the Regulator API. The OSE checks registered OSPs for compliance with the new regulations; where there is a breach the OSP is notified either by e-mail or the console. 
 *
 * OpenAPI spec version: 0.0.8
 * Contact: support@operando.eu
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eu.operando.core.ose.cli.Model
{
    /// <summary>
    /// A privacy rule that reflects a given privacy legislation as described by a particular set of laws in a given jurisdiction. 
    /// </summary>
    [DataContract]
    public partial class PrivacyRegulationInput :  IEquatable<PrivacyRegulationInput>
    {
        /// <summary>
        /// The type of private information; e.g. is it information that identifies the user (e.g. id number)? is it location information about the user? Is it about their activities? 
        /// </summary>
        /// <value>The type of private information; e.g. is it information that identifies the user (e.g. id number)? is it location information about the user? Is it about their activities? </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PrivateInformationTypeEnum
        {
            
            /// <summary>
            /// Enum Identification for "Identification"
            /// </summary>
            [EnumMember(Value = "Identification")]
            Identification,
            
            /// <summary>
            /// Enum SharedIdentification for "Shared Identification"
            /// </summary>
            [EnumMember(Value = "Shared Identification")]
            SharedIdentification,
            
            /// <summary>
            /// Enum Geographic for "Geographic"
            /// </summary>
            [EnumMember(Value = "Geographic")]
            Geographic,
            
            /// <summary>
            /// Enum Temporal for "Temporal"
            /// </summary>
            [EnumMember(Value = "Temporal")]
            Temporal,
            
            /// <summary>
            /// Enum Networkandrelationships for "Network and relationships"
            /// </summary>
            [EnumMember(Value = "Network and relationships")]
            Networkandrelationships,
            
            /// <summary>
            /// Enum Objects for "Objects"
            /// </summary>
            [EnumMember(Value = "Objects")]
            Objects,
            
            /// <summary>
            /// Enum Behavioural for "Behavioural"
            /// </summary>
            [EnumMember(Value = "Behavioural")]
            Behavioural,
            
            /// <summary>
            /// Enum Beliefs for "Beliefs"
            /// </summary>
            [EnumMember(Value = "Beliefs")]
            Beliefs,
            
            /// <summary>
            /// Enum Measurements for "Measurements"
            /// </summary>
            [EnumMember(Value = "Measurements")]
            Measurements
        }

        /// <summary>
        /// The type of consent that must be followed
        /// </summary>
        /// <value>The type of consent that must be followed</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RequiredConsentEnum
        {
            
            /// <summary>
            /// Enum In for "opt-in"
            /// </summary>
            [EnumMember(Value = "opt-in")]
            In,
            
            /// <summary>
            /// Enum Out for "opt-out"
            /// </summary>
            [EnumMember(Value = "opt-out")]
            Out
        }

        /// <summary>
        /// The type of private information; e.g. is it information that identifies the user (e.g. id number)? is it location information about the user? Is it about their activities? 
        /// </summary>
        /// <value>The type of private information; e.g. is it information that identifies the user (e.g. id number)? is it location information about the user? Is it about their activities? </value>
        [DataMember(Name="private_information_type", EmitDefaultValue=false)]
        public PrivateInformationTypeEnum? PrivateInformationType { get; set; }
        /// <summary>
        /// The type of consent that must be followed
        /// </summary>
        /// <value>The type of consent that must be followed</value>
        [DataMember(Name="required_consent", EmitDefaultValue=false)]
        public RequiredConsentEnum? RequiredConsent { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacyRegulationInput" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PrivacyRegulationInput() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacyRegulationInput" /> class.
        /// </summary>
        /// <param name="LegislationSector">The identifier of the set of legislation rules this rule belongs to e.g. the UK data protection act.  (required).</param>
        /// <param name="PrivateInformationSource">The source of the private data.</param>
        /// <param name="PrivateInformationType">The type of private information; e.g. is it information that identifies the user (e.g. id number)? is it location information about the user? Is it about their activities? .</param>
        /// <param name="Action">The action being carried out on the data.</param>
        /// <param name="RequiredConsent">The type of consent that must be followed.</param>
        public PrivacyRegulationInput(string LegislationSector = null, string PrivateInformationSource = null, PrivateInformationTypeEnum? PrivateInformationType = null, string Action = null, RequiredConsentEnum? RequiredConsent = null)
        {
            // to ensure "LegislationSector" is required (not null)
            if (LegislationSector == null)
            {
                throw new InvalidDataException("LegislationSector is a required property for PrivacyRegulationInput and cannot be null");
            }
            else
            {
                this.LegislationSector = LegislationSector;
            }
            this.PrivateInformationSource = PrivateInformationSource;
            this.PrivateInformationType = PrivateInformationType;
            this.Action = Action;
            this.RequiredConsent = RequiredConsent;
        }
        
        /// <summary>
        /// The identifier of the set of legislation rules this rule belongs to e.g. the UK data protection act. 
        /// </summary>
        /// <value>The identifier of the set of legislation rules this rule belongs to e.g. the UK data protection act. </value>
        [DataMember(Name="legislation_sector", EmitDefaultValue=false)]
        public string LegislationSector { get; set; }
        /// <summary>
        /// The source of the private data
        /// </summary>
        /// <value>The source of the private data</value>
        [DataMember(Name="private_information_source", EmitDefaultValue=false)]
        public string PrivateInformationSource { get; set; }
        /// <summary>
        /// The action being carried out on the data
        /// </summary>
        /// <value>The action being carried out on the data</value>
        [DataMember(Name="action", EmitDefaultValue=false)]
        public string Action { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PrivacyRegulationInput {\n");
            sb.Append("  LegislationSector: ").Append(LegislationSector).Append("\n");
            sb.Append("  PrivateInformationSource: ").Append(PrivateInformationSource).Append("\n");
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
            return this.Equals(obj as PrivacyRegulationInput);
        }

        /// <summary>
        /// Returns true if PrivacyRegulationInput instances are equal
        /// </summary>
        /// <param name="other">Instance of PrivacyRegulationInput to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PrivacyRegulationInput other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.LegislationSector == other.LegislationSector ||
                    this.LegislationSector != null &&
                    this.LegislationSector.Equals(other.LegislationSector)
                ) && 
                (
                    this.PrivateInformationSource == other.PrivateInformationSource ||
                    this.PrivateInformationSource != null &&
                    this.PrivateInformationSource.Equals(other.PrivateInformationSource)
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
                if (this.LegislationSector != null)
                    hash = hash * 59 + this.LegislationSector.GetHashCode();
                if (this.PrivateInformationSource != null)
                    hash = hash * 59 + this.PrivateInformationSource.GetHashCode();
                if (this.PrivateInformationType != null)
                    hash = hash * 59 + this.PrivateInformationType.GetHashCode();
                if (this.Action != null)
                    hash = hash * 59 + this.Action.GetHashCode();
                if (this.RequiredConsent != null)
                    hash = hash * 59 + this.RequiredConsent.GetHashCode();
                return hash;
            }
        }
    }

}