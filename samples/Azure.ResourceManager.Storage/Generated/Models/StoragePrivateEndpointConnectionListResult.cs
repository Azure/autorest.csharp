// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> List of private endpoint connection associated with the specified storage account. </summary>
    internal partial class StoragePrivateEndpointConnectionListResult
    {
        /// <summary> Initializes a new instance of StoragePrivateEndpointConnectionListResult. </summary>
        internal StoragePrivateEndpointConnectionListResult()
        {
            Value = new ChangeTrackingList<StoragePrivateEndpointConnectionData>();
        }

        /// <summary> Initializes a new instance of StoragePrivateEndpointConnectionListResult. </summary>
        /// <param name="value"> Array of private endpoint connections. </param>
        internal StoragePrivateEndpointConnectionListResult(IReadOnlyList<StoragePrivateEndpointConnectionData> value)
        {
            Value = value;
        }

        /// <summary> Array of private endpoint connections. </summary>
        public IReadOnlyList<StoragePrivateEndpointConnectionData> Value { get; }
    }
}
