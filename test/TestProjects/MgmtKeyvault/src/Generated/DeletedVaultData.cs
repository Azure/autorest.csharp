// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtKeyvault.Models;

namespace MgmtKeyvault
{
    /// <summary> A class representing the DeletedVault data model. </summary>
    public partial class DeletedVaultData : ResourceData
    {
        /// <summary> Initializes a new instance of DeletedVaultData. </summary>
        internal DeletedVaultData()
        {
        }

        /// <summary> Initializes a new instance of DeletedVaultData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> Properties of the vault. </param>
        internal DeletedVaultData(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, DeletedVaultProperties properties) : base(id, name, type, systemData)
        {
            Properties = properties;
        }

        /// <summary> Properties of the vault. </summary>
        public DeletedVaultProperties Properties { get; }
    }
}
