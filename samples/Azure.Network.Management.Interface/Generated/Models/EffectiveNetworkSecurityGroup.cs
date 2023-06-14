// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Effective network security group. </summary>
    public partial class EffectiveNetworkSecurityGroup
    {
        /// <summary> Initializes a new instance of EffectiveNetworkSecurityGroup. </summary>
        internal EffectiveNetworkSecurityGroup()
        {
            EffectiveSecurityRules = new ChangeTrackingList<EffectiveNetworkSecurityRule>();
        }

        /// <summary> Initializes a new instance of EffectiveNetworkSecurityGroup. </summary>
        /// <param name="networkSecurityGroup"> The ID of network security group that is applied. </param>
        /// <param name="association"> Associated resources. </param>
        /// <param name="effectiveSecurityRules"> A collection of effective security rules. </param>
        /// <param name="tagMap"> Mapping of tags to list of IP Addresses included within the tag. </param>
        internal EffectiveNetworkSecurityGroup(SubResource networkSecurityGroup, EffectiveNetworkSecurityGroupAssociation association, IReadOnlyList<EffectiveNetworkSecurityRule> effectiveSecurityRules, string tagMap)
        {
            NetworkSecurityGroup = networkSecurityGroup;
            Association = association;
            EffectiveSecurityRules = effectiveSecurityRules;
            TagMap = tagMap;
        }

        /// <summary> The ID of network security group that is applied. </summary>
        public SubResource NetworkSecurityGroup { get; }
        /// <summary> Associated resources. </summary>
        public EffectiveNetworkSecurityGroupAssociation Association { get; }
        /// <summary> A collection of effective security rules. </summary>
        public IReadOnlyList<EffectiveNetworkSecurityRule> EffectiveSecurityRules { get; }
        /// <summary> Mapping of tags to list of IP Addresses included within the tag. </summary>
        public string TagMap { get; }
    }
}
