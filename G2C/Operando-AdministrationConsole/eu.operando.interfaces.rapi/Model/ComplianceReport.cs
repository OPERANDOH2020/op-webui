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
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace eu.operando.interfaces.rapi.Model
{
    /// <summary>
    /// An OSP&#39;s compliance report 
    /// </summary>
    [DataContract]
    public partial class ComplianceReport :  IEquatable<ComplianceReport>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceReport" /> class.
        /// </summary>
        /// <param name="Privacypolicy">Privacypolicy.</param>
        public ComplianceReport(OSPReasonPolicy Privacypolicy = default(OSPReasonPolicy))
        {
            this.Privacypolicy = Privacypolicy;
        }
        
        /// <summary>
        /// Gets or Sets Privacypolicy
        /// </summary>
        [DataMember(Name="privacypolicy", EmitDefaultValue=false)]
        public OSPReasonPolicy Privacypolicy { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ComplianceReport {\n");
            sb.Append("  Privacypolicy: ").Append(Privacypolicy).Append("\n");
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
            return this.Equals(obj as ComplianceReport);
        }

        /// <summary>
        /// Returns true if ComplianceReport instances are equal
        /// </summary>
        /// <param name="other">Instance of ComplianceReport to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ComplianceReport other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Privacypolicy == other.Privacypolicy ||
                    this.Privacypolicy != null &&
                    this.Privacypolicy.Equals(other.Privacypolicy)
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
                if (this.Privacypolicy != null)
                    hash = hash * 59 + this.Privacypolicy.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}