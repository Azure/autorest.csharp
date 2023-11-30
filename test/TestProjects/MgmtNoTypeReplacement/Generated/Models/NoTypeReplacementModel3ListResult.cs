// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtNoTypeReplacement;

namespace MgmtNoTypeReplacement.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class NoTypeReplacementModel3ListResult
    {
        /// <summary> Initializes a new instance of <see cref="NoTypeReplacementModel3ListResult"/>. </summary>
        internal NoTypeReplacementModel3ListResult()
        {
            Value = new ChangeTrackingList<NoTypeReplacementModel3Data>();
        }

        /// <summary> Initializes a new instance of <see cref="NoTypeReplacementModel3ListResult"/>. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal NoTypeReplacementModel3ListResult(IReadOnlyList<NoTypeReplacementModel3Data> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<NoTypeReplacementModel3Data> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
