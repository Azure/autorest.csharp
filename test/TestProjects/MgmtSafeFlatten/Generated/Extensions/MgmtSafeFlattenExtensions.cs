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

namespace MgmtSafeFlatten
{
    /// <summary> A class to add extension methods to MgmtSafeFlatten. </summary>
    public static partial class MgmtSafeFlattenExtensions
    {
        private static SubscriptionExtensionClient GetExtensionClient(Subscription subscription)
        {
            return subscription.GetCachedClient((client) =>
            {
                return new SubscriptionExtensionClient(client, subscription.Id);
            }
            );
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes
        /// Operation Id: Common_ListTypeOnesBySubscription
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeOne" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<TypeOne> GetTypeOnesAsync(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetTypeOnesAsync(cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes
        /// Operation Id: Common_ListTypeOnesBySubscription
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeOne" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<TypeOne> GetTypeOnes(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetTypeOnes(cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos
        /// Operation Id: Common_ListTypeTwosBySubscription
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeTwo" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<TypeTwo> GetTypeTwosAsync(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetTypeTwosAsync(cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos
        /// Operation Id: Common_ListTypeTwosBySubscription
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeTwo" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<TypeTwo> GetTypeTwos(this Subscription subscription, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetTypeTwos(cancellationToken);
        }

        private static ResourceGroupExtensionClient GetExtensionClient(ResourceGroup resourceGroup)
        {
            return resourceGroup.GetCachedClient((client) =>
            {
                return new ResourceGroupExtensionClient(client, resourceGroup.Id);
            }
            );
        }

        /// <summary> Gets a collection of TypeOnes in the ResourceGroup. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of TypeOnes and their operations over a TypeOne. </returns>
        public static TypeOneCollection GetTypeOnes(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetTypeOnes();
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}
        /// Operation Id: Common_GetTypeOne
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public static async Task<Response<TypeOne>> GetTypeOneAsync(this ResourceGroup resourceGroup, string typeOneName, CancellationToken cancellationToken = default)
        {
            return await resourceGroup.GetTypeOnes().GetAsync(typeOneName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}
        /// Operation Id: Common_GetTypeOne
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="typeOneName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeOneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeOneName"/> is null. </exception>
        public static Response<TypeOne> GetTypeOne(this ResourceGroup resourceGroup, string typeOneName, CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetTypeOnes().Get(typeOneName, cancellationToken);
        }

        /// <summary> Gets a collection of TypeTwos in the ResourceGroup. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of TypeTwos and their operations over a TypeTwo. </returns>
        public static TypeTwoCollection GetTypeTwos(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetTypeTwos();
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_GetTypeTwo
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public static async Task<Response<TypeTwo>> GetTypeTwoAsync(this ResourceGroup resourceGroup, string typeTwoName, CancellationToken cancellationToken = default)
        {
            return await resourceGroup.GetTypeTwos().GetAsync(typeTwoName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeTwo/typeTwos/{typeTwoName}
        /// Operation Id: Common_GetTypeTwo
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="typeTwoName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="typeTwoName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="typeTwoName"/> is null. </exception>
        public static Response<TypeTwo> GetTypeTwo(this ResourceGroup resourceGroup, string typeTwoName, CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetTypeTwos().Get(typeTwoName, cancellationToken);
        }

        #region TypeOne
        /// <summary> Gets an object representing a TypeOne along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TypeOne" /> object. </returns>
        public static TypeOne GetTypeOne(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                TypeOne.ValidateResourceId(id);
                return new TypeOne(client, id);
            }
            );
        }
        #endregion

        #region TypeTwo
        /// <summary> Gets an object representing a TypeTwo along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TypeTwo" /> object. </returns>
        public static TypeTwo GetTypeTwo(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                TypeTwo.ValidateResourceId(id);
                return new TypeTwo(client, id);
            }
            );
        }
        #endregion
    }
}
