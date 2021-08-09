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
    /// <summary> A class representing collection of TenantTest and their operations over a Tenant. </summary>
    public partial class TenantTestContainer : ResourceContainer
    {
        /// <summary> Initializes a new instance of the <see cref="TenantTestContainer"/> class for mocking. </summary>
        protected TenantTestContainer()
        {
        }

        /// <summary> Initializes a new instance of TenantTestContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TenantTestContainer(ResourceOperations parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private TenantTestsRestOperations _restClient => new TenantTestsRestOperations(_clientDiagnostics, Pipeline, BaseUri);

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        // Container level operations.

        /// <summary> Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="parameters"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Response<TenantTest> CreateOrUpdate(string tenantTestName, TenantTestData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = StartCreateOrUpdate(tenantTestName, parameters, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="parameters"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<TenantTest>> CreateOrUpdateAsync(string tenantTestName, TenantTestData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(tenantTestName, parameters, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="parameters"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual TenantTestCreateOperation StartCreateOrUpdate(string tenantTestName, TenantTestData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.Create(tenantTestName, parameters, cancellationToken);
                return new TenantTestCreateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateRequest(tenantTestName, parameters).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the properties of a billing account. Currently, displayName and address can be updated. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="parameters"> Request parameters that are provided to the update billing account operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantTestName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<TenantTestCreateOperation> StartCreateOrUpdateAsync(string tenantTestName, TenantTestData parameters, CancellationToken cancellationToken = default)
        {
            if (tenantTestName == null)
            {
                throw new ArgumentNullException(nameof(tenantTestName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateAsync(tenantTestName, parameters, cancellationToken).ConfigureAwait(false);
                return new TenantTestCreateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateRequest(tenantTestName, parameters).Request, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<TenantTest> Get(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.Get");
            scope.Start();
            try
            {
                if (tenantTestName == null)
                {
                    throw new ArgumentNullException(nameof(tenantTestName));
                }

                var response = _restClient.Get(tenantTestName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TenantTest(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<TenantTest>> GetAsync(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.Get");
            scope.Start();
            try
            {
                if (tenantTestName == null)
                {
                    throw new ArgumentNullException(nameof(tenantTestName));
                }

                var response = await _restClient.GetAsync(tenantTestName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TenantTest(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<TenantTest> GetIfExists(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.GetIfExists");
            scope.Start();
            try
            {
                if (tenantTestName == null)
                {
                    throw new ArgumentNullException(nameof(tenantTestName));
                }

                var response = _restClient.Get(tenantTestName, expand, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<TenantTest>(null, response.GetRawResponse())
                    : Response.FromValue(new TenantTest(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<TenantTest>> GetIfExistsAsync(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.GetIfExists");
            scope.Start();
            try
            {
                if (tenantTestName == null)
                {
                    throw new ArgumentNullException(nameof(tenantTestName));
                }

                var response = await _restClient.GetAsync(tenantTestName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<TenantTest>(null, response.GetRawResponse())
                    : Response.FromValue(new TenantTest(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (tenantTestName == null)
                {
                    throw new ArgumentNullException(nameof(tenantTestName));
                }

                var response = GetIfExists(tenantTestName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="tenantTestName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="expand"> May be used to expand the soldTo, invoice sections and billing profiles. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string tenantTestName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (tenantTestName == null)
                {
                    throw new ArgumentNullException(nameof(tenantTestName));
                }

                var response = await GetIfExistsAsync(tenantTestName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all fakes in a resource group. </summary>
        /// <param name="requiredParam"> The expand expression to apply on the operation. </param>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantTest" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantTest> GetAll(string requiredParam, string optionalParam = null, CancellationToken cancellationToken = default)
        {
            Page<TenantTest> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(requiredParam, optionalParam, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTest(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TenantTest> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllNextPage(nextLink, requiredParam, optionalParam, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTest(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all fakes in a resource group. </summary>
        /// <param name="requiredParam"> The expand expression to apply on the operation. </param>
        /// <param name="optionalParam"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantTest" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantTest> GetAllAsync(string requiredParam, string optionalParam = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TenantTest>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(requiredParam, optionalParam, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTest(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TenantTest>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllNextPageAsync(nextLink, requiredParam, optionalParam, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TenantTest(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="TenantTest" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResourceExpanded> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TenantTestOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroupOperations, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="TenantTest" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResourceExpanded> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TenantTestContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TenantTestOperations.ResourceType);
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
        // public ArmBuilder<ResourceIdentifier, TenantTest, TenantTestData> Construct() { }
    }
}
