// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Properties of key vault. </summary>
    public partial class KeyVaultProperties
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="KeyVaultProperties"/>. </summary>
        public KeyVaultProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="KeyVaultProperties"/>. </summary>
        /// <param name="keyName"> The name of KeyVault key. </param>
        /// <param name="keyVersion"> The version of KeyVault key. </param>
        /// <param name="keyVaultUri"> The Uri of KeyVault. </param>
        /// <param name="currentVersionedKeyIdentifier"> The object identifier of the current versioned Key Vault Key in use. </param>
        /// <param name="lastKeyRotationTimestamp"> Timestamp of last rotation of the Key Vault Key. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal KeyVaultProperties(string keyName, string keyVersion, Uri keyVaultUri, string currentVersionedKeyIdentifier, DateTimeOffset? lastKeyRotationTimestamp, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            KeyName = keyName;
            KeyVersion = keyVersion;
            KeyVaultUri = keyVaultUri;
            CurrentVersionedKeyIdentifier = currentVersionedKeyIdentifier;
            LastKeyRotationTimestamp = lastKeyRotationTimestamp;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The name of KeyVault key. </summary>
        public string KeyName { get; set; }
        /// <summary> The version of KeyVault key. </summary>
        public string KeyVersion { get; set; }
        /// <summary> The Uri of KeyVault. </summary>
        public Uri KeyVaultUri { get; set; }
        /// <summary> The object identifier of the current versioned Key Vault Key in use. </summary>
        public string CurrentVersionedKeyIdentifier { get; }
        /// <summary> Timestamp of last rotation of the Key Vault Key. </summary>
        public DateTimeOffset? LastKeyRotationTimestamp { get; }
    }
}
