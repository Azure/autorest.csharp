// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtCustomizations.Models;

namespace MgmtCustomizations
{
    /// <summary>
    /// A class representing the PetStore data model.
    /// A pet store
    /// </summary>
    public partial class PetStoreData : ResourceData
    {
        /// <summary> Initializes a new instance of PetStoreData. </summary>
        public PetStoreData()
        {
        }

        /// <summary> Initializes a new instance of PetStoreData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> The properties. </param>
        internal PetStoreData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, PetStoreProperties properties) : base(id, name, resourceType, systemData)
        {
            Properties = properties;
        }

        /// <summary> The properties. </summary>
        public PetStoreProperties Properties { get; set; }
    }
}
