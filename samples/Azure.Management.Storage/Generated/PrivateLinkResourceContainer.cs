// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of PrivateLinkResource and their operations over a [ParentResource]. </summary>
    public partial class PrivateLinkResourceContainer
    {
        /// <summary> Initializes a new instance of PrivateLinkResourceContainer for mocking. </summary>
        protected PrivateLinkResourceContainer()
        {
        }

        internal PrivateLinkResourceContainer(ResourceGroupOperations resourceGroup)
        {
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected ResourceType ValidResourceType => StorageAccountOperations.ResourceType;
    }
}
