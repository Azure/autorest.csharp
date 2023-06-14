// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtSupersetFlattenInheritance;

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class ResourceModel1ListResult
    {
        /// <summary> Initializes a new instance of ResourceModel1ListResult. </summary>
        internal ResourceModel1ListResult()
        {
            Value = new ChangeTrackingList<ResourceModel1Data>();
        }

        /// <summary> Initializes a new instance of ResourceModel1ListResult. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        internal ResourceModel1ListResult(IReadOnlyList<ResourceModel1Data> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<ResourceModel1Data> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
