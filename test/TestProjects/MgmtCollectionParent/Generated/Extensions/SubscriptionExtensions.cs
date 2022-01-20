// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.ResourceManager.Resources;

namespace MgmtCollectionParent
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    public static partial class SubscriptionExtensions
    {
        private static SubscriptionExtensionClient GetExtensionClient(Subscription subscription)
        {
            return subscription.GetCachedClient((armClient) =>
            {
                return new SubscriptionExtensionClient(armClient, subscription.Id);
            }
            );
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orders
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ListOrderAtSubscriptionLevel
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of order, which provides the next page in the list of order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<OrderResource> GetOrderResourcesAsync(this Subscription subscription, string skipToken = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetOrderResourcesAsync(skipToken, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orders
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ListOrderAtSubscriptionLevel
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of order, which provides the next page in the list of order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<OrderResource> GetOrderResources(this Subscription subscription, string skipToken = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetOrderResources(skipToken, cancellationToken);
        }

        /// <summary> Filters the list of OrderResources for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<GenericResource> GetOrderResourcesAsGenericResourcesAsync(this Subscription subscription, string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetOrderResourcesAsGenericResourcesAsync(filter, expand, top, cancellationToken);
        }

        /// <summary> Filters the list of OrderResources for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<GenericResource> GetOrderResourcesAsGenericResources(this Subscription subscription, string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetOrderResourcesAsGenericResources(filter, expand, top, cancellationToken);
        }
    }
}
