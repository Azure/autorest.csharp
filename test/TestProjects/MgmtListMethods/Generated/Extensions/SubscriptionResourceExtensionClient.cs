// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics;
        private FakeParentWithAncestorWithNonResChWithLocsRestOperations _fakeParentWithAncestorWithNonResChWithLocRestClient;
        private ClientDiagnostics _fakeParentWithAncestorWithNonResChClientDiagnostics;
        private FakeParentWithAncestorWithNonResChesRestOperations _fakeParentWithAncestorWithNonResChRestClient;
        private ClientDiagnostics _fakeParentWithAncestorWithLocClientDiagnostics;
        private FakeParentWithAncestorWithLocsRestOperations _fakeParentWithAncestorWithLocRestClient;
        private ClientDiagnostics _fakeParentWithAncestorClientDiagnostics;
        private FakeParentWithAncestorsRestOperations _fakeParentWithAncestorRestClient;
        private ClientDiagnostics _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics;
        private ResGrpParentWithAncestorWithNonResChWithLocsRestOperations _resGrpParentWithAncestorWithNonResChWithLocRestClient;
        private ClientDiagnostics _resGrpParentWithAncestorWithNonResChClientDiagnostics;
        private ResGrpParentWithAncestorWithNonResChesRestOperations _resGrpParentWithAncestorWithNonResChRestClient;
        private ClientDiagnostics _resGrpParentWithAncestorWithLocClientDiagnostics;
        private ResGrpParentWithAncestorWithLocsRestOperations _resGrpParentWithAncestorWithLocRestClient;
        private ClientDiagnostics _resGrpParentWithAncestorClientDiagnostics;
        private ResGrpParentWithAncestorsRestOperations _resGrpParentWithAncestorRestClient;
        private ClientDiagnostics _quotasClientDiagnostics;
        private QuotasRestOperations _quotasRestClient;

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

        private ClientDiagnostics FakeParentWithAncestorWithNonResChWithLocClientDiagnostics => _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics ??= new ClientDiagnostics("MgmtListMethods", FakeParentWithAncestorWithNonResChWithLocResource.ResourceType.Namespace, Diagnostics);
        private FakeParentWithAncestorWithNonResChWithLocsRestOperations FakeParentWithAncestorWithNonResChWithLocRestClient => _fakeParentWithAncestorWithNonResChWithLocRestClient ??= new FakeParentWithAncestorWithNonResChWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(FakeParentWithAncestorWithNonResChWithLocResource.ResourceType));
        private ClientDiagnostics FakeParentWithAncestorWithNonResChClientDiagnostics => _fakeParentWithAncestorWithNonResChClientDiagnostics ??= new ClientDiagnostics("MgmtListMethods", FakeParentWithAncestorWithNonResChResource.ResourceType.Namespace, Diagnostics);
        private FakeParentWithAncestorWithNonResChesRestOperations FakeParentWithAncestorWithNonResChRestClient => _fakeParentWithAncestorWithNonResChRestClient ??= new FakeParentWithAncestorWithNonResChesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(FakeParentWithAncestorWithNonResChResource.ResourceType));
        private ClientDiagnostics FakeParentWithAncestorWithLocClientDiagnostics => _fakeParentWithAncestorWithLocClientDiagnostics ??= new ClientDiagnostics("MgmtListMethods", FakeParentWithAncestorWithLocResource.ResourceType.Namespace, Diagnostics);
        private FakeParentWithAncestorWithLocsRestOperations FakeParentWithAncestorWithLocRestClient => _fakeParentWithAncestorWithLocRestClient ??= new FakeParentWithAncestorWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(FakeParentWithAncestorWithLocResource.ResourceType));
        private ClientDiagnostics FakeParentWithAncestorClientDiagnostics => _fakeParentWithAncestorClientDiagnostics ??= new ClientDiagnostics("MgmtListMethods", FakeParentWithAncestorResource.ResourceType.Namespace, Diagnostics);
        private FakeParentWithAncestorsRestOperations FakeParentWithAncestorRestClient => _fakeParentWithAncestorRestClient ??= new FakeParentWithAncestorsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(FakeParentWithAncestorResource.ResourceType));
        private ClientDiagnostics ResGrpParentWithAncestorWithNonResChWithLocClientDiagnostics => _resGrpParentWithAncestorWithNonResChWithLocClientDiagnostics ??= new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestorWithNonResChWithLocResource.ResourceType.Namespace, Diagnostics);
        private ResGrpParentWithAncestorWithNonResChWithLocsRestOperations ResGrpParentWithAncestorWithNonResChWithLocRestClient => _resGrpParentWithAncestorWithNonResChWithLocRestClient ??= new ResGrpParentWithAncestorWithNonResChWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ResGrpParentWithAncestorWithNonResChWithLocResource.ResourceType));
        private ClientDiagnostics ResGrpParentWithAncestorWithNonResChClientDiagnostics => _resGrpParentWithAncestorWithNonResChClientDiagnostics ??= new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestorWithNonResChResource.ResourceType.Namespace, Diagnostics);
        private ResGrpParentWithAncestorWithNonResChesRestOperations ResGrpParentWithAncestorWithNonResChRestClient => _resGrpParentWithAncestorWithNonResChRestClient ??= new ResGrpParentWithAncestorWithNonResChesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ResGrpParentWithAncestorWithNonResChResource.ResourceType));
        private ClientDiagnostics ResGrpParentWithAncestorWithLocClientDiagnostics => _resGrpParentWithAncestorWithLocClientDiagnostics ??= new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestorWithLocResource.ResourceType.Namespace, Diagnostics);
        private ResGrpParentWithAncestorWithLocsRestOperations ResGrpParentWithAncestorWithLocRestClient => _resGrpParentWithAncestorWithLocRestClient ??= new ResGrpParentWithAncestorWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ResGrpParentWithAncestorWithLocResource.ResourceType));
        private ClientDiagnostics ResGrpParentWithAncestorClientDiagnostics => _resGrpParentWithAncestorClientDiagnostics ??= new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestorResource.ResourceType.Namespace, Diagnostics);
        private ResGrpParentWithAncestorsRestOperations ResGrpParentWithAncestorRestClient => _resGrpParentWithAncestorRestClient ??= new ResGrpParentWithAncestorsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ResGrpParentWithAncestorResource.ResourceType));
        private ClientDiagnostics QuotasClientDiagnostics => _quotasClientDiagnostics ??= new ClientDiagnostics("MgmtListMethods", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private QuotasRestOperations QuotasRestClient => _quotasRestClient ??= new QuotasRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of FakeResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of FakeResources and their operations over a FakeResource. </returns>
        public virtual FakeCollection GetFakes()
        {
            return GetCachedClient(Client => new FakeCollection(Client, Id));
        }

        /// <summary> Gets a collection of SubParentWithNonResChWithLocResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of SubParentWithNonResChWithLocResources and their operations over a SubParentWithNonResChWithLocResource. </returns>
        public virtual SubParentWithNonResChWithLocCollection GetSubParentWithNonResChWithLocs()
        {
            return GetCachedClient(Client => new SubParentWithNonResChWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of SubParentWithNonResChResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of SubParentWithNonResChResources and their operations over a SubParentWithNonResChResource. </returns>
        public virtual SubParentWithNonResChCollection GetSubParentWithNonResChes()
        {
            return GetCachedClient(Client => new SubParentWithNonResChCollection(Client, Id));
        }

        /// <summary> Gets a collection of SubParentWithLocResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of SubParentWithLocResources and their operations over a SubParentWithLocResource. </returns>
        public virtual SubParentWithLocCollection GetSubParentWithLocs()
        {
            return GetCachedClient(Client => new SubParentWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of SubParentResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of SubParentResources and their operations over a SubParentResource. </returns>
        public virtual SubParentCollection GetSubParents()
        {
            return GetCachedClient(Client => new SubParentCollection(Client, Id));
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestorWithNonResChWithLocResource> GetFakeParentWithAncestorWithNonResourceChWithLocAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithNonResChWithLocRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorWithNonResChWithLocRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithNonResChWithLocResource(Client, FakeParentWithAncestorWithNonResChWithLocData.DeserializeFakeParentWithAncestorWithNonResChWithLocData(e)), FakeParentWithAncestorWithNonResChWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestorWithNonResourceChWithLoc", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestorWithNonResChWithLocResource> GetFakeParentWithAncestorWithNonResourceChWithLoc(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithNonResChWithLocRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorWithNonResChWithLocRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithNonResChWithLocResource(Client, FakeParentWithAncestorWithNonResChWithLocData.DeserializeFakeParentWithAncestorWithNonResChWithLocData(e)), FakeParentWithAncestorWithNonResChWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestorWithNonResourceChWithLoc", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/nonResourceChild</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_ListTestByLocations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NonResourceChild> GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocsAsync(string location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithNonResChWithLocRestClient.CreateListTestByLocationsRequest(Id.SubscriptionId, location);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, NonResourceChild.DeserializeNonResourceChild, FakeParentWithAncestorWithNonResChWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocs", "value", null, cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/nonResourceChild</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_ListTestByLocations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NonResourceChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NonResourceChild> GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocs(string location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithNonResChWithLocRestClient.CreateListTestByLocationsRequest(Id.SubscriptionId, location);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, NonResourceChild.DeserializeNonResourceChild, FakeParentWithAncestorWithNonResChWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetTestByLocationsFakeParentWithAncestorWithNonResChWithLocs", "value", null, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChes_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestorWithNonResChResource> GetFakeParentWithAncestorWithNonResChesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithNonResChRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorWithNonResChRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithNonResChResource(Client, FakeParentWithAncestorWithNonResChData.DeserializeFakeParentWithAncestorWithNonResChData(e)), FakeParentWithAncestorWithNonResChClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestorWithNonResChes", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChes_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestorWithNonResChResource> GetFakeParentWithAncestorWithNonResChes(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithNonResChRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorWithNonResChRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithNonResChResource(Client, FakeParentWithAncestorWithNonResChData.DeserializeFakeParentWithAncestorWithNonResChData(e)), FakeParentWithAncestorWithNonResChClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestorWithNonResChes", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestorWithLocResource> GetFakeParentWithAncestorWithLocsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithLocRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorWithLocRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithLocResource(Client, FakeParentWithAncestorWithLocData.DeserializeFakeParentWithAncestorWithLocData(e)), FakeParentWithAncestorWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestorWithLocs", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestorWithLocResource> GetFakeParentWithAncestorWithLocs(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithLocRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorWithLocRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithLocResource(Client, FakeParentWithAncestorWithLocData.DeserializeFakeParentWithAncestorWithLocData(e)), FakeParentWithAncestorWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestorWithLocs", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListTestByLocations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestorWithLocResource> GetFakeParentWithAncestorWithLocsByLocationAsync(string location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithLocRestClient.CreateListTestByLocationsRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorWithLocRestClient.CreateListTestByLocationsNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithLocResource(Client, FakeParentWithAncestorWithLocData.DeserializeFakeParentWithAncestorWithLocData(e)), FakeParentWithAncestorWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestorWithLocsByLocation", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListTestByLocations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestorWithLocResource> GetFakeParentWithAncestorWithLocsByLocation(string location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorWithLocRestClient.CreateListTestByLocationsRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorWithLocRestClient.CreateListTestByLocationsNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithLocResource(Client, FakeParentWithAncestorWithLocData.DeserializeFakeParentWithAncestorWithLocData(e)), FakeParentWithAncestorWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestorWithLocsByLocation", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestors_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestorResource> GetFakeParentWithAncestorsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorResource(Client, FakeParentWithAncestorData.DeserializeFakeParentWithAncestorData(e)), FakeParentWithAncestorClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestors", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakeParentWithAncestors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestors_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestorResource> GetFakeParentWithAncestors(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FakeParentWithAncestorRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FakeParentWithAncestorRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorResource(Client, FakeParentWithAncestorData.DeserializeFakeParentWithAncestorData(e)), FakeParentWithAncestorClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetFakeParentWithAncestors", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetResGrpParentWithAncestorWithNonResChWithLocsAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorWithNonResChWithLocRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResGrpParentWithAncestorWithNonResChWithLocRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, expand);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, ResGrpParentWithAncestorWithNonResChWithLocData.DeserializeResGrpParentWithAncestorWithNonResChWithLocData(e)), ResGrpParentWithAncestorWithNonResChWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestorWithNonResChWithLocs", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChWithLocs_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetResGrpParentWithAncestorWithNonResChWithLocs(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorWithNonResChWithLocRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResGrpParentWithAncestorWithNonResChWithLocRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, expand);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, ResGrpParentWithAncestorWithNonResChWithLocData.DeserializeResGrpParentWithAncestorWithNonResChWithLocData(e)), ResGrpParentWithAncestorWithNonResChWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestorWithNonResChWithLocs", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithNonResChResource> GetResGrpParentWithAncestorWithNonResChesAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorWithNonResChRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResGrpParentWithAncestorWithNonResChRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, expand);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChResource(Client, ResGrpParentWithAncestorWithNonResChData.DeserializeResGrpParentWithAncestorWithNonResChData(e)), ResGrpParentWithAncestorWithNonResChClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestorWithNonResChes", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithNonResChes_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithNonResChResource> GetResGrpParentWithAncestorWithNonResChes(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorWithNonResChRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResGrpParentWithAncestorWithNonResChRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, expand);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChResource(Client, ResGrpParentWithAncestorWithNonResChData.DeserializeResGrpParentWithAncestorWithNonResChData(e)), ResGrpParentWithAncestorWithNonResChClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestorWithNonResChes", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithLocResource> GetResGrpParentWithAncestorWithLocsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorWithLocRestClient.CreateListTestRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResGrpParentWithAncestorWithLocRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithLocResource(Client, ResGrpParentWithAncestorWithLocData.DeserializeResGrpParentWithAncestorWithLocData(e)), ResGrpParentWithAncestorWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestorWithLocs", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithLocResource> GetResGrpParentWithAncestorWithLocs(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorWithLocRestClient.CreateListTestRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResGrpParentWithAncestorWithLocRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithLocResource(Client, ResGrpParentWithAncestorWithLocData.DeserializeResGrpParentWithAncestorWithLocData(e)), ResGrpParentWithAncestorWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestorWithLocs", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/locations/{location}/resGrpParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLocAsync(string location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorWithLocRestClient.CreateListAllRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResGrpParentWithAncestorWithLocRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, ResGrpParentWithAncestorWithNonResChWithLocData.DeserializeResGrpParentWithAncestorWithNonResChWithLocData(e)), ResGrpParentWithAncestorWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLoc", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/locations/{location}/resGrpParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestorWithLocs_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithNonResChWithLocResource> GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLoc(string location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorWithLocRestClient.CreateListAllRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ResGrpParentWithAncestorWithLocRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithAncestorWithNonResChWithLocResource(Client, ResGrpParentWithAncestorWithNonResChWithLocData.DeserializeResGrpParentWithAncestorWithNonResChWithLocData(e)), ResGrpParentWithAncestorWithLocClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestorWithNonResChWithLocsByLocationResGrpParentWithAncestorWithLoc", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestors_NonPageableListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorResource> GetResGrpParentWithAncestorsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorRestClient.CreateNonPageableListBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new ResGrpParentWithAncestorResource(Client, ResGrpParentWithAncestorData.DeserializeResGrpParentWithAncestorData(e)), ResGrpParentWithAncestorClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestors", "value", null, cancellationToken);
        }

        /// <summary>
        /// Lists all in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithAncestors_NonPageableListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorResource> GetResGrpParentWithAncestors(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ResGrpParentWithAncestorRestClient.CreateNonPageableListBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new ResGrpParentWithAncestorResource(Client, ResGrpParentWithAncestorData.DeserializeResGrpParentWithAncestorData(e)), ResGrpParentWithAncestorClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetResGrpParentWithAncestors", "value", null, cancellationToken);
        }

        /// <summary>
        /// Update quota for each VM family in workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/updateQuotas</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Quotas_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for update quota is queried. </param>
        /// <param name="content"> Quota update parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="UpdateWorkspaceQuotas" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<UpdateWorkspaceQuotas> UpdateAllQuotaAsync(string location, QuotaUpdateContent content, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => QuotasRestClient.CreateUpdateRequest(Id.SubscriptionId, location, content);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, UpdateWorkspaceQuotas.DeserializeUpdateWorkspaceQuotas, QuotasClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.UpdateAllQuota", "value", null, cancellationToken);
        }

        /// <summary>
        /// Update quota for each VM family in workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/locations/{location}/updateQuotas</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Quotas_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for update quota is queried. </param>
        /// <param name="content"> Quota update parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="UpdateWorkspaceQuotas" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<UpdateWorkspaceQuotas> UpdateAllQuota(string location, QuotaUpdateContent content, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => QuotasRestClient.CreateUpdateRequest(Id.SubscriptionId, location, content);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, UpdateWorkspaceQuotas.DeserializeUpdateWorkspaceQuotas, QuotasClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.UpdateAllQuota", "value", null, cancellationToken);
        }
    }
}
