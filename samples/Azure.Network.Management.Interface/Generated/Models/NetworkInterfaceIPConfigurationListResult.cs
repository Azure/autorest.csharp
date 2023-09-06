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
    internal partial class NetworkInterfaceIPConfigurationListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="NetworkInterfaceIPConfigurationListResult"/>. </summary>
        internal NetworkInterfaceIPConfigurationListResult()
        {
            Value = new ChangeTrackingList<NetworkInterfaceIPConfiguration>();
        }

        /// <summary> Initializes a new instance of <see cref="NetworkInterfaceIPConfigurationListResult"/>. </summary>
        /// <param name="value"> A list of ip configurations. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal NetworkInterfaceIPConfigurationListResult(IReadOnlyList<NetworkInterfaceIPConfiguration> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> A list of ip configurations. </summary>
        public IReadOnlyList<NetworkInterfaceIPConfiguration> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
