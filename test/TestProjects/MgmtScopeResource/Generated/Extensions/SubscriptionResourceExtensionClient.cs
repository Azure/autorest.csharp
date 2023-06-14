// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtScopeResource
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _resourceLinkClientDiagnostics;
        private ResourceLinksRestOperations _resourceLinkRestClient;

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

        private ClientDiagnostics ResourceLinkClientDiagnostics => _resourceLinkClientDiagnostics ??= new ClientDiagnostics("MgmtScopeResource", ResourceLinkResource.ResourceType.Namespace, Diagnostics);
        private ResourceLinksRestOperations ResourceLinkRestClient => _resourceLinkRestClient ??= new ResourceLinksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ResourceLinkResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of DeploymentExtendedResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of DeploymentExtendedResources and their operations over a DeploymentExtendedResource. </returns>
        public virtual DeploymentExtendedCollection GetDeploymentExtendeds()
        {
            return GetCachedClient(Client => new DeploymentExtendedCollection(Client, Id));
        }

        /// <summary>
        /// Gets all the linked resources for the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the list resource links operation. The supported filter for list resource links is targetId. For example, $filter=targetId eq {value}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceLinkResource> GetResourceLinksAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResourceLinkRestClient.CreateListAtSubscriptionRequest(Id.SubscriptionId, filter);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResourceLinkRestClient.CreateListAtSubscriptionNextPageRequest(nextLink, Id.SubscriptionId, filter);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResourceLinkResource(Client, ResourceLinkData.DeserializeResourceLinkData(e)), ResourceLinkClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResourceLinks", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all the linked resources for the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the list resource links operation. The supported filter for list resource links is targetId. For example, $filter=targetId eq {value}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceLinkResource> GetResourceLinks(string filter = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResourceLinkRestClient.CreateListAtSubscriptionRequest(Id.SubscriptionId, filter);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResourceLinkRestClient.CreateListAtSubscriptionNextPageRequest(nextLink, Id.SubscriptionId, filter);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResourceLinkResource(Client, ResourceLinkData.DeserializeResourceLinkData(e)), ResourceLinkClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResourceLinks", "value", "nextLink", cancellationToken);
        }
    }
}
