// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> The SKU of the storage account. </summary>
    public partial class Sku
    {
        /// <summary> Initializes a new instance of Sku. </summary>
        public Sku()
        {
        }

        /// <summary> Initializes a new instance of Sku. </summary>
        /// <param name="name"> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </param>
        /// <param name="tier"> The SKU tier. This is based on the SKU name. </param>
        internal Sku(SkuName name, SkuTier? tier)
        {
            Name = name;
            Tier = tier;
        }

        /// <summary> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </summary>
        public SkuName Name { get; set; }
        /// <summary> The SKU tier. This is based on the SKU name. </summary>
        public SkuTier? Tier { get; set; }
    }
}
