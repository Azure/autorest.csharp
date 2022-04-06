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

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="FakeParentWithAncestorWithNonResChResource" /> and their operations.
    /// Each <see cref="FakeParentWithAncestorWithNonResChResource" /> in the collection will belong to the same instance of <see cref="FakeResource" />.
    /// To get a <see cref="FakeParentWithAncestorWithNonResChCollection" /> instance call the GetFakeParentWithAncestorWithNonResChes method from an instance of <see cref="FakeResource" />.
    /// </summary>
    public partial class FakeParentWithAncestorWithNonResChCollection : ArmCollection, IEnumerable<FakeParentWithAncestorWithNonResChResource>, IAsyncEnumerable<FakeParentWithAncestorWithNonResChResource>
    {
        private readonly ClientDiagnostics _fakeParentWithAncestorWithNonResChClientDiagnostics;
        private readonly FakeParentWithAncestorWithNonResChesRestOperations _fakeParentWithAncestorWithNonResChRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorWithNonResChCollection"/> class for mocking. </summary>
        protected FakeParentWithAncestorWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorWithNonResChCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FakeParentWithAncestorWithNonResChCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeParentWithAncestorWithNonResChClientDiagnostics = new ClientDiagnostics("MgmtListMethods", FakeParentWithAncestorWithNonResChResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FakeParentWithAncestorWithNonResChResource.ResourceType, out string fakeParentWithAncestorWithNonResChApiVersion);
            _fakeParentWithAncestorWithNonResChRestClient = new FakeParentWithAncestorWithNonResChesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fakeParentWithAncestorWithNonResChApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FakeParentWithAncestorWithNonResChResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string fakeParentWithAncestorWithNonResChName, FakeParentWithAncestorWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChName, nameof(fakeParentWithAncestorWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithNonResChRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithAncestorWithNonResChResource>(Response.FromValue(new FakeParentWithAncestorWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FakeParentWithAncestorWithNonResChResource> CreateOrUpdate(WaitUntil waitUntil, string fakeParentWithAncestorWithNonResChName, FakeParentWithAncestorWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChName, nameof(fakeParentWithAncestorWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithNonResChRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithAncestorWithNonResChResource>(Response.FromValue(new FakeParentWithAncestorWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<FakeParentWithAncestorWithNonResChResource>> GetAsync(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChName, nameof(fakeParentWithAncestorWithNonResChName));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithNonResChResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<FakeParentWithAncestorWithNonResChResource> Get(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChName, nameof(fakeParentWithAncestorWithNonResChName));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithNonResChResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes
        /// Operation Id: FakeParentWithAncestorWithNonResChes_ListTest
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestorWithNonResChResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParentWithAncestorWithNonResChResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithAncestorWithNonResChRestClient.ListTestAsync(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FakeParentWithAncestorWithNonResChResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentWithAncestorWithNonResChRestClient.ListTestNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes
        /// Operation Id: FakeParentWithAncestorWithNonResChes_ListTest
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestorWithNonResChResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParentWithAncestorWithNonResChResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithAncestorWithNonResChRestClient.ListTest(Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FakeParentWithAncestorWithNonResChResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentWithAncestorWithNonResChRestClient.ListTestNextPage(nextLink, Id.SubscriptionId, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestorWithNonResChResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChName, nameof(fakeParentWithAncestorWithNonResChName));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}
        /// Operation Id: FakeParentWithAncestorWithNonResChes_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithNonResChName, nameof(fakeParentWithAncestorWithNonResChName));

            using var scope = _fakeParentWithAncestorWithNonResChClientDiagnostics.CreateScope("FakeParentWithAncestorWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithNonResChRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FakeParentWithAncestorWithNonResChResource> IEnumerable<FakeParentWithAncestorWithNonResChResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakeParentWithAncestorWithNonResChResource> IAsyncEnumerable<FakeParentWithAncestorWithNonResChResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
