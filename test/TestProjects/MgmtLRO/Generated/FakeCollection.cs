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
using Azure.ResourceManager.Resources;
using MgmtLRO.Models;

namespace MgmtLRO
{
    /// <summary> A class representing collection of Fake and their operations over its parent. </summary>
    public partial class FakeCollection : ArmCollection, IEnumerable<Fake>, IAsyncEnumerable<Fake>
    {
        private readonly ClientDiagnostics _fakeClientDiagnostics;
        private readonly FakesRestOperations _fakeRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeCollection"/> class for mocking. </summary>
        protected FakeCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakeCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FakeCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeClientDiagnostics = new ClientDiagnostics("MgmtLRO", Fake.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(Fake.ResourceType, out string fakeApiVersion);
            _fakeRestClient = new FakesRestOperations(_fakeClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, fakeApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update an fake.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}
        /// Operation Id: Fakes_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<FakeCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string fakeName, FakeData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, fakeName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new FakeCreateOrUpdateOperation(Client, _fakeClientDiagnostics, Pipeline, _fakeRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, fakeName, parameters).Request, response);
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
        /// Create or update an fake.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}
        /// Operation Id: Fakes_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="parameters"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual FakeCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string fakeName, FakeData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, fakeName, parameters, cancellationToken);
                var operation = new FakeCreateOrUpdateOperation(Client, _fakeClientDiagnostics, Pipeline, _fakeRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, fakeName, parameters).Request, response);
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
        /// Retrieves information about an fake.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}
        /// Operation Id: Fakes_Get
        /// </summary>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        public async virtual Task<Response<Fake>> GetAsync(string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, fakeName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _fakeClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Fake(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}
        /// Operation Id: Fakes_Get
        /// </summary>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        public virtual Response<Fake> Get(string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, fakeName, expand, cancellationToken);
                if (response.Value == null)
                    throw _fakeClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Fake(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all fakes in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes
        /// Operation Id: Fakes_List
        /// </summary>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Fake" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Fake> GetAllAsync(string optionalParam = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<Fake>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, optionalParam, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Fake(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Lists all fakes in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes
        /// Operation Id: Fakes_List
        /// </summary>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Fake" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Fake> GetAll(string optionalParam = null, CancellationToken cancellationToken = default)
        {
            Page<Fake> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, optionalParam, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Fake(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}
        /// Operation Id: Fakes_Get
        /// </summary>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(fakeName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}
        /// Operation Id: Fakes_Get
        /// </summary>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(fakeName, expand: expand, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}
        /// Operation Id: Fakes_Get
        /// </summary>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        public async virtual Task<Response<Fake>> GetIfExistsAsync(string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _fakeRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, fakeName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Fake>(null, response.GetRawResponse());
                return Response.FromValue(new Fake(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/fakes/{fakeName}
        /// Operation Id: Fakes_Get
        /// </summary>
        /// <param name="fakeName"> The name of the fake. </param>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeName"/> is null. </exception>
        public virtual Response<Fake> GetIfExists(string fakeName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeName, nameof(fakeName));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _fakeRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, fakeName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Fake>(null, response.GetRawResponse());
                return Response.FromValue(new Fake(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Fake> IEnumerable<Fake>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Fake> IAsyncEnumerable<Fake>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
