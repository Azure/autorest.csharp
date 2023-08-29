// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The parameters used to regenerate the storage account key. </summary>
    public partial class StorageAccountRegenerateKeyContent
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent
        ///
        /// </summary>
        /// <param name="keyName"> The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public StorageAccountRegenerateKeyContent(string keyName)
        {
            Argument.AssertNotNull(keyName, nameof(keyName));

            KeyName = keyName;
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent
        ///
        /// </summary>
        /// <param name="keyName"> The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StorageAccountRegenerateKeyContent(string keyName, Dictionary<string, BinaryData> rawData)
        {
            KeyName = keyName;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="StorageAccountRegenerateKeyContent"/> for deserialization. </summary>
        internal StorageAccountRegenerateKeyContent()
        {
        }

        /// <summary> The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2. </summary>
        public string KeyName { get; }
    }
}
