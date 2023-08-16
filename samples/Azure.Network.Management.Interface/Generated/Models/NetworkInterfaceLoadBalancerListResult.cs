// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Response for list ip configurations API service call. </summary>
    internal partial class NetworkInterfaceLoadBalancerListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.Network.Management.Interface.Models.NetworkInterfaceLoadBalancerListResult
        ///
        /// </summary>
        internal NetworkInterfaceLoadBalancerListResult()
        {
            Value = new ChangeTrackingList<LoadBalancer>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.Network.Management.Interface.Models.NetworkInterfaceLoadBalancerListResult
        ///
        /// </summary>
        /// <param name="value"> A list of load balancers. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal NetworkInterfaceLoadBalancerListResult(IReadOnlyList<LoadBalancer> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> A list of load balancers. </summary>
        public IReadOnlyList<LoadBalancer> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
