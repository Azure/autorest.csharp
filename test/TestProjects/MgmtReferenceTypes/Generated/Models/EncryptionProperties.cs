// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> Configuration of key for data encryption. </summary>
    [PropertyReferenceType]
    public partial class EncryptionProperties
    {
        /// <summary> Initializes a new instance of EncryptionProperties. </summary>
        [InitializationConstructor]
        public EncryptionProperties()
        {
        }

        /// <summary> Initializes a new instance of EncryptionProperties. </summary>
        /// <param name="status"> Indicates whether or not the encryption is enabled for container registry. </param>
        /// <param name="keyVaultProperties"> Key vault properties. </param>
        [SerializationConstructor]
        internal EncryptionProperties(EncryptionStatus? status, KeyVaultProperties keyVaultProperties)
        {
            Status = status;
            KeyVaultProperties = keyVaultProperties;
        }

        /// <summary> Indicates whether or not the encryption is enabled for container registry. </summary>
        public EncryptionStatus? Status { get; set; }
        /// <summary> Key vault properties. </summary>
        public KeyVaultProperties KeyVaultProperties { get; set; }
    }
}
