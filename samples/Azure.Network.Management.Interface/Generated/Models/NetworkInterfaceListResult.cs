// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Response for the ListNetworkInterface API service call. </summary>
    internal partial class NetworkInterfaceListResult
    {
        /// <summary> Initializes a new instance of NetworkInterfaceListResult. </summary>
        internal NetworkInterfaceListResult()
        {
            Value = new ChangeTrackingList<NetworkInterface>();
        }

        /// <summary> Initializes a new instance of NetworkInterfaceListResult. </summary>
        /// <param name="value"> A list of network interfaces in a resource group. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        internal NetworkInterfaceListResult(IReadOnlyList<NetworkInterface> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> A list of network interfaces in a resource group. </summary>
        public IReadOnlyList<NetworkInterface> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
