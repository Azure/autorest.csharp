// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
    /// <summary> A class representing collection of FakeParent and their operations over its parent. </summary>
    public partial class FakeParentContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly FakeParentsRestOperations _fakeParentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentContainer"/> class for mocking. </summary>
        protected FakeParentContainer()
        {
        }

        /// <summary> Initializes a new instance of FakeParentContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal FakeParentContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _fakeParentsRestClient = new FakeParentsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => "Microsoft.Fake/fakes";

        // Container level operations.

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual FakeParentCreateOrUpdateOperation CreateOrUpdate(string fakeParentName, FakeParentData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentsRestClient.CreateOrUpdate(Id.Name, fakeParentName, parameters, cancellationToken);
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

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<FakeParentCreateOrUpdateOperation> CreateOrUpdateAsync(string fakeParentName, FakeParentData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (fakeParentName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentsRestClient.CreateOrUpdateAsync(Id.Name, fakeParentName, parameters, cancellationToken).ConfigureAwait(false);
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

            using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.Get");
            scope.Start();
            try
            {
                var response = _fakeParentsRestClient.Get(Id.Name, fakeParentName, cancellationToken);
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

            using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentsRestClient.GetAsync(Id.Name, fakeParentName, cancellationToken).ConfigureAwait(false);
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
            using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.GetIfExists");
            scope.Start();
            try
            {
                if (fakeParentName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentName));
                }

                var response = _fakeParentsRestClient.Get(Id.Name, fakeParentName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<FakeParent>(null, response.GetRawResponse())
                    : Response.FromValue(new FakeParent(this, response.Value), response.GetRawResponse());
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
            using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.GetIfExistsAsync");
            scope.Start();
            try
            {
                if (fakeParentName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentName));
                }

                var response = await _fakeParentsRestClient.GetAsync(Id.Name, fakeParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<FakeParent>(null, response.GetRawResponse())
                    : Response.FromValue(new FakeParent(this, response.Value), response.GetRawResponse());
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
        public virtual Response<bool> CheckIfExists(string fakeParentName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (fakeParentName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentName));
                }

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
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.CheckIfExistsAsync");
            scope.Start();
            try
            {
                if (fakeParentName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentName));
                }

                var response = await GetIfExistsAsync(fakeParentName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParent> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentsRestClient.GetAll(Id.Name, cancellationToken: cancellationToken);
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
                using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _fakeParentsRestClient.GetAllNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
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

        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParent> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentsRestClient.GetAllAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _clientDiagnostics.CreateScope("FakeParentContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _fakeParentsRestClient.GetAllNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
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

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, FakeParent, FakeParentData> Construct() { }
    }
}
