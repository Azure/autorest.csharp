// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtExactMatchFlattenInheritance;

namespace MgmtExactMatchFlattenInheritance.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class AzureResourceFlattenModel1ListResult
    {
        /// <summary> Initializes a new instance of AzureResourceFlattenModel1ListResult. </summary>
        internal AzureResourceFlattenModel1ListResult()
        {
            Value = new ChangeTrackingList<AzureResourceFlattenModel1Data>();
        }

        /// <summary> Initializes a new instance of AzureResourceFlattenModel1ListResult. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal AzureResourceFlattenModel1ListResult(IReadOnlyList<AzureResourceFlattenModel1Data> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<AzureResourceFlattenModel1Data> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
