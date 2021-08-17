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
            Value = new ChangeTrackingList<DeletedVaultData>();
        }

        /// <summary> The list of deleted vaults. </summary>
        public IReadOnlyList<DeletedVaultData> Value { get; }
        /// <summary> The URL to get the next set of deleted vaults. </summary>
        public string NextLink { get; }
    }
}
