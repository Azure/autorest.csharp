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
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="PublicIPAddressSku"/>. </summary>
        public PublicIPAddressSku()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PublicIPAddressSku"/>. </summary>
        /// <param name="name"> Name of a public IP address SKU. </param>
        /// <param name="tier"> Tier of a public IP address SKU. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PublicIPAddressSku(PublicIPAddressSkuName? name, PublicIPAddressSkuTier? tier, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Tier = tier;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Name of a public IP address SKU. </summary>
        public PublicIPAddressSkuName? Name { get; set; }
        /// <summary> Tier of a public IP address SKU. </summary>
        public PublicIPAddressSkuTier? Tier { get; set; }
    }
}
