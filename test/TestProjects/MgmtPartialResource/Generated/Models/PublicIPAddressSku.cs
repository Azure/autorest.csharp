// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtPartialResource.Models
{
    /// <summary> SKU of a public IP address. </summary>
    public partial class PublicIPAddressSku
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtPartialResource.Models.PublicIPAddressSku
        ///
        /// </summary>
        public PublicIPAddressSku()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtPartialResource.Models.PublicIPAddressSku
        ///
        /// </summary>
        /// <param name="name"> Name of a public IP address SKU. </param>
        /// <param name="tier"> Tier of a public IP address SKU. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PublicIPAddressSku(PublicIPAddressSkuName? name, PublicIPAddressSkuTier? tier, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            Tier = tier;
            _rawData = rawData;
        }

        /// <summary> Name of a public IP address SKU. </summary>
        public PublicIPAddressSkuName? Name { get; set; }
        /// <summary> Tier of a public IP address SKU. </summary>
        public PublicIPAddressSkuTier? Tier { get; set; }
    }
}
