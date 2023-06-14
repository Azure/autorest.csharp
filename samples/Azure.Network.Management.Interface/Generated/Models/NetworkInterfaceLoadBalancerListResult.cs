// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Response for list ip configurations API service call. </summary>
    internal partial class NetworkInterfaceLoadBalancerListResult
    {
        /// <summary> Initializes a new instance of NetworkInterfaceLoadBalancerListResult. </summary>
        internal NetworkInterfaceLoadBalancerListResult()
        {
            Value = new ChangeTrackingList<LoadBalancer>();
        }

        /// <summary> Initializes a new instance of NetworkInterfaceLoadBalancerListResult. </summary>
        /// <param name="value"> A list of load balancers. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        internal NetworkInterfaceLoadBalancerListResult(IReadOnlyList<LoadBalancer> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> A list of load balancers. </summary>
        public IReadOnlyList<LoadBalancer> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
