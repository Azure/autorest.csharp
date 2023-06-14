// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> The KeyVaultProperties. </summary>
    [PropertyReferenceType]
    public partial class KeyVaultProperties
    {
        /// <summary> Initializes a new instance of KeyVaultProperties. </summary>
        [InitializationConstructor]
        public KeyVaultProperties()
        {
        }

        /// <summary> Initializes a new instance of KeyVaultProperties. </summary>
        /// <param name="keyIdentifier"> Key vault uri to access the encryption key. </param>
        /// <param name="identity"> The client ID of the identity which will be used to access key vault. </param>
        [SerializationConstructor]
        internal KeyVaultProperties(string keyIdentifier, string identity)
        {
            KeyIdentifier = keyIdentifier;
            Identity = identity;
        }

        /// <summary> Key vault uri to access the encryption key. </summary>
        public string KeyIdentifier { get; set; }
        /// <summary> The client ID of the identity which will be used to access key vault. </summary>
        public string Identity { get; set; }
    }
}
