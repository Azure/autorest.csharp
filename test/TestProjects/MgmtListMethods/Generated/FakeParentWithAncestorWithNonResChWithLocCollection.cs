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
    /// <summary> A class representing collection of FakeParentWithAncestorWithNonResChWithLoc and their operations over its parent. </summary>
    public partial class FakeParentWithAncestorWithNonResChWithLocCollection : ArmCollection, IEnumerable<FakeParentWithAncestorWithNonResChWithLocResource>, IAsyncEnumerable<FakeParentWithAncestorWithNonResChWithLocResource>
    {
        private readonly ClientDiagnostics _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics;
        private readonly FakeParentWithAncestorWithNonResChWithLocsRestOperations _fakeParentWithAncestorWithNonResChWithLocRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorWithNonResChWithLocCollection"/> class for mocking. </summary>
        protected FakeParentWithAncestorWithNonResChWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorWithNonResChWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FakeParentWithAncestorWithNonResChWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", FakeParentWithAncestorWithNonResChWithLocResource.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(FakeParentWithAncestorWithNonResChWithLocResource.ResourceType, out string fakeParentWithAncestorWithNonResChWithLocApiVersion);
            _fakeParentWithAncestorWithNonResChWithLocRestClient = new FakeParentWithAncestorWithNonResChWithLocsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, fakeParentWithAncestorWithNonResChWithLocApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != FakeResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, FakeResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<FakeParentWithAncestorWithNonResChWithLocResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string fakeParentWithAncestorWithNonResChWithLocName, FakeParentWithAncestorWithNonResChWithLocData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithNonResChWithLocRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithAncestorWithNonResChWithLocResource>(Response.FromValue(new FakeParentWithAncestorWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<FakeParentWithAncestorWithNonResChWithLocResource> CreateOrUpdate(WaitUntil waitUntil, string fakeParentWithAncestorWithNonResChWithLocName, FakeParentWithAncestorWithNonResChWithLocData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithNonResChWithLocRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChWithLocName, parameters, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithAncestorWithNonResChWithLocResource>(Response.FromValue(new FakeParentWithAncestorWithNonResChWithLocResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<FakeParentWithAncestorWithNonResChWithLocResource>> GetAsync(string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<FakeParentWithAncestorWithNonResChWithLocResource> Get(string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_ListTest
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestorWithNonResChWithLocResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParentWithAncestorWithNonResChWithLocResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithAncestorWithNonResChWithLocRestClient.ListTestAsync(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResChWithLocResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FakeParentWithAncestorWithNonResChWithLocResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithAncestorWithNonResChWithLocRestClient.ListTestNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResChWithLocResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_ListTest
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithNonResChWithLocResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestorWithNonResChWithLocResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParentWithAncestorWithNonResChWithLocResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithAncestorWithNonResChWithLocRestClient.ListTest(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResChWithLocResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FakeParentWithAncestorWithNonResChWithLocResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithAncestorWithNonResChWithLocRestClient.ListTestNextPage(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResChWithLocResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(fakeParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(fakeParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual async Task<Response<FakeParentWithAncestorWithNonResChWithLocResource>> GetIfExistsAsync(string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithNonResChWithLocRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<FakeParentWithAncestorWithNonResChWithLocResource>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}
        /// Operation Id: FakeParentWithAncestorWithNonResChWithLocs_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<FakeParentWithAncestorWithNonResChWithLocResource> GetIfExists(string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChWithLocName, nameof(fakeParentWithAncestorWithNonResChWithLocName));

            using var scope = _fakeParentWithAncestorWithNonResChWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithNonResChWithLocRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChWithLocName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<FakeParentWithAncestorWithNonResChWithLocResource>(null, response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithNonResChWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FakeParentWithAncestorWithNonResChWithLocResource> IEnumerable<FakeParentWithAncestorWithNonResChWithLocResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakeParentWithAncestorWithNonResChWithLocResource> IAsyncEnumerable<FakeParentWithAncestorWithNonResChWithLocResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
