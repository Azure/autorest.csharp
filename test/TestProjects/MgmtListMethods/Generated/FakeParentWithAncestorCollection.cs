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
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of FakeParentWithAncestor and their operations over its parent. </summary>
    public partial class FakeParentWithAncestorCollection : ArmCollection, IEnumerable<FakeParentWithAncestor>, IAsyncEnumerable<FakeParentWithAncestor>
    {
        private readonly ClientDiagnostics _fakeParentWithAncestorClientDiagnostics;
        private readonly FakeParentWithAncestorsRestOperations _fakeParentWithAncestorRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorCollection"/> class for mocking. </summary>
        protected FakeParentWithAncestorCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FakeParentWithAncestorCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeParentWithAncestorClientDiagnostics = new ClientDiagnostics("MgmtListMethods", FakeParentWithAncestor.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(FakeParentWithAncestor.ResourceType, out string fakeParentWithAncestorApiVersion);
            _fakeParentWithAncestorRestClient = new FakeParentWithAncestorsRestOperations(_fakeParentWithAncestorClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, fakeParentWithAncestorApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<FakeParentWithAncestorCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string fakeParentWithAncestorName, FakeParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new FakeParentWithAncestorCreateOrUpdateOperation(Client, response);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual FakeParentWithAncestorCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string fakeParentWithAncestorName, FakeParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, parameters, cancellationToken);
                var operation = new FakeParentWithAncestorCreateOrUpdateOperation(Client, response);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<FakeParentWithAncestor>> GetAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _fakeParentWithAncestorClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new FakeParentWithAncestor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual Response<FakeParentWithAncestor> Get(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken);
                if (response.Value == null)
                    throw _fakeParentWithAncestorClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors
        /// Operation Id: FakeParentWithAncestors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestor> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParentWithAncestor>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithAncestorRestClient.ListAsync(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FakeParentWithAncestor>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithAncestorRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors
        /// Operation Id: FakeParentWithAncestors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestor> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParentWithAncestor> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithAncestorRestClient.List(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FakeParentWithAncestor> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithAncestorRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Exists");
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

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Exists");
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

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<FakeParentWithAncestor>> GetIfExistsAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<FakeParentWithAncestor>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual Response<FakeParentWithAncestor> GetIfExists(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<FakeParentWithAncestor>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
    }
}
