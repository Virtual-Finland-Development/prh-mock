/*
 * PRH mock API
 *
 * API definition for PRH mock API
 *
 * The version of the OpenAPI document: 1.0
 * Contact: lassi.patanen@gofore.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = PrhApi.Models.CodeGen.Client.OpenAPIDateConverter;

namespace PrhApi.Models.CodeGen.Model
{
    /// <summary>
    /// MinimalCompanyDetails
    /// </summary>
    [DataContract(Name = "MinimalCompanyDetails")]
    public partial class MinimalCompanyDetails : IEquatable<MinimalCompanyDetails>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinimalCompanyDetails" /> class.
        /// </summary>
        /// <param name="businessId">businessId.</param>
        /// <param name="key">key.</param>
        public MinimalCompanyDetails(string businessId = default(string), string key = default(string))
        {
            this.BusinessId = businessId;
            this.Key = key;
        }

        /// <summary>
        /// Gets or Sets BusinessId
        /// </summary>
        [DataMember(Name = "businessId", EmitDefaultValue = false)]
        public string BusinessId { get; set; }

        /// <summary>
        /// Gets or Sets Key
        /// </summary>
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MinimalCompanyDetails {\n");
            sb.Append("  BusinessId: ").Append(BusinessId).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as MinimalCompanyDetails);
        }

        /// <summary>
        /// Returns true if MinimalCompanyDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of MinimalCompanyDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MinimalCompanyDetails input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.BusinessId == input.BusinessId ||
                    (this.BusinessId != null &&
                    this.BusinessId.Equals(input.BusinessId))
                ) && 
                (
                    this.Key == input.Key ||
                    (this.Key != null &&
                    this.Key.Equals(input.Key))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.BusinessId != null)
                {
                    hashCode = (hashCode * 59) + this.BusinessId.GetHashCode();
                }
                if (this.Key != null)
                {
                    hashCode = (hashCode * 59) + this.Key.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
