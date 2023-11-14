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
using MgmtOmitOperationGroups.Mocking;
using MgmtOmitOperationGroups.Models;

namespace MgmtOmitOperationGroups
{
    /// <summary> A class to add extension methods to MgmtOmitOperationGroups. </summary>
    public static partial class MgmtOmitOperationGroupsExtensions
    {
        private static MockableMgmtOmitOperationGroupsArmClient GetMockableMgmtOmitOperationGroupsArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableMgmtOmitOperationGroupsArmClient(client0));
        }

        private static MockableMgmtOmitOperationGroupsResourceGroupResource GetMockableMgmtOmitOperationGroupsResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtOmitOperationGroupsResourceGroupResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="Model2Resource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="Model2Resource.CreateResourceIdentifier" /> to create a <see cref="Model2Resource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsArmClient.GetModel2Resource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Model2Resource" /> object. </returns>
        public static Model2Resource GetModel2Resource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableMgmtOmitOperationGroupsArmClient(client).GetModel2Resource(id);
        }

        /// <summary>
        /// Gets a collection of Model2Resources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsResourceGroupResource.GetModel2s()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of Model2Resources and their operations over a Model2Resource. </returns>
        public static Model2Collection GetModel2s(this ResourceGroupResource resourceGroupResource)
        {
            return GetMockableMgmtOmitOperationGroupsResourceGroupResource(resourceGroupResource).GetModel2s();
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsResourceGroupResource.GetModel2Async(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="model2SName"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<Model2Resource>> GetModel2Async(this ResourceGroupResource resourceGroupResource, string model2SName, CancellationToken cancellationToken = default)
        {
            return await GetMockableMgmtOmitOperationGroupsResourceGroupResource(resourceGroupResource).GetModel2Async(model2SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model2s_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsResourceGroupResource.GetModel2(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="model2SName"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="model2SName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<Model2Resource> GetModel2(this ResourceGroupResource resourceGroupResource, string model2SName, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtOmitOperationGroupsResourceGroupResource(resourceGroupResource).GetModel2(model2SName, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model5s_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsResourceGroupResource.GetModel5s(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Model5" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<Model5> GetModel5sAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtOmitOperationGroupsResourceGroupResource(resourceGroupResource).GetModel5sAsync(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model5s_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsResourceGroupResource.GetModel5s(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Model5" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<Model5> GetModel5s(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtOmitOperationGroupsResourceGroupResource(resourceGroupResource).GetModel5s(cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model5s_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsResourceGroupResource.CreateOrUpdateModel5(string,Model5,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The string to use. </param>
        /// <param name="model5"> The Model5 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> or <paramref name="model5"/> is null. </exception>
        public static async Task<Response<Model5>> CreateOrUpdateModel5Async(this ResourceGroupResource resourceGroupResource, string model5SName, Model5 model5, CancellationToken cancellationToken = default)
        {
            return await GetMockableMgmtOmitOperationGroupsResourceGroupResource(resourceGroupResource).CreateOrUpdateModel5Async(model5SName, model5, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model5s_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsResourceGroupResource.CreateOrUpdateModel5(string,Model5,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The string to use. </param>
        /// <param name="model5"> The Model5 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> or <paramref name="model5"/> is null. </exception>
        public static Response<Model5> CreateOrUpdateModel5(this ResourceGroupResource resourceGroupResource, string model5SName, Model5 model5, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtOmitOperationGroupsResourceGroupResource(resourceGroupResource).CreateOrUpdateModel5(model5SName, model5, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model5s_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsResourceGroupResource.GetModel5(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> is null. </exception>
        public static async Task<Response<Model5>> GetModel5Async(this ResourceGroupResource resourceGroupResource, string model5SName, CancellationToken cancellationToken = default)
        {
            return await GetMockableMgmtOmitOperationGroupsResourceGroupResource(resourceGroupResource).GetModel5Async(model5SName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Model5s_Get</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtOmitOperationGroupsResourceGroupResource.GetModel5(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The string to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="model5SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> is null. </exception>
        public static Response<Model5> GetModel5(this ResourceGroupResource resourceGroupResource, string model5SName, CancellationToken cancellationToken = default)
        {
            return GetMockableMgmtOmitOperationGroupsResourceGroupResource(resourceGroupResource).GetModel5(model5SName, cancellationToken);
        }
    }
}
