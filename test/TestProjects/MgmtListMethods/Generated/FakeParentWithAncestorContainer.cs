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
using Azure.ResourceManager.Resources;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary> A class representing collection of FakeParentWithAncestor and their operations over a Fake. </summary>
    public partial class FakeParentWithAncestorContainer : ResourceContainer
    {
        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorContainer"/> class for mocking. </summary>
        protected FakeParentWithAncestorContainer()
        {
        }

        /// <summary> Initializes a new instance of FakeParentWithAncestorContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal FakeParentWithAncestorContainer(ResourceOperations parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private FakeParentWithAncestorsRestOperations _restClient => new FakeParentWithAncestorsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => FakeOperations.ResourceType;

        // Container level operations.

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<FakeParentWithAncestor> CreateOrUpdate(string fakeParentWithAncestorName, FakeParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(fakeParentWithAncestorName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<FakeParentWithAncestor>> CreateOrUpdateAsync(string fakeParentWithAncestorName, FakeParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(fakeParentWithAncestorName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual FakeParentWithAncestorCreateOrUpdateOperation StartCreateOrUpdate(string fakeParentWithAncestorName, FakeParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.Name, fakeParentWithAncestorName, parameters, cancellationToken);
                return new FakeParentWithAncestorCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<FakeParentWithAncestorCreateOrUpdateOperation> StartCreateOrUpdateAsync(string fakeParentWithAncestorName, FakeParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            if (fakeParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.Name, fakeParentWithAncestorName, parameters, cancellationToken).ConfigureAwait(false);
                return new FakeParentWithAncestorCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<FakeParentWithAncestor> Get(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.Get");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
                }

                var response = _restClient.Get(Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestor(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<FakeParentWithAncestor>> GetAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.Get");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
                }

                var response = await _restClient.GetAsync(Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new FakeParentWithAncestor(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<FakeParentWithAncestor> GetIfExists(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.GetIfExists");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
                }

                var response = _restClient.Get(Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<FakeParentWithAncestor>(null, response.GetRawResponse())
                    : Response.FromValue(new FakeParentWithAncestor(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<FakeParentWithAncestor>> GetIfExistsAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.GetIfExists");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
                }

                var response = await _restClient.GetAsync(Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<FakeParentWithAncestor>(null, response.GetRawResponse())
                    : Response.FromValue(new FakeParentWithAncestor(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
                }

                var response = GetIfExists(fakeParentWithAncestorName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (fakeParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(fakeParentWithAncestorName));
                }

                var response = await GetIfExistsAsync(fakeParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <returns> A collection of <see cref="FakeParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<FakeParentWithAncestor> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FakeParentWithAncestor> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FakeParentWithAncestor> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="FakeParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<FakeParentWithAncestor> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FakeParentWithAncestor>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FakeParentWithAncestor>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FakeParentWithAncestor(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="FakeParentWithAncestor" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(FakeParentWithAncestorOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="FakeParentWithAncestor" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("FakeParentWithAncestorContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(FakeParentWithAncestorOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, FakeParentWithAncestor, FakeParentWithAncestorData> Construct() { }
    }
}
