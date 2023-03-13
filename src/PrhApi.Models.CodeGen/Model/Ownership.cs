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
    /// Ownership
    /// </summary>
    [DataContract(Name = "Ownership")]
    public partial class Ownership : IEquatable<Ownership>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ownership" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Ownership() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Ownership" /> class.
        /// </summary>
        /// <param name="shareSeriesClass">shareSeriesClass (required).</param>
        /// <param name="quantity">quantity (required).</param>
        public Ownership(string shareSeriesClass = default(string), int quantity = default(int))
        {
            // to ensure "shareSeriesClass" is required (not null)
            if (shareSeriesClass == null)
            {
                throw new ArgumentNullException("shareSeriesClass is a required property for Ownership and cannot be null");
            }
            this.ShareSeriesClass = shareSeriesClass;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Gets or Sets ShareSeriesClass
        /// </summary>
        [DataMember(Name = "shareSeriesClass", IsRequired = true, EmitDefaultValue = true)]
        public string ShareSeriesClass { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = true)]
        public int Quantity { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Ownership {\n");
            sb.Append("  ShareSeriesClass: ").Append(ShareSeriesClass).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
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
            return this.Equals(input as Ownership);
        }

        /// <summary>
        /// Returns true if Ownership instances are equal
        /// </summary>
        /// <param name="input">Instance of Ownership to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Ownership input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ShareSeriesClass == input.ShareSeriesClass ||
                    (this.ShareSeriesClass != null &&
                    this.ShareSeriesClass.Equals(input.ShareSeriesClass))
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    this.Quantity.Equals(input.Quantity)
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
                if (this.ShareSeriesClass != null)
                {
                    hashCode = (hashCode * 59) + this.ShareSeriesClass.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Quantity.GetHashCode();
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
