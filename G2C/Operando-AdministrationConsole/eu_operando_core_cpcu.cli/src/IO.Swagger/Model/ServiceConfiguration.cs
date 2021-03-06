/* 
 * REST API for CPCU Operando
 *
 * A REST API to access and edit Questionnaires and Services within the CPCU platform
 *
 * OpenAPI spec version: 2.0
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

namespace eu.operando.core.cpcu.cli.Model
{
    /// <summary>
    /// ServiceConfiguration
    /// </summary>
    [DataContract]
    public partial class ServiceConfiguration :  IEquatable<ServiceConfiguration>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceConfiguration" /> class.
        /// </summary>
        /// <param name="AquisitionMethod">AquisitionMethod.</param>
        /// <param name="DataLocation">DataLocation.</param>
        /// <param name="Id">Id.</param>
        /// <param name="Metadata">Metadata.</param>
        /// <param name="Preference">Preference.</param>
        /// <param name="RoleLocation">RoleLocation.</param>
        public ServiceConfiguration(string AquisitionMethod = default(string), string DataLocation = default(string), int? Id = default(int?), string Metadata = default(string), string Preference = default(string), string RoleLocation = default(string))
        {
            this.AquisitionMethod = AquisitionMethod;
            this.DataLocation = DataLocation;
            this.Id = Id;
            this.Metadata = Metadata;
            this.Preference = Preference;
            this.RoleLocation = RoleLocation;
        }
        
        /// <summary>
        /// Gets or Sets AquisitionMethod
        /// </summary>
        [DataMember(Name="aquisitionMethod", EmitDefaultValue=false)]
        public string AquisitionMethod { get; set; }
        /// <summary>
        /// Gets or Sets DataLocation
        /// </summary>
        [DataMember(Name="dataLocation", EmitDefaultValue=false)]
        public string DataLocation { get; set; }
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }
        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name="metadata", EmitDefaultValue=false)]
        public string Metadata { get; set; }
        /// <summary>
        /// Gets or Sets Preference
        /// </summary>
        [DataMember(Name="preference", EmitDefaultValue=false)]
        public string Preference { get; set; }
        /// <summary>
        /// Gets or Sets RoleLocation
        /// </summary>
        [DataMember(Name="roleLocation", EmitDefaultValue=false)]
        public string RoleLocation { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ServiceConfiguration {\n");
            sb.Append("  AquisitionMethod: ").Append(AquisitionMethod).Append("\n");
            sb.Append("  DataLocation: ").Append(DataLocation).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Preference: ").Append(Preference).Append("\n");
            sb.Append("  RoleLocation: ").Append(RoleLocation).Append("\n");
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
            return this.Equals(obj as ServiceConfiguration);
        }

        /// <summary>
        /// Returns true if ServiceConfiguration instances are equal
        /// </summary>
        /// <param name="other">Instance of ServiceConfiguration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ServiceConfiguration other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AquisitionMethod == other.AquisitionMethod ||
                    this.AquisitionMethod != null &&
                    this.AquisitionMethod.Equals(other.AquisitionMethod)
                ) && 
                (
                    this.DataLocation == other.DataLocation ||
                    this.DataLocation != null &&
                    this.DataLocation.Equals(other.DataLocation)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Metadata == other.Metadata ||
                    this.Metadata != null &&
                    this.Metadata.Equals(other.Metadata)
                ) && 
                (
                    this.Preference == other.Preference ||
                    this.Preference != null &&
                    this.Preference.Equals(other.Preference)
                ) && 
                (
                    this.RoleLocation == other.RoleLocation ||
                    this.RoleLocation != null &&
                    this.RoleLocation.Equals(other.RoleLocation)
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
                if (this.AquisitionMethod != null)
                    hash = hash * 59 + this.AquisitionMethod.GetHashCode();
                if (this.DataLocation != null)
                    hash = hash * 59 + this.DataLocation.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.Metadata != null)
                    hash = hash * 59 + this.Metadata.GetHashCode();
                if (this.Preference != null)
                    hash = hash * 59 + this.Preference.GetHashCode();
                if (this.RoleLocation != null)
                    hash = hash * 59 + this.RoleLocation.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
