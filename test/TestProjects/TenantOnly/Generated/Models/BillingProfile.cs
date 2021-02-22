// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace TenantOnly
{
    /// <summary> A billing profile. </summary>
    public partial class BillingProfile : Resource
    {
        /// <summary> Initializes a new instance of BillingProfile. </summary>
        public BillingProfile()
        {
        }

        /// <summary> Initializes a new instance of BillingProfile. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="idPropertiesId"> Resource Id. </param>
        /// <param name="namePropertiesName"> Resource name. </param>
        /// <param name="typePropertiesType"> Resource type. </param>
        internal BillingProfile(string id, string name, string type, string idPropertiesId, string namePropertiesName, string typePropertiesType) : base(id, name, type)
        {
            IdPropertiesId = idPropertiesId;
            NamePropertiesName = namePropertiesName;
            TypePropertiesType = typePropertiesType;
        }

        /// <summary> Resource Id. </summary>
        public string IdPropertiesId { get; }
        /// <summary> Resource name. </summary>
        public string NamePropertiesName { get; }
        /// <summary> Resource type. </summary>
        public string TypePropertiesType { get; }
    }
}
