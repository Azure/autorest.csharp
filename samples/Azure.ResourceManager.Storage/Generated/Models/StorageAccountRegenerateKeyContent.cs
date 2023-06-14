// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The parameters used to regenerate the storage account key. </summary>
    public partial class StorageAccountRegenerateKeyContent
    {
        /// <summary> Initializes a new instance of StorageAccountRegenerateKeyContent. </summary>
        /// <param name="keyName"> The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public StorageAccountRegenerateKeyContent(string keyName)
        {
            Argument.AssertNotNull(keyName, nameof(keyName));

            KeyName = keyName;
        }

        /// <summary> The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2. </summary>
        public string KeyName { get; }
    }
}
