// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> The effective network security group association. </summary>
    public partial class EffectiveNetworkSecurityGroupAssociation
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="EffectiveNetworkSecurityGroupAssociation"/>. </summary>
        internal EffectiveNetworkSecurityGroupAssociation()
        {
        }

        /// <summary> Initializes a new instance of <see cref="EffectiveNetworkSecurityGroupAssociation"/>. </summary>
        /// <param name="subnet"> The ID of the subnet if assigned. </param>
        /// <param name="networkInterface"> The ID of the network interface if assigned. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal EffectiveNetworkSecurityGroupAssociation(SubResource subnet, SubResource networkInterface, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Subnet = subnet;
            NetworkInterface = networkInterface;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The ID of the subnet if assigned. </summary>
        public SubResource Subnet { get; }
        /// <summary> The ID of the network interface if assigned. </summary>
        public SubResource NetworkInterface { get; }
    }
}
