// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> List of keys. </summary>
    internal partial class VaultListKeysResult
    {
        /// <summary> Initializes a new instance of VaultListKeysResult. </summary>
        internal VaultListKeysResult()
        {
            Value = new ChangeTrackingList<VaultKey>();
        }

        /// <summary> Initializes a new instance of VaultListKeysResult. </summary>
        /// <param name="value"> The list of vaults. </param>
        /// <param name="nextLink"> The URL to get the next set of vaults. </param>
        internal VaultListKeysResult(IReadOnlyList<VaultKey> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of vaults. </summary>
        public IReadOnlyList<VaultKey> Value { get; }
        /// <summary> The URL to get the next set of vaults. </summary>
        public string NextLink { get; }
    }
}
