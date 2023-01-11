// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtCollectionParent
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _orderResourceClientDiagnostics;
        private ComputeManagementRestOperations _orderResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class for mocking. </summary>
        protected SubscriptionResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics OrderResourceClientDiagnostics => _orderResourceClientDiagnostics ??= new ClientDiagnostics("MgmtCollectionParent", OrderResource.ResourceType.Namespace, Diagnostics);
        private ComputeManagementRestOperations OrderResourceRestClient => _orderResourceRestClient ??= new ComputeManagementRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(OrderResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Lists order at subscription level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orders</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListOrderAtSubscriptionLevel</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"> $skipToken is supported on Get list of order, which provides the next page in the list of order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OrderResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OrderResource> GetOrderResourcesAsync(string skipToken = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => OrderResourceRestClient.CreateListOrderAtSubscriptionLevelRequest(Id.SubscriptionId, skipToken);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => OrderResourceRestClient.CreateListOrderAtSubscriptionLevelNextPageRequest(nextLink, Id.SubscriptionId, skipToken);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new OrderResource(Client, OrderResourceData.DeserializeOrderResourceData(e)), OrderResourceClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetOrderResources", "value", "nextLink");
        }

        /// <summary>
        /// Lists order at subscription level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orders</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListOrderAtSubscriptionLevel</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"> $skipToken is supported on Get list of order, which provides the next page in the list of order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OrderResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OrderResource> GetOrderResources(string skipToken = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => OrderResourceRestClient.CreateListOrderAtSubscriptionLevelRequest(Id.SubscriptionId, skipToken);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => OrderResourceRestClient.CreateListOrderAtSubscriptionLevelNextPageRequest(nextLink, Id.SubscriptionId, skipToken);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new OrderResource(Client, OrderResourceData.DeserializeOrderResourceData(e)), OrderResourceClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetOrderResources", "value", "nextLink");
        }
    }
}
