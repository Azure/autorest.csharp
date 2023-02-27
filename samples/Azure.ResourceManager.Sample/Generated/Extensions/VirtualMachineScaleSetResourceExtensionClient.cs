// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Mock
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class VirtualMachineScaleSetResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _virtualMachineScaleSetClientDiagnostics;
        private VirtualMachineScaleSetsRestOperations _virtualMachineScaleSetRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetResourceExtensionClient"/> class for mocking. </summary>
        protected VirtualMachineScaleSetResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics VirtualMachineScaleSetClientDiagnostics => _virtualMachineScaleSetClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample.Mock", VirtualMachineScaleSetResource.ResourceType.Namespace, Diagnostics);
        private VirtualMachineScaleSetsRestOperations VirtualMachineScaleSetRestClient => _virtualMachineScaleSetRestClient ??= new VirtualMachineScaleSetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(VirtualMachineScaleSetResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets a list of all VM Scale Sets in the subscription, regardless of the associated resource group. Use nextLink property in the response to get the next page of VM Scale Sets. Do this till nextLink is null to fetch all the VM Scale Sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachineScaleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineScaleSetRestClient.CreateListAllRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineScaleSetRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineScaleSetResource(Client, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(e)), VirtualMachineScaleSetClientDiagnostics, Pipeline, "VirtualMachineScaleSetResourceExtensionClient.GetVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of all VM Scale Sets in the subscription, regardless of the associated resource group. Use nextLink property in the response to get the next page of VM Scale Sets. Do this till nextLink is null to fetch all the VM Scale Sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachineScaleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineScaleSetResource> GetVirtualMachineScaleSets(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineScaleSetRestClient.CreateListAllRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineScaleSetRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineScaleSetResource(Client, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(e)), VirtualMachineScaleSetClientDiagnostics, Pipeline, "VirtualMachineScaleSetResourceExtensionClient.GetVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
        }
    }
}
