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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using MgmtKeyvault.Models;

namespace MgmtKeyvault
{
    /// <summary> An internal class to add extension methods to. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _vaultClientDiagnostics;
        private VaultsRestOperations _vaultRestClient;
        private ClientDiagnostics _vaultsClientDiagnostics;
        private VaultsRestOperations _vaultsRestClient;
        private ClientDiagnostics _managedHsmClientDiagnostics;
        private ManagedHsmsRestOperations _managedHsmRestClient;
        private ClientDiagnostics _managedHsmsClientDiagnostics;
        private ManagedHsmsRestOperations _managedHsmsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionExtensionClient(ArmClient armClient, ResourceIdentifier id) : base(armClient, id)
        {
        }

        private ClientDiagnostics VaultClientDiagnostics => _vaultClientDiagnostics ??= new ClientDiagnostics("MgmtKeyvault", Vault.ResourceType.Namespace, DiagnosticOptions);
        private VaultsRestOperations VaultRestClient => _vaultRestClient ??= new VaultsRestOperations(VaultClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(Vault.ResourceType));
        private ClientDiagnostics VaultsClientDiagnostics => _vaultsClientDiagnostics ??= new ClientDiagnostics("MgmtKeyvault", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private VaultsRestOperations VaultsRestClient => _vaultsRestClient ??= new VaultsRestOperations(VaultsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
        private ClientDiagnostics ManagedHsmClientDiagnostics => _managedHsmClientDiagnostics ??= new ClientDiagnostics("MgmtKeyvault", ManagedHsm.ResourceType.Namespace, DiagnosticOptions);
        private ManagedHsmsRestOperations ManagedHsmRestClient => _managedHsmRestClient ??= new ManagedHsmsRestOperations(ManagedHsmClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(ManagedHsm.ResourceType));
        private ClientDiagnostics ManagedHsmsClientDiagnostics => _managedHsmsClientDiagnostics ??= new ClientDiagnostics("MgmtKeyvault", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private ManagedHsmsRestOperations ManagedHsmsRestClient => _managedHsmsRestClient ??= new ManagedHsmsRestOperations(ManagedHsmsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            ArmClient.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/vaults
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Vaults_ListBySubscription
        /// <summary> The List operation gets information about the vaults associated with the subscription. </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Vault" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Vault> GetVaultsAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<Vault>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VaultClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVaults");
                scope.Start();
                try
                {
                    var response = await VaultRestClient.ListBySubscriptionAsync(Id.SubscriptionId, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Vault(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Vault>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VaultClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVaults");
                scope.Start();
                try
                {
                    var response = await VaultRestClient.ListBySubscriptionNextPageAsync(nextLink, Id.SubscriptionId, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Vault(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/vaults
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Vaults_ListBySubscription
        /// <summary> The List operation gets information about the vaults associated with the subscription. </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Vault" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Vault> GetVaults(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<Vault> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VaultClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVaults");
                scope.Start();
                try
                {
                    var response = VaultRestClient.ListBySubscription(Id.SubscriptionId, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Vault(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Vault> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VaultClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetVaults");
                scope.Start();
                try
                {
                    var response = VaultRestClient.ListBySubscriptionNextPage(nextLink, Id.SubscriptionId, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Vault(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of Vaults for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> GetVaultsAsGenericResourcesAsync(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(Vault.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContextAsync(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// <summary> Filters the list of Vaults for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> GetVaultsAsGenericResources(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(Vault.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContext(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Vaults_ListDeleted
        /// <summary> Gets information about the deleted vaults in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedVault" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeletedVault> GetDeletedVaultsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DeletedVault>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VaultsClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeletedVaults");
                scope.Start();
                try
                {
                    var response = await VaultsRestClient.ListDeletedAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedVault(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DeletedVault>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VaultsClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeletedVaults");
                scope.Start();
                try
                {
                    var response = await VaultsRestClient.ListDeletedNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedVault(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Vaults_ListDeleted
        /// <summary> Gets information about the deleted vaults in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedVault" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeletedVault> GetDeletedVaults(CancellationToken cancellationToken = default)
        {
            Page<DeletedVault> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = VaultsClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeletedVaults");
                scope.Start();
                try
                {
                    var response = VaultsRestClient.ListDeleted(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedVault(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DeletedVault> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = VaultsClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeletedVaults");
                scope.Start();
                try
                {
                    var response = VaultsRestClient.ListDeletedNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedVault(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of DeletedVaults for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> GetDeletedVaultsAsGenericResourcesAsync(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(DeletedVault.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContextAsync(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// <summary> Filters the list of DeletedVaults for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> GetDeletedVaultsAsGenericResources(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(DeletedVault.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContext(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/checkNameAvailability
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Vaults_CheckNameAvailability
        /// <summary> Checks that the vault name is valid and is not already in use. </summary>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public async virtual Task<Response<CheckNameAvailabilityResult>> CheckNameAvailabilityVaultAsync(VaultCheckNameAvailabilityParameters vaultName, CancellationToken cancellationToken = default)
        {
            if (vaultName == null)
            {
                throw new ArgumentNullException(nameof(vaultName));
            }

            using var scope = VaultsClientDiagnostics.CreateScope("SubscriptionExtensionClient.CheckNameAvailabilityVault");
            scope.Start();
            try
            {
                var response = await VaultsRestClient.CheckNameAvailabilityAsync(Id.SubscriptionId, vaultName, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/checkNameAvailability
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: Vaults_CheckNameAvailability
        /// <summary> Checks that the vault name is valid and is not already in use. </summary>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public virtual Response<CheckNameAvailabilityResult> CheckNameAvailabilityVault(VaultCheckNameAvailabilityParameters vaultName, CancellationToken cancellationToken = default)
        {
            if (vaultName == null)
            {
                throw new ArgumentNullException(nameof(vaultName));
            }

            using var scope = VaultsClientDiagnostics.CreateScope("SubscriptionExtensionClient.CheckNameAvailabilityVault");
            scope.Start();
            try
            {
                var response = VaultsRestClient.CheckNameAvailability(Id.SubscriptionId, vaultName, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/managedHSMs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ManagedHsms_ListBySubscription
        /// <summary> The List operation gets information about the managed HSM Pools associated with the subscription. </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedHsm" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedHsm> GetManagedHsmsAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedHsm>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ManagedHsmClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetManagedHsms");
                scope.Start();
                try
                {
                    var response = await ManagedHsmRestClient.ListBySubscriptionAsync(Id.SubscriptionId, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedHsm>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ManagedHsmClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetManagedHsms");
                scope.Start();
                try
                {
                    var response = await ManagedHsmRestClient.ListBySubscriptionNextPageAsync(nextLink, Id.SubscriptionId, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/managedHSMs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ManagedHsms_ListBySubscription
        /// <summary> The List operation gets information about the managed HSM Pools associated with the subscription. </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedHsm" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedHsm> GetManagedHsms(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedHsm> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ManagedHsmClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetManagedHsms");
                scope.Start();
                try
                {
                    var response = ManagedHsmRestClient.ListBySubscription(Id.SubscriptionId, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedHsm> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ManagedHsmClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetManagedHsms");
                scope.Start();
                try
                {
                    var response = ManagedHsmRestClient.ListBySubscriptionNextPage(nextLink, Id.SubscriptionId, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of ManagedHsms for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> GetManagedHsmsAsGenericResourcesAsync(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(ManagedHsm.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContextAsync(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// <summary> Filters the list of ManagedHsms for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> GetManagedHsmsAsGenericResources(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(ManagedHsm.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContext(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedManagedHSMs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ManagedHsms_ListDeleted
        /// <summary> The List operation gets information about the deleted managed HSMs associated with the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedManagedHsm" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeletedManagedHsm> GetDeletedManagedHsmsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DeletedManagedHsm>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ManagedHsmsClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeletedManagedHsms");
                scope.Start();
                try
                {
                    var response = await ManagedHsmsRestClient.ListDeletedAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DeletedManagedHsm>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ManagedHsmsClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeletedManagedHsms");
                scope.Start();
                try
                {
                    var response = await ManagedHsmsRestClient.ListDeletedNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedManagedHSMs
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: ManagedHsms_ListDeleted
        /// <summary> The List operation gets information about the deleted managed HSMs associated with the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedManagedHsm" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeletedManagedHsm> GetDeletedManagedHsms(CancellationToken cancellationToken = default)
        {
            Page<DeletedManagedHsm> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ManagedHsmsClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeletedManagedHsms");
                scope.Start();
                try
                {
                    var response = ManagedHsmsRestClient.ListDeleted(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DeletedManagedHsm> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ManagedHsmsClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeletedManagedHsms");
                scope.Start();
                try
                {
                    var response = ManagedHsmsRestClient.ListDeletedNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedManagedHsm(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of DeletedManagedHsms for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> GetDeletedManagedHsmsAsGenericResourcesAsync(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(DeletedManagedHsm.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContextAsync(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }

        /// <summary> Filters the list of DeletedManagedHsms for a <see cref="Subscription" /> represented as generic resources. </summary>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> GetDeletedManagedHsmsAsGenericResources(string filter, string expand, int? top, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new(DeletedManagedHsm.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.GetAtContext(ArmClient.GetSubscription(Id), filters, expand, top, cancellationToken);
        }
    }
}
