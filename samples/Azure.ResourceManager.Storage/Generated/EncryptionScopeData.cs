// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing the EncryptionScope data model.
    /// The Encryption Scope resource.
    /// </summary>
    public partial class EncryptionScopeData : ResourceData
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.EncryptionScopeData
        ///
        /// </summary>
        public EncryptionScopeData()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.EncryptionScopeData
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="source"> The provider for the encryption scope. Possible values (case-insensitive):  Microsoft.Storage, Microsoft.KeyVault. </param>
        /// <param name="state"> The state of the encryption scope. Possible values (case-insensitive):  Enabled, Disabled. </param>
        /// <param name="createdOn"> Gets the creation date and time of the encryption scope in UTC. </param>
        /// <param name="lastModifiedOn"> Gets the last modification date and time of the encryption scope in UTC. </param>
        /// <param name="keyVaultProperties"> The key vault properties for the encryption scope. This is a required field if encryption scope 'source' attribute is set to 'Microsoft.KeyVault'. </param>
        /// <param name="requireInfrastructureEncryption"> A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal EncryptionScopeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, EncryptionScopeSource? source, EncryptionScopeState? state, DateTimeOffset? createdOn, DateTimeOffset? lastModifiedOn, EncryptionScopeKeyVaultProperties keyVaultProperties, bool? requireInfrastructureEncryption, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData)
        {
            Source = source;
            State = state;
            CreatedOn = createdOn;
            LastModifiedOn = lastModifiedOn;
            KeyVaultProperties = keyVaultProperties;
            RequireInfrastructureEncryption = requireInfrastructureEncryption;
            _rawData = rawData;
        }

        /// <summary> The provider for the encryption scope. Possible values (case-insensitive):  Microsoft.Storage, Microsoft.KeyVault. </summary>
        public EncryptionScopeSource? Source { get; set; }
        /// <summary> The state of the encryption scope. Possible values (case-insensitive):  Enabled, Disabled. </summary>
        public EncryptionScopeState? State { get; set; }
        /// <summary> Gets the creation date and time of the encryption scope in UTC. </summary>
        public DateTimeOffset? CreatedOn { get; }
        /// <summary> Gets the last modification date and time of the encryption scope in UTC. </summary>
        public DateTimeOffset? LastModifiedOn { get; }
        /// <summary> The key vault properties for the encryption scope. This is a required field if encryption scope 'source' attribute is set to 'Microsoft.KeyVault'. </summary>
        public EncryptionScopeKeyVaultProperties KeyVaultProperties { get; set; }
        /// <summary> A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest. </summary>
        public bool? RequireInfrastructureEncryption { get; set; }
    }
}
