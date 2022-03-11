// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace MgmtCollectionParent
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _orderResourceClientDiagnostics;
        private ComputeManagementRestOperations _orderResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class for mocking. </summary>
        protected SubscriptionExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics OrderResourceClientDiagnostics => _orderResourceClientDiagnostics ??= new ClientDiagnostics("MgmtCollectionParent", OrderResource.ResourceType.Namespace, DiagnosticOptions);
        private ComputeManagementRestOperations OrderResourceRestClient => _orderResourceRestClient ??= new ComputeManagementRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(OrderResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Lists order at subscription level.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orders
        /// Operation Id: ListOrderAtSubscriptionLevel
        /// </summary>
        /// <param name="skipToken"> $skipToken is supported on Get list of order, which provides the next page in the list of order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OrderResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OrderResource> GetOrderResourcesAsync(string skipToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<OrderResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = OrderResourceClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetOrderResources");
                scope.Start();
                try
                {
                    var response = await OrderResourceRestClient.ListOrderAtSubscriptionLevelAsync(Id.SubscriptionId, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new OrderResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<OrderResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = OrderResourceClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetOrderResources");
                scope.Start();
                try
                {
                    var response = await OrderResourceRestClient.ListOrderAtSubscriptionLevelNextPageAsync(nextLink, Id.SubscriptionId, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new OrderResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists order at subscription level.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orders
        /// Operation Id: ListOrderAtSubscriptionLevel
        /// </summary>
        /// <param name="skipToken"> $skipToken is supported on Get list of order, which provides the next page in the list of order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OrderResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OrderResource> GetOrderResources(string skipToken = null, CancellationToken cancellationToken = default)
        {
            Page<OrderResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = OrderResourceClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetOrderResources");
                scope.Start();
                try
                {
                    var response = OrderResourceRestClient.ListOrderAtSubscriptionLevel(Id.SubscriptionId, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new OrderResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<OrderResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = OrderResourceClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetOrderResources");
                scope.Start();
                try
                {
                    var response = OrderResourceRestClient.ListOrderAtSubscriptionLevelNextPage(nextLink, Id.SubscriptionId, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new OrderResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
