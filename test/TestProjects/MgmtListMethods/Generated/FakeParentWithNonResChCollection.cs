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
    /// A class representing a collection of <see cref="FakeParentWithNonResChResource"/> and their operations.
    /// Each <see cref="FakeParentWithNonResChResource"/> in the collection will belong to the same instance of <see cref="FakeResource"/>.
    /// To get a <see cref="FakeParentWithNonResChCollection"/> instance call the GetFakeParentWithNonResChes method from an instance of <see cref="FakeResource"/>.
    /// </summary>
    public partial class FakeParentWithNonResChCollection : ArmCollection, IEnumerable<FakeParentWithNonResChResource>, IAsyncEnumerable<FakeParentWithNonResChResource>
    {
        private readonly ClientDiagnostics _fakeParentWithNonResChClientDiagnostics;
        private readonly FakeParentWithNonResChesRestOperations _fakeParentWithNonResChRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithNonResChCollection"/> class for mocking. </summary>
        protected FakeParentWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithNonResChCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FakeParentWithNonResChCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeParentWithNonResChClientDiagnostics = new ClientDiagnostics("MgmtListMethods", FakeParentWithNonResChResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FakeParentWithNonResChResource.ResourceType, out string fakeParentWithNonResChApiVersion);
            _fakeParentWithNonResChRestClient = new FakeParentWithNonResChesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fakeParentWithNonResChApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FakeParentWithNonResChResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string fakeParentWithNonResChName, FakeParentWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithNonResChName, nameof(fakeParentWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentWithNonResChClientDiagnostics.CreateScope("FakeParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentWithNonResChRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithNonResChResource>(Response.FromValue(new FakeParentWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FakeParentWithNonResChResource> CreateOrUpdate(WaitUntil waitUntil, string fakeParentWithNonResChName, FakeParentWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithNonResChName, nameof(fakeParentWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentWithNonResChClientDiagnostics.CreateScope("FakeParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentWithNonResChRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithNonResChResource>(Response.FromValue(new FakeParentWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<FakeParentWithNonResChResource>> GetAsync(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithNonResChName, nameof(fakeParentWithNonResChName));

            using var scope = _fakeParentWithNonResChClientDiagnostics.CreateScope("FakeParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public virtual Response<FakeParentWithNonResChResource> Get(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithNonResChName, nameof(fakeParentWithNonResChName));

            using var scope = _fakeParentWithNonResChClientDiagnostics.CreateScope("FakeParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentWithNonResChRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithNonResChResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithNonResChResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeParentWithNonResChRestClient.CreateListTestRequest(Id.SubscriptionId, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakeParentWithNonResChRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithNonResChResource(Client, FakeParentWithNonResChData.DeserializeFakeParentWithNonResChData(e)), _fakeParentWithNonResChClientDiagnostics, Pipeline, "FakeParentWithNonResChCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_ListTest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithNonResChResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithNonResChResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeParentWithNonResChRestClient.CreateListTestRequest(Id.SubscriptionId, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakeParentWithNonResChRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithNonResChResource(Client, FakeParentWithNonResChData.DeserializeFakeParentWithNonResChData(e)), _fakeParentWithNonResChClientDiagnostics, Pipeline, "FakeParentWithNonResChCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithNonResChName, nameof(fakeParentWithNonResChName));

            using var scope = _fakeParentWithNonResChClientDiagnostics.CreateScope("FakeParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = await _fakeParentWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithNonResChName, nameof(fakeParentWithNonResChName));

            using var scope = _fakeParentWithNonResChClientDiagnostics.CreateScope("FakeParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = _fakeParentWithNonResChRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public virtual async Task<NullableResponse<FakeParentWithNonResChResource>> GetIfExistsAsync(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithNonResChName, nameof(fakeParentWithNonResChName));

            using var scope = _fakeParentWithNonResChClientDiagnostics.CreateScope("FakeParentWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fakeParentWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<FakeParentWithNonResChResource>(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        public virtual NullableResponse<FakeParentWithNonResChResource> GetIfExists(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithNonResChName, nameof(fakeParentWithNonResChName));

            using var scope = _fakeParentWithNonResChClientDiagnostics.CreateScope("FakeParentWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeParentWithNonResChRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithNonResChName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<FakeParentWithNonResChResource>(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FakeParentWithNonResChResource> IEnumerable<FakeParentWithNonResChResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakeParentWithNonResChResource> IAsyncEnumerable<FakeParentWithNonResChResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
