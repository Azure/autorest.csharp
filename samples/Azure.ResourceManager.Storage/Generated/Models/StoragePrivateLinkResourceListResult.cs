// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> A list of private link resources. </summary>
    internal partial class StoragePrivateLinkResourceListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceListResult
        ///
        /// </summary>
        internal StoragePrivateLinkResourceListResult()
        {
            Value = new ChangeTrackingList<StoragePrivateLinkResource>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceListResult
        ///
        /// </summary>
        /// <param name="value"> Array of private link resources. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StoragePrivateLinkResourceListResult(IReadOnlyList<StoragePrivateLinkResource> value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> Array of private link resources. </summary>
        public IReadOnlyList<StoragePrivateLinkResource> Value { get; }
    }
}
