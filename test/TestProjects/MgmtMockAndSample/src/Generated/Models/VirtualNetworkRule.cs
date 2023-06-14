// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> A rule governing the accessibility of a vault from a specific virtual network. </summary>
    public partial class VirtualNetworkRule
    {
        /// <summary> Initializes a new instance of VirtualNetworkRule. </summary>
        /// <param name="id"> Full resource id of a vnet subnet, such as '/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/subnet1'. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public VirtualNetworkRule(string id)
        {
            Argument.AssertNotNull(id, nameof(id));

            Id = id;
        }

        /// <summary> Initializes a new instance of VirtualNetworkRule. </summary>
        /// <param name="id"> Full resource id of a vnet subnet, such as '/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/subnet1'. </param>
        /// <param name="ignoreMissingVnetServiceEndpoint"> Property to specify whether NRP will ignore the check if parent subnet has serviceEndpoints configured. </param>
        internal VirtualNetworkRule(string id, bool? ignoreMissingVnetServiceEndpoint)
        {
            Id = id;
            IgnoreMissingVnetServiceEndpoint = ignoreMissingVnetServiceEndpoint;
        }

        /// <summary> Full resource id of a vnet subnet, such as '/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/subnet1'. </summary>
        public string Id { get; set; }
        /// <summary> Property to specify whether NRP will ignore the check if parent subnet has serviceEndpoints configured. </summary>
        public bool? IgnoreMissingVnetServiceEndpoint { get; set; }
    }
}
