// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The response from the ListKeys operation. </summary>
    public partial class StorageAccountListKeysResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="StorageAccountListKeysResult"/>. </summary>
        internal StorageAccountListKeysResult()
        {
            Keys = new ChangeTrackingList<StorageAccountKey>();
        }

        /// <summary> Initializes a new instance of <see cref="StorageAccountListKeysResult"/>. </summary>
        /// <param name="keys"> Gets the list of storage account keys and their properties for the specified storage account. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal StorageAccountListKeysResult(IReadOnlyList<StorageAccountKey> keys, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Keys = keys;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the list of storage account keys and their properties for the specified storage account. </summary>
        public IReadOnlyList<StorageAccountKey> Keys { get; }
    }
}
