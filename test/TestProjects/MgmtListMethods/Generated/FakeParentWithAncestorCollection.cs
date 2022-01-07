// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of FakeParentWithAncestor and their operations over its parent. </summary>
    public partial class FakeParentWithAncestorCollection : ArmCollection, IEnumerable<FakeParentWithAncestor>, IAsyncEnumerable<FakeParentWithAncestor>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly FakeParentWithAncestorsRestOperations _fakeParentWithAncestorsRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorCollection"/> class for mocking. </summary>
        protected FakeParentWithAncestorCollection()
        {
        }

        /// <summary> Initializes a new instance of FakeParentWithAncestorCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal FakeParentWithAncestorCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _fakeParentWithAncestorsRestClient = new FakeParentWithAncestorsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => Fake.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithAncestors_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual FakeParentWithAncestorCreateOrUpdateOperation CreateOrUpdate(string fakeParentWithAncestorName, FakeParentWithAncestorData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, parameters, cancellationToken);
                var operation = new FakeParentWithAncestorCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithAncestors_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<FakeParentWithAncestorCreateOrUpdateOperation> CreateOrUpdateAsync(string fakeParentWithAncestorName, FakeParentWithAncestorData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new FakeParentWithAncestorCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithAncestors_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual Response<FakeParentWithAncestor> Get(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorsRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestor(Parent, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithAncestors_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<FakeParentWithAncestor>> GetAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorsRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new FakeParentWithAncestor(Parent, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual Response<FakeParentWithAncestor> GetIfExists(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorsRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<FakeParentWithAncestor>(null, response.GetRawResponse())
                    : Response.FromValue(new FakeParentWithAncestor(this, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<FakeParentWithAncestor>> GetIfExistsAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorsRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<FakeParentWithAncestor>(null, response.GetRawResponse())
                    : Response.FromValue(new FakeParentWithAncestor(this, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(fakeParentWithAncestorName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(fakeParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithAncestors_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestor> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParentWithAncestor> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithAncestorsRestClient.List(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Parent, value.Id, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FakeParentWithAncestor> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithAncestorsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Parent, value.Id, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithAncestors_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestor> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParentWithAncestor>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithAncestorsRestClient.ListAsync(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Parent, value.Id, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FakeParentWithAncestor>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithAncestorsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Parent, value.Id, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<FakeParentWithAncestor> IEnumerable<FakeParentWithAncestor>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakeParentWithAncestor> IAsyncEnumerable<FakeParentWithAncestor>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, FakeParentWithAncestor, FakeParentWithAncestorData> Construct() { }
    }
}
