// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class ResGrpParentWithAncestorWithNonResChCollection : ArmCollection, IEnumerable<ResGrpParentWithAncestorWithNonResCh>, IAsyncEnumerable<ResGrpParentWithAncestorWithNonResCh>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResGrpParentWithAncestorWithNonResChesRestOperations _resGrpParentWithAncestorWithNonResChesRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChCollection"/> class for mocking. </summary>
        protected ResGrpParentWithAncestorWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithAncestorWithNonResChCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ResGrpParentWithAncestorWithNonResChCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResGrpParentWithAncestorWithNonResCh.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ResGrpParentWithAncestorWithNonResCh.ResourceType, out string apiVersion);
            _resGrpParentWithAncestorWithNonResChesRestClient = new ResGrpParentWithAncestorWithNonResChesRestOperations(_clientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestorWithNonResChes_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null or empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ResGrpParentWithAncestorWithNonResChCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string resGrpParentWithAncestorWithNonResChName, ResGrpParentWithAncestorWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(resGrpParentWithAncestorWithNonResChName))
            {
                throw new ArgumentException($"Parameter {nameof(resGrpParentWithAncestorWithNonResChName)} cannot be null or empty", nameof(resGrpParentWithAncestorWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, parameters, cancellationToken);
                var operation = new ResGrpParentWithAncestorWithNonResChCreateOrUpdateOperation(ArmClient, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestorWithNonResChes_CreateOrUpdate
        /// <summary> Create or update. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="parameters"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null or empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResGrpParentWithAncestorWithNonResChCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string resGrpParentWithAncestorWithNonResChName, ResGrpParentWithAncestorWithNonResChData parameters, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(resGrpParentWithAncestorWithNonResChName))
            {
                throw new ArgumentException($"Parameter {nameof(resGrpParentWithAncestorWithNonResChName)} cannot be null or empty", nameof(resGrpParentWithAncestorWithNonResChName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResGrpParentWithAncestorWithNonResChCreateOrUpdateOperation(ArmClient, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestorWithNonResChes_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null or empty. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResCh> Get(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(resGrpParentWithAncestorWithNonResChName))
            {
                throw new ArgumentException($"Parameter {nameof(resGrpParentWithAncestorWithNonResChName)} cannot be null or empty", nameof(resGrpParentWithAncestorWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes/{resGrpParentWithAncestorWithNonResChName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestorWithNonResChes_Get
        /// <summary> Retrieves information. </summary>
        /// <param name="resGrpParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null or empty. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestorWithNonResCh>> GetAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(resGrpParentWithAncestorWithNonResChName))
            {
                throw new ArgumentException($"Parameter {nameof(resGrpParentWithAncestorWithNonResChName)} cannot be null or empty", nameof(resGrpParentWithAncestorWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(ArmClient, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null or empty. </exception>
        public virtual Response<ResGrpParentWithAncestorWithNonResCh> GetIfExists(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(resGrpParentWithAncestorWithNonResChName))
            {
                throw new ArgumentException($"Parameter {nameof(resGrpParentWithAncestorWithNonResChName)} cannot be null or empty", nameof(resGrpParentWithAncestorWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithAncestorWithNonResChesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ResGrpParentWithAncestorWithNonResCh>(null, response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(ArmClient, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null or empty. </exception>
        public async virtual Task<Response<ResGrpParentWithAncestorWithNonResCh>> GetIfExistsAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(resGrpParentWithAncestorWithNonResChName))
            {
                throw new ArgumentException($"Parameter {nameof(resGrpParentWithAncestorWithNonResChName)} cannot be null or empty", nameof(resGrpParentWithAncestorWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithAncestorWithNonResChesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ResGrpParentWithAncestorWithNonResCh>(null, response.GetRawResponse());
                return Response.FromValue(new ResGrpParentWithAncestorWithNonResCh(ArmClient, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null or empty. </exception>
        public virtual Response<bool> Exists(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(resGrpParentWithAncestorWithNonResChName))
            {
                throw new ArgumentException($"Parameter {nameof(resGrpParentWithAncestorWithNonResChName)} cannot be null or empty", nameof(resGrpParentWithAncestorWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Exists");
            scope.Start();
            try
            {
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
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithAncestorWithNonResChName"/> is null or empty. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string resGrpParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(resGrpParentWithAncestorWithNonResChName))
            {
                throw new ArgumentException($"Parameter {nameof(resGrpParentWithAncestorWithNonResChName)} cannot be null or empty", nameof(resGrpParentWithAncestorWithNonResChName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resGrpParentWithAncestorWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestorWithNonResChes_ListTest
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithAncestorWithNonResCh> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResGrpParentWithAncestorWithNonResCh> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithNonResChesRestClient.ListTest(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ResGrpParentWithAncestorWithNonResCh> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _resGrpParentWithAncestorWithNonResChesRestClient.ListTestNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithAncestorWithNonResChes
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResGrpParentWithAncestorWithNonResChes_ListTest
        /// <summary> Lists all in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithAncestorWithNonResCh" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithAncestorWithNonResCh> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResGrpParentWithAncestorWithNonResCh>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithNonResChesRestClient.ListTestAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ResGrpParentWithAncestorWithNonResCh>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resGrpParentWithAncestorWithNonResChesRestClient.ListTestNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResGrpParentWithAncestorWithNonResCh(ArmClient, value)), response.Value.NextLink, response.GetRawResponse());
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
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAllAsGenericResources");
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
            using var scope = _clientDiagnostics.CreateScope("ResGrpParentWithAncestorWithNonResChCollection.GetAllAsGenericResources");
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

        IEnumerator<ResGrpParentWithAncestorWithNonResCh> IEnumerable<ResGrpParentWithAncestorWithNonResCh>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentWithAncestorWithNonResCh> IAsyncEnumerable<ResGrpParentWithAncestorWithNonResCh>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
