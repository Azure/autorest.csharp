// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary>
    /// A class representing the ResourceLink data model.
    /// The resource link.
    /// </summary>
    public partial class ResourceLinkData : ResourceData
    {
        /// <summary> Initializes a new instance of ResourceLinkData. </summary>
        public ResourceLinkData()
        {
        }

        /// <summary> Initializes a new instance of ResourceLinkData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> Properties for resource link. </param>
        internal ResourceLinkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceLinkProperties properties) : base(id, name, resourceType, systemData)
        {
            Properties = properties;
        }

        /// <summary> Properties for resource link. </summary>
        public ResourceLinkProperties Properties { get; set; }
    }
}
