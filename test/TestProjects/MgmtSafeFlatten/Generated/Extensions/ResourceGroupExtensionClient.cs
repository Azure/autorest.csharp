// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace MgmtSafeFlatten
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
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of TypeOneResources in the TypeOneResource. </summary>
        /// <returns> An object representing collection of TypeOneResources and their operations over a TypeOneResource. </returns>
        public virtual TypeOneCollection GetTypeOnes()
        {
            return GetCachedClient(Client => new TypeOneCollection(Client, Id));
        }

        /// <summary> Gets a collection of TypeTwoResources in the TypeTwoResource. </summary>
        /// <returns> An object representing collection of TypeTwoResources and their operations over a TypeTwoResource. </returns>
        public virtual TypeTwoCollection GetTypeTwos()
        {
            return GetCachedClient(Client => new TypeTwoCollection(Client, Id));
        }
    }
}
