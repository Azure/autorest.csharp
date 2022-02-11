// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Resources;
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
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

        /// <summary>
        /// Lists the DNS zones in all resource groups in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/dnszones
        /// Operation Id: Zones_List
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="top"> The maximum number of DNS zones to return. If not specified, returns up to 100 zones. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Zone" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<Zone> GetZonesByDnszoneAsync(this Subscription subscription, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetZonesByDnszoneAsync(top, cancellationToken);
        }

        /// <summary>
        /// Lists the DNS zones in all resource groups in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/dnszones
        /// Operation Id: Zones_List
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="top"> The maximum number of DNS zones to return. If not specified, returns up to 100 zones. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Zone" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<Zone> GetZonesByDnszone(this Subscription subscription, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscription).GetZonesByDnszone(top, cancellationToken);
        }

        /// <summary>
        /// Returns the DNS records specified by the referencing targetResourceIds.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/getDnsResourceReference
        /// Operation Id: DnsResourceReference_GetByTargetResources
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="parameters"> Properties for dns resource reference request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async static Task<Response<DnsResourceReferenceResult>> GetByTargetResourcesDnsResourceReferenceAsync(this Subscription subscription, DnsResourceReferenceRequest parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return await GetExtensionClient(subscription).GetByTargetResourcesDnsResourceReferenceAsync(parameters, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the DNS records specified by the referencing targetResourceIds.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/getDnsResourceReference
        /// Operation Id: DnsResourceReference_GetByTargetResources
        /// </summary>
        /// <param name="subscription"> The <see cref="Subscription" /> instance the method will execute against. </param>
        /// <param name="parameters"> Properties for dns resource reference request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public static Response<DnsResourceReferenceResult> GetByTargetResourcesDnsResourceReference(this Subscription subscription, DnsResourceReferenceRequest parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return GetExtensionClient(subscription).GetByTargetResourcesDnsResourceReference(parameters, cancellationToken);
        }
    }
}
