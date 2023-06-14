// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A class representing the DiskEncryptionSet data model.
    /// disk encryption set resource.
    /// </summary>
    public partial class DiskEncryptionSetData : ResourceData
    {
        /// <summary> Initializes a new instance of DiskEncryptionSetData. </summary>
        public DiskEncryptionSetData()
        {
            PreviousKeys = new ChangeTrackingList<KeyForDiskEncryptionSet>();
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of DiskEncryptionSetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identity"> Identity for the virtual machine. </param>
        /// <param name="encryptionType"> The type of key used to encrypt the data of the disk. </param>
        /// <param name="activeKey"> The key vault key which is currently used by this disk encryption set. </param>
        /// <param name="previousKeys"> A readonly collection of key vault keys previously used by this disk encryption set while a key rotation is in progress. It will be empty if there is no ongoing key rotation. </param>
        /// <param name="provisioningState"> The disk encryption set provisioning state. </param>
        /// <param name="rotationToLatestKeyVersionEnabled"> Set this flag to true to enable auto-updating of this disk encryption set to the latest key version. </param>
        /// <param name="lastKeyRotationTimestamp"> The time when the active key of this disk encryption set was updated. </param>
        /// <param name="federatedClientId"> Multi-tenant application client id to access key vault in a different tenant. Setting the value to 'None' will clear the property. </param>
        /// <param name="minimumTlsVersion"> The minimum tls version. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        internal DiskEncryptionSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ManagedServiceIdentity identity, DiskEncryptionSetType? encryptionType, KeyForDiskEncryptionSet activeKey, IReadOnlyList<KeyForDiskEncryptionSet> previousKeys, string provisioningState, bool? rotationToLatestKeyVersionEnabled, DateTimeOffset? lastKeyRotationTimestamp, string federatedClientId, MinimumTlsVersion? minimumTlsVersion, AzureLocation? location, IReadOnlyDictionary<string, string> tags) : base(id, name, resourceType, systemData)
        {
            Identity = identity;
            EncryptionType = encryptionType;
            ActiveKey = activeKey;
            PreviousKeys = previousKeys;
            ProvisioningState = provisioningState;
            RotationToLatestKeyVersionEnabled = rotationToLatestKeyVersionEnabled;
            LastKeyRotationTimestamp = lastKeyRotationTimestamp;
            FederatedClientId = federatedClientId;
            MinimumTlsVersion = minimumTlsVersion;
            Location = location;
            Tags = tags;
        }

        /// <summary> Identity for the virtual machine. </summary>
        public ManagedServiceIdentity Identity { get; set; }
        /// <summary> The type of key used to encrypt the data of the disk. </summary>
        public DiskEncryptionSetType? EncryptionType { get; set; }
        /// <summary> The key vault key which is currently used by this disk encryption set. </summary>
        public KeyForDiskEncryptionSet ActiveKey { get; set; }
        /// <summary> A readonly collection of key vault keys previously used by this disk encryption set while a key rotation is in progress. It will be empty if there is no ongoing key rotation. </summary>
        public IReadOnlyList<KeyForDiskEncryptionSet> PreviousKeys { get; }
        /// <summary> The disk encryption set provisioning state. </summary>
        public string ProvisioningState { get; }
        /// <summary> Set this flag to true to enable auto-updating of this disk encryption set to the latest key version. </summary>
        public bool? RotationToLatestKeyVersionEnabled { get; set; }
        /// <summary> The time when the active key of this disk encryption set was updated. </summary>
        public DateTimeOffset? LastKeyRotationTimestamp { get; }
        /// <summary> Multi-tenant application client id to access key vault in a different tenant. Setting the value to 'None' will clear the property. </summary>
        public string FederatedClientId { get; set; }
        /// <summary> The minimum tls version. </summary>
        public MinimumTlsVersion? MinimumTlsVersion { get; set; }
        /// <summary> Azure location of the key vault resource. </summary>
        public AzureLocation? Location { get; }
        /// <summary> Tags assigned to the key vault resource. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
