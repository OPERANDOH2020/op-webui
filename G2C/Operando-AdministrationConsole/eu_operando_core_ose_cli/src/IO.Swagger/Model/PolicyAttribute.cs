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
    /// PolicyAttribute
    /// </summary>
    [DataContract]
    public partial class PolicyAttribute :  IEquatable<PolicyAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyAttribute" /> class.
        /// </summary>
        /// <param name="AttributeName">AttributeName.</param>
        /// <param name="AttributeValue">AttributeValue.</param>
        public PolicyAttribute(string AttributeName = null, string AttributeValue = null)
        {
            this.AttributeName = AttributeName;
            this.AttributeValue = AttributeValue;
        }
        
        /// <summary>
        /// Gets or Sets AttributeName
        /// </summary>
        [DataMember(Name="attribute_name", EmitDefaultValue=false)]
        public string AttributeName { get; set; }
        /// <summary>
        /// Gets or Sets AttributeValue
        /// </summary>
        [DataMember(Name="attribute_value", EmitDefaultValue=false)]
        public string AttributeValue { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PolicyAttribute {\n");
            sb.Append("  AttributeName: ").Append(AttributeName).Append("\n");
            sb.Append("  AttributeValue: ").Append(AttributeValue).Append("\n");
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
            return this.Equals(obj as PolicyAttribute);
        }

        /// <summary>
        /// Returns true if PolicyAttribute instances are equal
        /// </summary>
        /// <param name="other">Instance of PolicyAttribute to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolicyAttribute other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AttributeName == other.AttributeName ||
                    this.AttributeName != null &&
                    this.AttributeName.Equals(other.AttributeName)
                ) && 
                (
                    this.AttributeValue == other.AttributeValue ||
                    this.AttributeValue != null &&
                    this.AttributeValue.Equals(other.AttributeValue)
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
                if (this.AttributeName != null)
                    hash = hash * 59 + this.AttributeName.GetHashCode();
                if (this.AttributeValue != null)
                    hash = hash * 59 + this.AttributeValue.GetHashCode();
                return hash;
            }
        }
    }

}
