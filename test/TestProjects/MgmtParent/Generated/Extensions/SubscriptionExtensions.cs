// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace MgmtParent
{
    /// <summary> Extension methods for convenient access on SubscriptionOperations in a client. </summary>
    public static partial class SubscriptionExtensions
    {
        #region AvailabilitySet
        private static AvailabilitySetsRestOperations GetAvailabilitySetsRestOperations(ClientDiagnostics clientDiagnostics, TokenCredential credential, ArmClientOptions clientOptions, string subscriptionId, Uri endpoint = null)
        {
            var httpPipeline = ManagementPipelineBuilder.Build(credential, endpoint, clientOptions);
            return new AvailabilitySetsRestOperations(clientDiagnostics, httpPipeline, subscriptionId, endpoint);
        }

        /// <summary> Lists the AvailabilitySets for this Azure.ResourceManager.Core.SubscriptionOperations. </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <return> A collection of resource operations that may take multiple service requests to iterate over. </return>
        public static AsyncPageable<AvailabilitySet> ListAvailabilitySetAsync(this SubscriptionOperations subscription, CancellationToken cancellationToken = default)
        {
            return subscription.ListResources((baseUri, credential, options) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetAvailabilitySetsRestOperations(clientDiagnostics, credential, options, subscription.Id.SubscriptionId, baseUri);
                var result = ListBySubscriptionAsync(clientDiagnostics, restOperations);
                return new PhWrappingAsyncPageable<AvailabilitySetData, AvailabilitySet>(
                result,
                s => new AvailabilitySet(subscription, s));
            }
            );
        }

        /// <summary> Lists all availability sets in a subscription. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="restOperations"> Resource client operations. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private static AsyncPageable<AvailabilitySetData> ListBySubscriptionAsync(ClientDiagnostics clientDiagnostics, AvailabilitySetsRestOperations restOperations, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<AvailabilitySetData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = clientDiagnostics.CreateScope("AvailabilitySetOperations.ListBySubscription");
                scope.Start();
                try
                {
                    var response = await restOperations.ListBySubscriptionAsync(expand, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AvailabilitySetData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = clientDiagnostics.CreateScope("AvailabilitySetOperations.ListBySubscription");
                scope.Start();
                try
                {
                    var response = await restOperations.ListBySubscriptionNextPageAsync(nextLink, expand, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the AvailabilitySets for this Azure.ResourceManager.Core.SubscriptionOperations. </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <return> A collection of resource operations that may take multiple service requests to iterate over. </return>
        public static Pageable<AvailabilitySet> ListAvailabilitySet(this SubscriptionOperations subscription, CancellationToken cancellationToken = default)
        {
            return subscription.ListResources((baseUri, credential, options) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetAvailabilitySetsRestOperations(clientDiagnostics, credential, options, subscription.Id.SubscriptionId, baseUri);
                var result = ListBySubscription(clientDiagnostics, restOperations);
                return new PhWrappingPageable<AvailabilitySetData, AvailabilitySet>(
                result,
                s => new AvailabilitySet(subscription, s));
            }
            );
        }

        /// <summary> Lists all availability sets in a subscription. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="restOperations"> Resource client operations. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private static Pageable<AvailabilitySetData> ListBySubscription(ClientDiagnostics clientDiagnostics, AvailabilitySetsRestOperations restOperations, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<AvailabilitySetData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = clientDiagnostics.CreateScope("AvailabilitySetOperations.ListBySubscription");
                scope.Start();
                try
                {
                    var response = restOperations.ListBySubscription(expand, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AvailabilitySetData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = clientDiagnostics.CreateScope("AvailabilitySetOperations.ListBySubscription");
                scope.Start();
                try
                {
                    var response = restOperations.ListBySubscriptionNextPage(nextLink, expand, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of AvailabilitySets for a Azure.ResourceManager.Core.SubscriptionOperations represented as generic resources. </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <return> A collection of resource operations that may take multiple service requests to iterate over. </return>
        public static AsyncPageable<GenericResource> ListAvailabilitySetByNameAsync(this SubscriptionOperations subscription, string filter, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(AvailabilitySetOperations.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.ListAtContextAsync(subscription, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of AvailabilitySets for a Azure.ResourceManager.Core.SubscriptionOperations represented as generic resources. </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <return> A collection of resource operations that may take multiple service requests to iterate over. </return>
        public static Pageable<GenericResource> ListAvailabilitySetByName(this SubscriptionOperations subscription, string filter, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(AvailabilitySetOperations.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.ListAtContext(subscription, filters, top, cancellationToken);
        }
        #endregion
    }
}
