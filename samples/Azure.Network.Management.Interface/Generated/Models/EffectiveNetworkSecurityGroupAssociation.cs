// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> The effective network security group association. </summary>
    public partial class EffectiveNetworkSecurityGroupAssociation
    {
        /// <summary> Initializes a new instance of <see cref="EffectiveNetworkSecurityGroupAssociation"/>. </summary>
        internal EffectiveNetworkSecurityGroupAssociation()
        {
        }

        /// <summary> Initializes a new instance of <see cref="EffectiveNetworkSecurityGroupAssociation"/>. </summary>
        /// <param name="subnet"> The ID of the subnet if assigned. </param>
        /// <param name="networkInterface"> The ID of the network interface if assigned. </param>
        internal EffectiveNetworkSecurityGroupAssociation(SubResource subnet, SubResource networkInterface)
        {
            Subnet = subnet;
            NetworkInterface = networkInterface;
        }

        /// <summary> The ID of the subnet if assigned. </summary>
        public SubResource Subnet { get; }
        /// <summary> The ID of the network interface if assigned. </summary>
        public SubResource NetworkInterface { get; }
    }
}
