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
    /// <summary> A class representing collection of SubFake and their operations over a Fake. </summary>
    public partial class SubFakeContainer : ResourceContainer
    {
        /// <summary> Initializes a new instance of the <see cref="SubFakeContainer"/> class for mocking. </summary>
        protected SubFakeContainer()
        {
        }

        /// <summary> Initializes a new instance of SubFakeContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SubFakeContainer(ResourceOperations parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private SubFakesRestOperations _restClient => new SubFakesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => FakeOperations.ResourceType;

        // Container level operations.

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="body"> The body parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subFakeName"/> or <paramref name="body"/> is null. </exception>
        public virtual Response<SubFake> CreateOrUpdate(string subFakeName, SubFakeData body, CancellationToken cancellationToken = default)
        {
            if (subFakeName == null)
            {
                throw new ArgumentNullException(nameof(subFakeName));
            }
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(subFakeName, body, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="body"> The body parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subFakeName"/> or <paramref name="body"/> is null. </exception>
        public async virtual Task<Response<SubFake>> CreateOrUpdateAsync(string subFakeName, SubFakeData body, CancellationToken cancellationToken = default)
        {
            if (subFakeName == null)
            {
                throw new ArgumentNullException(nameof(subFakeName));
            }
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(subFakeName, body, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="body"> The body parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subFakeName"/> or <paramref name="body"/> is null. </exception>
        public virtual SubFakesCreateOrUpdateOperation StartCreateOrUpdate(string subFakeName, SubFakeData body, CancellationToken cancellationToken = default)
        {
            if (subFakeName == null)
            {
                throw new ArgumentNullException(nameof(subFakeName));
            }
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.Name, subFakeName, body, cancellationToken);
                return new SubFakesCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="body"> The body parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subFakeName"/> or <paramref name="body"/> is null. </exception>
        public async virtual Task<SubFakesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string subFakeName, SubFakeData body, CancellationToken cancellationToken = default)
        {
            if (subFakeName == null)
            {
                throw new ArgumentNullException(nameof(subFakeName));
            }
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.Name, subFakeName, body, cancellationToken).ConfigureAwait(false);
                return new SubFakesCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<SubFake> Get(string subFakeName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.Get");
            scope.Start();
            try
            {
                if (subFakeName == null)
                {
                    throw new ArgumentNullException(nameof(subFakeName));
                }

                var response = _restClient.Get(subFakeName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubFake(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<SubFake>> GetAsync(string subFakeName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.Get");
            scope.Start();
            try
            {
                if (subFakeName == null)
                {
                    throw new ArgumentNullException(nameof(subFakeName));
                }

                var response = await _restClient.GetAsync(subFakeName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubFake(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<SubFake> GetIfExists(string subFakeName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.GetIfExists");
            scope.Start();
            try
            {
                if (subFakeName == null)
                {
                    throw new ArgumentNullException(nameof(subFakeName));
                }

                var response = _restClient.Get(subFakeName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<SubFake>(null, response.GetRawResponse())
                    : Response.FromValue(new SubFake(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<SubFake>> GetIfExistsAsync(string subFakeName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.GetIfExists");
            scope.Start();
            try
            {
                if (subFakeName == null)
                {
                    throw new ArgumentNullException(nameof(subFakeName));
                }

                var response = await _restClient.GetAsync(subFakeName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<SubFake>(null, response.GetRawResponse())
                    : Response.FromValue(new SubFake(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string subFakeName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (subFakeName == null)
                {
                    throw new ArgumentNullException(nameof(subFakeName));
                }

                var response = GetIfExists(subFakeName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subFakeName"> The name of the fake. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string subFakeName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (subFakeName == null)
                {
                    throw new ArgumentNullException(nameof(subFakeName));
                }

                var response = await GetIfExistsAsync(subFakeName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets an agreement by ID. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubFake" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<SubFake> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SubFake> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubFake(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubFake> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllNextPage(nextLink, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubFake(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets an agreement by ID. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubFake" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<SubFake> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SubFake>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubFake(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubFake>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllNextPageAsync(nextLink, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubFake(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="SubFake" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResourceExpanded> GetAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.GetAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubFakeOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SubFake" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResourceExpanded> GetAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubFakeContainer.GetAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubFakeOperations.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, SubFake, SubFakeData> Construct() { }
    }
}
