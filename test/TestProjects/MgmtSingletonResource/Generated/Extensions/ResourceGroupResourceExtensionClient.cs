// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using MgmtSingletonResource;

namespace MgmtSingletonResource.Mock
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of CarResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of CarResources and their operations over a CarResource. </returns>
        public virtual CarCollection GetCars()
        {
            return GetCachedClient(Client => new CarCollection(Client, Id));
        }

        /// <summary> Gets a collection of ParentResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ParentResources and their operations over a ParentResource. </returns>
        public virtual ParentResourceCollection GetParentResources()
        {
            return GetCachedClient(Client => new ParentResourceCollection(Client, Id));
        }
    }
}
