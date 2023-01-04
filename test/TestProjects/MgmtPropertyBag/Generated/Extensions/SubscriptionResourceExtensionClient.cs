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

namespace MgmtPropertyBag
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _fooClientDiagnostics;
        private FoosRestOperations _fooRestClient;
        private ClientDiagnostics _barClientDiagnostics;
        private BarsRestOperations _barRestClient;

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

        private ClientDiagnostics FooClientDiagnostics => _fooClientDiagnostics ??= new ClientDiagnostics("MgmtPropertyBag", FooResource.ResourceType.Namespace, Diagnostics);
        private FoosRestOperations FooRestClient => _fooRestClient ??= new FoosRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(FooResource.ResourceType));
        private ClientDiagnostics BarClientDiagnostics => _barClientDiagnostics ??= new ClientDiagnostics("MgmtPropertyBag", BarResource.ResourceType.Namespace, Diagnostics);
        private BarsRestOperations BarRestClient => _barRestClient ??= new BarsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(BarResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets a list of foo with two optional query parameters.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/foos
        /// Operation Id: Foos_ListWithSubscription
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FooResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FooResource> GetFoosAsync(string filter = null, int? top = 10, CancellationToken cancellationToken = default)
        {
            async Task<Page<FooResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = FooClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetFoos");
                scope.Start();
                try
                {
                    var response = await FooRestClient.ListWithSubscriptionAsync(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Select(value => new FooResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets a list of foo with two optional query parameters.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/foos
        /// Operation Id: Foos_ListWithSubscription
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FooResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FooResource> GetFoos(string filter = null, int? top = 10, CancellationToken cancellationToken = default)
        {
            Page<FooResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = FooClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetFoos");
                scope.Start();
                try
                {
                    var response = FooRestClient.ListWithSubscription(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Select(value => new FooResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets a list of bar with one required header parameter and one optional query parameter.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/bars
        /// Operation Id: Bars_ListWithSubscription
        /// </summary>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of &quot;*&quot; can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BarResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BarResource> GetBarsAsync(ETag? ifMatch = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<BarResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = BarClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetBars");
                scope.Start();
                try
                {
                    var response = await BarRestClient.ListWithSubscriptionAsync(Id.SubscriptionId, ifMatch, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BarResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<BarResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = BarClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetBars");
                scope.Start();
                try
                {
                    var response = await BarRestClient.ListWithSubscriptionNextPageAsync(nextLink, Id.SubscriptionId, ifMatch, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BarResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of bar with one required header parameter and one optional query parameter.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/bars
        /// Operation Id: Bars_ListWithSubscription
        /// </summary>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of &quot;*&quot; can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BarResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BarResource> GetBars(ETag? ifMatch = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<BarResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = BarClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetBars");
                scope.Start();
                try
                {
                    var response = BarRestClient.ListWithSubscription(Id.SubscriptionId, ifMatch, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BarResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<BarResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = BarClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetBars");
                scope.Start();
                try
                {
                    var response = BarRestClient.ListWithSubscriptionNextPage(nextLink, Id.SubscriptionId, ifMatch, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BarResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
