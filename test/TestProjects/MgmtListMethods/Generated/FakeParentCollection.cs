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

namespace MgmtListMethods
{
    /// <summary> A class representing collection of FakeParent and their operations over its parent. </summary>
    public partial class FakeParentCollection : ArmCollection, IEnumerable<FakeParent>, IAsyncEnumerable<FakeParent>
    {
        private readonly ClientDiagnostics _fakeParentClientDiagnostics;
        private readonly FakeParentsRestOperations _fakeParentRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentCollection"/> class for mocking. </summary>
        protected FakeParentCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakeParentCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FakeParentCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeParentClientDiagnostics = new ClientDiagnostics("MgmtListMethods", FakeParent.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(FakeParent.ResourceType, out string fakeParentApiVersion);
            _fakeParentRestClient = new FakeParentsRestOperations(_fakeParentClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, fakeParentApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Fake.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Fake.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// Operation Id: FakeParents_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<FakeParent>> CreateOrUpdateAsync(bool waitForCompletion, string fakeParentName, FakeParentData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<FakeParent>(Response.FromValue(new FakeParent(Client, response), response.GetRawResponse()));
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
        /// Create or update.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// Operation Id: FakeParents_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<FakeParent> CreateOrUpdate(bool waitForCompletion, string fakeParentName, FakeParentData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<FakeParent>(Response.FromValue(new FakeParent(Client, response), response.GetRawResponse()));
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
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// Operation Id: FakeParents_Get
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public async virtual Task<Response<FakeParent>> GetAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _fakeParentClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new FakeParent(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// Operation Id: FakeParents_Get
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual Response<FakeParent> Get(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken);
                if (response.Value == null)
                    throw _fakeParentClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParent(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents
        /// Operation Id: FakeParents_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParent> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentRestClient.ListAsync(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParent(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FakeParent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParent(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents
        /// Operation Id: FakeParents_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParent> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentRestClient.List(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParent(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FakeParent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParent(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// Operation Id: FakeParents_Get
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.Exists");
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

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// Operation Id: FakeParents_Get
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.Exists");
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

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// Operation Id: FakeParents_Get
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public async virtual Task<Response<FakeParent>> GetIfExistsAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fakeParentRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<FakeParent>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParent(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}
        /// Operation Id: FakeParents_Get
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual Response<FakeParent> GetIfExists(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeParentRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<FakeParent>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParent(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
    }
}
