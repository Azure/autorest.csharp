// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtCustomizations
{
    /// <summary> A class to add extension methods to MgmtCustomizations. </summary>
    public static partial class MgmtCustomizationsExtensions
    {
        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ResourceGroupResourceExtensionClient(client, resource.Id);
            });
        }

        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ResourceGroupResourceExtensionClient(client, scope);
            });
        }
        #region PetStoreResource
        /// <summary>
        /// Gets an object representing a <see cref="PetStoreResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PetStoreResource.CreateResourceIdentifier" /> to create a <see cref="PetStoreResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PetStoreResource" /> object. </returns>
        public static PetStoreResource GetPetStoreResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PetStoreResource.ValidateResourceId(id);
                return new PetStoreResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of PetStoreResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of PetStoreResources and their operations over a PetStoreResource. </returns>
        public static PetStoreCollection GetPetStores(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetPetStores();
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PetStoreResource>> GetPetStoreAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetPetStores().GetAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<PetStoreResource> GetPetStore(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetPetStores().Get(name, cancellationToken);
        }
    }
}
