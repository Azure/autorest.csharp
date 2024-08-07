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

namespace _Azure.ResourceManager.Models.Resources.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class Mockable_AzureResourceManagerModelsResourcesSubscriptionResource : ArmResource
    {
        private ClientDiagnostics _topLevelTrackedResourceClientDiagnostics;
        private TopLevelTrackedResourcesRestOperations _topLevelTrackedResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="Mockable_AzureResourceManagerModelsResourcesSubscriptionResource"/> class for mocking. </summary>
        protected Mockable_AzureResourceManagerModelsResourcesSubscriptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="Mockable_AzureResourceManagerModelsResourcesSubscriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Mockable_AzureResourceManagerModelsResourcesSubscriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics TopLevelTrackedResourceClientDiagnostics => _topLevelTrackedResourceClientDiagnostics ??= new ClientDiagnostics("_Azure.ResourceManager.Models.Resources", TopLevelTrackedResource.ResourceType.Namespace, Diagnostics);
        private TopLevelTrackedResourcesRestOperations TopLevelTrackedResourceRestClient => _topLevelTrackedResourceRestClient ??= new TopLevelTrackedResourcesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(TopLevelTrackedResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// List TopLevelTrackedResource resources by subscription ID
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Azure.ResourceManager.Models.Resources/topLevelTrackedResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TopLevelTrackedResource_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TopLevelTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TopLevelTrackedResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TopLevelTrackedResource> GetTopLevelTrackedResourcesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TopLevelTrackedResourceRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => TopLevelTrackedResourceRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new TopLevelTrackedResource(Client, TopLevelTrackedResourceData.DeserializeTopLevelTrackedResourceData(e)), TopLevelTrackedResourceClientDiagnostics, Pipeline, "Mockable_AzureResourceManagerModelsResourcesSubscriptionResource.GetTopLevelTrackedResources", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List TopLevelTrackedResource resources by subscription ID
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Azure.ResourceManager.Models.Resources/topLevelTrackedResources</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TopLevelTrackedResource_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="TopLevelTrackedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TopLevelTrackedResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TopLevelTrackedResource> GetTopLevelTrackedResources(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => TopLevelTrackedResourceRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => TopLevelTrackedResourceRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new TopLevelTrackedResource(Client, TopLevelTrackedResourceData.DeserializeTopLevelTrackedResourceData(e)), TopLevelTrackedResourceClientDiagnostics, Pipeline, "Mockable_AzureResourceManagerModelsResourcesSubscriptionResource.GetTopLevelTrackedResources", "value", "nextLink", cancellationToken);
        }
    }
}
