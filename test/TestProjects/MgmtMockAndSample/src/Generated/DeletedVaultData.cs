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
    /// <summary>
    /// A class representing the DeletedVault data model.
    /// Deleted vault information with extended details.
    /// </summary>
    public partial class DeletedVaultData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="DeletedVaultData"/>. </summary>
        internal DeletedVaultData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeletedVaultData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> Properties of the vault. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DeletedVaultData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DeletedVaultProperties properties, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData)
        {
            Properties = properties;
            _rawData = rawData;
        }

        /// <summary> Properties of the vault. </summary>
        public DeletedVaultProperties Properties { get; }
    }
}
