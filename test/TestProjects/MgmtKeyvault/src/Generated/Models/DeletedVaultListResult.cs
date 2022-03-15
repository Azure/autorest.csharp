// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtKeyvault;

namespace MgmtKeyvault.Models
{
    /// <summary> List of vaults. </summary>
    internal partial class DeletedVaultListResult
    {
        /// <summary> Initializes a new instance of DeletedVaultListResult. </summary>
        internal DeletedVaultListResult()
        {
            Value = new ChangeTrackingList<DeletedVaultResourceData>();
        }

        /// <summary> Initializes a new instance of DeletedVaultListResult. </summary>
        /// <param name="value"> The list of deleted vaults. </param>
        /// <param name="nextLink"> The URL to get the next set of deleted vaults. </param>
        internal DeletedVaultListResult(IReadOnlyList<DeletedVaultResourceData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of deleted vaults. </summary>
        public IReadOnlyList<DeletedVaultResourceData> Value { get; }
        /// <summary> The URL to get the next set of deleted vaults. </summary>
        public string NextLink { get; }
    }
}
