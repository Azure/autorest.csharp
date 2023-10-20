// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Virtual Network rule. </summary>
    public partial class VirtualNetworkRule
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VirtualNetworkRule"/>. </summary>
        /// <param name="virtualNetworkResourceId"> Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkResourceId"/> is null. </exception>
        public VirtualNetworkRule(string virtualNetworkResourceId)
        {
            Argument.AssertNotNull(virtualNetworkResourceId, nameof(virtualNetworkResourceId));

            VirtualNetworkResourceId = virtualNetworkResourceId;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualNetworkRule"/>. </summary>
        /// <param name="virtualNetworkResourceId"> Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}. </param>
        /// <param name="action"> The action of virtual network rule. </param>
        /// <param name="state"> Gets the state of virtual network rule. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualNetworkRule(string virtualNetworkResourceId, Action? action, State? state, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            VirtualNetworkResourceId = virtualNetworkResourceId;
            Action = action;
            State = state;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualNetworkRule"/> for deserialization. </summary>
        internal VirtualNetworkRule()
        {
        }

        /// <summary> Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}. </summary>
        public string VirtualNetworkResourceId { get; set; }
        /// <summary> The action of virtual network rule. </summary>
        public Action? Action { get; set; }
        /// <summary> Gets the state of virtual network rule. </summary>
        public State? State { get; set; }
    }
}
