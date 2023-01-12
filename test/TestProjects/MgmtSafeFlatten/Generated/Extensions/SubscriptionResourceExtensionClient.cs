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

namespace MgmtSafeFlatten
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _typeOneCommonClientDiagnostics;
        private CommonRestOperations _typeOneCommonRestClient;
        private ClientDiagnostics _typeTwoCommonClientDiagnostics;
        private CommonRestOperations _typeTwoCommonRestClient;

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

        private ClientDiagnostics TypeOneCommonClientDiagnostics => _typeOneCommonClientDiagnostics ??= new ClientDiagnostics("MgmtSafeFlatten", TypeOneResource.ResourceType.Namespace, Diagnostics);
        private CommonRestOperations TypeOneCommonRestClient => _typeOneCommonRestClient ??= new CommonRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(TypeOneResource.ResourceType));
        private ClientDiagnostics TypeTwoCommonClientDiagnostics => _typeTwoCommonClientDiagnostics ??= new ClientDiagnostics("MgmtSafeFlatten", TypeTwoResource.ResourceType.Namespace, Diagnostics);
        private CommonRestOperations TypeTwoCommonRestClient => _typeTwoCommonRestClient ??= new CommonRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(TypeTwoResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes
        /// Operation Id: Common_ListTypeOnesBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeOneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeOneResource> GetTypeOnesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TypeOneCommonRestClient.CreateListTypeOnesBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new TypeOneResource(Client, TypeOneData.DeserializeTypeOneData(e)), TypeOneCommonClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetTypeOnes", "value", null, cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes
        /// Operation Id: Common_ListTypeOnesBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeOneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeOneResource> GetTypeOnes(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TypeOneCommonRestClient.CreateListTypeOnesBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new TypeOneResource(Client, TypeOneData.DeserializeTypeOneData(e)), TypeOneCommonClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetTypeOnes", "value", null, cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos
        /// Operation Id: Common_ListTypeTwosBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeTwoResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeTwoResource> GetTypeTwosAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TypeTwoCommonRestClient.CreateListTypeTwosBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new TypeTwoResource(Client, TypeTwoData.DeserializeTypeTwoData(e)), TypeTwoCommonClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetTypeTwos", "value", null, cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.TypeTwo/typeTwos
        /// Operation Id: Common_ListTypeTwosBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeTwoResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeTwoResource> GetTypeTwos(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TypeTwoCommonRestClient.CreateListTypeTwosBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new TypeTwoResource(Client, TypeTwoData.DeserializeTypeTwoData(e)), TypeTwoCommonClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetTypeTwos", "value", null, cancellationToken);
        }
    }
}
