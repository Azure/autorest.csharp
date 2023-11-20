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
using MgmtExtensionCommonRestOperation.Mocking;

namespace MgmtExtensionCommonRestOperation
{
    /// <summary> A class to add extension methods to MgmtExtensionCommonRestOperation. </summary>
    public static partial class MgmtExtensionCommonRestOperationExtensions
    {
        private static MockableMgmtExtensionCommonRestOperationArmClient GetMockableMgmtExtensionCommonRestOperationArmClient(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MockableMgmtExtensionCommonRestOperationArmClient(client0));
        }

        private static MockableMgmtExtensionCommonRestOperationResourceGroupResource GetMockableMgmtExtensionCommonRestOperationResourceGroupResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtExtensionCommonRestOperationResourceGroupResource(client, resource.Id));
        }

        private static MockableMgmtExtensionCommonRestOperationSubscriptionResource GetMockableMgmtExtensionCommonRestOperationSubscriptionResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableMgmtExtensionCommonRestOperationSubscriptionResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="TypeOneResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TypeOneResource.CreateResourceIdentifier" /> to create a <see cref="TypeOneResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationArmClient.GetTypeOneResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="TypeOneResource" /> object. </returns>
        public static TypeOneResource GetTypeOneResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtExtensionCommonRestOperationArmClient(client).GetTypeOneResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="TypeTwoResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TypeTwoResource.CreateResourceIdentifier" /> to create a <see cref="TypeTwoResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationArmClient.GetTypeTwoResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="TypeTwoResource" /> object. </returns>
        public static TypeTwoResource GetTypeTwoResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMgmtExtensionCommonRestOperationArmClient(client).GetTypeTwoResource(id);
        }

        /// <summary>
        /// Gets a collection of TypeOneResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationResourceGroupResource.GetTypeOnes()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of TypeOneResources and their operations over a TypeOneResource. </returns>
        public static TypeOneCollection GetTypeOnes(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtExtensionCommonRestOperationResourceGroupResource(resourceGroupResource).GetTypeOnes();
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationResourceGroupResource.GetTypeOneAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="typeOneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<TypeOneResource>> GetTypeOneAsync(this ResourceGroupResource resourceGroupResource, string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableMgmtExtensionCommonRestOperationResourceGroupResource(resourceGroupResource).GetTypeOneAsync(typeOneName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeOne</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationResourceGroupResource.GetTypeOne(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="typeOneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<TypeOneResource> GetTypeOne(this ResourceGroupResource resourceGroupResource, string typeOneName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtExtensionCommonRestOperationResourceGroupResource(resourceGroupResource).GetTypeOne(typeOneName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of TypeTwoResources in the ResourceGroupResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationResourceGroupResource.GetTypeTwos()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
        /// <returns> An object representing collection of TypeTwoResources and their operations over a TypeTwoResource. </returns>
        public static TypeTwoCollection GetTypeTwos(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtExtensionCommonRestOperationResourceGroupResource(resourceGroupResource).GetTypeTwos();
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationResourceGroupResource.GetTypeTwoAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="typeTwoName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<TypeTwoResource>> GetTypeTwoAsync(this ResourceGroupResource resourceGroupResource, string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return await GetMockableMgmtExtensionCommonRestOperationResourceGroupResource(resourceGroupResource).GetTypeTwoAsync(typeTwoName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_GetTypeTwo</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationResourceGroupResource.GetTypeTwo(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> or <paramref name="typeTwoName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<TypeTwoResource> GetTypeTwo(this ResourceGroupResource resourceGroupResource, string typeTwoName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMgmtExtensionCommonRestOperationResourceGroupResource(resourceGroupResource).GetTypeTwo(typeTwoName, cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeOnesBySubscription</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationSubscriptionResource.GetTypeOnes(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="TypeOneResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<TypeOneResource> GetTypeOnesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMgmtExtensionCommonRestOperationSubscriptionResource(subscriptionResource).GetTypeOnesAsync(cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeOnesBySubscription</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationSubscriptionResource.GetTypeOnes(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="TypeOneResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<TypeOneResource> GetTypeOnes(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMgmtExtensionCommonRestOperationSubscriptionResource(subscriptionResource).GetTypeOnes(cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeTwosBySubscription</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationSubscriptionResource.GetTypeTwos(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="TypeTwoResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<TypeTwoResource> GetTypeTwosAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMgmtExtensionCommonRestOperationSubscriptionResource(subscriptionResource).GetTypeTwosAsync(cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeTwosBySubscription</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableMgmtExtensionCommonRestOperationSubscriptionResource.GetTypeTwos(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="TypeTwoResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<TypeTwoResource> GetTypeTwos(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMgmtExtensionCommonRestOperationSubscriptionResource(subscriptionResource).GetTypeTwos(cancellationToken);
        }
    }
}
