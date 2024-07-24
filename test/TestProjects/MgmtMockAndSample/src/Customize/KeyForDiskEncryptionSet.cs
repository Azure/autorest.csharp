// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Key Vault Key Url to be used for server side encryption of Managed Disks and Snapshots. </summary>
    [CodeGenSerialization(nameof(NewKeyUri), "newKeyUrl")]
    [CodeGenSerialization(nameof(NewListProperty), "newListProperty")]
    [CodeGenSerialization(nameof(NewReadOnlyListProperty), "newReadOnlyListProperty")]
    public partial class KeyForDiskEncryptionSet
    {
        /// <summary>
        /// add a new property in serialization
        /// </summary>
        public Uri NewKeyUri { get; set; }

        /// <summary>
        /// add a new property in serialization
        /// </summary>
        public IList<string> NewListProperty { get; }

        /// <summary>
        /// add a new property in serialization
        /// </summary>
        public IReadOnlyList<string> NewReadOnlyListProperty { get; }
    }
}
