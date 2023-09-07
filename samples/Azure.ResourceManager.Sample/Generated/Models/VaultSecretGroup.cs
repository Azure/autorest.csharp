// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a set of certificates which are all in the same Key Vault.
    /// Serialized Name: VaultSecretGroup
    /// </summary>
    public partial class VaultSecretGroup
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VaultSecretGroup"/>. </summary>
        public VaultSecretGroup()
        {
            VaultCertificates = new ChangeTrackingList<VaultCertificate>();
        }

        /// <summary> Initializes a new instance of <see cref="VaultSecretGroup"/>. </summary>
        /// <param name="sourceVault">
        /// The relative URL of the Key Vault containing all of the certificates in VaultCertificates.
        /// Serialized Name: VaultSecretGroup.sourceVault
        /// </param>
        /// <param name="vaultCertificates">
        /// The list of key vault references in SourceVault which contain certificates.
        /// Serialized Name: VaultSecretGroup.vaultCertificates
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VaultSecretGroup(WritableSubResource sourceVault, IList<VaultCertificate> vaultCertificates, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            SourceVault = sourceVault;
            VaultCertificates = vaultCertificates;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The relative URL of the Key Vault containing all of the certificates in VaultCertificates.
        /// Serialized Name: VaultSecretGroup.sourceVault
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

        /// <summary>
        /// The list of key vault references in SourceVault which contain certificates.
        /// Serialized Name: VaultSecretGroup.vaultCertificates
        /// </summary>
        public IList<VaultCertificate> VaultCertificates { get; }
    }
}
