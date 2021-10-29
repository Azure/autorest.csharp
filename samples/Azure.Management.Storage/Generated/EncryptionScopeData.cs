// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Management.Storage.Models;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;

namespace Azure.Management.Storage
{
    /// <summary> A class representing the EncryptionScope data model. </summary>
    public partial class EncryptionScopeData : Resource
    {
        /// <summary> Initializes a new instance of EncryptionScopeData. </summary>
        public EncryptionScopeData()
        {
        }

        /// <summary> Initializes a new instance of EncryptionScopeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="source"> The provider for the encryption scope. Possible values (case-insensitive):  Microsoft.Storage, Microsoft.KeyVault. </param>
        /// <param name="state"> The state of the encryption scope. Possible values (case-insensitive):  Enabled, Disabled. </param>
        /// <param name="creationTime"> Gets the creation date and time of the encryption scope in UTC. </param>
        /// <param name="lastModifiedTime"> Gets the last modification date and time of the encryption scope in UTC. </param>
        /// <param name="keyVaultProperties"> The key vault properties for the encryption scope. This is a required field if encryption scope &apos;source&apos; attribute is set to &apos;Microsoft.KeyVault&apos;. </param>
        /// <param name="requireInfrastructureEncryption"> A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest. </param>
        internal EncryptionScopeData(ResourceIdentifier id, string name, ResourceType type, EncryptionScopeSource? source, EncryptionScopeState? state, DateTimeOffset? creationTime, DateTimeOffset? lastModifiedTime, EncryptionScopeKeyVaultProperties keyVaultProperties, bool? requireInfrastructureEncryption) : base(id, name, type)
        {
            Source = source;
            State = state;
            CreationTime = creationTime;
            LastModifiedTime = lastModifiedTime;
            KeyVaultProperties = keyVaultProperties;
            RequireInfrastructureEncryption = requireInfrastructureEncryption;
        }

        /// <summary> The provider for the encryption scope. Possible values (case-insensitive):  Microsoft.Storage, Microsoft.KeyVault. </summary>
        public EncryptionScopeSource? Source { get; set; }
        /// <summary> The state of the encryption scope. Possible values (case-insensitive):  Enabled, Disabled. </summary>
        public EncryptionScopeState? State { get; set; }
        /// <summary> Gets the creation date and time of the encryption scope in UTC. </summary>
        public DateTimeOffset? CreationTime { get; }
        /// <summary> Gets the last modification date and time of the encryption scope in UTC. </summary>
        public DateTimeOffset? LastModifiedTime { get; }
        /// <summary> The key vault properties for the encryption scope. This is a required field if encryption scope &apos;source&apos; attribute is set to &apos;Microsoft.KeyVault&apos;. </summary>
        public EncryptionScopeKeyVaultProperties KeyVaultProperties { get; set; }
        /// <summary> A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest. </summary>
        public bool? RequireInfrastructureEncryption { get; set; }
    }
}
