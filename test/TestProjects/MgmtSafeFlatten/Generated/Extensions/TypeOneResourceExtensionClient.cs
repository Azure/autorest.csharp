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
    public partial class TypeOneResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _typeOneCommonClientDiagnostics;
        private CommonRestOperations _typeOneCommonRestClient;

        /// <summary> Initializes a new instance of the <see cref="TypeOneResourceExtensionClient"/> class for mocking. </summary>
        protected TypeOneResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TypeOneResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal TypeOneResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics TypeOneCommonClientDiagnostics => _typeOneCommonClientDiagnostics ??= new ClientDiagnostics("MgmtSafeFlatten.Mock", TypeOneResource.ResourceType.Namespace, Diagnostics);
        private CommonRestOperations TypeOneCommonRestClient => _typeOneCommonRestClient ??= new CommonRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(TypeOneResource.ResourceType));

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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeOnesBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TypeOneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TypeOneResource> GetTypeOnesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TypeOneCommonRestClient.CreateListTypeOnesBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new TypeOneResource(Client, TypeOneData.DeserializeTypeOneData(e)), TypeOneCommonClientDiagnostics, Pipeline, "TypeOneResourceExtensionClient.GetTypeOnes", "value", null, cancellationToken);
        }

        /// <summary>
        /// Description for Validate information for a certificate order.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.TypeOne/typeOnes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Common_ListTypeOnesBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TypeOneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TypeOneResource> GetTypeOnes(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TypeOneCommonRestClient.CreateListTypeOnesBySubscriptionRequest(Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new TypeOneResource(Client, TypeOneData.DeserializeTypeOneData(e)), TypeOneCommonClientDiagnostics, Pipeline, "TypeOneResourceExtensionClient.GetTypeOnes", "value", null, cancellationToken);
        }
    }
}
