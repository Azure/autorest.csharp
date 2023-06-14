// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class ExactMatchModel3ListResult
    {
        /// <summary> Initializes a new instance of ExactMatchModel3ListResult. </summary>
        internal ExactMatchModel3ListResult()
        {
            Value = new ChangeTrackingList<ExactMatchModel3>();
        }

        /// <summary> Initializes a new instance of ExactMatchModel3ListResult. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal ExactMatchModel3ListResult(IReadOnlyList<ExactMatchModel3> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<ExactMatchModel3> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
