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
    /// <summary> A class representing collection of SubParentWithNonResChWithLoc and their operations over its parent. </summary>
    public partial class SubParentWithNonResChWithLocContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SubParentWithNonResChWithLocsRestOperations _subParentWithNonResChWithLocsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubParentWithNonResChWithLocContainer"/> class for mocking. </summary>
        protected SubParentWithNonResChWithLocContainer()
        {
        }

        /// <summary> Initializes a new instance of SubParentWithNonResChWithLocContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SubParentWithNonResChWithLocContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _subParentWithNonResChWithLocsRestClient = new SubParentWithNonResChWithLocsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => Subscription.ResourceType;

        // Container level operations.

        /// <summary> Create or update. </summary>
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SubParentWithNonResChWithLocCreateOrUpdateOperation CreateOrUpdate(string subParentWithNonResChWithLocName, SubParentWithNonResChWithLocData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (subParentWithNonResChWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithNonResChWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _subParentWithNonResChWithLocsRestClient.CreateOrUpdate(subParentWithNonResChWithLocName, parameters, cancellationToken);
                var operation = new SubParentWithNonResChWithLocCreateOrUpdateOperation(Parent, response);
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
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SubParentWithNonResChWithLocCreateOrUpdateOperation> CreateOrUpdateAsync(string subParentWithNonResChWithLocName, SubParentWithNonResChWithLocData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (subParentWithNonResChWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithNonResChWithLocName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _subParentWithNonResChWithLocsRestClient.CreateOrUpdateAsync(subParentWithNonResChWithLocName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SubParentWithNonResChWithLocCreateOrUpdateOperation(Parent, response);
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
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<SubParentWithNonResChWithLoc> Get(string subParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithNonResChWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithNonResChWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.Get");
            scope.Start();
            try
            {
                var response = _subParentWithNonResChWithLocsRestClient.Get(subParentWithNonResChWithLocName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubParentWithNonResChWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves information. </summary>
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> is null. </exception>
        public async virtual Task<Response<SubParentWithNonResChWithLoc>> GetAsync(string subParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithNonResChWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithNonResChWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.Get");
            scope.Start();
            try
            {
                var response = await _subParentWithNonResChWithLocsRestClient.GetAsync(subParentWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SubParentWithNonResChWithLoc(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<SubParentWithNonResChWithLoc> GetIfExists(string subParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithNonResChWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithNonResChWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.GetIfExists");
            scope.Start();
            try
            {
                var response = _subParentWithNonResChWithLocsRestClient.Get(subParentWithNonResChWithLocName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<SubParentWithNonResChWithLoc>(null, response.GetRawResponse())
                    : Response.FromValue(new SubParentWithNonResChWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> is null. </exception>
        public async virtual Task<Response<SubParentWithNonResChWithLoc>> GetIfExistsAsync(string subParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithNonResChWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithNonResChWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _subParentWithNonResChWithLocsRestClient.GetAsync(subParentWithNonResChWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<SubParentWithNonResChWithLoc>(null, response.GetRawResponse())
                    : Response.FromValue(new SubParentWithNonResChWithLoc(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string subParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithNonResChWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithNonResChWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.CheckIfExists");
            scope.Start();
            try
            {
                var response = GetIfExists(subParentWithNonResChWithLocName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="subParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParentWithNonResChWithLocName"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string subParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            if (subParentWithNonResChWithLocName == null)
            {
                throw new ArgumentNullException(nameof(subParentWithNonResChWithLocName));
            }

            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.CheckIfExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(subParentWithNonResChWithLocName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <returns> A collection of <see cref="SubParentWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubParentWithNonResChWithLoc> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SubParentWithNonResChWithLoc> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _subParentWithNonResChWithLocsRestClient.List(cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentWithNonResChWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubParentWithNonResChWithLoc> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _subParentWithNonResChWithLocsRestClient.ListNextPage(nextLink, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentWithNonResChWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="SubParentWithNonResChWithLoc" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubParentWithNonResChWithLoc> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SubParentWithNonResChWithLoc>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _subParentWithNonResChWithLocsRestClient.ListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentWithNonResChWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubParentWithNonResChWithLoc>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _subParentWithNonResChWithLocsRestClient.ListNextPageAsync(nextLink, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubParentWithNonResChWithLoc(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="SubParentWithNonResChWithLoc" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubParentWithNonResChWithLoc.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SubParentWithNonResChWithLoc" /> for this subscription represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubParentWithNonResChWithLocContainer.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SubParentWithNonResChWithLoc.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as Subscription, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, SubParentWithNonResChWithLoc, SubParentWithNonResChWithLocData> Construct() { }
    }
}
