// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtResourceName;

namespace MgmtResourceName.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class NetworkResourceListResult
    {
        /// <summary> Initializes a new instance of NetworkResourceListResult. </summary>
        internal NetworkResourceListResult()
        {
            Value = new ChangeTrackingList<NetworkData>();
        }

        /// <summary> Initializes a new instance of NetworkResourceListResult. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal NetworkResourceListResult(IReadOnlyList<NetworkData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<NetworkData> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
