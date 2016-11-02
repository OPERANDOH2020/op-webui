/* 
 * Policy DB
 *
 * The Policy Database that stores three types of documents in dedicated collections.   1) User Privacy Policy. Each OPERANDO user has one UPP document describing their privacy policies for each of the OSP services they are subscribed to. The UPP contains the current B2C privacy settings for a subscribed to OSP. The UPP contains the users privacy preferences. The UPP contains the G2C access policies for the OSP with justification for access.   2) The legislation policies. The regulations entered into OPERANDO using the OPERANDO regulation API.   3) The OSP descriptions and data requests. For each OSP its privacy policy, its access control rules, and the data it requests (as a workflow). For B2C, the set of privacy settings is stored. 
 *
 * OpenAPI spec version: 1.0.0
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

namespace eu.operando.core.pdb.cli.Model
{
    /// <summary>
    /// OSPConsents
    /// </summary>
    [DataContract]
    public partial class OSPConsents :  IEquatable<OSPConsents>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OSPConsents" /> class.
        /// </summary>
        /// <param name="OspId">The unique ID of the OSP user is subscribed to and these consent policies concern.  .</param>
        /// <param name="AccessPolicies">OSP access policies.</param>
        public OSPConsents(string OspId = null, List<AccessPolicy> AccessPolicies = null)
        {
            this.OspId = OspId;
            this.AccessPolicies = AccessPolicies;
        }
        
        /// <summary>
        /// The unique ID of the OSP user is subscribed to and these consent policies concern.  
        /// </summary>
        /// <value>The unique ID of the OSP user is subscribed to and these consent policies concern.  </value>
        [DataMember(Name="osp_id", EmitDefaultValue=false)]
        public string OspId { get; set; }
        /// <summary>
        /// OSP access policies
        /// </summary>
        /// <value>OSP access policies</value>
        [DataMember(Name="access_policies", EmitDefaultValue=false)]
        public List<AccessPolicy> AccessPolicies { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OSPConsents {\n");
            sb.Append("  OspId: ").Append(OspId).Append("\n");
            sb.Append("  AccessPolicies: ").Append(AccessPolicies).Append("\n");
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
            return this.Equals(obj as OSPConsents);
        }

        /// <summary>
        /// Returns true if OSPConsents instances are equal
        /// </summary>
        /// <param name="other">Instance of OSPConsents to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OSPConsents other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.OspId == other.OspId ||
                    this.OspId != null &&
                    this.OspId.Equals(other.OspId)
                ) && 
                (
                    this.AccessPolicies == other.AccessPolicies ||
                    this.AccessPolicies != null &&
                    this.AccessPolicies.SequenceEqual(other.AccessPolicies)
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
                if (this.OspId != null)
                    hash = hash * 59 + this.OspId.GetHashCode();
                if (this.AccessPolicies != null)
                    hash = hash * 59 + this.AccessPolicies.GetHashCode();
                return hash;
            }
        }
    }

}