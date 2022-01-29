// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using MgmtKeyvault.Models;

namespace MgmtKeyvault
{
    /// <summary> A class representing collection of Vault and their operations over its parent. </summary>
    public partial class VaultCollection : ArmCollection, IEnumerable<Vault>, IAsyncEnumerable<Vault>
    {
        private readonly ClientDiagnostics _vaultClientDiagnostics;
        private readonly VaultsRestOperations _vaultRestClient;

        /// <summary> Initializes a new instance of the <see cref="VaultCollection"/> class for mocking. </summary>
        protected VaultCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VaultCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VaultCollection(ArmResource parent) : base(parent)
        {
            _vaultClientDiagnostics = new ClientDiagnostics("MgmtKeyvault", Vault.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(Vault.ResourceType, out string vaultApiVersion);
            _vaultRestClient = new VaultsRestOperations(_vaultClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, vaultApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Vaults_CreateOrUpdate
        /// <summary> Create or update a key vault in the specified subscription. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="vaultName"> Name of the vault. </param>
        /// <param name="parameters"> Parameters to create or update the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual VaultCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string vaultName, VaultCreateOrUpdateParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _vaultRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, vaultName, parameters, cancellationToken);
                var operation = new VaultCreateOrUpdateOperation(ArmClient, _vaultClientDiagnostics, Pipeline, _vaultRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, vaultName, parameters).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Vaults_CreateOrUpdate
        /// <summary> Create or update a key vault in the specified subscription. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="vaultName"> Name of the vault. </param>
        /// <param name="parameters"> Parameters to create or update the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<VaultCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string vaultName, VaultCreateOrUpdateParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _vaultRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, vaultName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new VaultCreateOrUpdateOperation(ArmClient, _vaultClientDiagnostics, Pipeline, _vaultRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, vaultName, parameters).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Vaults_Get
        /// <summary> Gets the specified Azure key vault. </summary>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public virtual Response<Vault> Get(string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.Get");
            scope.Start();
            try
            {
                var response = _vaultRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vaultName, cancellationToken);
                if (response.Value == null)
                    throw _vaultClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Vault(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Vaults_Get
        /// <summary> Gets the specified Azure key vault. </summary>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public async virtual Task<Response<Vault>> GetAsync(string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.Get");
            scope.Start();
            try
            {
                var response = await _vaultRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vaultName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _vaultClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Vault(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public virtual Response<Vault> GetIfExists(string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _vaultRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vaultName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Vault>(null, response.GetRawResponse());
                return Response.FromValue(new Vault(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public async virtual Task<Response<Vault>> GetIfExistsAsync(string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _vaultRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vaultName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Vault>(null, response.GetRawResponse());
                return Response.FromValue(new Vault(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public virtual Response<bool> Exists(string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(vaultName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(vaultName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Vaults_ListByResourceGroup
        /// <summary> The List operation gets information about the vaults associated with the subscription and within the specified resource group. </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Vault" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Vault> GetAll(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<Vault> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _vaultRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
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
                using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _vaultRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Vaults_ListByResourceGroup
        /// <summary> The List operation gets information about the vaults associated with the subscription and within the specified resource group. </summary>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Vault" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Vault> GetAllAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<Vault>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _vaultRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _vaultClientDiagnostics.CreateScope("VaultCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _vaultRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, top, cancellationToken: cancellationToken).ConfigureAwait(false);
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

        IEnumerator<Vault> IEnumerable<Vault>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Vault> IAsyncEnumerable<Vault>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
