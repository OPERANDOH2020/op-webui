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
    /// OSPDataRequest
    /// </summary>
    [DataContract]
    public partial class OSPDataRequest :  IEquatable<OSPDataRequest>, IValidatableObject
    {
        /// <summary>
        /// The action being carried out on the private date e.g. accessing, disclosing to a third party.  
        /// </summary>
        /// <value>The action being carried out on the private date e.g. accessing, disclosing to a third party.  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ActionEnum
        {
            
            /// <summary>
            /// Enum Collect for "Collect"
            /// </summary>
            [EnumMember(Value = "Collect")]
            Collect,
            
            /// <summary>
            /// Enum Access for "Access"
            /// </summary>
            [EnumMember(Value = "Access")]
            Access,
            
            /// <summary>
            /// Enum Use for "Use"
            /// </summary>
            [EnumMember(Value = "Use")]
            Use,
            
            /// <summary>
            /// Enum Disclose for "Disclose"
            /// </summary>
            [EnumMember(Value = "Disclose")]
            Disclose,
            
            /// <summary>
            /// Enum Archive for "Archive"
            /// </summary>
            [EnumMember(Value = "Archive")]
            Archive,

            /// <summary>
            /// Enum Select for "Select"
            /// </summary>
            [EnumMember(Value = "Select")]
            Select,

            /// <summary>
            /// Enum Update for "Update"
            /// </summary>
            [EnumMember(Value = "Update")]
            Update,

            /// <summary>
            /// Enum Insert for "Insert"
            /// </summary>
            [EnumMember(Value = "Insert")]
            Insert,

            /// <summary>
            /// Enum Delete for "Delete"
            /// </summary>
            [EnumMember(Value = "Delete")]
            Delete,

            /// <summary>
            /// Enum Create for "Create"
            /// </summary>
            [EnumMember(Value = "Create")]
            Create
        }

        /// <summary>
        /// The action being carried out on the private date e.g. accessing, disclosing to a third party.  
        /// </summary>
        /// <value>The action being carried out on the private date e.g. accessing, disclosing to a third party.  </value>
        [DataMember(Name="action", EmitDefaultValue=false)]
        public ActionEnum? Action { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OSPDataRequest" /> class.
        /// </summary>
        /// <param name="RequesterId">Id of the requester (typically the id of an OSP)..</param>
        /// <param name="Subject">A description of the subject who the policies grants/doesn&#39;t grant to carry out. .</param>
        /// <param name="RequestedUrl">The Requested URL of the data. .</param>
        /// <param name="Action">The action being carried out on the private date e.g. accessing, disclosing to a third party.  .</param>
        /// <param name="Attributes">The set of context attributes attached to the policy (e.g. subject role, subject purpose) .</param>
        public OSPDataRequest(string RequesterId = default(string), string Subject = default(string), string RequestedUrl = default(string), ActionEnum? Action = default(ActionEnum?), List<PolicyAttribute> Attributes = default(List<PolicyAttribute>))
        {
            this.RequesterId = RequesterId;
            this.Subject = Subject;
            this.RequestedUrl = RequestedUrl;
            this.Action = Action;
            this.Attributes = Attributes;
        }
        
        /// <summary>
        /// Id of the requester (typically the id of an OSP).
        /// </summary>
        /// <value>Id of the requester (typically the id of an OSP).</value>
        [DataMember(Name="requester_id", EmitDefaultValue=false)]
        public string RequesterId { get; set; }
        /// <summary>
        /// A description of the subject who the policies grants/doesn&#39;t grant to carry out. 
        /// </summary>
        /// <value>A description of the subject who the policies grants/doesn&#39;t grant to carry out. </value>
        [DataMember(Name="subject", EmitDefaultValue=false)]
        public string Subject { get; set; }
        /// <summary>
        /// The Requested URL of the data. 
        /// </summary>
        /// <value>The Requested URL of the data. </value>
        [DataMember(Name="requested_url", EmitDefaultValue=false)]
        public string RequestedUrl { get; set; }
        /// <summary>
        /// The set of context attributes attached to the policy (e.g. subject role, subject purpose) 
        /// </summary>
        /// <value>The set of context attributes attached to the policy (e.g. subject role, subject purpose) </value>
        [DataMember(Name="attributes", EmitDefaultValue=false)]
        public List<PolicyAttribute> Attributes { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OSPDataRequest {\n");
            sb.Append("  RequesterId: ").Append(RequesterId).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  RequestedUrl: ").Append(RequestedUrl).Append("\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  Attributes: ").Append(Attributes).Append("\n");
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
            return this.Equals(obj as OSPDataRequest);
        }

        /// <summary>
        /// Returns true if OSPDataRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of OSPDataRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OSPDataRequest other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.RequesterId == other.RequesterId ||
                    this.RequesterId != null &&
                    this.RequesterId.Equals(other.RequesterId)
                ) && 
                (
                    this.Subject == other.Subject ||
                    this.Subject != null &&
                    this.Subject.Equals(other.Subject)
                ) && 
                (
                    this.RequestedUrl == other.RequestedUrl ||
                    this.RequestedUrl != null &&
                    this.RequestedUrl.Equals(other.RequestedUrl)
                ) && 
                (
                    this.Action == other.Action ||
                    this.Action != null &&
                    this.Action.Equals(other.Action)
                ) && 
                (
                    this.Attributes == other.Attributes ||
                    this.Attributes != null &&
                    this.Attributes.SequenceEqual(other.Attributes)
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
                if (this.RequesterId != null)
                    hash = hash * 59 + this.RequesterId.GetHashCode();
                if (this.Subject != null)
                    hash = hash * 59 + this.Subject.GetHashCode();
                if (this.RequestedUrl != null)
                    hash = hash * 59 + this.RequestedUrl.GetHashCode();
                if (this.Action != null)
                    hash = hash * 59 + this.Action.GetHashCode();
                if (this.Attributes != null)
                    hash = hash * 59 + this.Attributes.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
