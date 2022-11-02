// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    /// <summary> A class representing the Vault data model. </summary>
    public partial class VaultData : ResourceData
    {
        /// <summary> Initializes a new instance of VaultData. </summary>
        /// <param name="properties"> Properties of the vault. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        internal VaultData(VaultProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Tags = new ChangeTrackingDictionary<string, string>();
            Properties = properties;
        }

        /// <summary> Initializes a new instance of VaultData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        /// <param name="properties"> Properties of the vault. </param>
        /// <param name="identity"> Identity of the vault. </param>
        internal VaultData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, IReadOnlyDictionary<string, string> tags, VaultProperties properties, ManagedServiceIdentity identity) : base(id, name, resourceType, systemData)
        {
            Location = location;
            Tags = tags;
            Properties = properties;
            Identity = identity;
        }

        /// <summary> Azure location of the key vault resource. </summary>
        public AzureLocation? Location { get; }
        /// <summary> Tags assigned to the key vault resource. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
        /// <summary> Properties of the vault. </summary>
        public VaultProperties Properties { get; }
        /// <summary> Identity of the vault. </summary>
        public ManagedServiceIdentity Identity { get; }
    }
}
