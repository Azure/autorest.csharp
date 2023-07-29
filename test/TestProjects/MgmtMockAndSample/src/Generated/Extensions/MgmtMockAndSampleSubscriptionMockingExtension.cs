// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtMockAndSample;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MgmtMockAndSampleSubscriptionMockingExtension : ArmResource
    {
        private ClientDiagnostics _vaultClientDiagnostics;
        private VaultsRestOperations _vaultRestClient;
        private ClientDiagnostics _vaultsClientDiagnostics;
        private VaultsRestOperations _vaultsRestClient;
        private ClientDiagnostics _diskEncryptionSetClientDiagnostics;
        private DiskEncryptionSetsRestOperations _diskEncryptionSetRestClient;
        private ClientDiagnostics _managedHsmClientDiagnostics;
        private ManagedHsmsRestOperations _managedHsmRestClient;
        private ClientDiagnostics _managedHsmsClientDiagnostics;
        private ManagedHsmsRestOperations _managedHsmsRestClient;
        private ClientDiagnostics _firewallPolicyClientDiagnostics;
        private FirewallPoliciesRestOperations _firewallPolicyRestClient;

        /// <summary> Initializes a new instance of the <see cref="MgmtMockAndSampleSubscriptionMockingExtension"/> class for mocking. </summary>
        protected MgmtMockAndSampleSubscriptionMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtMockAndSampleSubscriptionMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtMockAndSampleSubscriptionMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics VaultClientDiagnostics => _vaultClientDiagnostics ??= new ClientDiagnostics("MgmtMockAndSample", VaultResource.ResourceType.Namespace, Diagnostics);
        private VaultsRestOperations VaultRestClient => _vaultRestClient ??= new VaultsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(VaultResource.ResourceType));
        private ClientDiagnostics VaultsClientDiagnostics => _vaultsClientDiagnostics ??= new ClientDiagnostics("MgmtMockAndSample", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private VaultsRestOperations VaultsRestClient => _vaultsRestClient ??= new VaultsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics DiskEncryptionSetClientDiagnostics => _diskEncryptionSetClientDiagnostics ??= new ClientDiagnostics("MgmtMockAndSample", DiskEncryptionSetResource.ResourceType.Namespace, Diagnostics);
        private DiskEncryptionSetsRestOperations DiskEncryptionSetRestClient => _diskEncryptionSetRestClient ??= new DiskEncryptionSetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(DiskEncryptionSetResource.ResourceType));
        private ClientDiagnostics ManagedHsmClientDiagnostics => _managedHsmClientDiagnostics ??= new ClientDiagnostics("MgmtMockAndSample", ManagedHsmResource.ResourceType.Namespace, Diagnostics);
        private ManagedHsmsRestOperations ManagedHsmRestClient => _managedHsmRestClient ??= new ManagedHsmsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ManagedHsmResource.ResourceType));
        private ClientDiagnostics ManagedHsmsClientDiagnostics => _managedHsmsClientDiagnostics ??= new ClientDiagnostics("MgmtMockAndSample", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private ManagedHsmsRestOperations ManagedHsmsRestClient => _managedHsmsRestClient ??= new ManagedHsmsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics FirewallPolicyClientDiagnostics => _firewallPolicyClientDiagnostics ??= new ClientDiagnostics("MgmtMockAndSample", FirewallPolicyResource.ResourceType.Namespace, Diagnostics);
        private FirewallPoliciesRestOperations FirewallPolicyRestClient => _firewallPolicyRestClient ??= new FirewallPoliciesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(FirewallPolicyResource.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of DeletedVaultResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of DeletedVaultResources and their operations over a DeletedVaultResource. </returns>
        public virtual DeletedVaultCollection GetDeletedVaults()
        {
            return GetCachedClient(Client => new DeletedVaultCollection(Client, Id));
        }

        /// <summary>
        /// Gets the deleted Azure key vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DeletedVaultResource>> GetDeletedVaultAsync(AzureLocation location, string vaultName, CancellationToken cancellationToken = default)
        {
            return await GetDeletedVaults().GetAsync(location, vaultName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the deleted Azure key vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DeletedVaultResource> GetDeletedVault(AzureLocation location, string vaultName, CancellationToken cancellationToken = default)
        {
            return GetDeletedVaults().Get(location, vaultName, cancellationToken);
        }

        /// <summary> Gets a collection of VirtualMachineExtensionImageResources in the SubscriptionResource. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> is null. </exception>
        /// <returns> An object representing collection of VirtualMachineExtensionImageResources and their operations over a VirtualMachineExtensionImageResource. </returns>
        public virtual VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(AzureLocation location, string publisherName)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));

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
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
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
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            return GetVirtualMachineExtensionImages(location, publisherName).Get(type, version, cancellationToken);
        }

        /// <summary> Gets a collection of DeletedManagedHsmResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of DeletedManagedHsmResources and their operations over a DeletedManagedHsmResource. </returns>
        public virtual DeletedManagedHsmCollection GetDeletedManagedHsms()
        {
            return GetCachedClient(Client => new DeletedManagedHsmCollection(Client, Id));
        }

        /// <summary>
        /// Gets the specified deleted managed HSM.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DeletedManagedHsmResource>> GetDeletedManagedHsmAsync(AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            return await GetDeletedManagedHsms().GetAsync(location, name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified deleted managed HSM.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DeletedManagedHsmResource> GetDeletedManagedHsm(AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            return GetDeletedManagedHsms().Get(location, name, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the vaults associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/vaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VaultResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VaultResource> GetVaultsAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VaultRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VaultRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, top);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VaultResource(Client, VaultData.DeserializeVaultData(e)), VaultClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetVaults", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the vaults associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/vaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VaultResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VaultResource> GetVaults(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VaultRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VaultRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, top);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VaultResource(Client, VaultData.DeserializeVaultData(e)), VaultClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetVaults", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets information about the deleted vaults in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_ListDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedVaultResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeletedVaultResource> GetDeletedVaultsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VaultsRestClient.CreateListDeletedRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VaultsRestClient.CreateListDeletedNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new DeletedVaultResource(Client, DeletedVaultData.DeserializeDeletedVaultData(e)), VaultsClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetDeletedVaults", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets information about the deleted vaults in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_ListDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedVaultResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeletedVaultResource> GetDeletedVaults(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VaultsRestClient.CreateListDeletedRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => VaultsRestClient.CreateListDeletedNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new DeletedVaultResource(Client, DeletedVaultData.DeserializeDeletedVaultData(e)), VaultsClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetDeletedVaults", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks that the vault name is valid and is not already in use.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_CheckNameAvailability</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<CheckNameAvailabilityResult>> CheckNameAvailabilityVaultAsync(VaultCheckNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = VaultClientDiagnostics.CreateScope("MgmtMockAndSampleSubscriptionMockingExtension.CheckNameAvailabilityVault");
            scope.Start();
            try
            {
                var response = await VaultRestClient.CheckNameAvailabilityAsync(Id.SubscriptionId, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks that the vault name is valid and is not already in use.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_CheckNameAvailability</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<CheckNameAvailabilityResult> CheckNameAvailabilityVault(VaultCheckNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = VaultClientDiagnostics.CreateScope("MgmtMockAndSampleSubscriptionMockingExtension.CheckNameAvailabilityVault");
            scope.Start();
            try
            {
                var response = VaultRestClient.CheckNameAvailability(Id.SubscriptionId, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all the disk encryption sets under a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/diskEncryptionSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DiskEncryptionSets_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DiskEncryptionSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DiskEncryptionSetResource> GetDiskEncryptionSetsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => DiskEncryptionSetRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DiskEncryptionSetRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new DiskEncryptionSetResource(Client, DiskEncryptionSetData.DeserializeDiskEncryptionSetData(e)), DiskEncryptionSetClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetDiskEncryptionSets", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all the disk encryption sets under a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/diskEncryptionSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DiskEncryptionSets_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DiskEncryptionSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DiskEncryptionSetResource> GetDiskEncryptionSets(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => DiskEncryptionSetRestClient.CreateListRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => DiskEncryptionSetRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new DiskEncryptionSetResource(Client, DiskEncryptionSetData.DeserializeDiskEncryptionSetData(e)), DiskEncryptionSetClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetDiskEncryptionSets", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the managed HSM Pools associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/managedHSMs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedHsmResource> GetManagedHsmsAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ManagedHsmRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ManagedHsmRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, top);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ManagedHsmResource(Client, ManagedHsmData.DeserializeManagedHsmData(e)), ManagedHsmClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetManagedHsms", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the managed HSM Pools associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/managedHSMs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedHsmResource> GetManagedHsms(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ManagedHsmRestClient.CreateListBySubscriptionRequest(Id.SubscriptionId, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ManagedHsmRestClient.CreateListBySubscriptionNextPageRequest(nextLink, Id.SubscriptionId, top);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ManagedHsmResource(Client, ManagedHsmData.DeserializeManagedHsmData(e)), ManagedHsmClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetManagedHsms", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the deleted managed HSMs associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedManagedHSMs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_ListDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeletedManagedHsmResource> GetDeletedManagedHsmsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ManagedHsmsRestClient.CreateListDeletedRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ManagedHsmsRestClient.CreateListDeletedNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new DeletedManagedHsmResource(Client, DeletedManagedHsmData.DeserializeDeletedManagedHsmData(e)), ManagedHsmsClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetDeletedManagedHsms", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the deleted managed HSMs associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedManagedHSMs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_ListDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeletedManagedHsmResource> GetDeletedManagedHsms(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => ManagedHsmsRestClient.CreateListDeletedRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => ManagedHsmsRestClient.CreateListDeletedNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new DeletedManagedHsmResource(Client, DeletedManagedHsmData.DeserializeDeletedManagedHsmData(e)), ManagedHsmsClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetDeletedManagedHsms", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all the Firewall Policies in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/firewallPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FirewallPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FirewallPolicyResource> GetFirewallPoliciesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FirewallPolicyRestClient.CreateListAllRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FirewallPolicyRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FirewallPolicyResource(Client, FirewallPolicyData.DeserializeFirewallPolicyData(e)), FirewallPolicyClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetFirewallPolicies", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all the Firewall Policies in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/firewallPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FirewallPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FirewallPolicyResource> GetFirewallPolicies(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => FirewallPolicyRestClient.CreateListAllRequest(Id.SubscriptionId);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => FirewallPolicyRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FirewallPolicyResource(Client, FirewallPolicyData.DeserializeFirewallPolicyData(e)), FirewallPolicyClientDiagnostics, Pipeline, "MgmtMockAndSampleSubscriptionMockingExtension.GetFirewallPolicies", "value", "nextLink", cancellationToken);
        }
    }
}
