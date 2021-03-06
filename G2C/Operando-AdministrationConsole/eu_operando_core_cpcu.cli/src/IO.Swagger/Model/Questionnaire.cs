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
    /// Questionnaire
    /// </summary>
    [DataContract]
    public partial class Questionnaire :  IEquatable<Questionnaire>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Questionnaire" /> class.
        /// </summary>
        /// <param name="Metadata">Metadata.</param>
        /// <param name="Category">Category.</param>
        /// <param name="Type">Type.</param>
        /// <param name="Title">Title.</param>
        /// <param name="ServiceID">ServiceID.</param>
        public Questionnaire(string Metadata = default(string), List<QNCategory> Category = default(List<QNCategory>), string Type = default(string), string Title = default(string), string ServiceID = default(string))
        {
            this.Metadata = Metadata;
            this.Category = Category;
            this.Type = Type;
            this.Title = Title;
            this.ServiceID = ServiceID;
        }
        
        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name="metadata", EmitDefaultValue=false)]
        public string Metadata { get; set; }
        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [DataMember(Name="category", EmitDefaultValue=false)]
        public List<QNCategory> Category { get; set; }
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }
        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }
        /// <summary>
        /// Gets or Sets ServiceID
        /// </summary>
        [DataMember(Name="serviceID", EmitDefaultValue=false)]
        public string ServiceID { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Questionnaire {\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  ServiceID: ").Append(ServiceID).Append("\n");
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
            return this.Equals(obj as Questionnaire);
        }

        /// <summary>
        /// Returns true if Questionnaire instances are equal
        /// </summary>
        /// <param name="other">Instance of Questionnaire to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Questionnaire other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Metadata == other.Metadata ||
                    this.Metadata != null &&
                    this.Metadata.Equals(other.Metadata)
                ) && 
                (
                    this.Category == other.Category ||
                    this.Category != null &&
                    this.Category.SequenceEqual(other.Category)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.Title == other.Title ||
                    this.Title != null &&
                    this.Title.Equals(other.Title)
                ) && 
                (
                    this.ServiceID == other.ServiceID ||
                    this.ServiceID != null &&
                    this.ServiceID.Equals(other.ServiceID)
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
                if (this.Metadata != null)
                    hash = hash * 59 + this.Metadata.GetHashCode();
                if (this.Category != null)
                    hash = hash * 59 + this.Category.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.Title != null)
                    hash = hash * 59 + this.Title.GetHashCode();
                if (this.ServiceID != null)
                    hash = hash * 59 + this.ServiceID.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
