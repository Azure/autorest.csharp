// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
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
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="PetStoreData"/>. </summary>
        public PetStoreData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PetStoreData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> The properties. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PetStoreData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, PetStoreProperties properties, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData)
        {
            Properties = properties;
            _rawData = rawData;
        }

        /// <summary> The properties. </summary>
        public PetStoreProperties Properties { get; set; }
    }
}
