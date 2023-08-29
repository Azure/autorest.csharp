// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a reference to Key Vault Secret
    /// Serialized Name: KeyVaultSecretReference
    /// </summary>
    public partial class KeyVaultSecretReference
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="KeyVaultSecretReference"/>. </summary>
        /// <param name="secretUri">
        /// The URL referencing a secret in a Key Vault.
        /// Serialized Name: KeyVaultSecretReference.secretUrl
        /// </param>
        /// <param name="sourceVault">
        /// The relative URL of the Key Vault containing the secret.
        /// Serialized Name: KeyVaultSecretReference.sourceVault
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="secretUri"/> or <paramref name="sourceVault"/> is null. </exception>
        public KeyVaultSecretReference(Uri secretUri, WritableSubResource sourceVault)
        {
            Argument.AssertNotNull(secretUri, nameof(secretUri));
            Argument.AssertNotNull(sourceVault, nameof(sourceVault));

            SecretUri = secretUri;
            SourceVault = sourceVault;
        }

        /// <summary> Initializes a new instance of <see cref="KeyVaultSecretReference"/>. </summary>
        /// <param name="secretUri">
        /// The URL referencing a secret in a Key Vault.
        /// Serialized Name: KeyVaultSecretReference.secretUrl
        /// </param>
        /// <param name="sourceVault">
        /// The relative URL of the Key Vault containing the secret.
        /// Serialized Name: KeyVaultSecretReference.sourceVault
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal KeyVaultSecretReference(Uri secretUri, WritableSubResource sourceVault, Dictionary<string, BinaryData> rawData)
        {
            SecretUri = secretUri;
            SourceVault = sourceVault;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="KeyVaultSecretReference"/> for deserialization. </summary>
        internal KeyVaultSecretReference()
        {
        }

        /// <summary>
        /// The URL referencing a secret in a Key Vault.
        /// Serialized Name: KeyVaultSecretReference.secretUrl
        /// </summary>
        public Uri SecretUri { get; set; }
        /// <summary>
        /// The relative URL of the Key Vault containing the secret.
        /// Serialized Name: KeyVaultSecretReference.sourceVault
        /// </summary>
        internal WritableSubResource SourceVault { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SourceVaultId
        {
            get => SourceVault is null ? default : SourceVault.Id;
            set
            {
                if (SourceVault is null)
                    SourceVault = new WritableSubResource();
                SourceVault.Id = value;
            }
        }
    }
}
