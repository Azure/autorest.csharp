// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A class representing the ManagedHsm data model.
    /// Resource information with extended details.
    /// </summary>
    public partial class ManagedHsmData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of ManagedHsmData. </summary>
        /// <param name="location"> The location. </param>
        public ManagedHsmData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of ManagedHsmData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Properties of the managed HSM. </param>
        /// <param name="sku"> SKU details. </param>
        internal ManagedHsmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedHsmProperties properties, ManagedHsmSku sku) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            Sku = sku;
        }

        /// <summary> Properties of the managed HSM. </summary>
        public ManagedHsmProperties Properties { get; set; }
        /// <summary> SKU details. </summary>
        public ManagedHsmSku Sku { get; set; }
    }
}
