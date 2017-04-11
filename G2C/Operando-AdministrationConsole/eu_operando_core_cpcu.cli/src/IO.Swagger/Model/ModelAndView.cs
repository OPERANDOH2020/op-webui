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
    /// ModelAndView
    /// </summary>
    [DataContract]
    public partial class ModelAndView :  IEquatable<ModelAndView>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAndView" /> class.
        /// </summary>
        /// <param name="Empty">Empty.</param>
        /// <param name="Model">Model.</param>
        /// <param name="ModelMap">ModelMap.</param>
        /// <param name="Reference">Reference.</param>
        /// <param name="Status">Status.</param>
        /// <param name="View">View.</param>
        /// <param name="ViewName">ViewName.</param>
        public ModelAndView(bool? Empty = default(bool?), Object Model = default(Object), Dictionary<string, Object> ModelMap = default(Dictionary<string, Object>), bool? Reference = default(bool?), string Status = default(string), View View = default(View), string ViewName = default(string))
        {
            this.Empty = Empty;
            this.Model = Model;
            this.ModelMap = ModelMap;
            this.Reference = Reference;
            this.Status = Status;
            this.View = View;
            this.ViewName = ViewName;
        }
        
        /// <summary>
        /// Gets or Sets Empty
        /// </summary>
        [DataMember(Name="empty", EmitDefaultValue=false)]
        public bool? Empty { get; set; }
        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        [DataMember(Name="model", EmitDefaultValue=false)]
        public Object Model { get; set; }
        /// <summary>
        /// Gets or Sets ModelMap
        /// </summary>
        [DataMember(Name="modelMap", EmitDefaultValue=false)]
        public Dictionary<string, Object> ModelMap { get; set; }
        /// <summary>
        /// Gets or Sets Reference
        /// </summary>
        [DataMember(Name="reference", EmitDefaultValue=false)]
        public bool? Reference { get; set; }
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        /// Gets or Sets View
        /// </summary>
        [DataMember(Name="view", EmitDefaultValue=false)]
        public View View { get; set; }
        /// <summary>
        /// Gets or Sets ViewName
        /// </summary>
        [DataMember(Name="viewName", EmitDefaultValue=false)]
        public string ViewName { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ModelAndView {\n");
            sb.Append("  Empty: ").Append(Empty).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  ModelMap: ").Append(ModelMap).Append("\n");
            sb.Append("  Reference: ").Append(Reference).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  View: ").Append(View).Append("\n");
            sb.Append("  ViewName: ").Append(ViewName).Append("\n");
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
            return this.Equals(obj as ModelAndView);
        }

        /// <summary>
        /// Returns true if ModelAndView instances are equal
        /// </summary>
        /// <param name="other">Instance of ModelAndView to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModelAndView other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Empty == other.Empty ||
                    this.Empty != null &&
                    this.Empty.Equals(other.Empty)
                ) && 
                (
                    this.Model == other.Model ||
                    this.Model != null &&
                    this.Model.Equals(other.Model)
                ) && 
                (
                    this.ModelMap == other.ModelMap ||
                    this.ModelMap != null &&
                    this.ModelMap.SequenceEqual(other.ModelMap)
                ) && 
                (
                    this.Reference == other.Reference ||
                    this.Reference != null &&
                    this.Reference.Equals(other.Reference)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.View == other.View ||
                    this.View != null &&
                    this.View.Equals(other.View)
                ) && 
                (
                    this.ViewName == other.ViewName ||
                    this.ViewName != null &&
                    this.ViewName.Equals(other.ViewName)
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
                if (this.Empty != null)
                    hash = hash * 59 + this.Empty.GetHashCode();
                if (this.Model != null)
                    hash = hash * 59 + this.Model.GetHashCode();
                if (this.ModelMap != null)
                    hash = hash * 59 + this.ModelMap.GetHashCode();
                if (this.Reference != null)
                    hash = hash * 59 + this.Reference.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.View != null)
                    hash = hash * 59 + this.View.GetHashCode();
                if (this.ViewName != null)
                    hash = hash * 59 + this.ViewName.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}