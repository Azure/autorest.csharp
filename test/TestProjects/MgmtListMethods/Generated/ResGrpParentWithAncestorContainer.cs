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
    /// <summary> A class representing collection of ResGrpParentWithAncestor and their operations over a ResourceGroup. </summary>
    public partial class ResGrpParentWithAncestorContainer : ResourceContainer
    {
        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorContainer"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorContainer()
        {
        }

        /// <summary> Initializes a new instance of ResGrpParentWithAncestorContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ResGrpParentWithAncestorContainer(ResourceOperations parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ResGrpParentWithAncestorsRestOperations _restClient => new ResGrpParentWithAncestorsRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId, BaseUri);

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestor> CreateOrUpdate(string resGrpParentWithAncestorName, ResGrpParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(resGrpParentWithAncestorName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestor>> CreateOrUpdateAsync(string resGrpParentWithAncestorName, ResGrpParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(resGrpParentWithAncestorName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ResGrpParentWithAncestorCreateOrUpdateOperation StartCreateOrUpdate(string resGrpParentWithAncestorName, ResGrpParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, resGrpParentWithAncestorName, parameters, cancellationToken);
                return new ResGrpParentWithAncestorCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResGrpParentWithAncestorCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resGrpParentWithAncestorName, ResGrpParentWithAncestorData parameters, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, resGrpParentWithAncestorName, parameters, cancellationToken).ConfigureAwait(false);
                return new ResGrpParentWithAncestorCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ResGrpParentWithAncestor> Get(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.Get");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestor(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ResGrpParentWithAncestor>> GetAsync(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.Get");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResGrpParentWithAncestor(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ResGrpParentWithAncestor> GetIfExists(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.GetIfExists");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ResGrpParentWithAncestor>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParentWithAncestor(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ResGrpParentWithAncestor>> GetIfExistsAsync(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.GetIfExists");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ResGrpParentWithAncestor>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParentWithAncestor(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
                }

                var response = GetIfExists(resGrpParentWithAncestorName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
                }

                var response = await GetIfExistsAsync(resGrpParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <returns> A collection of <see cref="ResGrpParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestor> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResGrpParentWithAncestor> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestor(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResGrpParentWithAncestor> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestor(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestor> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResGrpParentWithAncestor>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestor(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResGrpParentWithAncestor>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestor(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="ResGrpParentWithAncestor" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResourceExpanded> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithAncestorOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ResGrpParentWithAncestor" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResourceExpanded> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithAncestorOperations.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, ResGrpParentWithAncestor, ResGrpParentWithAncestorData> Construct() { }
    }
}
