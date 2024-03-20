// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace AzureSample.ResourceManager.Storage.Models
{
    /// <summary> The BlobServiceItems. </summary>
    internal partial class BlobServiceItems
    {
        /// <summary> Initializes a new instance of <see cref="BlobServiceItems"/>. </summary>
        internal BlobServiceItems()
        {
            Value = new ChangeTrackingList<BlobServiceData>();
        }

        /// <summary> Initializes a new instance of <see cref="BlobServiceItems"/>. </summary>
        /// <param name="value"> List of blob services returned. </param>
        internal BlobServiceItems(IReadOnlyList<BlobServiceData> value)
        {
            Value = value;
        }

        /// <summary> List of blob services returned. </summary>
        public IReadOnlyList<BlobServiceData> Value { get; }
    }
}
