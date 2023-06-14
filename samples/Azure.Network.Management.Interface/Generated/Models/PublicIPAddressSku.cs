// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> SKU of a public IP address. </summary>
    public partial class PublicIPAddressSku
    {
        /// <summary> Initializes a new instance of PublicIPAddressSku. </summary>
        public PublicIPAddressSku()
        {
        }

        /// <summary> Initializes a new instance of PublicIPAddressSku. </summary>
        /// <param name="name"> Name of a public IP address SKU. </param>
        internal PublicIPAddressSku(PublicIPAddressSkuName? name)
        {
            Name = name;
        }

        /// <summary> Name of a public IP address SKU. </summary>
        public PublicIPAddressSkuName? Name { get; set; }
    }
}
