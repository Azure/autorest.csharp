// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
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
    /// <summary> A class representing collection of ResGrpParentWithAncestor and their operations over its parent. </summary>
    public partial class ResGrpParentWithAncestorCollection : ArmCollection, IEnumerable<ResGrpParentWithAncestor>, IAsyncEnumerable<ResGrpParentWithAncestor>

    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResGrpParentWithAncestorsRestOperations _resGrpParentWithAncestorsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorCollection"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorCollection()
        {
        }

        /// <summary> Initializes a new instance of ResGrpParentWithAncestorCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ResGrpParentWithAncestorCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _resGrpParentWithAncestorsRestClient = new ResGrpParentWithAncestorsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestors_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ResGrpParentWithAncestorCreateOrUpdateOperation CreateOrUpdate(string resGrpParentWithAncestorName, ResGrpParentWithAncestorData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, parameters, cancellationToken);
                var operation = new ResGrpParentWithAncestorCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestors_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResGrpParentWithAncestorCreateOrUpdateOperation> CreateOrUpdateAsync(string resGrpParentWithAncestorName, ResGrpParentWithAncestorData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResGrpParentWithAncestorCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestors_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestor> Get(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors/{resGrpParentWithAncestorName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestors_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestor>> GetAsync(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public virtual Response<ResGrpParentWithAncestor> GetIfExists(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken: cancellationToken);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestor>> GetIfExistsAsync(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.CheckIfExists");
            scope.Start();
            try
            {
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithAncestorName"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string resGrpParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithAncestorName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithAncestorName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.CheckIfExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resGrpParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestors_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestor> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResGrpParentWithAncestor> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
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
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestors
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestors_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestor" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestor> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResGrpParentWithAncestor>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithAncestor.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
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
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithAncestor.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParentWithAncestor> IEnumerable<ResGrpParentWithAncestor>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentWithAncestor> IAsyncEnumerable<ResGrpParentWithAncestor>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, ResGrpParentWithAncestor, ResGrpParentWithAncestorData> Construct() { }
    }
}
