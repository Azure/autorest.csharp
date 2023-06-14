// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtOmitOperationGroups;

namespace MgmtOmitOperationGroups.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class Model2ListResult
    {
        /// <summary> Initializes a new instance of Model2ListResult. </summary>
        internal Model2ListResult()
        {
            Value = new ChangeTrackingList<Model2Data>();
        }

        /// <summary> Initializes a new instance of Model2ListResult. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal Model2ListResult(IReadOnlyList<Model2Data> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<Model2Data> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
