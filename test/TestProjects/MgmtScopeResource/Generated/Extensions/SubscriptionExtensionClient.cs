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
using Azure.ResourceManager.Resources;

namespace MgmtScopeResource
{
    /// <summary> An internal class to add extension methods to. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _resourceLinkClientDiagnostics;
        private ResourceLinksRestOperations _resourceLinkRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class for mocking. </summary>
        protected SubscriptionExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionExtensionClient(ArmClient armClient, ResourceIdentifier id) : base(armClient, id)
        {
        }

        private ClientDiagnostics ResourceLinkClientDiagnostics => _resourceLinkClientDiagnostics ??= new ClientDiagnostics("MgmtScopeResource", ResourceLink.ResourceType.Namespace, DiagnosticOptions);
        private ResourceLinksRestOperations ResourceLinkRestClient => _resourceLinkRestClient ??= new ResourceLinksRestOperations(ResourceLinkClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(ResourceLink.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            ArmClient.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Resources/links
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResourceLinks_ListAtSubscription
        /// <summary> Gets all the linked resources for the subscription. </summary>
        /// <param name="filter"> The filter to apply on the list resource links operation. The supported filter for list resource links is targetId. For example, $filter=targetId eq {value}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceLink> GetResourceLinksAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ResourceLink>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ResourceLinkClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetResourceLinks");
                scope.Start();
                try
                {
                    var response = await ResourceLinkRestClient.ListAtSubscriptionAsync(Id.SubscriptionId, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceLink(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResourceLink>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ResourceLinkClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetResourceLinks");
                scope.Start();
                try
                {
                    var response = await ResourceLinkRestClient.ListAtSubscriptionNextPageAsync(nextLink, Id.SubscriptionId, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceLink(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Resources/links
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ResourceLinks_ListAtSubscription
        /// <summary> Gets all the linked resources for the subscription. </summary>
        /// <param name="filter"> The filter to apply on the list resource links operation. The supported filter for list resource links is targetId. For example, $filter=targetId eq {value}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceLink" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceLink> GetResourceLinks(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ResourceLink> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ResourceLinkClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetResourceLinks");
                scope.Start();
                try
                {
                    var response = ResourceLinkRestClient.ListAtSubscription(Id.SubscriptionId, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceLink(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResourceLink> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ResourceLinkClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetResourceLinks");
                scope.Start();
                try
                {
                    var response = ResourceLinkRestClient.ListAtSubscriptionNextPage(nextLink, Id.SubscriptionId, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceLink(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of ResourceLinks for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> GetResourceLinksAsGenericResourcesAsync(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(ResourceLink.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContextAsync(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// <summary> Filters the list of ResourceLinks for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> GetResourceLinksAsGenericResources(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(ResourceLink.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContext(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }
    }
}
