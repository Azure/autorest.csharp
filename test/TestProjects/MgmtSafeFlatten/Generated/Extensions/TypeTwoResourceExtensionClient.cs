// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtSafeFlatten;

namespace MgmtSafeFlatten.Mock
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class TypeTwoResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _typeTwoCommonClientDiagnostics;
        private CommonRestOperations _typeTwoCommonRestClient;

        /// <summary> Initializes a new instance of the <see cref="TypeTwoResourceExtensionClient"/> class for mocking. </summary>
        protected TypeTwoResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TypeTwoResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TypeTwoResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics TypeTwoCommonClientDiagnostics => _typeTwoCommonClientDiagnostics ??= new ClientDiagnostics("MgmtSafeFlatten.Mock", TypeTwoResource.ResourceType.Namespace, Diagnostics);
        private CommonRestOperations TypeTwoCommonRestClient => _typeTwoCommonRestClient ??= new CommonRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(TypeTwoResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeTwosBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeTwoResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeTwoResource> GetTypeTwosAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TypeTwoCommonRestClient.CreateListTypeTwosBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new TypeTwoResource(Client, TypeTwoData.DeserializeTypeTwoData(e)), TypeTwoCommonClientDiagnostics, Pipeline, "TypeTwoResourceExtensionClient.GetTypeTwos", "value", null, cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeTwosBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeTwoResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeTwoResource> GetTypeTwos(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TypeTwoCommonRestClient.CreateListTypeTwosBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new TypeTwoResource(Client, TypeTwoData.DeserializeTypeTwoData(e)), TypeTwoCommonClientDiagnostics, Pipeline, "TypeTwoResourceExtensionClient.GetTypeTwos", "value", null, cancellationToken);
        }
    }
}
