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

namespace MgmtVirtualResource
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _publicIPAddressClientDiagnostics;
        private PublicIPAddressesRestOperations _publicIPAddressRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics PublicIPAddressClientDiagnostics => _publicIPAddressClientDiagnostics ??= new ClientDiagnostics("MgmtVirtualResource", PublicIPAddressResource.ResourceType.Namespace, Diagnostics);
        private PublicIPAddressesRestOperations PublicIPAddressRestClient => _publicIPAddressRestClient ??= new PublicIPAddressesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(PublicIPAddressResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of PublicIPAddressResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of PublicIPAddressResources and their operations over a PublicIPAddressResource. </returns>
        public virtual PublicIPAddressCollection GetPublicIPAddresses()
        {
            return GetCachedClient(Client => new PublicIPAddressCollection(Client, Id));
        }

        /// <summary>
        /// Gets information about all public IP addresses on a virtual machine scale set level.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/publicipaddresses
        /// Operation Id: PublicIPAddresses_ListVirtualMachineScaleSetPublicIPAddresses
        /// </summary>
        /// <param name="virtualMachineScaleSetName"> The name of the virtual machine scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PublicIPAddressResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PublicIPAddressResource> GetPublicIPAddressesByMicrosoftComputeVirtualMachineScaleSetPublicipaddressAsync(string virtualMachineScaleSetName, CancellationToken cancellationToken = default)
        {
            async Task<Page<PublicIPAddressResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PublicIPAddressClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetPublicIPAddressesByMicrosoftComputeVirtualMachineScaleSetPublicipaddress");
                scope.Start();
                try
                {
                    var response = await PublicIPAddressRestClient.ListVirtualMachineScaleSetPublicIPAddressesAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPAddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PublicIPAddressResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = PublicIPAddressClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetPublicIPAddressesByMicrosoftComputeVirtualMachineScaleSetPublicipaddress");
                scope.Start();
                try
                {
                    var response = await PublicIPAddressRestClient.ListVirtualMachineScaleSetPublicIPAddressesNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPAddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets information about all public IP addresses on a virtual machine scale set level.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/publicipaddresses
        /// Operation Id: PublicIPAddresses_ListVirtualMachineScaleSetPublicIPAddresses
        /// </summary>
        /// <param name="virtualMachineScaleSetName"> The name of the virtual machine scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PublicIPAddressResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PublicIPAddressResource> GetPublicIPAddressesByMicrosoftComputeVirtualMachineScaleSetPublicipaddress(string virtualMachineScaleSetName, CancellationToken cancellationToken = default)
        {
            Page<PublicIPAddressResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PublicIPAddressClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetPublicIPAddressesByMicrosoftComputeVirtualMachineScaleSetPublicipaddress");
                scope.Start();
                try
                {
                    var response = PublicIPAddressRestClient.ListVirtualMachineScaleSetPublicIPAddresses(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPAddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PublicIPAddressResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = PublicIPAddressClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetPublicIPAddressesByMicrosoftComputeVirtualMachineScaleSetPublicipaddress");
                scope.Start();
                try
                {
                    var response = PublicIPAddressRestClient.ListVirtualMachineScaleSetPublicIPAddressesNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPAddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
