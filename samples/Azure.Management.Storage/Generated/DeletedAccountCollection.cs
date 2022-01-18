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
using Azure.Management.Storage.Models;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of DeletedAccount and their operations over its parent. </summary>
    public partial class DeletedAccountCollection : ArmCollection, IEnumerable<DeletedAccount>, IAsyncEnumerable<DeletedAccount>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly DeletedAccountsRestOperations _deletedAccountsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DeletedAccountCollection"/> class for mocking. </summary>
        protected DeletedAccountCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DeletedAccountCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal DeletedAccountCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(DeletedAccount.ResourceType, out string apiVersion);
            _deletedAccountsRestClient = new DeletedAccountsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: DeletedAccounts_Get
        /// <summary> Get properties of specified deleted account resource. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null or empty. </exception>
        public virtual Response<DeletedAccount> Get(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException($"Parameter {nameof(location)} cannot be null or empty", nameof(location));
            }
            if (string.IsNullOrEmpty(deletedAccountName))
            {
                throw new ArgumentException($"Parameter {nameof(deletedAccountName)} cannot be null or empty", nameof(deletedAccountName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.Get");
            scope.Start();
            try
            {
                var response = _deletedAccountsRestClient.Get(Id.SubscriptionId, location, deletedAccountName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: DeletedAccounts_Get
        /// <summary> Get properties of specified deleted account resource. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null or empty. </exception>
        public async virtual Task<Response<DeletedAccount>> GetAsync(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException($"Parameter {nameof(location)} cannot be null or empty", nameof(location));
            }
            if (string.IsNullOrEmpty(deletedAccountName))
            {
                throw new ArgumentException($"Parameter {nameof(deletedAccountName)} cannot be null or empty", nameof(deletedAccountName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.Get");
            scope.Start();
            try
            {
                var response = await _deletedAccountsRestClient.GetAsync(Id.SubscriptionId, location, deletedAccountName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DeletedAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null or empty. </exception>
        public virtual Response<DeletedAccount> GetIfExists(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException($"Parameter {nameof(location)} cannot be null or empty", nameof(location));
            }
            if (string.IsNullOrEmpty(deletedAccountName))
            {
                throw new ArgumentException($"Parameter {nameof(deletedAccountName)} cannot be null or empty", nameof(deletedAccountName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _deletedAccountsRestClient.Get(Id.SubscriptionId, location, deletedAccountName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DeletedAccount>(null, response.GetRawResponse());
                return Response.FromValue(new DeletedAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null or empty. </exception>
        public async virtual Task<Response<DeletedAccount>> GetIfExistsAsync(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException($"Parameter {nameof(location)} cannot be null or empty", nameof(location));
            }
            if (string.IsNullOrEmpty(deletedAccountName))
            {
                throw new ArgumentException($"Parameter {nameof(deletedAccountName)} cannot be null or empty", nameof(deletedAccountName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _deletedAccountsRestClient.GetAsync(Id.SubscriptionId, location, deletedAccountName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DeletedAccount>(null, response.GetRawResponse());
                return Response.FromValue(new DeletedAccount(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null or empty. </exception>
        public virtual Response<bool> Exists(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException($"Parameter {nameof(location)} cannot be null or empty", nameof(location));
            }
            if (string.IsNullOrEmpty(deletedAccountName))
            {
                throw new ArgumentException($"Parameter {nameof(deletedAccountName)} cannot be null or empty", nameof(deletedAccountName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(location, deletedAccountName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null or empty. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentException($"Parameter {nameof(location)} cannot be null or empty", nameof(location));
            }
            if (string.IsNullOrEmpty(deletedAccountName))
            {
                throw new ArgumentException($"Parameter {nameof(deletedAccountName)} cannot be null or empty", nameof(deletedAccountName));
            }

            using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(location, deletedAccountName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: DeletedAccounts_List
        /// <summary> Lists deleted accounts under the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedAccount" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeletedAccount> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DeletedAccount> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deletedAccountsRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedAccount(this, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DeletedAccount> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deletedAccountsRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedAccount(this, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: DeletedAccounts_List
        /// <summary> Lists deleted accounts under the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedAccount" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeletedAccount> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DeletedAccount>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deletedAccountsRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedAccount(this, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DeletedAccount>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deletedAccountsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedAccount(this, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="DeletedAccount" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DeletedAccount.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="DeletedAccount" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DeletedAccountCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DeletedAccount.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DeletedAccount> IEnumerable<DeletedAccount>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DeletedAccount> IAsyncEnumerable<DeletedAccount>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, DeletedAccount, DeletedAccountData> Construct() { }
    }
}
