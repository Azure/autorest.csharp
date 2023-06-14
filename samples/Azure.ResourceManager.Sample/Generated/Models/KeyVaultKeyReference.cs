// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a reference to Key Vault Key
    /// Serialized Name: KeyVaultKeyReference
    /// </summary>
    public partial class KeyVaultKeyReference
    {
        /// <summary> Initializes a new instance of KeyVaultKeyReference. </summary>
        /// <param name="keyUri">
        /// The URL referencing a key encryption key in Key Vault.
        /// Serialized Name: KeyVaultKeyReference.keyUrl
        /// </param>
        /// <param name="sourceVault">
        /// The relative URL of the Key Vault containing the key.
        /// Serialized Name: KeyVaultKeyReference.sourceVault
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyUri"/> or <paramref name="sourceVault"/> is null. </exception>
        public KeyVaultKeyReference(Uri keyUri, WritableSubResource sourceVault)
        {
            Argument.AssertNotNull(keyUri, nameof(keyUri));
            Argument.AssertNotNull(sourceVault, nameof(sourceVault));

            KeyUri = keyUri;
            SourceVault = sourceVault;
        }

        /// <summary>
        /// The URL referencing a key encryption key in Key Vault.
        /// Serialized Name: KeyVaultKeyReference.keyUrl
        /// </summary>
        public Uri KeyUri { get; set; }
        /// <summary>
        /// The relative URL of the Key Vault containing the key.
        /// Serialized Name: KeyVaultKeyReference.sourceVault
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
