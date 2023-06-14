// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Encryption identity for the storage account. </summary>
    internal partial class EncryptionIdentity
    {
        /// <summary> Initializes a new instance of EncryptionIdentity. </summary>
        public EncryptionIdentity()
        {
        }

        /// <summary> Initializes a new instance of EncryptionIdentity. </summary>
        /// <param name="encryptionUserAssignedIdentity"> Resource identifier of the UserAssigned identity to be associated with server-side encryption on the storage account. </param>
        internal EncryptionIdentity(string encryptionUserAssignedIdentity)
        {
            EncryptionUserAssignedIdentity = encryptionUserAssignedIdentity;
        }

        /// <summary> Resource identifier of the UserAssigned identity to be associated with server-side encryption on the storage account. </summary>
        public string EncryptionUserAssignedIdentity { get; set; }
    }
}
