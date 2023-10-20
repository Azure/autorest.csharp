// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ProviderOperationData"/>. </summary>
        internal ProviderOperationData()
        {
            ResourceTypes = new ChangeTrackingList<Models.ResourceType>();
            Operations = new ChangeTrackingList<ResourceOperation>();
        }

        /// <summary> Initializes a new instance of <see cref="ProviderOperationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="displayName"> The provider display name. </param>
        /// <param name="resourceTypes"> The provider resource types. </param>
        /// <param name="operations"> The provider operations. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ProviderOperationData(ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, SystemData systemData, string displayName, IReadOnlyList<Models.ResourceType> resourceTypes, IReadOnlyList<ResourceOperation> operations, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            DisplayName = displayName;
            ResourceTypes = resourceTypes;
            Operations = operations;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The provider display name. </summary>
        public string DisplayName { get; }
        /// <summary> The provider resource types. </summary>
        public IReadOnlyList<Models.ResourceType> ResourceTypes { get; }
        /// <summary> The provider operations. </summary>
        public IReadOnlyList<ResourceOperation> Operations { get; }
    }
}
