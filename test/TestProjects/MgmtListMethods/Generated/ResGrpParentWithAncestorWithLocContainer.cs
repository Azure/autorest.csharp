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
    /// <summary> A class representing collection of ResGrpParentWithAncestorWithLoc and their operations over its parent. </summary>
    public partial class ResGrpParentWithAncestorWithLocContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResGrpParentWithAncestorWithLocsRestOperations _resGrpParentWithAncestorWithLocsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithLocContainer"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorWithLocContainer()
        {
        }

        /// <summary> Initializes a new instance of ResGrpParentWithAncestorWithLocContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ResGrpParentWithAncestorWithLocContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _resGrpParentWithAncestorWithLocsRestClient = new ResGrpParentWithAncestorWithLocsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Container level operations.

        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ResGrpParentWithAncestorWithLocCreateOrUpdateOperation CreateOrUpdate(string resGrpParentWithAncestorWithLocName, ResGrpParentWithAncestorWithLocData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithLocName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithLocsRestClient.CreateOrUpdate(Id.ResourceGroupName, resGrpParentWithAncestorWithLocName, parameters, cancellationToken);
                var operation = new ResGrpParentWithAncestorWithLocCreateOrUpdateOperation(Parent, response);
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
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResGrpParentWithAncestorWithLocCreateOrUpdateOperation> CreateOrUpdateAsync(string resGrpParentWithAncestorWithLocName, ResGrpParentWithAncestorWithLocData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithLocName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithLocsRestClient.CreateOrUpdateAsync(Id.ResourceGroupName, resGrpParentWithAncestorWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResGrpParentWithAncestorWithLocCreateOrUpdateOperation(Parent, response);
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
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithLoc> Get(string resGrpParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithLocName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithLocsRestClient.Get(Id.ResourceGroupName, resGrpParentWithAncestorWithLocName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestorWithLoc>> GetAsync(string resGrpParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithLocName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithLocsRestClient.GetAsync(Id.ResourceGroupName, resGrpParentWithAncestorWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResGrpParentWithAncestorWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestorWithLoc> GetIfExists(string resGrpParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithLocName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.GetIfExists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithLocsRestClient.Get(Id.ResourceGroupName, resGrpParentWithAncestorWithLocName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ResGrpParentWithAncestorWithLoc>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParentWithAncestorWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestorWithLoc>> GetIfExistsAsync(string resGrpParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithLocName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithLocsRestClient.GetAsync(Id.ResourceGroupName, resGrpParentWithAncestorWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ResGrpParentWithAncestorWithLoc>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParentWithAncestorWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string resGrpParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithLocName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.CheckIfExists");
            scope.Start();
            try
            {
                var response = GetIfExists(resGrpParentWithAncestorWithLocName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorWithLocName"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string resGrpParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorWithLocName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.CheckIfExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resGrpParentWithAncestorWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithLoc> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResGrpParentWithAncestorWithLoc> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithLocsRestClient.List(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResGrpParentWithAncestorWithLoc> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithLocsRestClient.ListNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithLoc> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResGrpParentWithAncestorWithLoc>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithLocsRestClient.ListAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResGrpParentWithAncestorWithLoc>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithLocsRestClient.ListNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="ResGrpParentWithAncestorWithLoc" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithAncestorWithLoc.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ResGrpParentWithAncestorWithLoc" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithLocContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithAncestorWithLoc.ResourceType);
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
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, ResGrpParentWithAncestorWithLoc, ResGrpParentWithAncestorWithLocData> Construct() { }
    }
}
