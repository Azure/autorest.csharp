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
using MgmtLRO.Models;

namespace MgmtLRO
{
    /// <summary> A class representing collection of Bar and their operations over its parent. </summary>
    public partial class BarCollection : ArmCollection, IEnumerable<Bar>, IAsyncEnumerable<Bar>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly BarsRestOperations _barsRestClient;

        /// <summary> Initializes a new instance of the <see cref="BarCollection"/> class for mocking. </summary>
        protected BarCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BarCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal BarCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics("MgmtLRO", Bar.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(Bar.ResourceType, out string apiVersion);
            _barsRestClient = new BarsRestOperations(_clientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, apiVersion);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Bars_Create
        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="body"> The Bar to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is null or empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual BarCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string barName, BarData body, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(barName))
            {
                throw new ArgumentException($"Parameter {nameof(barName)} cannot be null or empty", nameof(barName));
            }
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var scope = _clientDiagnostics.CreateScope("BarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _barsRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, barName, body, cancellationToken);
                var operation = new BarCreateOrUpdateOperation(ArmClient, _clientDiagnostics, Pipeline, _barsRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, barName, body).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Bars_Create
        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="body"> The Bar to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is null or empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public async virtual Task<BarCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string barName, BarData body, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(barName))
            {
                throw new ArgumentException($"Parameter {nameof(barName)} cannot be null or empty", nameof(barName));
            }
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            using var scope = _clientDiagnostics.CreateScope("BarCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _barsRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, barName, body, cancellationToken).ConfigureAwait(false);
                var operation = new BarCreateOrUpdateOperation(ArmClient, _clientDiagnostics, Pipeline, _barsRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, barName, body).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Bars_Get
        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is null or empty. </exception>
        public virtual Response<Bar> Get(string barName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(barName))
            {
                throw new ArgumentException($"Parameter {nameof(barName)} cannot be null or empty", nameof(barName));
            }

            using var scope = _clientDiagnostics.CreateScope("BarCollection.Get");
            scope.Start();
            try
            {
                var response = _barsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Bar(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Bars_Get
        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is null or empty. </exception>
        public async virtual Task<Response<Bar>> GetAsync(string barName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(barName))
            {
                throw new ArgumentException($"Parameter {nameof(barName)} cannot be null or empty", nameof(barName));
            }

            using var scope = _clientDiagnostics.CreateScope("BarCollection.Get");
            scope.Start();
            try
            {
                var response = await _barsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Bar(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is null or empty. </exception>
        public virtual Response<Bar> GetIfExists(string barName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(barName))
            {
                throw new ArgumentException($"Parameter {nameof(barName)} cannot be null or empty", nameof(barName));
            }

            using var scope = _clientDiagnostics.CreateScope("BarCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _barsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Bar>(null, response.GetRawResponse());
                return Response.FromValue(new Bar(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is null or empty. </exception>
        public async virtual Task<Response<Bar>> GetIfExistsAsync(string barName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(barName))
            {
                throw new ArgumentException($"Parameter {nameof(barName)} cannot be null or empty", nameof(barName));
            }

            using var scope = _clientDiagnostics.CreateScope("BarCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _barsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, barName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Bar>(null, response.GetRawResponse());
                return Response.FromValue(new Bar(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is null or empty. </exception>
        public virtual Response<bool> Exists(string barName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(barName))
            {
                throw new ArgumentException($"Parameter {nameof(barName)} cannot be null or empty", nameof(barName));
            }

            using var scope = _clientDiagnostics.CreateScope("BarCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(barName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="barName"> The name of the fake. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="barName"/> is null or empty. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string barName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(barName))
            {
                throw new ArgumentException($"Parameter {nameof(barName)} cannot be null or empty", nameof(barName));
            }

            using var scope = _clientDiagnostics.CreateScope("BarCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(barName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Bars_List
        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Bar" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Bar> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Bar> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("BarCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _barsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Bar(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Bars_List
        /// <summary> Retrieves information about an fake. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Bar" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Bar> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Bar>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("BarCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _barsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Bar(ArmClient, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of <see cref="Bar" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BarCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Bar.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Bar" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("BarCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Bar.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Bar> IEnumerable<Bar>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Bar> IAsyncEnumerable<Bar>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
