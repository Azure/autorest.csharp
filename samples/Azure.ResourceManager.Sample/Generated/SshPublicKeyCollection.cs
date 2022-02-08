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
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of SshPublicKey and their operations over its parent. </summary>
    public partial class SshPublicKeyCollection : ArmCollection, IEnumerable<SshPublicKey>, IAsyncEnumerable<SshPublicKey>
    {
        private readonly ClientDiagnostics _sshPublicKeyClientDiagnostics;
        private readonly SshPublicKeysRestOperations _sshPublicKeyRestClient;

        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyCollection"/> class for mocking. </summary>
        protected SshPublicKeyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SshPublicKeyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sshPublicKeyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sample", SshPublicKey.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(SshPublicKey.ResourceType, out string sshPublicKeyApiVersion);
            _sshPublicKeyRestClient = new SshPublicKeysRestOperations(_sshPublicKeyClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, sshPublicKeyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new SSH public key resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Create
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="parameters"> Parameters supplied to create the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SshPublicKeyCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string sshPublicKeyName, SshPublicKeyData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SshPublicKeyCreateOrUpdateOperation(Client, response);
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

        /// <summary>
        /// Creates a new SSH public key resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Create
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="parameters"> Parameters supplied to create the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SshPublicKeyCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string sshPublicKeyName, SshPublicKeyData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _sshPublicKeyRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, parameters, cancellationToken);
                var operation = new SshPublicKeyCreateOrUpdateOperation(Client, response);
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

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public async virtual Task<Response<SshPublicKey>> GetAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.Get");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _sshPublicKeyClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SshPublicKey(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual Response<SshPublicKey> Get(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.Get");
            scope.Start();
            try
            {
                var response = _sshPublicKeyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken);
                if (response.Value == null)
                    throw _sshPublicKeyClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SshPublicKey(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all of the SSH public keys in the specified resource group. Use the nextLink property in the response to get the next page of SSH public keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys
        /// Operation Id: SshPublicKeys_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SshPublicKey" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SshPublicKey> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SshPublicKey>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sshPublicKeyRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKey(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SshPublicKey>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sshPublicKeyRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKey(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all of the SSH public keys in the specified resource group. Use the nextLink property in the response to get the next page of SSH public keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys
        /// Operation Id: SshPublicKeys_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SshPublicKey" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SshPublicKey> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SshPublicKey> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sshPublicKeyRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKey(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SshPublicKey> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sshPublicKeyRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKey(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(sshPublicKeyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual Response<bool> Exists(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(sshPublicKeyName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public async virtual Task<Response<SshPublicKey>> GetIfExistsAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SshPublicKey>(null, response.GetRawResponse());
                return Response.FromValue(new SshPublicKey(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual Response<SshPublicKey> GetIfExists(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _sshPublicKeyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SshPublicKey>(null, response.GetRawResponse());
                return Response.FromValue(new SshPublicKey(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SshPublicKey> IEnumerable<SshPublicKey>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SshPublicKey> IAsyncEnumerable<SshPublicKey>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
