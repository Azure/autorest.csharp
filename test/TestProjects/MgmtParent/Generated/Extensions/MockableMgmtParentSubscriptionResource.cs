// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtParent;

namespace MgmtParent.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableMgmtParentSubscriptionResource : ArmResource
    {
        private ClientDiagnostics _availabilitySetClientDiagnostics;
        private AvailabilitySetsRestOperations _availabilitySetRestClient;

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtParentSubscriptionResource"/> class for mocking. </summary>
        protected MockableMgmtParentSubscriptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtParentSubscriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtParentSubscriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
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
        /// <param name="publisherName"> The <see cref="string"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="publisherName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of VirtualMachineExtensionImageResources and their operations over a VirtualMachineExtensionImageResource. </returns>
        public virtual VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(string location, string publisherName)
        {
            return new VirtualMachineExtensionImageCollection(Client, Id, location, publisherName);
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineExtensionImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The <see cref="string"/> to use. </param>
        /// <param name="type"> The <see cref="string"/> to use. </param>
        /// <param name="version"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(string location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            return await GetVirtualMachineExtensionImages(location, publisherName).GetAsync(type, version, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineExtensionImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The <see cref="string"/> to use. </param>
        /// <param name="type"> The <see cref="string"/> to use. </param>
        /// <param name="version"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/>, <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(string location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            return GetVirtualMachineExtensionImages(location, publisherName).Get(type, version, cancellationToken);
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
        /// <returns> An async collection of <see cref="AvailabilitySetResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AvailabilitySetResource> GetAvailabilitySetsAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AvailabilitySetRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AvailabilitySetRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, expand);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AvailabilitySetResource(Client, AvailabilitySetData.DeserializeAvailabilitySetData(e)), AvailabilitySetClientDiagnostics, Pipeline, "MockableMgmtParentSubscriptionResource.GetAvailabilitySets", "value", "nextLink", cancellationToken);
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
        /// <returns> A collection of <see cref="AvailabilitySetResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AvailabilitySetResource> GetAvailabilitySets(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => AvailabilitySetRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => AvailabilitySetRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, expand);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AvailabilitySetResource(Client, AvailabilitySetData.DeserializeAvailabilitySetData(e)), AvailabilitySetClientDiagnostics, Pipeline, "MockableMgmtParentSubscriptionResource.GetAvailabilitySets", "value", "nextLink", cancellationToken);
        }
    }
}
