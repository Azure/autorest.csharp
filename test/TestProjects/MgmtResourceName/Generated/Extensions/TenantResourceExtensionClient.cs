// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtResourceName
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    internal partial class TenantResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="TenantResourceExtensionClient"/> class for mocking. </summary>
        protected TenantResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TenantResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of ProviderOperationResources in the TenantResource. </summary>
        /// <returns> An object representing collection of ProviderOperationResources and their operations over a ProviderOperationResource. </returns>
        public virtual ProviderOperationCollection GetProviderOperations()
        {
            return GetCachedClient(Client => new ProviderOperationCollection(Client, Id));
        }
    }
}
