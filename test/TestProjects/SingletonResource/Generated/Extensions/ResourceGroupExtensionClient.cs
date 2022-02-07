// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace SingletonResource
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    internal partial class ResourceGroupExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            Client.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of Cars in the Car. </summary>
        /// <returns> An object representing collection of Cars and their operations over a Car. </returns>
        public virtual CarCollection GetCars()
        {
            return new CarCollection(Client, Id);
        }

        /// <summary> Gets a collection of ParentResources in the ParentResource. </summary>
        /// <returns> An object representing collection of ParentResources and their operations over a ParentResource. </returns>
        public virtual ParentResourceCollection GetParentResources()
        {
            return new ParentResourceCollection(Client, Id);
        }
    }
}
