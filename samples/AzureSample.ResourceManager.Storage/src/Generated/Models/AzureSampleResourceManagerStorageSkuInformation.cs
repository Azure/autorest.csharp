// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AzureSample.ResourceManager.Storage.Models
{
    /// <summary> Storage SKU and its properties. </summary>
    public partial class AzureSampleResourceManagerStorageSkuInformation
    {
        /// <summary> Initializes a new instance of <see cref="AzureSampleResourceManagerStorageSkuInformation"/>. </summary>
        /// <param name="name"> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </param>
        internal AzureSampleResourceManagerStorageSkuInformation(AzureSampleResourceManagerStorageSkuName name)
        {
            Name = name;
            Locations = new ChangeTrackingList<string>();
            Capabilities = new ChangeTrackingList<SKUCapability>();
            Restrictions = new ChangeTrackingList<Restriction>();
        }

        /// <summary> Initializes a new instance of <see cref="AzureSampleResourceManagerStorageSkuInformation"/>. </summary>
        /// <param name="name"> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </param>
        /// <param name="tier"> The SKU tier. This is based on the SKU name. </param>
        /// <param name="resourceType"> The type of the resource, usually it is 'storageAccounts'. </param>
        /// <param name="kind"> Indicates the type of storage account. </param>
        /// <param name="locations"> The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). </param>
        /// <param name="capabilities"> The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </param>
        /// <param name="restrictions"> The restrictions because of which SKU cannot be used. This is empty if there are no restrictions. </param>
        internal AzureSampleResourceManagerStorageSkuInformation(AzureSampleResourceManagerStorageSkuName name, AzureSampleResourceManagerStorageSkuTier? tier, ResourceType? resourceType, AzureSampleResourceManagerStorageKind? kind, IReadOnlyList<string> locations, IReadOnlyList<SKUCapability> capabilities, IReadOnlyList<Restriction> restrictions)
        {
            Name = name;
            Tier = tier;
            ResourceType = resourceType;
            Kind = kind;
            Locations = locations;
            Capabilities = capabilities;
            Restrictions = restrictions;
        }

        /// <summary> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </summary>
        public AzureSampleResourceManagerStorageSkuName Name { get; }
        /// <summary> The SKU tier. This is based on the SKU name. </summary>
        public AzureSampleResourceManagerStorageSkuTier? Tier { get; }
        /// <summary> The type of the resource, usually it is 'storageAccounts'. </summary>
        public ResourceType? ResourceType { get; }
        /// <summary> Indicates the type of storage account. </summary>
        public AzureSampleResourceManagerStorageKind? Kind { get; }
        /// <summary> The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). </summary>
        public IReadOnlyList<string> Locations { get; }
        /// <summary> The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </summary>
        public IReadOnlyList<SKUCapability> Capabilities { get; }
        /// <summary> The restrictions because of which SKU cannot be used. This is empty if there are no restrictions. </summary>
        public IReadOnlyList<Restriction> Restrictions { get; }
    }
}
