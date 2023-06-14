// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtSingletonResource;

namespace MgmtSingletonResource.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class CarListResult
    {
        /// <summary> Initializes a new instance of CarListResult. </summary>
        internal CarListResult()
        {
            Value = new ChangeTrackingList<CarData>();
        }

        /// <summary> Initializes a new instance of CarListResult. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal CarListResult(IReadOnlyList<CarData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<CarData> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
