// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> A list of private link resources. </summary>
    internal partial class StoragePrivateLinkResourceListResult
    {
        /// <summary> Initializes a new instance of StoragePrivateLinkResourceListResult. </summary>
        internal StoragePrivateLinkResourceListResult()
        {
            Value = new ChangeTrackingList<StoragePrivateLinkResource>();
        }

        /// <summary> Initializes a new instance of StoragePrivateLinkResourceListResult. </summary>
        /// <param name="value"> Array of private link resources. </param>
        internal StoragePrivateLinkResourceListResult(IReadOnlyList<StoragePrivateLinkResource> value)
        {
            Value = value;
        }

        /// <summary> Array of private link resources. </summary>
        public IReadOnlyList<StoragePrivateLinkResource> Value { get; }
    }
}
