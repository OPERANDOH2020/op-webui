/* 
 * eu.operando.interfaces.aapi
 *
 * Operandos AS interfaces
 *
 * OpenAPI spec version: 0.0.1
 * Contact: kpatsak@gmail.com
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

namespace eu.operando.interfaces.aapi.Model
{
    /// <summary>
    /// SettingAttribute
    /// </summary>
    [DataContract]
    public partial class PrivacySetting :  IEquatable<PrivacySetting>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacySetting" /> class.
        /// </summary>
        /// <param name="SettingName">AttrName.</param>
        /// <param name="SettingValue">AttrValue.</param>
        public PrivacySetting(string SettingName = null, string SettingValue = null)
        {
            this.SettingName = SettingName;
            this.SettingValue = SettingValue;
        }

        /// <summary>
        /// Gets or Sets SettingName
        /// </summary>
        //[DataMember(Name="setting_name", EmitDefaultValue=false)]
        [DataMember(Name = "settingName", EmitDefaultValue = false)]
        public string SettingName { get; set; }
        /// <summary>
        /// Gets or Sets SettingValue
        /// </summary>
        //[DataMember(Name="setting_value", EmitDefaultValue=false)]
        [DataMember(Name = "settingValue", EmitDefaultValue = false)]
        public string SettingValue { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PrivacySetting {\n");
            sb.Append("  SettingName: ").Append(SettingName).Append("\n");
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
        /// Returns true if Attribute instances are equal
        /// </summary>
        /// <param name="other">Instance of Attribute to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PrivacySetting other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.SettingName == other.SettingName ||
                    this.SettingName != null &&
                    this.SettingName.Equals(other.SettingName)
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
                if (this.SettingName != null)
                    hash = hash * 59 + this.SettingName.GetHashCode();
                if (this.SettingValue != null)
                    hash = hash * 59 + this.SettingValue.GetHashCode();
                return hash;
            }
        }
    }

}
