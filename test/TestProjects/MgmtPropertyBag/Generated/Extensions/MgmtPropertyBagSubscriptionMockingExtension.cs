// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtPropertyBag;

namespace MgmtPropertyBag.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MgmtPropertyBagSubscriptionMockingExtension : ArmResource
    {
        private ClientDiagnostics _fooClientDiagnostics;
        private FoosRestOperations _fooRestClient;
        private ClientDiagnostics _barClientDiagnostics;
        private BarsRestOperations _barRestClient;

        /// <summary> Initializes a new instance of the <see cref="MgmtPropertyBagSubscriptionMockingExtension"/> class for mocking. </summary>
        protected MgmtPropertyBagSubscriptionMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtPropertyBagSubscriptionMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtPropertyBagSubscriptionMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/foos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_ListWithSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. The default value is 10. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FooResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FooResource> GetFoosAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FooRestClient.CreateListWithSubscriptionRequest(Id.SubscriptionId, filter, top);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new FooResource(Client, FooData.DeserializeFooData(e)), FooClientDiagnostics, Pipeline, "MgmtPropertyBagSubscriptionMockingExtension.GetFoos", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of foo with two optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/foos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_ListWithSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. The default value is 10. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FooResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FooResource> GetFoos(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FooRestClient.CreateListWithSubscriptionRequest(Id.SubscriptionId, filter, top);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new FooResource(Client, FooData.DeserializeFooData(e)), FooClientDiagnostics, Pipeline, "MgmtPropertyBagSubscriptionMockingExtension.GetFoos", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of bar with one required header parameter and one optional query parameter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/bars</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_ListWithSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BarResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BarResource> GetBarsAsync(ETag? ifMatch = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => BarRestClient.CreateListWithSubscriptionRequest(Id.SubscriptionId, ifMatch, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => BarRestClient.CreateListWithSubscriptionNextPageRequest(nextLink, Id.SubscriptionId, ifMatch, top);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new BarResource(Client, BarData.DeserializeBarData(e)), BarClientDiagnostics, Pipeline, "MgmtPropertyBagSubscriptionMockingExtension.GetBars", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of bar with one required header parameter and one optional query parameter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/bars</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_ListWithSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BarResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BarResource> GetBars(ETag? ifMatch = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => BarRestClient.CreateListWithSubscriptionRequest(Id.SubscriptionId, ifMatch, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => BarRestClient.CreateListWithSubscriptionNextPageRequest(nextLink, Id.SubscriptionId, ifMatch, top);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new BarResource(Client, BarData.DeserializeBarData(e)), BarClientDiagnostics, Pipeline, "MgmtPropertyBagSubscriptionMockingExtension.GetBars", "value", "nextLink", cancellationToken);
        }
    }
}
