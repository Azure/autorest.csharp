// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.ResourceManager.Resources;

namespace MgmtParamOrdering
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    public static partial class SubscriptionExtensions
    {
        #region VirtualMachineExtensionImage
        /// <summary> Gets an object representing a VirtualMachineExtensionImageCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <returns> Returns a <see cref="VirtualMachineExtensionImageCollection" /> object. </returns>
        public static VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(this Subscription subscription, string location, string publisherName)
        {
            return new VirtualMachineExtensionImageCollection(subscription, location, publisherName);
        }
        #endregion

        private static SubscriptionExtensionClient GetExtensionClient(Subscription subscription)
        {
            return subscription.GetCachedClient((armClient) =>
            {
                return new SubscriptionExtensionClient(armClient, subscription.Id);
            }
            );
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: AvailabilitySets_ListBySubscription
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AvailabilitySet> GetAvailabilitySetsAsync(this Subscription subscription, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetAvailabilitySetsAsync(expand, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: AvailabilitySets_ListBySubscription
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<AvailabilitySet> GetAvailabilitySets(this Subscription subscription, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetAvailabilitySets(expand, cancellationToken);
        }

        /// <summary> Filters the list of AvailabilitySets for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<GenericResource> GetAvailabilitySetsAsGenericResourcesAsync(this Subscription subscription, string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetAvailabilitySetsAsGenericResourcesAsync(filter, expand, top, cancellationToken);
        }

        /// <summary> Filters the list of AvailabilitySets for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<GenericResource> GetAvailabilitySetsAsGenericResources(this Subscription subscription, string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetAvailabilitySetsAsGenericResources(filter, expand, top, cancellationToken);
        }
    }
}
