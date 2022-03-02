// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Describes a set of certificates which are all in the same Key Vault. </summary>
    public partial class VaultSecretGroup
    {
        /// <summary> Initializes a new instance of VaultSecretGroup. </summary>
        public VaultSecretGroup()
        {
            VaultCertificates = new ChangeTrackingList<VaultCertificate>();
        }

        /// <summary> Initializes a new instance of VaultSecretGroup. </summary>
        /// <param name="sourceVault"> The relative URL of the Key Vault containing all of the certificates in VaultCertificates. </param>
        /// <param name="vaultCertificates"> The list of key vault references in SourceVault which contain certificates. </param>
        internal VaultSecretGroup(WritableSubResource sourceVault, IList<VaultCertificate> vaultCertificates)
        {
            SourceVault = sourceVault;
            VaultCertificates = vaultCertificates;
        }

        /// <summary> The relative URL of the Key Vault containing all of the certificates in VaultCertificates. </summary>
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

        /// <summary> The list of key vault references in SourceVault which contain certificates. </summary>
        public IList<VaultCertificate> VaultCertificates { get; }
    }
}
