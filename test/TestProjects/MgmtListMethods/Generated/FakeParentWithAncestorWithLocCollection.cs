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
    /// A class representing a collection of <see cref="FakeParentWithAncestorWithLocResource"/> and their operations.
    /// Each <see cref="FakeParentWithAncestorWithLocResource"/> in the collection will belong to the same instance of <see cref="FakeResource"/>.
    /// To get a <see cref="FakeParentWithAncestorWithLocCollection"/> instance call the GetFakeParentWithAncestorWithLocs method from an instance of <see cref="FakeResource"/>.
    /// </summary>
    public partial class FakeParentWithAncestorWithLocCollection : ArmCollection, IEnumerable<FakeParentWithAncestorWithLocResource>, IAsyncEnumerable<FakeParentWithAncestorWithLocResource>
    {
        private readonly ClientDiagnostics _fakeParentWithAncestorWithLocClientDiagnostics;
        private readonly FakeParentWithAncestorWithLocsRestOperations _fakeParentWithAncestorWithLocRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorWithLocCollection"/> class for mocking. </summary>
        protected FakeParentWithAncestorWithLocCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorWithLocCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FakeParentWithAncestorWithLocCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeParentWithAncestorWithLocClientDiagnostics = new ClientDiagnostics("MgmtListMethods", FakeParentWithAncestorWithLocResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FakeParentWithAncestorWithLocResource.ResourceType, out string fakeParentWithAncestorWithLocApiVersion);
            _fakeParentWithAncestorWithLocRestClient = new FakeParentWithAncestorWithLocsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fakeParentWithAncestorWithLocApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FakeParentWithAncestorWithLocResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string fakeParentWithAncestorWithLocName, FakeParentWithAncestorWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithLocName, nameof(fakeParentWithAncestorWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentWithAncestorWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithLocRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithLocName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithAncestorWithLocResource>(Response.FromValue(new FakeParentWithAncestorWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FakeParentWithAncestorWithLocResource> CreateOrUpdate(WaitUntil waitUntil, string fakeParentWithAncestorWithLocName, FakeParentWithAncestorWithLocData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithLocName, nameof(fakeParentWithAncestorWithLocName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentWithAncestorWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithLocCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithLocRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithLocName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithAncestorWithLocResource>(Response.FromValue(new FakeParentWithAncestorWithLocResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> is null. </exception>
        public virtual async Task<Response<FakeParentWithAncestorWithLocResource>> GetAsync(string fakeParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithLocName, nameof(fakeParentWithAncestorWithLocName));

            using var scope = _fakeParentWithAncestorWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithLocRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithLocResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> is null. </exception>
        public virtual Response<FakeParentWithAncestorWithLocResource> Get(string fakeParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithLocName, nameof(fakeParentWithAncestorWithLocName));

            using var scope = _fakeParentWithAncestorWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithLocCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithLocRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithLocName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithLocResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListTest</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorWithLocResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestorWithLocResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeParentWithAncestorWithLocRestClient.CreateListTestRequest(Id.SubscriptionId, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakeParentWithAncestorWithLocRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithLocResource(Client, FakeParentWithAncestorWithLocData.DeserializeFakeParentWithAncestorWithLocData(e)), _fakeParentWithAncestorWithLocClientDiagnostics, Pipeline, "FakeParentWithAncestorWithLocCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_ListTest</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorWithLocResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestorWithLocResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeParentWithAncestorWithLocRestClient.CreateListTestRequest(Id.SubscriptionId, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakeParentWithAncestorWithLocRestClient.CreateListTestNextPageRequest(nextLink, Id.SubscriptionId, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorWithLocResource(Client, FakeParentWithAncestorWithLocData.DeserializeFakeParentWithAncestorWithLocData(e)), _fakeParentWithAncestorWithLocClientDiagnostics, Pipeline, "FakeParentWithAncestorWithLocCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string fakeParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithLocName, nameof(fakeParentWithAncestorWithLocName));

            using var scope = _fakeParentWithAncestorWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithLocRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithLocName, nameof(fakeParentWithAncestorWithLocName));

            using var scope = _fakeParentWithAncestorWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithLocCollection.Exists");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithLocRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithLocName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> is null. </exception>
        public virtual async Task<NullableResponse<FakeParentWithAncestorWithLocResource>> GetIfExistsAsync(string fakeParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithLocName, nameof(fakeParentWithAncestorWithLocName));

            using var scope = _fakeParentWithAncestorWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorWithLocRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<FakeParentWithAncestorWithLocResource>(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithLocResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2020-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="FakeParentWithAncestorWithLocResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> is null. </exception>
        public virtual NullableResponse<FakeParentWithAncestorWithLocResource> GetIfExists(string fakeParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorWithLocName, nameof(fakeParentWithAncestorWithLocName));

            using var scope = _fakeParentWithAncestorWithLocClientDiagnostics.CreateScope("FakeParentWithAncestorWithLocCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorWithLocRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorWithLocName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<FakeParentWithAncestorWithLocResource>(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorWithLocResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FakeParentWithAncestorWithLocResource> IEnumerable<FakeParentWithAncestorWithLocResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakeParentWithAncestorWithLocResource> IAsyncEnumerable<FakeParentWithAncestorWithLocResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
