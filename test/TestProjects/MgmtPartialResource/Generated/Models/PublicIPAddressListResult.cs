// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtPartialResource;

namespace MgmtPartialResource.Models
{
    /// <summary> Response for ListPublicIpAddresses API service call. </summary>
    internal partial class PublicIPAddressListResult
    {
        /// <summary> Initializes a new instance of PublicIPAddressListResult. </summary>
        internal PublicIPAddressListResult()
        {
            Value = new ChangeTrackingList<PublicIPAddressData>();
        }

        /// <summary> Initializes a new instance of PublicIPAddressListResult. </summary>
        /// <param name="value"> A list of public IP addresses that exists in a resource group. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        internal PublicIPAddressListResult(IReadOnlyList<PublicIPAddressData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> A list of public IP addresses that exists in a resource group. </summary>
        public IReadOnlyList<PublicIPAddressData> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
