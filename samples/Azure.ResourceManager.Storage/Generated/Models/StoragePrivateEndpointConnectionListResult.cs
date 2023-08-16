// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> List of private endpoint connection associated with the specified storage account. </summary>
    internal partial class StoragePrivateEndpointConnectionListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionListResult
        ///
        /// </summary>
        internal StoragePrivateEndpointConnectionListResult()
        {
            Value = new ChangeTrackingList<StoragePrivateEndpointConnectionData>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionListResult
        ///
        /// </summary>
        /// <param name="value"> Array of private endpoint connections. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StoragePrivateEndpointConnectionListResult(IReadOnlyList<StoragePrivateEndpointConnectionData> value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> Array of private endpoint connections. </summary>
        public IReadOnlyList<StoragePrivateEndpointConnectionData> Value { get; }
    }
}
