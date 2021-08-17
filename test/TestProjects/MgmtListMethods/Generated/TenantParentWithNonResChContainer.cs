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
    /// <summary> A class representing collection of TenantParentWithNonResCh and their operations over a TenantTest. </summary>
    public partial class TenantParentWithNonResChContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TenantParentWithNonResChesRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="TenantParentWithNonResChContainer"/> class for mocking. </summary>
        protected TenantParentWithNonResChContainer()
        {
        }

        /// <summary> Initializes a new instance of TenantParentWithNonResChContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TenantParentWithNonResChContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new TenantParentWithNonResChesRestOperations(_clientDiagnostics, Pipeline, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => TenantTest.ResourceType;

        // Container level operations.

        /// <summary> Create or update. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<TenantParentWithNonResCh> CreateOrUpdate(string tenantParentWithNonResChName, TenantParentWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(tenantParentWithNonResChName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<TenantParentWithNonResCh>> CreateOrUpdateAsync(string tenantParentWithNonResChName, TenantParentWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(tenantParentWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual TenantParentWithNonResChCreateOrUpdateOperation StartCreateOrUpdate(string tenantParentWithNonResChName, TenantParentWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.Name, tenantParentWithNonResChName, parameters, cancellationToken);
                return new TenantParentWithNonResChCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<TenantParentWithNonResChCreateOrUpdateOperation> StartCreateOrUpdateAsync(string tenantParentWithNonResChName, TenantParentWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.Name, tenantParentWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                return new TenantParentWithNonResChCreateOrUpdateOperation(Parent, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<TenantParentWithNonResCh> Get(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.Get");
            scope.Start();
            try
            {
                if (tenantParentWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
                }

                var response = _restClient.Get(Id.Name, tenantParentWithNonResChName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantParentWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<TenantParentWithNonResCh>> GetAsync(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.Get");
            scope.Start();
            try
            {
                if (tenantParentWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
                }

                var response = await _restClient.GetAsync(Id.Name, tenantParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TenantParentWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<TenantParentWithNonResCh> GetIfExists(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.GetIfExists");
            scope.Start();
            try
            {
                if (tenantParentWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
                }

                var response = _restClient.Get(Id.Name, tenantParentWithNonResChName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<TenantParentWithNonResCh>(null, response.GetRawResponse())
                    : Response.FromValue(new TenantParentWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<TenantParentWithNonResCh>> GetIfExistsAsync(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.GetIfExists");
            scope.Start();
            try
            {
                if (tenantParentWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
                }

                var response = await _restClient.GetAsync(Id.Name, tenantParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<TenantParentWithNonResCh>(null, response.GetRawResponse())
                    : Response.FromValue(new TenantParentWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (tenantParentWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
                }

                var response = GetIfExists(tenantParentWithNonResChName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string tenantParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (tenantParentWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(tenantParentWithNonResChName));
                }

                var response = await GetIfExistsAsync(tenantParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <returns> A collection of <see cref="TenantParentWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantParentWithNonResCh> GetAll(CancellationToken cancellationToken = default)
        {
            Page<TenantParentWithNonResCh> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantParentWithNonResCh> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllNextPage(nextLink, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="TenantParentWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantParentWithNonResCh> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantParentWithNonResCh>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantParentWithNonResCh>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllNextPageAsync(nextLink, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="TenantParentWithNonResCh" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TenantParentWithNonResCh.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="TenantParentWithNonResCh" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantParentWithNonResChContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TenantParentWithNonResCh.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, TenantParentWithNonResCh, TenantParentWithNonResChData> Construct() { }
    }
}
