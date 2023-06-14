// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Response for list effective network security groups API service call. </summary>
    public partial class EffectiveNetworkSecurityGroupListResult
    {
        /// <summary> Initializes a new instance of EffectiveNetworkSecurityGroupListResult. </summary>
        internal EffectiveNetworkSecurityGroupListResult()
        {
            Value = new ChangeTrackingList<EffectiveNetworkSecurityGroup>();
        }

        /// <summary> Initializes a new instance of EffectiveNetworkSecurityGroupListResult. </summary>
        /// <param name="value"> A list of effective network security groups. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        internal EffectiveNetworkSecurityGroupListResult(IReadOnlyList<EffectiveNetworkSecurityGroup> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> A list of effective network security groups. </summary>
        public IReadOnlyList<EffectiveNetworkSecurityGroup> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
