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
    /// CompanyDetails
    /// </summary>
    [DataContract(Name = "CompanyDetails")]
    public partial class CompanyDetails : IEquatable<CompanyDetails>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CompanyDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyDetails" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="alternativeName">alternativeName.</param>
        /// <param name="foundingDate">foundingDate (required).</param>
        /// <param name="industrySector">industrySector (required).</param>
        /// <param name="shareCapital">shareCapital (required).</param>
        /// <param name="capitalCurrency">capitalCurrency (required).</param>
        /// <param name="settlementDeposit">settlementDeposit.</param>
        /// <param name="depositCurrency">depositCurrency.</param>
        /// <param name="settlementDate">settlementDate.</param>
        /// <param name="countryOfResidence">countryOfResidence.</param>
        public CompanyDetails(string name = default(string), string alternativeName = default(string), string foundingDate = default(string), string industrySector = default(string), decimal shareCapital = default(decimal), string capitalCurrency = default(string), decimal settlementDeposit = default(decimal), string depositCurrency = default(string), string settlementDate = default(string), string countryOfResidence = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for CompanyDetails and cannot be null");
            }
            this.Name = name;
            // to ensure "foundingDate" is required (not null)
            if (foundingDate == null)
            {
                throw new ArgumentNullException("foundingDate is a required property for CompanyDetails and cannot be null");
            }
            this.FoundingDate = foundingDate;
            // to ensure "industrySector" is required (not null)
            if (industrySector == null)
            {
                throw new ArgumentNullException("industrySector is a required property for CompanyDetails and cannot be null");
            }
            this.IndustrySector = industrySector;
            this.ShareCapital = shareCapital;
            // to ensure "capitalCurrency" is required (not null)
            if (capitalCurrency == null)
            {
                throw new ArgumentNullException("capitalCurrency is a required property for CompanyDetails and cannot be null");
            }
            this.CapitalCurrency = capitalCurrency;
            this.AlternativeName = alternativeName;
            this.SettlementDeposit = settlementDeposit;
            this.DepositCurrency = depositCurrency;
            this.SettlementDate = settlementDate;
            this.CountryOfResidence = countryOfResidence;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets AlternativeName
        /// </summary>
        [DataMember(Name = "alternativeName", EmitDefaultValue = false)]
        public string AlternativeName { get; set; }

        /// <summary>
        /// Gets or Sets FoundingDate
        /// </summary>
        [DataMember(Name = "foundingDate", IsRequired = true, EmitDefaultValue = true)]
        public string FoundingDate { get; set; }

        /// <summary>
        /// Gets or Sets IndustrySector
        /// </summary>
        [DataMember(Name = "industrySector", IsRequired = true, EmitDefaultValue = true)]
        public string IndustrySector { get; set; }

        /// <summary>
        /// Gets or Sets ShareCapital
        /// </summary>
        [DataMember(Name = "shareCapital", IsRequired = true, EmitDefaultValue = true)]
        public decimal ShareCapital { get; set; }

        /// <summary>
        /// Gets or Sets CapitalCurrency
        /// </summary>
        [DataMember(Name = "capitalCurrency", IsRequired = true, EmitDefaultValue = true)]
        public string CapitalCurrency { get; set; }

        /// <summary>
        /// Gets or Sets SettlementDeposit
        /// </summary>
        [DataMember(Name = "settlementDeposit", EmitDefaultValue = false)]
        public decimal SettlementDeposit { get; set; }

        /// <summary>
        /// Gets or Sets DepositCurrency
        /// </summary>
        [DataMember(Name = "depositCurrency", EmitDefaultValue = false)]
        public string DepositCurrency { get; set; }

        /// <summary>
        /// Gets or Sets SettlementDate
        /// </summary>
        [DataMember(Name = "settlementDate", EmitDefaultValue = true)]
        public string SettlementDate { get; set; }

        /// <summary>
        /// Gets or Sets CountryOfResidence
        /// </summary>
        [DataMember(Name = "countryOfResidence", EmitDefaultValue = false)]
        public string CountryOfResidence { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CompanyDetails {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  AlternativeName: ").Append(AlternativeName).Append("\n");
            sb.Append("  FoundingDate: ").Append(FoundingDate).Append("\n");
            sb.Append("  IndustrySector: ").Append(IndustrySector).Append("\n");
            sb.Append("  ShareCapital: ").Append(ShareCapital).Append("\n");
            sb.Append("  CapitalCurrency: ").Append(CapitalCurrency).Append("\n");
            sb.Append("  SettlementDeposit: ").Append(SettlementDeposit).Append("\n");
            sb.Append("  DepositCurrency: ").Append(DepositCurrency).Append("\n");
            sb.Append("  SettlementDate: ").Append(SettlementDate).Append("\n");
            sb.Append("  CountryOfResidence: ").Append(CountryOfResidence).Append("\n");
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
            return this.Equals(input as CompanyDetails);
        }

        /// <summary>
        /// Returns true if CompanyDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of CompanyDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CompanyDetails input)
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
                    this.AlternativeName == input.AlternativeName ||
                    (this.AlternativeName != null &&
                    this.AlternativeName.Equals(input.AlternativeName))
                ) && 
                (
                    this.FoundingDate == input.FoundingDate ||
                    (this.FoundingDate != null &&
                    this.FoundingDate.Equals(input.FoundingDate))
                ) && 
                (
                    this.IndustrySector == input.IndustrySector ||
                    (this.IndustrySector != null &&
                    this.IndustrySector.Equals(input.IndustrySector))
                ) && 
                (
                    this.ShareCapital == input.ShareCapital ||
                    this.ShareCapital.Equals(input.ShareCapital)
                ) && 
                (
                    this.CapitalCurrency == input.CapitalCurrency ||
                    (this.CapitalCurrency != null &&
                    this.CapitalCurrency.Equals(input.CapitalCurrency))
                ) && 
                (
                    this.SettlementDeposit == input.SettlementDeposit ||
                    this.SettlementDeposit.Equals(input.SettlementDeposit)
                ) && 
                (
                    this.DepositCurrency == input.DepositCurrency ||
                    (this.DepositCurrency != null &&
                    this.DepositCurrency.Equals(input.DepositCurrency))
                ) && 
                (
                    this.SettlementDate == input.SettlementDate ||
                    (this.SettlementDate != null &&
                    this.SettlementDate.Equals(input.SettlementDate))
                ) && 
                (
                    this.CountryOfResidence == input.CountryOfResidence ||
                    (this.CountryOfResidence != null &&
                    this.CountryOfResidence.Equals(input.CountryOfResidence))
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
                if (this.AlternativeName != null)
                {
                    hashCode = (hashCode * 59) + this.AlternativeName.GetHashCode();
                }
                if (this.FoundingDate != null)
                {
                    hashCode = (hashCode * 59) + this.FoundingDate.GetHashCode();
                }
                if (this.IndustrySector != null)
                {
                    hashCode = (hashCode * 59) + this.IndustrySector.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ShareCapital.GetHashCode();
                if (this.CapitalCurrency != null)
                {
                    hashCode = (hashCode * 59) + this.CapitalCurrency.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SettlementDeposit.GetHashCode();
                if (this.DepositCurrency != null)
                {
                    hashCode = (hashCode * 59) + this.DepositCurrency.GetHashCode();
                }
                if (this.SettlementDate != null)
                {
                    hashCode = (hashCode * 59) + this.SettlementDate.GetHashCode();
                }
                if (this.CountryOfResidence != null)
                {
                    hashCode = (hashCode * 59) + this.CountryOfResidence.GetHashCode();
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
            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 250)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 250.", new [] { "Name" });
            }

            // AlternativeName (string) maxLength
            if (this.AlternativeName != null && this.AlternativeName.Length > 250)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AlternativeName, length must be less than 250.", new [] { "AlternativeName" });
            }

            // CountryOfResidence (string) maxLength
            if (this.CountryOfResidence != null && this.CountryOfResidence.Length > 3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CountryOfResidence, length must be less than 3.", new [] { "CountryOfResidence" });
            }

            // CountryOfResidence (string) minLength
            if (this.CountryOfResidence != null && this.CountryOfResidence.Length < 3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CountryOfResidence, length must be greater than 3.", new [] { "CountryOfResidence" });
            }

            yield break;
        }
    }

}
