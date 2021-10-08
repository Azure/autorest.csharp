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
    /// <summary> A class representing collection of ResGrpParentWithAncestorWithNonResCh and their operations over its parent. </summary>
    public partial class ResGrpParentWithAncestorWithNonResChContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResGrpParentWithAncestorWithNonResChesRestOperations _resGrpParentWithAncestorWithNonResChesRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChContainer"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorWithNonResChContainer()
        {
        }

        /// <summary> Initializes a new instance of ResGrpParentWithAncestorWithNonResChContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ResGrpParentWithAncestorWithNonResChContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _resGrpParentWithAncestorWithNonResChesRestClient = new ResGrpParentWithAncestorWithNonResChesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Container level operations.

        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ResGrpParentWithAncestorWithNonResChCreateOrUpdateOperation CreateOrUpdate(string resGrpParentWithAncestorWithNonResChName, ResGrpParentWithAncestorWithNonResChData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChesRestClient.CreateOrUpdate(Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, parameters, cancellationToken);
                var operation = new ResGrpParentWithAncestorWithNonResChCreateOrUpdateOperation(Parent, response);
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
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResGrpParentWithAncestorWithNonResChCreateOrUpdateOperation> CreateOrUpdateAsync(string resGrpParentWithAncestorWithNonResChName, ResGrpParentWithAncestorWithNonResChData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChesRestClient.CreateOrUpdateAsync(Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResGrpParentWithAncestorWithNonResChCreateOrUpdateOperation(Parent, response);
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
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResCh> Get(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChesRestClient.Get(Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestorWithNonResCh>> GetAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChesRestClient.GetAsync(Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResCh> GetIfExists(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.GetIfExists");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithNonResChName));
                }

                var response = _resGrpParentWithAncestorWithNonResChesRestClient.Get(Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ResGrpParentWithAncestorWithNonResCh>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestorWithNonResCh>> GetIfExistsAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.GetIfExistsAsync");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithNonResChName));
                }

                var response = await _resGrpParentWithAncestorWithNonResChesRestClient.GetAsync(Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ResGrpParentWithAncestorWithNonResCh>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithNonResChName));
                }

                var response = GetIfExists(resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.CheckIfExistsAsync");
            scope.Start();
            try
            {
                if (resGrpParentWithAncestorWithNonResChName == null)
                {
                    throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithNonResChName));
                }

                var response = await GetIfExistsAsync(resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithNonResCh> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResGrpParentWithAncestorWithNonResCh> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithNonResChesRestClient.GetTest(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResGrpParentWithAncestorWithNonResCh> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithNonResChesRestClient.GetTestNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithNonResCh> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResGrpParentWithAncestorWithNonResCh>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithNonResChesRestClient.GetTestAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResGrpParentWithAncestorWithNonResCh>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithNonResChesRestClient.GetTestNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="ResGrpParentWithAncestorWithNonResCh" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithAncestorWithNonResCh.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ResGrpParentWithAncestorWithNonResCh" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithAncestorWithNonResCh.ResourceType);
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
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, ResGrpParentWithAncestorWithNonResCh, ResGrpParentWithAncestorWithNonResChData> Construct() { }
    }
}
