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
    /// <summary> A class representing collection of FakeParentWithNonResCh and their operations over its parent. </summary>
    public partial class FakeParentWithNonResChCollection : ArmCollection, IEnumerable<FakeParentWithNonResCh>, IAsyncEnumerable<FakeParentWithNonResCh>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly FakeParentWithNonResChesRestOperations _fakeParentWithNonResChesRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithNonResChCollection"/> class for mocking. </summary>
        protected FakeParentWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of FakeParentWithNonResChCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal FakeParentWithNonResChCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _fakeParentWithNonResChesRestClient = new FakeParentWithNonResChesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Fake.ResourceType)
                throw new ArgumentException(nameof(id), string.Format("Invalid resource type {0} expected {1}", id.ResourceType, Fake.ResourceType));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithNonResChes_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual FakeParentWithNonResChCreateOrUpdateOperation CreateOrUpdate(string fakeParentWithNonResChName, FakeParentWithNonResChData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentWithNonResChesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, parameters, cancellationToken);
                var operation = new FakeParentWithNonResChCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithNonResChes_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<FakeParentWithNonResChCreateOrUpdateOperation> CreateOrUpdateAsync(string fakeParentWithNonResChName, FakeParentWithNonResChData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentWithNonResChesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new FakeParentWithNonResChCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithNonResChes_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public virtual Response<FakeParentWithNonResCh> Get(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentWithNonResChesRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithNonResChes_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<FakeParentWithNonResCh>> GetAsync(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentWithNonResChesRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new FakeParentWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public virtual Response<FakeParentWithNonResCh> GetIfExists(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeParentWithNonResChesRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<FakeParentWithNonResCh>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParentWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<FakeParentWithNonResCh>> GetIfExistsAsync(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _fakeParentWithNonResChesRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<FakeParentWithNonResCh>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParentWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(fakeParentWithNonResChName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(fakeParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithNonResChes_ListTest
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithNonResCh> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParentWithNonResCh> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithNonResChesRestClient.ListTest(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FakeParentWithNonResCh> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithNonResChesRestClient.ListTestNextPage(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParentWithNonResChes_ListTest
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithNonResCh> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParentWithNonResCh>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithNonResChesRestClient.ListTestAsync(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FakeParentWithNonResCh>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithNonResChesRestClient.ListTestNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<FakeParentWithNonResCh> IEnumerable<FakeParentWithNonResCh>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakeParentWithNonResCh> IAsyncEnumerable<FakeParentWithNonResCh>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, FakeParentWithNonResCh, FakeParentWithNonResChData> Construct() { }
    }
}
