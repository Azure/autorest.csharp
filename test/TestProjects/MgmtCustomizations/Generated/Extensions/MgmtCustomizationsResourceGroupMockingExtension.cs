// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using MgmtCustomizations;

namespace MgmtCustomizations.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MgmtCustomizationsResourceGroupMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MgmtCustomizationsResourceGroupMockingExtension"/> class for mocking. </summary>
        protected MgmtCustomizationsResourceGroupMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtCustomizationsResourceGroupMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtCustomizationsResourceGroupMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of PetStoreResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PetStoreResources and their operations over a PetStoreResource. </returns>
        public virtual PetStoreCollection GetPetStores()
        {
            return GetCachedClient(client => new PetStoreCollection(client, Id));
        }

        /// <summary>
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Pets/petStore/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PetStores_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<PetStoreResource>> GetPetStoreAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetPetStores().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Pets/petStore/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PetStores_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<PetStoreResource> GetPetStore(string name, CancellationToken cancellationToken = default)
        {
            return GetPetStores().Get(name, cancellationToken);
        }
    }
}
