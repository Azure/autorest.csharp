// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Encryption identity for the storage account. </summary>
    internal partial class EncryptionIdentity
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="EncryptionIdentity"/>. </summary>
        public EncryptionIdentity()
        {
        }

        /// <summary> Initializes a new instance of <see cref="EncryptionIdentity"/>. </summary>
        /// <param name="encryptionUserAssignedIdentity"> Resource identifier of the UserAssigned identity to be associated with server-side encryption on the storage account. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal EncryptionIdentity(string encryptionUserAssignedIdentity, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            EncryptionUserAssignedIdentity = encryptionUserAssignedIdentity;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Resource identifier of the UserAssigned identity to be associated with server-side encryption on the storage account. </summary>
        public string EncryptionUserAssignedIdentity { get; set; }
    }
}
