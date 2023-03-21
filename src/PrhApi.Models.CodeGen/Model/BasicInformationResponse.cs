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
    /// BasicInformationResponse
    /// </summary>
    [DataContract(Name = "BasicInformationResponse")]
    public partial class BasicInformationResponse : IEquatable<BasicInformationResponse>, IValidatableObject
    {

        /// <summary>
        /// Status of the legal entity
        /// </summary>
        /// <value>Status of the legal entity</value>
        [DataMember(Name = "legalStatus", IsRequired = true, EmitDefaultValue = true)]
        public string LegalStatus { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicInformationResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public BasicInformationResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicInformationResponse" /> class.
        /// </summary>
        /// <param name="name">The name of the legal entity (required).</param>
        /// <param name="legalForm">The [Nordic Legal Form code](https://koodistot.suomi.fi/codescheme;registryCode&#x3D;verotus;schemeCode&#x3D;LegalForm2) for the company. (required).</param>
        /// <param name="legalStatus">Status of the legal entity (required).</param>
        /// <param name="registrationDate">Official registration date of the legal entity in the national trade registry (required).</param>
        /// <param name="registeredAddress">registeredAddress (required).</param>
        public BasicInformationResponse(string name = default(string), string legalForm = default(string), string legalStatus = default(string), string registrationDate = default(string), RegisteredAddress registeredAddress = default(RegisteredAddress))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for BasicInformationResponse and cannot be null");
            }
            this.Name = name;
            // to ensure "legalForm" is required (not null)
            if (legalForm == null)
            {
                throw new ArgumentNullException("legalForm is a required property for BasicInformationResponse and cannot be null");
            }
            this.LegalForm = legalForm;
            this.LegalStatus = legalStatus;
            this.RegistrationDate = registrationDate;
            // to ensure "registeredAddress" is required (not null)
            if (registeredAddress == null)
            {
                throw new ArgumentNullException("registeredAddress is a required property for BasicInformationResponse and cannot be null");
            }
            this.RegisteredAddress = registeredAddress;
        }

        /// <summary>
        /// The name of the legal entity
        /// </summary>
        /// <value>The name of the legal entity</value>
        /// <example>&quot;Oy Example Ab&quot;</example>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The [Nordic Legal Form code](https://koodistot.suomi.fi/codescheme;registryCode&#x3D;verotus;schemeCode&#x3D;LegalForm2) for the company.
        /// </summary>
        /// <value>The [Nordic Legal Form code](https://koodistot.suomi.fi/codescheme;registryCode&#x3D;verotus;schemeCode&#x3D;LegalForm2) for the company.</value>
        [DataMember(Name = "legalForm", IsRequired = true, EmitDefaultValue = true)]
        public string LegalForm { get; set; }

        /// <summary>
        /// Official registration date of the legal entity in the national trade registry
        /// </summary>
        /// <value>Official registration date of the legal entity in the national trade registry</value>
        [DataMember(Name = "registrationDate", IsRequired = true, EmitDefaultValue = true)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public string RegistrationDate { get; set; }

        /// <summary>
        /// Gets or Sets RegisteredAddress
        /// </summary>
        [DataMember(Name = "registeredAddress", IsRequired = true, EmitDefaultValue = true)]
        public RegisteredAddress RegisteredAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BasicInformationResponse {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  LegalForm: ").Append(LegalForm).Append("\n");
            sb.Append("  LegalStatus: ").Append(LegalStatus).Append("\n");
            sb.Append("  RegistrationDate: ").Append(RegistrationDate).Append("\n");
            sb.Append("  RegisteredAddress: ").Append(RegisteredAddress).Append("\n");
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
            return this.Equals(input as BasicInformationResponse);
        }

        /// <summary>
        /// Returns true if BasicInformationResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of BasicInformationResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BasicInformationResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.LegalForm == input.LegalForm ||
                    (this.LegalForm != null &&
                    this.LegalForm.Equals(input.LegalForm))
                ) && 
                (
                    this.LegalStatus == input.LegalStatus ||
                    this.LegalStatus.Equals(input.LegalStatus)
                ) && 
                (
                    this.RegistrationDate == input.RegistrationDate ||
                    (this.RegistrationDate != null &&
                    this.RegistrationDate.Equals(input.RegistrationDate))
                ) && 
                (
                    this.RegisteredAddress == input.RegisteredAddress ||
                    (this.RegisteredAddress != null &&
                    this.RegisteredAddress.Equals(input.RegisteredAddress))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.LegalForm != null)
                {
                    hashCode = (hashCode * 59) + this.LegalForm.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.LegalStatus.GetHashCode();
                if (this.RegistrationDate != null)
                {
                    hashCode = (hashCode * 59) + this.RegistrationDate.GetHashCode();
                }
                if (this.RegisteredAddress != null)
                {
                    hashCode = (hashCode * 59) + this.RegisteredAddress.GetHashCode();
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
