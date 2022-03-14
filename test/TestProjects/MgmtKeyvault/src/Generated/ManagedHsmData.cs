// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtKeyvault.Models;

namespace MgmtKeyvault
{
    /// <summary> A class representing the ManagedHsm data model. </summary>
    public partial class ManagedHsmData : ManagedHsmResource
    {
        /// <summary> Initializes a new instance of ManagedHsmData. </summary>
        /// <param name="location"> The location. </param>
        public ManagedHsmData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of ManagedHsmData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> SKU details. </param>
        /// <param name="properties"> Properties of the managed HSM. </param>
        internal ManagedHsmData(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedHsmSku sku, ManagedHsmProperties properties) : base(id, name, type, systemData, tags, location, sku)
        {
            Properties = properties;
        }

        /// <summary> Properties of the managed HSM. </summary>
        public ManagedHsmProperties Properties { get; set; }
    }
}
