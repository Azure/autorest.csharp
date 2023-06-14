// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtResourceName.Models;

namespace MgmtResourceName
{
    /// <summary>
    /// A class representing the ProviderOperation data model.
    /// Provider Operations metadata
    /// </summary>
    public partial class ProviderOperationData : ResourceData
    {
        /// <summary> Initializes a new instance of ProviderOperationData. </summary>
        internal ProviderOperationData()
        {
            ResourceTypes = new ChangeTrackingList<Models.ResourceType>();
            Operations = new ChangeTrackingList<ResourceOperation>();
        }

        /// <summary> Initializes a new instance of ProviderOperationData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="displayName"> The provider display name. </param>
        /// <param name="resourceTypes"> The provider resource types. </param>
        /// <param name="operations"> The provider operations. </param>
        internal ProviderOperationData(ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, SystemData systemData, string displayName, IReadOnlyList<Models.ResourceType> resourceTypes, IReadOnlyList<ResourceOperation> operations) : base(id, name, resourceType, systemData)
        {
            DisplayName = displayName;
            ResourceTypes = resourceTypes;
            Operations = operations;
        }

        /// <summary> The provider display name. </summary>
        public string DisplayName { get; }
        /// <summary> The provider resource types. </summary>
        public IReadOnlyList<Models.ResourceType> ResourceTypes { get; }
        /// <summary> The provider operations. </summary>
        public IReadOnlyList<ResourceOperation> Operations { get; }
    }
}
