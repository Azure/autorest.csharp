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
using Azure.ResourceManager.Resources;
using MgmtCustomizations.Mocking;

namespace MgmtCustomizations
{
    /// <summary> A class to add extension methods to MgmtCustomizations. </summary>
    public static partial class MgmtCustomizationsExtensions
    {
        private static MockableMgmtCustomizationsArmClient GetMockableMgmtCustomizationsArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableMgmtCustomizationsArmClient(client0));
        }

        private static MockableMgmtCustomizationsResourceGroupResource GetMockableMgmtCustomizationsResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtCustomizationsResourceGroupResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="PetStoreResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PetStoreResource.CreateResourceIdentifier" /> to create a <see cref="PetStoreResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtCustomizationsArmClient.GetPetStoreResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="PetStoreResource" /> object. </returns>
        public static PetStoreResource GetPetStoreResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtCustomizationsArmClient(client).GetPetStoreResource(id);
        }

        /// <summary>
        /// Gets a collection of PetStoreResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtCustomizationsResourceGroupResource.GetPetStores()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of PetStoreResources and their operations over a PetStoreResource. </returns>
        public static PetStoreCollection GetPetStores(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtCustomizationsResourceGroupResource(resourceGroupResource).GetPetStores();
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtCustomizationsResourceGroupResource.GetPetStoreAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<PetStoreResource>> GetPetStoreAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableMgmtCustomizationsResourceGroupResource(resourceGroupResource).GetPetStoreAsync(name, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtCustomizationsResourceGroupResource.GetPetStore(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<PetStoreResource> GetPetStore(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtCustomizationsResourceGroupResource(resourceGroupResource).GetPetStore(name, cancellationToken);
        }
    }
}
