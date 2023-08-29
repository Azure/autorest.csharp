// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Storage SKU and its properties. </summary>
    public partial class StorageSkuInformation
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="StorageSkuInformation"/>. </summary>
        /// <param name="name"> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </param>
        internal StorageSkuInformation(StorageSkuName name)
        {
            Name = name;
            Locations = new ChangeTrackingList<string>();
            Capabilities = new ChangeTrackingList<SKUCapability>();
            Restrictions = new ChangeTrackingList<Restriction>();
        }

        /// <summary> Initializes a new instance of <see cref="StorageSkuInformation"/>. </summary>
        /// <param name="name"> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </param>
        /// <param name="tier"> The SKU tier. This is based on the SKU name. </param>
        /// <param name="resourceType"> The type of the resource, usually it is 'storageAccounts'. </param>
        /// <param name="kind"> Indicates the type of storage account. </param>
        /// <param name="locations"> The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). </param>
        /// <param name="capabilities"> The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </param>
        /// <param name="restrictions"> The restrictions because of which SKU cannot be used. This is empty if there are no restrictions. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StorageSkuInformation(StorageSkuName name, StorageSkuTier? tier, ResourceType? resourceType, StorageKind? kind, IReadOnlyList<string> locations, IReadOnlyList<SKUCapability> capabilities, IReadOnlyList<Restriction> restrictions, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            Tier = tier;
            ResourceType = resourceType;
            Kind = kind;
            Locations = locations;
            Capabilities = capabilities;
            Restrictions = restrictions;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="StorageSkuInformation"/> for deserialization. </summary>
        internal StorageSkuInformation()
        {
        }

        /// <summary> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </summary>
        public StorageSkuName Name { get; }
        /// <summary> The SKU tier. This is based on the SKU name. </summary>
        public StorageSkuTier? Tier { get; }
        /// <summary> The type of the resource, usually it is 'storageAccounts'. </summary>
        public ResourceType? ResourceType { get; }
        /// <summary> Indicates the type of storage account. </summary>
        public StorageKind? Kind { get; }
        /// <summary> The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). </summary>
        public IReadOnlyList<string> Locations { get; }
        /// <summary> The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </summary>
        public IReadOnlyList<SKUCapability> Capabilities { get; }
        /// <summary> The restrictions because of which SKU cannot be used. This is empty if there are no restrictions. </summary>
        public IReadOnlyList<Restriction> Restrictions { get; }
    }
}
