// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary> A class to add extension methods to ArmResource. </summary>
    internal partial class ArmResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _resourceLinkClientDiagnostics;
        private ResourceLinksRestOperations _resourceLinkRestClient;
        private ClientDiagnostics _marketplacesClientDiagnostics;
        private MarketplacesRestOperations _marketplacesRestClient;

        /// <summary> Initializes a new instance of the <see cref="ArmResourceExtensionClient"/> class for mocking. </summary>
        protected ArmResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ArmResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ArmResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics ResourceLinkClientDiagnostics => _resourceLinkClientDiagnostics ??= new ClientDiagnostics("MgmtScopeResource", ResourceLinkResource.ResourceType.Namespace, Diagnostics);
        private ResourceLinksRestOperations ResourceLinkRestClient => _resourceLinkRestClient ??= new ResourceLinksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ResourceLinkResource.ResourceType));
        private ClientDiagnostics MarketplacesClientDiagnostics => _marketplacesClientDiagnostics ??= new ClientDiagnostics("MgmtScopeResource", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private MarketplacesRestOperations MarketplacesRestClient => _marketplacesRestClient ??= new MarketplacesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of FakePolicyAssignmentResources in the ArmResource. </summary>
        /// <returns> An object representing collection of FakePolicyAssignmentResources and their operations over a FakePolicyAssignmentResource. </returns>
        public virtual FakePolicyAssignmentCollection GetFakePolicyAssignments()
        {
            return GetCachedClient(Client => new FakePolicyAssignmentCollection(Client, Id));
        }

        /// <summary> Gets an object representing a VMInsightsOnboardingStatusResource along with the instance operations that can be performed on it in the ArmResource. </summary>
        /// <returns> Returns a <see cref="VMInsightsOnboardingStatusResource" /> object. </returns>
        public virtual VMInsightsOnboardingStatusResource GetVMInsightsOnboardingStatus()
        {
            return new VMInsightsOnboardingStatusResource(Client, Id.AppendProviderResource("Microsoft.Insights", "vmInsightsOnboardingStatuses", "default"));
        }

        /// <summary> Gets a collection of GuestConfigurationAssignmentResources in the ArmResource. </summary>
        /// <returns> An object representing collection of GuestConfigurationAssignmentResources and their operations over a GuestConfigurationAssignmentResource. </returns>
        public virtual GuestConfigurationAssignmentCollection GetGuestConfigurationAssignments()
        {
            return GetCachedClient(Client => new GuestConfigurationAssignmentCollection(Client, Id));
        }

        /// <summary>
        /// Gets a list of resource links at and below the specified source scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSourceScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply when getting resource links. To get links only at the specified scope (not below the scope), use Filter.atScope(). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceLinkResource> GetAllAsync(Filter? filter = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => ResourceLinkRestClient.CreateListAtSourceScopeRequest(Id, filter);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResourceLinkRestClient.CreateListAtSourceScopeNextPageRequest(nextLink, Id, filter);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResourceLinkResource(Client, ResourceLinkData.DeserializeResourceLinkData(e)), ResourceLinkClientDiagnostics, Pipeline, "ArmResourceExtensionClient.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of resource links at and below the specified source scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSourceScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply when getting resource links. To get links only at the specified scope (not below the scope), use Filter.atScope(). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceLinkResource> GetAll(Filter? filter = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => ResourceLinkRestClient.CreateListAtSourceScopeRequest(Id, filter);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResourceLinkRestClient.CreateListAtSourceScopeNextPageRequest(nextLink, Id, filter);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResourceLinkResource(Client, ResourceLinkData.DeserializeResourceLinkData(e)), ResourceLinkClientDiagnostics, Pipeline, "ArmResourceExtensionClient.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists the marketplaces for a scope at the defined scope. Marketplaces are available via this API only for May 1, 2014 or later.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Consumption/marketplaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Marketplaces_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> May be used to filter marketplaces by properties/usageEnd (Utc time), properties/usageStart (Utc time), properties/resourceGroup, properties/instanceName or properties/instanceId. The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'. It does not currently support 'ne', 'or', or 'not'. </param>
        /// <param name="top"> May be used to limit the number of results to the most recent N marketplaces. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Marketplace" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Marketplace> GetMarketplacesAsync(string filter = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => MarketplacesRestClient.CreateListRequest(Id, filter, top, skiptoken);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => MarketplacesRestClient.CreateListNextPageRequest(nextLink, Id, filter, top, skiptoken);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, Marketplace.DeserializeMarketplace, MarketplacesClientDiagnostics, Pipeline, "ArmResourceExtensionClient.GetMarketplaces", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists the marketplaces for a scope at the defined scope. Marketplaces are available via this API only for May 1, 2014 or later.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Consumption/marketplaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Marketplaces_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> May be used to filter marketplaces by properties/usageEnd (Utc time), properties/usageStart (Utc time), properties/resourceGroup, properties/instanceName or properties/instanceId. The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'. It does not currently support 'ne', 'or', or 'not'. </param>
        /// <param name="top"> May be used to limit the number of results to the most recent N marketplaces. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Marketplace" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Marketplace> GetMarketplaces(string filter = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            Azure.Core.HttpMessage FirstPageRequest(int? pageSizeHint) => MarketplacesRestClient.CreateListRequest(Id, filter, top, skiptoken);
            Azure.Core.HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => MarketplacesRestClient.CreateListNextPageRequest(nextLink, Id, filter, top, skiptoken);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, Marketplace.DeserializeMarketplace, MarketplacesClientDiagnostics, Pipeline, "ArmResourceExtensionClient.GetMarketplaces", "value", "nextLink", cancellationToken);
        }
    }
}
