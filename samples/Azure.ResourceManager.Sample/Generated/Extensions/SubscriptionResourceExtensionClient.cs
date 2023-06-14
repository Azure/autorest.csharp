// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    internal partial class SubscriptionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _availabilitySetClientDiagnostics;
        private AvailabilitySetsRestOperations _availabilitySetRestClient;
        private ClientDiagnostics _proximityPlacementGroupClientDiagnostics;
        private ProximityPlacementGroupsRestOperations _proximityPlacementGroupRestClient;
        private ClientDiagnostics _dedicatedHostGroupClientDiagnostics;
        private DedicatedHostGroupsRestOperations _dedicatedHostGroupRestClient;
        private ClientDiagnostics _sshPublicKeyClientDiagnostics;
        private SshPublicKeysRestOperations _sshPublicKeyRestClient;
        private ClientDiagnostics _virtualMachineImagesClientDiagnostics;
        private VirtualMachineImagesRestOperations _virtualMachineImagesRestClient;
        private ClientDiagnostics _usageClientDiagnostics;
        private UsageRestOperations _usageRestClient;
        private ClientDiagnostics _virtualMachineClientDiagnostics;
        private VirtualMachinesRestOperations _virtualMachineRestClient;
        private ClientDiagnostics _virtualMachineSizesClientDiagnostics;
        private VirtualMachineSizesRestOperations _virtualMachineSizesRestClient;
        private ClientDiagnostics _imageClientDiagnostics;
        private ImagesRestOperations _imageRestClient;
        private ClientDiagnostics _virtualMachineScaleSetClientDiagnostics;
        private VirtualMachineScaleSetsRestOperations _virtualMachineScaleSetRestClient;
        private ClientDiagnostics _logAnalyticsClientDiagnostics;
        private LogAnalyticsRestOperations _logAnalyticsRestClient;

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

        private ClientDiagnostics AvailabilitySetClientDiagnostics => _availabilitySetClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", AvailabilitySetResource.ResourceType.Namespace, Diagnostics);
        private AvailabilitySetsRestOperations AvailabilitySetRestClient => _availabilitySetRestClient ??= new AvailabilitySetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(AvailabilitySetResource.ResourceType));
        private ClientDiagnostics ProximityPlacementGroupClientDiagnostics => _proximityPlacementGroupClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", ProximityPlacementGroupResource.ResourceType.Namespace, Diagnostics);
        private ProximityPlacementGroupsRestOperations ProximityPlacementGroupRestClient => _proximityPlacementGroupRestClient ??= new ProximityPlacementGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ProximityPlacementGroupResource.ResourceType));
        private ClientDiagnostics DedicatedHostGroupClientDiagnostics => _dedicatedHostGroupClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", DedicatedHostGroupResource.ResourceType.Namespace, Diagnostics);
        private DedicatedHostGroupsRestOperations DedicatedHostGroupRestClient => _dedicatedHostGroupRestClient ??= new DedicatedHostGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(DedicatedHostGroupResource.ResourceType));
        private ClientDiagnostics SshPublicKeyClientDiagnostics => _sshPublicKeyClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", SshPublicKeyResource.ResourceType.Namespace, Diagnostics);
        private SshPublicKeysRestOperations SshPublicKeyRestClient => _sshPublicKeyRestClient ??= new SshPublicKeysRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(SshPublicKeyResource.ResourceType));
        private ClientDiagnostics VirtualMachineImagesClientDiagnostics => _virtualMachineImagesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private VirtualMachineImagesRestOperations VirtualMachineImagesRestClient => _virtualMachineImagesRestClient ??= new VirtualMachineImagesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics UsageClientDiagnostics => _usageClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private UsageRestOperations UsageRestClient => _usageRestClient ??= new UsageRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics VirtualMachineClientDiagnostics => _virtualMachineClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", VirtualMachineResource.ResourceType.Namespace, Diagnostics);
        private VirtualMachinesRestOperations VirtualMachineRestClient => _virtualMachineRestClient ??= new VirtualMachinesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(VirtualMachineResource.ResourceType));
        private ClientDiagnostics VirtualMachineSizesClientDiagnostics => _virtualMachineSizesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private VirtualMachineSizesRestOperations VirtualMachineSizesRestClient => _virtualMachineSizesRestClient ??= new VirtualMachineSizesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics ImageClientDiagnostics => _imageClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", ImageResource.ResourceType.Namespace, Diagnostics);
        private ImagesRestOperations ImageRestClient => _imageRestClient ??= new ImagesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ImageResource.ResourceType));
        private ClientDiagnostics VirtualMachineScaleSetClientDiagnostics => _virtualMachineScaleSetClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", VirtualMachineScaleSetResource.ResourceType.Namespace, Diagnostics);
        private VirtualMachineScaleSetsRestOperations VirtualMachineScaleSetRestClient => _virtualMachineScaleSetRestClient ??= new VirtualMachineScaleSetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(VirtualMachineScaleSetResource.ResourceType));
        private ClientDiagnostics LogAnalyticsClientDiagnostics => _logAnalyticsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Sample", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private LogAnalyticsRestOperations LogAnalyticsRestClient => _logAnalyticsRestClient ??= new LogAnalyticsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of VirtualMachineExtensionImageResources in the SubscriptionResource. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <returns> An object representing collection of VirtualMachineExtensionImageResources and their operations over a VirtualMachineExtensionImageResource. </returns>
        public virtual VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(AzureLocation location, string publisherName)
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

        /// <summary>
        /// Lists all proximity placement groups in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/proximityPlacementGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProximityPlacementGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ProximityPlacementGroupResource> GetProximityPlacementGroupsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ProximityPlacementGroupRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ProximityPlacementGroupRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ProximityPlacementGroupResource(Client, ProximityPlacementGroupData.DeserializeProximityPlacementGroupData(e)), ProximityPlacementGroupClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetProximityPlacementGroups", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all proximity placement groups in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/proximityPlacementGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ProximityPlacementGroups_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProximityPlacementGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ProximityPlacementGroupResource> GetProximityPlacementGroups(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ProximityPlacementGroupRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ProximityPlacementGroupRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ProximityPlacementGroupResource(Client, ProximityPlacementGroupData.DeserializeProximityPlacementGroupData(e)), ProximityPlacementGroupClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetProximityPlacementGroups", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the dedicated host groups in the subscription. Use the nextLink property in the response to get the next page of dedicated host groups.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/hostGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHostGroups_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DedicatedHostGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DedicatedHostGroupResource> GetDedicatedHostGroupsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => DedicatedHostGroupRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DedicatedHostGroupRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new DedicatedHostGroupResource(Client, DedicatedHostGroupData.DeserializeDedicatedHostGroupData(e)), DedicatedHostGroupClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetDedicatedHostGroups", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the dedicated host groups in the subscription. Use the nextLink property in the response to get the next page of dedicated host groups.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/hostGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DedicatedHostGroups_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DedicatedHostGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DedicatedHostGroupResource> GetDedicatedHostGroups(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => DedicatedHostGroupRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DedicatedHostGroupRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new DedicatedHostGroupResource(Client, DedicatedHostGroupData.DeserializeDedicatedHostGroupData(e)), DedicatedHostGroupClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetDedicatedHostGroups", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the SSH public keys in the subscription. Use the nextLink property in the response to get the next page of SSH public keys.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/sshPublicKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SshPublicKeys_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SshPublicKeyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SshPublicKeyResource> GetSshPublicKeysAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => SshPublicKeyRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => SshPublicKeyRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new SshPublicKeyResource(Client, SshPublicKeyData.DeserializeSshPublicKeyData(e)), SshPublicKeyClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetSshPublicKeys", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the SSH public keys in the subscription. Use the nextLink property in the response to get the next page of SSH public keys.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/sshPublicKeys</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SshPublicKeys_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SshPublicKeyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SshPublicKeyResource> GetSshPublicKeys(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => SshPublicKeyRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => SshPublicKeyRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new SshPublicKeyResource(Client, SshPublicKeyData.DeserializeSshPublicKeyData(e)), SshPublicKeyClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetSshPublicKeys", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a virtual machine image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="version"> A valid image SKU version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<VirtualMachineImage>> GetVirtualMachineImageAsync(AzureLocation location, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default)
        {
            using var scope = VirtualMachineImagesClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetVirtualMachineImage");
            scope.Start();
            try
            {
                var response = await VirtualMachineImagesRestClient.GetAsync(Id.SubscriptionId, location, publisherName, offer, skus, version, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a virtual machine image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="version"> A valid image SKU version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VirtualMachineImage> GetVirtualMachineImage(AzureLocation location, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default)
        {
            using var scope = VirtualMachineImagesClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetVirtualMachineImage");
            scope.Start();
            try
            {
                var response = VirtualMachineImagesRestClient.Get(Id.SubscriptionId, location, publisherName, offer, skus, version, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, publisher, offer, and SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineImageResource> GetVirtualMachineImagesAsync(SubscriptionResourceGetVirtualMachineImagesOptions options, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineImagesRestClient.CreateListRequest(Id.SubscriptionId, options.Location, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, VirtualMachineImageResource.DeserializeVirtualMachineImageResource, VirtualMachineImagesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachineImages", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, publisher, offer, and SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineImageResource> GetVirtualMachineImages(SubscriptionResourceGetVirtualMachineImagesOptions options, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineImagesRestClient.CreateListRequest(Id.SubscriptionId, options.Location, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, VirtualMachineImageResource.DeserializeVirtualMachineImageResource, VirtualMachineImagesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachineImages", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image offers for the specified location and publisher.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListOffers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineImageResource> GetOffersVirtualMachineImagesAsync(AzureLocation location, string publisherName, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineImagesRestClient.CreateListOffersRequest(Id.SubscriptionId, location, publisherName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, VirtualMachineImageResource.DeserializeVirtualMachineImageResource, VirtualMachineImagesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetOffersVirtualMachineImages", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image offers for the specified location and publisher.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListOffers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineImageResource> GetOffersVirtualMachineImages(AzureLocation location, string publisherName, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineImagesRestClient.CreateListOffersRequest(Id.SubscriptionId, location, publisherName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, VirtualMachineImageResource.DeserializeVirtualMachineImageResource, VirtualMachineImagesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetOffersVirtualMachineImages", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image publishers for the specified Azure location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListPublishers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineImageResource> GetPublishersVirtualMachineImagesAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineImagesRestClient.CreateListPublishersRequest(Id.SubscriptionId, location);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, VirtualMachineImageResource.DeserializeVirtualMachineImageResource, VirtualMachineImagesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetPublishersVirtualMachineImages", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image publishers for the specified Azure location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListPublishers</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineImageResource> GetPublishersVirtualMachineImages(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineImagesRestClient.CreateListPublishersRequest(Id.SubscriptionId, location);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, VirtualMachineImageResource.DeserializeVirtualMachineImageResource, VirtualMachineImagesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetPublishersVirtualMachineImages", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image SKUs for the specified location, publisher, and offer.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListSkus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineImageResource> GetSkusVirtualMachineImagesAsync(AzureLocation location, string publisherName, string offer, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineImagesRestClient.CreateListSkusRequest(Id.SubscriptionId, location, publisherName, offer);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, VirtualMachineImageResource.DeserializeVirtualMachineImageResource, VirtualMachineImagesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetSkusVirtualMachineImages", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of virtual machine image SKUs for the specified location, publisher, and offer.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_ListSkus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineImageResource> GetSkusVirtualMachineImages(AzureLocation location, string publisherName, string offer, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineImagesRestClient.CreateListSkusRequest(Id.SubscriptionId, location, publisherName, offer);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, VirtualMachineImageResource.DeserializeVirtualMachineImageResource, VirtualMachineImagesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetSkusVirtualMachineImages", "", null, cancellationToken);
        }

        /// <summary>
        /// Gets, for the specified location, the current compute resource usage information as well as the limits for compute resources under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/usages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Usage_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which resource usage is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SampleUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SampleUsage> GetUsagesAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => UsageRestClient.CreateListRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => UsageRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, SampleUsage.DeserializeSampleUsage, UsageClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetUsages", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets, for the specified location, the current compute resource usage information as well as the limits for compute resources under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/usages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Usage_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which resource usage is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SampleUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SampleUsage> GetUsages(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => UsageRestClient.CreateListRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => UsageRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, SampleUsage.DeserializeSampleUsage, UsageClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetUsages", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all the virtual machines under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineResource> GetVirtualMachinesByLocationAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineRestClient.CreateListByLocationRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineRestClient.CreateListByLocationNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), VirtualMachineClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachinesByLocation", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all the virtual machines under the specified subscription for the specified location.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListByLocation</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location for which virtual machines under the subscription are queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineResource> GetVirtualMachinesByLocation(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineRestClient.CreateListByLocationRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineRestClient.CreateListByLocationNextPageRequest(nextLink, Id.SubscriptionId, location);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), VirtualMachineClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachinesByLocation", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineResource> GetVirtualMachinesAsync(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineRestClient.CreateListAllRequest(Id.SubscriptionId, statusOnly);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, statusOnly);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), VirtualMachineClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachines", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/virtualMachines</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachines_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="statusOnly"> statusOnly=true enables fetching run time status of all Virtual Machines in the subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineResource> GetVirtualMachines(string statusOnly = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineRestClient.CreateListAllRequest(Id.SubscriptionId, statusOnly);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VirtualMachineRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, statusOnly);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), VirtualMachineClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachines", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// This API is deprecated. Use [Resources Skus](https://docs.microsoft.com/en-us/rest/api/compute/resourceskus/list)
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/vmSizes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineSizes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineSize" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineSize> GetVirtualMachineSizesAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineSizesRestClient.CreateListRequest(Id.SubscriptionId, location);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, VirtualMachineSize.DeserializeVirtualMachineSize, VirtualMachineSizesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachineSizes", "value", null, cancellationToken);
        }

        /// <summary>
        /// This API is deprecated. Use [Resources Skus](https://docs.microsoft.com/en-us/rest/api/compute/resourceskus/list)
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/vmSizes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineSizes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineSize" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineSize> GetVirtualMachineSizes(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VirtualMachineSizesRestClient.CreateListRequest(Id.SubscriptionId, location);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, VirtualMachineSize.DeserializeVirtualMachineSize, VirtualMachineSizesClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachineSizes", "value", null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of Images in the subscription. Use nextLink property in the response to get the next page of Images. Do this till nextLink is null to fetch all the Images.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ImageResource> GetImagesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ImageRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ImageRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ImageResource(Client, ImageData.DeserializeImageData(e)), ImageClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetImages", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets the list of Images in the subscription. Use nextLink property in the response to get the next page of Images. Do this till nextLink is null to fetch all the Images.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ImageResource> GetImages(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ImageRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ImageRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ImageResource(Client, ImageData.DeserializeImageData(e)), ImageClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetImages", "value", "nextLink", cancellationToken);
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
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineScaleSetResource(Client, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(e)), VirtualMachineScaleSetClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
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
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineScaleSetResource(Client, VirtualMachineScaleSetData.DeserializeVirtualMachineScaleSetData(e)), VirtualMachineScaleSetClientDiagnostics, Pipeline, "SubscriptionResourceExtensionClient.GetVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Export logs that show Api requests made by this subscription in the given time window to show throttling activities.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getRequestRateByInterval</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportRequestRateByInterval</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getRequestRateByInterval Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<LogAnalytics>> ExportRequestRateByIntervalLogAnalyticAsync(WaitUntil waitUntil, AzureLocation location, RequestRateByIntervalContent content, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.ExportRequestRateByIntervalLogAnalytic");
            scope.Start();
            try
            {
                var response = await LogAnalyticsRestClient.ExportRequestRateByIntervalAsync(Id.SubscriptionId, location, content, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportRequestRateByIntervalRequest(Id.SubscriptionId, location, content).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Export logs that show Api requests made by this subscription in the given time window to show throttling activities.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getRequestRateByInterval</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportRequestRateByInterval</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getRequestRateByInterval Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<LogAnalytics> ExportRequestRateByIntervalLogAnalytic(WaitUntil waitUntil, AzureLocation location, RequestRateByIntervalContent content, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.ExportRequestRateByIntervalLogAnalytic");
            scope.Start();
            try
            {
                var response = LogAnalyticsRestClient.ExportRequestRateByInterval(Id.SubscriptionId, location, content, cancellationToken);
                var operation = new SampleArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportRequestRateByIntervalRequest(Id.SubscriptionId, location, content).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Export logs that show total throttled Api requests for this subscription in the given time window.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getThrottledRequests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportThrottledRequests</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getThrottledRequests Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<LogAnalytics>> ExportThrottledRequestsLogAnalyticAsync(WaitUntil waitUntil, AzureLocation location, ThrottledRequestsContent content, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.ExportThrottledRequestsLogAnalytic");
            scope.Start();
            try
            {
                var response = await LogAnalyticsRestClient.ExportThrottledRequestsAsync(Id.SubscriptionId, location, content, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportThrottledRequestsRequest(Id.SubscriptionId, location, content).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Export logs that show total throttled Api requests for this subscription in the given time window.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/logAnalytics/apiAccess/getThrottledRequests</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_ExportThrottledRequests</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="location"> The location upon which virtual-machine-sizes is queried. </param>
        /// <param name="content"> Parameters supplied to the LogAnalytics getThrottledRequests Api. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<LogAnalytics> ExportThrottledRequestsLogAnalytic(WaitUntil waitUntil, AzureLocation location, ThrottledRequestsContent content, CancellationToken cancellationToken = default)
        {
            using var scope = LogAnalyticsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.ExportThrottledRequestsLogAnalytic");
            scope.Start();
            try
            {
                var response = LogAnalyticsRestClient.ExportThrottledRequests(Id.SubscriptionId, location, content, cancellationToken);
                var operation = new SampleArmOperation<LogAnalytics>(new LogAnalyticsOperationSource(), LogAnalyticsClientDiagnostics, Pipeline, LogAnalyticsRestClient.CreateExportThrottledRequestsRequest(Id.SubscriptionId, location, content).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
