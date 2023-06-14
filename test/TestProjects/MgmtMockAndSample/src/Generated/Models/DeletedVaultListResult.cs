// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    /// <summary> List of vaults. </summary>
    internal partial class DeletedVaultListResult
    {
        /// <summary> Initializes a new instance of DeletedVaultListResult. </summary>
        internal DeletedVaultListResult()
        {
            Value = new ChangeTrackingList<DeletedVaultData>();
        }

        /// <summary> Initializes a new instance of DeletedVaultListResult. </summary>
        /// <param name="value"> The list of deleted vaults. </param>
        /// <param name="nextLink"> The URL to get the next set of deleted vaults. </param>
        internal DeletedVaultListResult(IReadOnlyList<DeletedVaultData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of deleted vaults. </summary>
        public IReadOnlyList<DeletedVaultData> Value { get; }
        /// <summary> The URL to get the next set of deleted vaults. </summary>
        public string NextLink { get; }
    }
}
