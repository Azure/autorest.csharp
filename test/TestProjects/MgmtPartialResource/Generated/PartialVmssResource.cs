// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtPartialResource
{
    /// <summary>
    /// A class extending from the VirtualMachineScaleSetResource in MgmtPartialResource along with the instance operations that can be performed on it.
    /// You can only construct a <see cref="PartialVmssResource" /> from a <see cref="ResourceIdentifier" /> with a resource type of Microsoft.Compute/virtualMachineScaleSets.
    /// </summary>
    public partial class PartialVmssResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="PartialVmssResource"/> instance. </summary>
        internal static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _publicIPAddressClientDiagnostics;
        private readonly PublicIPAddressesRestOperations _publicIPAddressRestClient;

        /// <summary> Initializes a new instance of the <see cref="PartialVmssResource"/> class for mocking. </summary>
        protected PartialVmssResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PartialVmssResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PartialVmssResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _publicIPAddressClientDiagnostics = new ClientDiagnostics("MgmtPartialResource", PublicIPAddressResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PublicIPAddressResource.ResourceType, out string publicIPAddressApiVersion);
            _publicIPAddressRestClient = new PublicIPAddressesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, publicIPAddressApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachineScaleSets";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets information about all public IP addresses on a virtual machine scale set level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/publicipaddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PublicIPAddresses_ListVirtualMachineScaleSetPublicIPAddresses</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PublicIPAddressResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PublicIPAddressResource> GetPublicIPAddressesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _publicIPAddressRestClient.CreateListVirtualMachineScaleSetPublicIPAddressesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _publicIPAddressRestClient.CreateListVirtualMachineScaleSetPublicIPAddressesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new PublicIPAddressResource(Client, PublicIPAddressData.DeserializePublicIPAddressData(e)), _publicIPAddressClientDiagnostics, Pipeline, "PartialVmssResource.GetPublicIPAddresses", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets information about all public IP addresses on a virtual machine scale set level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/publicipaddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PublicIPAddresses_ListVirtualMachineScaleSetPublicIPAddresses</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PublicIPAddressResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PublicIPAddressResource> GetPublicIPAddresses(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _publicIPAddressRestClient.CreateListVirtualMachineScaleSetPublicIPAddressesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _publicIPAddressRestClient.CreateListVirtualMachineScaleSetPublicIPAddressesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new PublicIPAddressResource(Client, PublicIPAddressData.DeserializePublicIPAddressData(e)), _publicIPAddressClientDiagnostics, Pipeline, "PartialVmssResource.GetPublicIPAddresses", "value", "nextLink", cancellationToken);
        }
    }
}
