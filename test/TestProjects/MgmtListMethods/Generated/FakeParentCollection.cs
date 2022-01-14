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
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of FakeParent and their operations over its parent. </summary>
    public partial class FakeParentCollection : ArmCollection, IEnumerable<FakeParent>, IAsyncEnumerable<FakeParent>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly FakeParentsRestOperations _fakeParentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentCollection"/> class for mocking. </summary>
        protected FakeParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakeParentCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal FakeParentCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _fakeParentsRestClient = new FakeParentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Fake.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Fake.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParents_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual FakeParentCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string fakeParentName, FakeParentData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentName, parameters, cancellationToken);
                var operation = new FakeParentCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParents_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<FakeParentCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string fakeParentName, FakeParentData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new FakeParentCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParents_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual Response<FakeParent> Get(string fakeParentName, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentsRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParent(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParents_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public async virtual Task<Response<FakeParent>> GetAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentsRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new FakeParent(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual Response<FakeParent> GetIfExists(string fakeParentName, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeParentsRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<FakeParent>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParent(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public async virtual Task<Response<FakeParent>> GetIfExistsAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fakeParentsRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<FakeParent>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParent(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentName, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(fakeParentName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(fakeParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParents_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParent> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentsRestClient.List(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FakeParent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents
        /// ContextualPath: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
        /// OperationId: FakeParents_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParent> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentsRestClient.ListAsync(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FakeParent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParent(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<FakeParent> IEnumerable<FakeParent>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakeParent> IAsyncEnumerable<FakeParent>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, FakeParent, FakeParentData> Construct() { }
    }
}
