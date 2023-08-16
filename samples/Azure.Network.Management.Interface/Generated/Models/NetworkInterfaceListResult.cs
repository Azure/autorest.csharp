// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Response for the ListNetworkInterface API service call. </summary>
    internal partial class NetworkInterfaceListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.Network.Management.Interface.Models.NetworkInterfaceListResult
        ///
        /// </summary>
        internal NetworkInterfaceListResult()
        {
            Value = new ChangeTrackingList<NetworkInterface>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.Network.Management.Interface.Models.NetworkInterfaceListResult
        ///
        /// </summary>
        /// <param name="value"> A list of network interfaces in a resource group. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal NetworkInterfaceListResult(IReadOnlyList<NetworkInterface> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> A list of network interfaces in a resource group. </summary>
        public IReadOnlyList<NetworkInterface> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
