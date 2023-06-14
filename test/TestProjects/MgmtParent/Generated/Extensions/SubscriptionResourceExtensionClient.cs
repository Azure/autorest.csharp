// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtParent
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _availabilitySetClientDiagnostics;
        private AvailabilitySetsRestOperations _availabilitySetRestClient;

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

        private ClientDiagnostics AvailabilitySetClientDiagnostics => _availabilitySetClientDiagnostics ??= new ClientDiagnostics("MgmtParent", AvailabilitySetResource.ResourceType.Namespace, Diagnostics);
        private AvailabilitySetsRestOperations AvailabilitySetRestClient => _availabilitySetRestClient ??= new AvailabilitySetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(AvailabilitySetResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of VirtualMachineExtensionImageResources in the SubscriptionResource. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <returns> An object representing collection of VirtualMachineExtensionImageResources and their operations over a VirtualMachineExtensionImageResource. </returns>
        public virtual VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(string location, string publisherName)
        {
            return new VirtualMachineExtensionImageCollection(Client, Id, location, publisherName);
        }

        /// <summary>
        /// Lists all availability sets in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AvailabilitySetResource> GetAvailabilitySetsAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AvailabilitySetRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AvailabilitySetRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, expand);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AvailabilitySetResource(Client, AvailabilitySetData.DeserializeAvailabilitySetData(e)), AvailabilitySetClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetAvailabilitySets", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all availability sets in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/availabilitySets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySets_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are 'instanceView'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AvailabilitySetResource> GetAvailabilitySets(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AvailabilitySetRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AvailabilitySetRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, expand);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AvailabilitySetResource(Client, AvailabilitySetData.DeserializeAvailabilitySetData(e)), AvailabilitySetClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetAvailabilitySets", "value", "nextLink", cancellationToken);
        }
    }
}
