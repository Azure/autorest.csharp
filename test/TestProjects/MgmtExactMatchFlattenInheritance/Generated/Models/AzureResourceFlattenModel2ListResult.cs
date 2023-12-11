// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtExactMatchFlattenInheritance.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class AzureResourceFlattenModel2ListResult
    {
        /// <summary> Initializes a new instance of <see cref="AzureResourceFlattenModel2ListResult"/>. </summary>
        internal AzureResourceFlattenModel2ListResult()
        {
            Value = new ChangeTrackingList<AzureResourceFlattenModel2>();
        }

        /// <summary> Initializes a new instance of <see cref="AzureResourceFlattenModel2ListResult"/>. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal AzureResourceFlattenModel2ListResult(IReadOnlyList<AzureResourceFlattenModel2> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<AzureResourceFlattenModel2> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
