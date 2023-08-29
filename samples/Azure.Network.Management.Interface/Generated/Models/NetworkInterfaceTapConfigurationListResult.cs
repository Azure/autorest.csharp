// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Response for list tap configurations API service call. </summary>
    internal partial class NetworkInterfaceTapConfigurationListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="NetworkInterfaceTapConfigurationListResult"/>. </summary>
        internal NetworkInterfaceTapConfigurationListResult()
        {
            Value = new ChangeTrackingList<NetworkInterfaceTapConfiguration>();
        }

        /// <summary> Initializes a new instance of <see cref="NetworkInterfaceTapConfigurationListResult"/>. </summary>
        /// <param name="value"> A list of tap configurations. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal NetworkInterfaceTapConfigurationListResult(IReadOnlyList<NetworkInterfaceTapConfiguration> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> A list of tap configurations. </summary>
        public IReadOnlyList<NetworkInterfaceTapConfiguration> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
