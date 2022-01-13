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
using OmitOperationGroups.Models;

namespace OmitOperationGroups
{
    /// <summary> A class representing collection of Model2 and their operations over its parent. </summary>
    public partial class Model2Collection : ArmCollection, IEnumerable<Model2>, IAsyncEnumerable<Model2>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Model2SRestOperations _model2sRestClient;

        /// <summary> Initializes a new instance of the <see cref="Model2Collection"/> class for mocking. </summary>
        protected Model2Collection()
        {
        }

        /// <summary> Initializes a new instance of Model2Collection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal Model2Collection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _model2sRestClient = new Model2SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model2s_CreateOrUpdate
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="parameters"> The Model2 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual Model2SCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string model2SName, Model2Data parameters, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _model2sRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, model2SName, parameters, cancellationToken);
                var operation = new Model2SCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model2s_CreateOrUpdate
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="parameters"> The Model2 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Model2SCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string model2SName, Model2Data parameters, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _model2sRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new Model2SCreateOrUpdateOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model2s_Get
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual Response<Model2> Get(string model2SName, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Collection.Get");
            scope.Start();
            try
            {
                var response = _model2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Model2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model2s_Get
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public async virtual Task<Response<Model2>> GetAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Collection.Get");
            scope.Start();
            try
            {
                var response = await _model2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Model2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual Response<Model2> GetIfExists(string model2SName, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _model2sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Model2>(null, response.GetRawResponse());
                return Response.FromValue(new Model2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public async virtual Task<Response<Model2>> GetIfExistsAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Collection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _model2sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, model2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Model2>(null, response.GetRawResponse());
                return Response.FromValue(new Model2(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public virtual Response<bool> Exists(string model2SName, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(model2SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="model2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model2SName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string model2SName, CancellationToken cancellationToken = default)
        {
            if (model2SName == null)
            {
                throw new ArgumentNullException(nameof(model2SName));
            }

            using var scope = _clientDiagnostics.CreateScope("Model2Collection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(model2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model2s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Model2" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Model2> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Model2> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("Model2Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _model2sRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Model2(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model2s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Model2" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Model2> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Model2>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("Model2Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _model2sRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Model2(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of <see cref="Model2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Model2.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Model2" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("Model2Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Model2.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Model2> IEnumerable<Model2>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Model2> IAsyncEnumerable<Model2>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, Model2, Model2Data> Construct() { }
    }
}
