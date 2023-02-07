// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtPropertyBag
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
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

        /// <summary> Gets a collection of FooResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of FooResources and their operations over a FooResource. </returns>
        public virtual FooCollection GetFoos()
        {
            return GetCachedClient(Client => new FooCollection(Client, Id));
        }

        /// <summary> Gets a collection of BarResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of BarResources and their operations over a BarResource. </returns>
        public virtual BarCollection GetBars()
        {
            return GetCachedClient(Client => new BarCollection(Client, Id));
        }
    }
}
