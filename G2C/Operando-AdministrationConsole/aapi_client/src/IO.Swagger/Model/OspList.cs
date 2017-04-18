using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eu.operando.interfaces.aapi.Model
{
    [DataContract]
    public partial class OspList : IEquatable<OspList>
    {
        public OspList(Object ospList = null)
        {
            this.osps = (List<string>)ospList;
        }
        [DataMember(Name = "osps", EmitDefaultValue = false)]
        public List<string> osps { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OspList {\n");
            foreach(string str in osps)
            {
                sb.Append("   ").Append(str).Append("\n");
            }
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
            return this.Equals(obj as OspList);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="other">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OspList other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return (osps.Count == other.osps.Count);                
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
                foreach(string str in osps)
                {
                    hash = hash * 59 + str.GetHashCode();
                }
                return hash;
            }
        }
    }
}
