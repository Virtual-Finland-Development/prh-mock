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
    /// RegisteredAddress
    /// </summary>
    [DataContract(Name = "RegisteredAddress")]
    public partial class RegisteredAddress : IEquatable<RegisteredAddress>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredAddress" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected RegisteredAddress() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisteredAddress" /> class.
        /// </summary>
        /// <param name="fullAddress">The complete address written as a string. Use of this property is recommended as it will not suffer any misunderstandings that might arise through the breaking up of an address into its component parts..</param>
        /// <param name="thoroughfare">The name of a passage or way through from one location to another. A thoroughfare is usually a street, but it might be a waterway or some other feature..</param>
        /// <param name="locatorDesignator">A number or sequence of characters that uniquely identifies the locator within the relevant scope. In simpler terms, this is the building number, apartment number, etc..</param>
        /// <param name="locatorName">Proper noun(s) applied to the real world entity identified by the locator. The locator name could be the name of the property or complex, of the building or part of the building, or it could be the name of a room inside a building. The key difference between a locator and a locator name is that the latter is a proper name and is unlikely to include digits..</param>
        /// <param name="addressArea">The name of a geographic area that groups Addresses. This would typically be part of a city, a neighbourhood or village. Address area is not an administrative unit..</param>
        /// <param name="postCode">The code created and maintained for postal purposes to identify a subdivision of addresses and postal delivery points..</param>
        /// <param name="postName">A name created and maintained for postal purposes to identify a subdivision of addresses and postal delivery points. Usually a city..</param>
        /// <param name="poBox">A location designator for a postal delivery point at a post office, usually a number..</param>
        /// <param name="adminUnitLevel1">The name of the uppermost level of the address, almost always a country. ISO 3166 two character (Alpha 2) format (required).</param>
        /// <param name="adminUnitLevel2">The name of a secondary level/region of the address, usually a county, state or other such area that typically encompasses several localities. Values could be a region or province, more granular than level 1..</param>
        /// <param name="addressId">A globally unique identifier for each instance of an Address. The concept of adding a globally unique identifier for each instance of an address is a crucial part of the INSPIRE data spec. A number of EU countries have already implemented an ID (a UUID) in their Address Register, among them Denmark..</param>
        public RegisteredAddress(string fullAddress = default(string), string thoroughfare = default(string), string locatorDesignator = default(string), string locatorName = default(string), string addressArea = default(string), string postCode = default(string), string postName = default(string), string poBox = default(string), string adminUnitLevel1 = default(string), string adminUnitLevel2 = default(string), string addressId = default(string))
        {
            // to ensure "adminUnitLevel1" is required (not null)
            if (adminUnitLevel1 == null)
            {
                throw new ArgumentNullException("adminUnitLevel1 is a required property for RegisteredAddress and cannot be null");
            }
            this.AdminUnitLevel1 = adminUnitLevel1;
            this.FullAddress = fullAddress;
            this.Thoroughfare = thoroughfare;
            this.LocatorDesignator = locatorDesignator;
            this.LocatorName = locatorName;
            this.AddressArea = addressArea;
            this.PostCode = postCode;
            this.PostName = postName;
            this.PoBox = poBox;
            this.AdminUnitLevel2 = adminUnitLevel2;
            this.AddressId = addressId;
        }

        /// <summary>
        /// The complete address written as a string. Use of this property is recommended as it will not suffer any misunderstandings that might arise through the breaking up of an address into its component parts.
        /// </summary>
        /// <value>The complete address written as a string. Use of this property is recommended as it will not suffer any misunderstandings that might arise through the breaking up of an address into its component parts.</value>
        /// <example>&quot;Tietotie 4 A 7, 00100 Helsinki, Finland&quot;</example>
        [DataMember(Name = "fullAddress", EmitDefaultValue = false)]
        public string FullAddress { get; set; }

        /// <summary>
        /// The name of a passage or way through from one location to another. A thoroughfare is usually a street, but it might be a waterway or some other feature.
        /// </summary>
        /// <value>The name of a passage or way through from one location to another. A thoroughfare is usually a street, but it might be a waterway or some other feature.</value>
        /// <example>&quot;Avenue des Champs-Élysées&quot;</example>
        [DataMember(Name = "thoroughfare", EmitDefaultValue = false)]
        public string Thoroughfare { get; set; }

        /// <summary>
        /// A number or sequence of characters that uniquely identifies the locator within the relevant scope. In simpler terms, this is the building number, apartment number, etc.
        /// </summary>
        /// <value>A number or sequence of characters that uniquely identifies the locator within the relevant scope. In simpler terms, this is the building number, apartment number, etc.</value>
        /// <example>&quot;Flat 3, 17 or 3 A 4&quot;</example>
        [DataMember(Name = "locatorDesignator", EmitDefaultValue = false)]
        public string LocatorDesignator { get; set; }

        /// <summary>
        /// Proper noun(s) applied to the real world entity identified by the locator. The locator name could be the name of the property or complex, of the building or part of the building, or it could be the name of a room inside a building. The key difference between a locator and a locator name is that the latter is a proper name and is unlikely to include digits.
        /// </summary>
        /// <value>Proper noun(s) applied to the real world entity identified by the locator. The locator name could be the name of the property or complex, of the building or part of the building, or it could be the name of a room inside a building. The key difference between a locator and a locator name is that the latter is a proper name and is unlikely to include digits.</value>
        /// <example>&quot;Shumann, Berlaymont (meeting room name)&quot;</example>
        [DataMember(Name = "locatorName", EmitDefaultValue = false)]
        public string LocatorName { get; set; }

        /// <summary>
        /// The name of a geographic area that groups Addresses. This would typically be part of a city, a neighbourhood or village. Address area is not an administrative unit.
        /// </summary>
        /// <value>The name of a geographic area that groups Addresses. This would typically be part of a city, a neighbourhood or village. Address area is not an administrative unit.</value>
        /// <example>&quot;Montmartre (in Paris)&quot;</example>
        [DataMember(Name = "addressArea", EmitDefaultValue = false)]
        public string AddressArea { get; set; }

        /// <summary>
        /// The code created and maintained for postal purposes to identify a subdivision of addresses and postal delivery points.
        /// </summary>
        /// <value>The code created and maintained for postal purposes to identify a subdivision of addresses and postal delivery points.</value>
        /// <example>&quot;75000&quot;</example>
        [DataMember(Name = "postCode", EmitDefaultValue = false)]
        public string PostCode { get; set; }

        /// <summary>
        /// A name created and maintained for postal purposes to identify a subdivision of addresses and postal delivery points. Usually a city.
        /// </summary>
        /// <value>A name created and maintained for postal purposes to identify a subdivision of addresses and postal delivery points. Usually a city.</value>
        /// <example>&quot;Paris&quot;</example>
        [DataMember(Name = "postName", EmitDefaultValue = false)]
        public string PostName { get; set; }

        /// <summary>
        /// A location designator for a postal delivery point at a post office, usually a number.
        /// </summary>
        /// <value>A location designator for a postal delivery point at a post office, usually a number.</value>
        /// <example>&quot;9383&quot;</example>
        [DataMember(Name = "poBox", EmitDefaultValue = false)]
        public string PoBox { get; set; }

        /// <summary>
        /// The name of the uppermost level of the address, almost always a country. ISO 3166 two character (Alpha 2) format
        /// </summary>
        /// <value>The name of the uppermost level of the address, almost always a country. ISO 3166 two character (Alpha 2) format</value>
        /// <example>&quot;USA&quot;</example>
        [DataMember(Name = "adminUnitLevel_1", IsRequired = true, EmitDefaultValue = true)]
        public string AdminUnitLevel1 { get; set; }

        /// <summary>
        /// The name of a secondary level/region of the address, usually a county, state or other such area that typically encompasses several localities. Values could be a region or province, more granular than level 1.
        /// </summary>
        /// <value>The name of a secondary level/region of the address, usually a county, state or other such area that typically encompasses several localities. Values could be a region or province, more granular than level 1.</value>
        /// <example>&quot;Uusimaa&quot;</example>
        [DataMember(Name = "adminUnitLevel_2", EmitDefaultValue = false)]
        public string AdminUnitLevel2 { get; set; }

        /// <summary>
        /// A globally unique identifier for each instance of an Address. The concept of adding a globally unique identifier for each instance of an address is a crucial part of the INSPIRE data spec. A number of EU countries have already implemented an ID (a UUID) in their Address Register, among them Denmark.
        /// </summary>
        /// <value>A globally unique identifier for each instance of an Address. The concept of adding a globally unique identifier for each instance of an address is a crucial part of the INSPIRE data spec. A number of EU countries have already implemented an ID (a UUID) in their Address Register, among them Denmark.</value>
        /// <example>&quot;123e4567-e89b-12d3-a456-42661417400&quot;</example>
        [DataMember(Name = "addressId", EmitDefaultValue = false)]
        public string AddressId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RegisteredAddress {\n");
            sb.Append("  FullAddress: ").Append(FullAddress).Append("\n");
            sb.Append("  Thoroughfare: ").Append(Thoroughfare).Append("\n");
            sb.Append("  LocatorDesignator: ").Append(LocatorDesignator).Append("\n");
            sb.Append("  LocatorName: ").Append(LocatorName).Append("\n");
            sb.Append("  AddressArea: ").Append(AddressArea).Append("\n");
            sb.Append("  PostCode: ").Append(PostCode).Append("\n");
            sb.Append("  PostName: ").Append(PostName).Append("\n");
            sb.Append("  PoBox: ").Append(PoBox).Append("\n");
            sb.Append("  AdminUnitLevel1: ").Append(AdminUnitLevel1).Append("\n");
            sb.Append("  AdminUnitLevel2: ").Append(AdminUnitLevel2).Append("\n");
            sb.Append("  AddressId: ").Append(AddressId).Append("\n");
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
            return this.Equals(input as RegisteredAddress);
        }

        /// <summary>
        /// Returns true if RegisteredAddress instances are equal
        /// </summary>
        /// <param name="input">Instance of RegisteredAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RegisteredAddress input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.FullAddress == input.FullAddress ||
                    (this.FullAddress != null &&
                    this.FullAddress.Equals(input.FullAddress))
                ) && 
                (
                    this.Thoroughfare == input.Thoroughfare ||
                    (this.Thoroughfare != null &&
                    this.Thoroughfare.Equals(input.Thoroughfare))
                ) && 
                (
                    this.LocatorDesignator == input.LocatorDesignator ||
                    (this.LocatorDesignator != null &&
                    this.LocatorDesignator.Equals(input.LocatorDesignator))
                ) && 
                (
                    this.LocatorName == input.LocatorName ||
                    (this.LocatorName != null &&
                    this.LocatorName.Equals(input.LocatorName))
                ) && 
                (
                    this.AddressArea == input.AddressArea ||
                    (this.AddressArea != null &&
                    this.AddressArea.Equals(input.AddressArea))
                ) && 
                (
                    this.PostCode == input.PostCode ||
                    (this.PostCode != null &&
                    this.PostCode.Equals(input.PostCode))
                ) && 
                (
                    this.PostName == input.PostName ||
                    (this.PostName != null &&
                    this.PostName.Equals(input.PostName))
                ) && 
                (
                    this.PoBox == input.PoBox ||
                    (this.PoBox != null &&
                    this.PoBox.Equals(input.PoBox))
                ) && 
                (
                    this.AdminUnitLevel1 == input.AdminUnitLevel1 ||
                    (this.AdminUnitLevel1 != null &&
                    this.AdminUnitLevel1.Equals(input.AdminUnitLevel1))
                ) && 
                (
                    this.AdminUnitLevel2 == input.AdminUnitLevel2 ||
                    (this.AdminUnitLevel2 != null &&
                    this.AdminUnitLevel2.Equals(input.AdminUnitLevel2))
                ) && 
                (
                    this.AddressId == input.AddressId ||
                    (this.AddressId != null &&
                    this.AddressId.Equals(input.AddressId))
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
                if (this.FullAddress != null)
                {
                    hashCode = (hashCode * 59) + this.FullAddress.GetHashCode();
                }
                if (this.Thoroughfare != null)
                {
                    hashCode = (hashCode * 59) + this.Thoroughfare.GetHashCode();
                }
                if (this.LocatorDesignator != null)
                {
                    hashCode = (hashCode * 59) + this.LocatorDesignator.GetHashCode();
                }
                if (this.LocatorName != null)
                {
                    hashCode = (hashCode * 59) + this.LocatorName.GetHashCode();
                }
                if (this.AddressArea != null)
                {
                    hashCode = (hashCode * 59) + this.AddressArea.GetHashCode();
                }
                if (this.PostCode != null)
                {
                    hashCode = (hashCode * 59) + this.PostCode.GetHashCode();
                }
                if (this.PostName != null)
                {
                    hashCode = (hashCode * 59) + this.PostName.GetHashCode();
                }
                if (this.PoBox != null)
                {
                    hashCode = (hashCode * 59) + this.PoBox.GetHashCode();
                }
                if (this.AdminUnitLevel1 != null)
                {
                    hashCode = (hashCode * 59) + this.AdminUnitLevel1.GetHashCode();
                }
                if (this.AdminUnitLevel2 != null)
                {
                    hashCode = (hashCode * 59) + this.AdminUnitLevel2.GetHashCode();
                }
                if (this.AddressId != null)
                {
                    hashCode = (hashCode * 59) + this.AddressId.GetHashCode();
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
            // FullAddress (string) maxLength
            if (this.FullAddress != null && this.FullAddress.Length > 250)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FullAddress, length must be less than 250.", new [] { "FullAddress" });
            }

            // FullAddress (string) minLength
            if (this.FullAddress != null && this.FullAddress.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FullAddress, length must be greater than 1.", new [] { "FullAddress" });
            }

            // Thoroughfare (string) maxLength
            if (this.Thoroughfare != null && this.Thoroughfare.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Thoroughfare, length must be less than 40.", new [] { "Thoroughfare" });
            }

            // Thoroughfare (string) minLength
            if (this.Thoroughfare != null && this.Thoroughfare.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Thoroughfare, length must be greater than 1.", new [] { "Thoroughfare" });
            }

            // LocatorDesignator (string) maxLength
            if (this.LocatorDesignator != null && this.LocatorDesignator.Length > 10)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LocatorDesignator, length must be less than 10.", new [] { "LocatorDesignator" });
            }

            // LocatorDesignator (string) minLength
            if (this.LocatorDesignator != null && this.LocatorDesignator.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LocatorDesignator, length must be greater than 1.", new [] { "LocatorDesignator" });
            }

            // LocatorName (string) maxLength
            if (this.LocatorName != null && this.LocatorName.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LocatorName, length must be less than 40.", new [] { "LocatorName" });
            }

            // LocatorName (string) minLength
            if (this.LocatorName != null && this.LocatorName.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LocatorName, length must be greater than 1.", new [] { "LocatorName" });
            }

            // AddressArea (string) maxLength
            if (this.AddressArea != null && this.AddressArea.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressArea, length must be less than 40.", new [] { "AddressArea" });
            }

            // AddressArea (string) minLength
            if (this.AddressArea != null && this.AddressArea.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressArea, length must be greater than 1.", new [] { "AddressArea" });
            }

            // PostCode (string) maxLength
            if (this.PostCode != null && this.PostCode.Length > 10)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PostCode, length must be less than 10.", new [] { "PostCode" });
            }

            // PostCode (string) minLength
            if (this.PostCode != null && this.PostCode.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PostCode, length must be greater than 1.", new [] { "PostCode" });
            }

            // PostName (string) maxLength
            if (this.PostName != null && this.PostName.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PostName, length must be less than 40.", new [] { "PostName" });
            }

            // PostName (string) minLength
            if (this.PostName != null && this.PostName.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PostName, length must be greater than 1.", new [] { "PostName" });
            }

            // PoBox (string) maxLength
            if (this.PoBox != null && this.PoBox.Length > 10)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PoBox, length must be less than 10.", new [] { "PoBox" });
            }

            // PoBox (string) minLength
            if (this.PoBox != null && this.PoBox.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PoBox, length must be greater than 1.", new [] { "PoBox" });
            }

            // AdminUnitLevel1 (string) maxLength
            if (this.AdminUnitLevel1 != null && this.AdminUnitLevel1.Length > 2)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AdminUnitLevel1, length must be less than 2.", new [] { "AdminUnitLevel1" });
            }

            // AdminUnitLevel1 (string) minLength
            if (this.AdminUnitLevel1 != null && this.AdminUnitLevel1.Length < 2)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AdminUnitLevel1, length must be greater than 2.", new [] { "AdminUnitLevel1" });
            }

            // AdminUnitLevel2 (string) maxLength
            if (this.AdminUnitLevel2 != null && this.AdminUnitLevel2.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AdminUnitLevel2, length must be less than 40.", new [] { "AdminUnitLevel2" });
            }

            // AdminUnitLevel2 (string) minLength
            if (this.AdminUnitLevel2 != null && this.AdminUnitLevel2.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AdminUnitLevel2, length must be greater than 1.", new [] { "AdminUnitLevel2" });
            }

            // AddressId (string) maxLength
            if (this.AddressId != null && this.AddressId.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressId, length must be less than 40.", new [] { "AddressId" });
            }

            // AddressId (string) minLength
            if (this.AddressId != null && this.AddressId.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AddressId, length must be greater than 1.", new [] { "AddressId" });
            }

            yield break;
        }
    }

}