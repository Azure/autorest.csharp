// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The response from the List Usages operation. </summary>
    internal partial class UsageListResult
    {
        /// <summary> Initializes a new instance of UsageListResult. </summary>
        internal UsageListResult()
        {
            Value = new ChangeTrackingList<StorageUsage>();
        }

        /// <summary> Initializes a new instance of UsageListResult. </summary>
        /// <param name="value"> Gets or sets the list of Storage Resource Usages. </param>
        internal UsageListResult(IReadOnlyList<StorageUsage> value)
        {
            Value = value;
        }

        /// <summary> Gets or sets the list of Storage Resource Usages. </summary>
        public IReadOnlyList<StorageUsage> Value { get; }
    }
}
