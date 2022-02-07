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

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of DeletedAccount and their operations over its parent. </summary>
    public partial class DeletedAccountCollection : ArmCollection, IEnumerable<DeletedAccount>, IAsyncEnumerable<DeletedAccount>
    {
        private readonly ClientDiagnostics _deletedAccountClientDiagnostics;
        private readonly DeletedAccountsRestOperations _deletedAccountRestClient;

        /// <summary> Initializes a new instance of the <see cref="DeletedAccountCollection"/> class for mocking. </summary>
        protected DeletedAccountCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DeletedAccountCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DeletedAccountCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deletedAccountClientDiagnostics = new ClientDiagnostics("Azure.Management.Storage", DeletedAccount.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(DeletedAccount.ResourceType, out string deletedAccountApiVersion);
            _deletedAccountRestClient = new DeletedAccountsRestOperations(_deletedAccountClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deletedAccountApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: DeletedAccounts_Get
        /// <summary> Get properties of specified deleted account resource. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public async virtual Task<Response<DeletedAccount>> GetAsync(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.Get");
            scope.Start();
            try
            {
                var response = await _deletedAccountRestClient.GetAsync(Id.SubscriptionId, location, deletedAccountName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _deletedAccountClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DeletedAccount(Client, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public virtual Response<DeletedAccount> Get(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.Get");
            scope.Start();
            try
            {
                var response = _deletedAccountRestClient.Get(Id.SubscriptionId, location, deletedAccountName, cancellationToken);
                if (response.Value == null)
                    throw _deletedAccountClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedAccount(Client, response.Value), response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="DeletedAccount" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeletedAccount> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DeletedAccount>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deletedAccountRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedAccount(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DeletedAccount>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deletedAccountRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedAccount(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
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
                using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deletedAccountRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedAccount(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DeletedAccount> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deletedAccountRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedAccount(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: DeletedAccounts_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.Exists");
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: DeletedAccounts_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public virtual Response<bool> Exists(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.Exists");
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
        /// ContextualPath: /subscriptions/{subscriptionId}
        /// OperationId: DeletedAccounts_Get
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public async virtual Task<Response<DeletedAccount>> GetIfExistsAsync(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _deletedAccountRestClient.GetAsync(Id.SubscriptionId, location, deletedAccountName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DeletedAccount>(null, response.GetRawResponse());
                return Response.FromValue(new DeletedAccount(Client, response.Value), response.GetRawResponse());
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
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="location"> The location of the deleted storage account. </param>
        /// <param name="deletedAccountName"> Name of the deleted storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="deletedAccountName"/> is null. </exception>
        public virtual Response<DeletedAccount> GetIfExists(string location, string deletedAccountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNullOrEmpty(deletedAccountName, nameof(deletedAccountName));

            using var scope = _deletedAccountClientDiagnostics.CreateScope("DeletedAccountCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _deletedAccountRestClient.Get(Id.SubscriptionId, location, deletedAccountName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DeletedAccount>(null, response.GetRawResponse());
                return Response.FromValue(new DeletedAccount(Client, response.Value), response.GetRawResponse());
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
    }
}
