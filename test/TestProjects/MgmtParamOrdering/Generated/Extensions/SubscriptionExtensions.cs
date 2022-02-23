// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace MgmtParamOrdering
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    public static partial class SubscriptionExtensions
    {
        private static SubscriptionExtensionClient GetExtensionClient(Subscription subscription)
        {
            return subscription.GetCachedClient((client) =>
            {
                return new SubscriptionExtensionClient(client, subscription.Id);
            }
            );
        }

        /// <summary> Gets a collection of VirtualMachineExtensionImages in the VirtualMachineExtensionImage. </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="publisherName"/> is null. </exception>
        /// <returns> An object representing collection of VirtualMachineExtensionImages and their operations over a VirtualMachineExtensionImage. </returns>
        public static VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(this Subscription subscription, string location, string publisherName)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));

            return GetExtensionClient(subscription).GetVirtualMachineExtensionImages(location, publisherName);
        }

        /// <summary>
        /// Lists all availability sets in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets
        /// Operation Id: AvailabilitySets_ListBySubscription
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySet" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AvailabilitySet> GetAvailabilitySetsAsync(this Subscription subscription, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetAvailabilitySetsAsync(expand, cancellationToken);
        }

        /// <summary>
        /// Lists all availability sets in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets
        /// Operation Id: AvailabilitySets_ListBySubscription
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySet" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<AvailabilitySet> GetAvailabilitySets(this Subscription subscription, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetAvailabilitySets(expand, cancellationToken);
        }
    }
}
