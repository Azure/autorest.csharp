// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Response for list tap configurations API service call. </summary>
    public partial class NetworkInterfaceTapConfigurationListResult
    {
        /// <summary> Initializes a new instance of NetworkInterfaceTapConfigurationListResult. </summary>
        internal NetworkInterfaceTapConfigurationListResult()
        {
        }

        /// <summary> Initializes a new instance of NetworkInterfaceTapConfigurationListResult. </summary>
        /// <param name="value"> A list of tap configurations. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        internal NetworkInterfaceTapConfigurationListResult(IList<NetworkInterfaceTapConfiguration> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> A list of tap configurations. </summary>
        public IList<NetworkInterfaceTapConfiguration> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
