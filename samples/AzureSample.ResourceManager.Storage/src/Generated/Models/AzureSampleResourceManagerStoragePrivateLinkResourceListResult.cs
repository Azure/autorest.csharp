// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using AzureSample.ResourceManager.Storage;

namespace AzureSample.ResourceManager.Storage.Models
{
    /// <summary> A list of private link resources. </summary>
    internal partial class AzureSampleResourceManagerStoragePrivateLinkResourceListResult
    {
        /// <summary> Initializes a new instance of <see cref="AzureSampleResourceManagerStoragePrivateLinkResourceListResult"/>. </summary>
        internal AzureSampleResourceManagerStoragePrivateLinkResourceListResult()
        {
            Value = new ChangeTrackingList<AzureSampleResourceManagerStoragePrivateLinkResource>();
        }

        /// <summary> Initializes a new instance of <see cref="AzureSampleResourceManagerStoragePrivateLinkResourceListResult"/>. </summary>
        /// <param name="value"> Array of private link resources. </param>
        internal AzureSampleResourceManagerStoragePrivateLinkResourceListResult(IReadOnlyList<AzureSampleResourceManagerStoragePrivateLinkResource> value)
        {
            Value = value;
        }

        /// <summary> Array of private link resources. </summary>
        public IReadOnlyList<AzureSampleResourceManagerStoragePrivateLinkResource> Value { get; }
    }
}
