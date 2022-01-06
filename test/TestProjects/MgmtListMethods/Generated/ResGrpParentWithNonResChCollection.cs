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
    /// <summary> A class representing collection of ResGrpParentWithNonResCh and their operations over its parent. </summary>
    public partial class ResGrpParentWithNonResChCollection : ArmCollection, IEnumerable<ResGrpParentWithNonResCh>, IAsyncEnumerable<ResGrpParentWithNonResCh>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResGrpParentWithNonResChesRestOperations _resGrpParentWithNonResChesRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithNonResChCollection"/> class for mocking. </summary>
        protected ResGrpParentWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of ResGrpParentWithNonResChCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ResGrpParentWithNonResChCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _resGrpParentWithNonResChesRestClient = new ResGrpParentWithNonResChesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithNonResChes_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ResGrpParentWithNonResChCreateOrUpdateOperation CreateOrUpdate(string resGrpParentWithNonResChName, ResGrpParentWithNonResChData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithNonResChesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, parameters, cancellationToken);
                var operation = new ResGrpParentWithNonResChCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithNonResChes_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResGrpParentWithNonResChCreateOrUpdateOperation> CreateOrUpdateAsync(string resGrpParentWithNonResChName, ResGrpParentWithNonResChData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithNonResChesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResGrpParentWithNonResChCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithNonResChes_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public virtual Response<ResGrpParentWithNonResCh> Get(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithNonResChesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithNonResChes_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithNonResCh>> GetAsync(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithNonResChesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResGrpParentWithNonResCh(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public virtual Response<ResGrpParentWithNonResCh> GetIfExists(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithNonResChesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ResGrpParentWithNonResCh>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParentWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<ResGrpParentWithNonResCh>> GetIfExistsAsync(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithNonResChesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ResGrpParentWithNonResCh>(null, response.GetRawResponse())
                    : Response.FromValue(new ResGrpParentWithNonResCh(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public virtual Response<bool> Exists(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(resGrpParentWithNonResChName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (resGrpParentWithNonResChName == null)
            {
                throw new ArgumentNullException(nameof(resGrpParentWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resGrpParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithNonResChes_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithNonResCh> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResGrpParentWithNonResCh> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithNonResChesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResGrpParentWithNonResCh> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithNonResChesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithNonResChes_List
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithNonResCh> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResGrpParentWithNonResCh>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithNonResChesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResGrpParentWithNonResCh>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithNonResChesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithNonResCh(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="ResGrpParentWithNonResCh" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithNonResCh.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ResGrpParentWithNonResCh" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResGrpParentWithNonResCh.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParentWithNonResCh> IEnumerable<ResGrpParentWithNonResCh>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentWithNonResCh> IAsyncEnumerable<ResGrpParentWithNonResCh>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, ResGrpParentWithNonResCh, ResGrpParentWithNonResChData> Construct() { }
    }
}
