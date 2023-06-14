// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Parameters for creating or updating a vault. </summary>
    public partial class VaultPatch
    {
        /// <summary> Initializes a new instance of VaultPatch. </summary>
        public VaultPatch()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> The tags that will be assigned to the key vault. </summary>
        public IDictionary<string, string> Tags { get; }
        /// <summary> Properties of the vault. </summary>
        public VaultPatchProperties Properties { get; set; }
    }
}
