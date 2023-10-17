// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="FakeParentResource" /> and their operations.
    /// Each <see cref="FakeParentResource" /> in the collection will belong to the same instance of <see cref="FakeResource" />.
    /// To get a <see cref="FakeParentCollection" /> instance call the GetFakeParents method from an instance of <see cref="FakeResource" />.
    /// </summary>
    public partial class FakeParentCollection : ArmCollection, IEnumerable<FakeParentResource>, IAsyncEnumerable<FakeParentResource>
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
            _fakeParentClientDiagnostics = new ClientDiagnostics("MgmtListMethods", FakeParentResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FakeParentResource.ResourceType, out string fakeParentApiVersion);
            _fakeParentRestClient = new FakeParentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fakeParentApiVersion);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FakeParentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string fakeParentName, FakeParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<FakeParentResource>(Response.FromValue(new FakeParentResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FakeParentResource> CreateOrUpdate(WaitUntil waitUntil, string fakeParentName, FakeParentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<FakeParentResource>(Response.FromValue(new FakeParentResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual async Task<Response<FakeParentResource>> GetAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual Response<FakeParentResource> Get(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeParentRestClient.CreateListRequest(Id.SubscriptionId, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakeParentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, (e, o) => new FakeParentResource(Client, FakeParentData.DeserializeFakeParentData(e)), _fakeParentClientDiagnostics, Pipeline, "FakeParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeParentRestClient.CreateListRequest(Id.SubscriptionId, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakeParentRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, (e, o) => new FakeParentResource(Client, FakeParentData.DeserializeFakeParentData(e)), _fakeParentClientDiagnostics, Pipeline, "FakeParentCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.Exists");
            scope.Start();
            try
            {
                var response = await _fakeParentRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.Exists");
            scope.Start();
            try
            {
                var response = _fakeParentRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken: cancellationToken);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual async Task<NullableResponse<FakeParentResource>> GetIfExistsAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fakeParentRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<FakeParentResource>(response.GetRawResponse());
                return Response.FromValue(new FakeParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        public virtual NullableResponse<FakeParentResource> GetIfExists(string fakeParentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentName, nameof(fakeParentName));

            using var scope = _fakeParentClientDiagnostics.CreateScope("FakeParentCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeParentRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<FakeParentResource>(response.GetRawResponse());
                return Response.FromValue(new FakeParentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FakeParentResource> IEnumerable<FakeParentResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakeParentResource> IAsyncEnumerable<FakeParentResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
