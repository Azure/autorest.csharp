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
using SupersetFlattenInheritance.Models;

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing collection of ResourceModel1 and their operations over its parent. </summary>
    public partial class ResourceModel1Collection : ArmCollection, IEnumerable<ResourceModel1>, IAsyncEnumerable<ResourceModel1>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ResourceModel1SRestOperations _resourceModel1sRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceModel1Collection"/> class for mocking. </summary>
        protected ResourceModel1Collection()
        {
        }

        /// <summary> Initializes a new instance of ResourceModel1Collection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ResourceModel1Collection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _resourceModel1sRestClient = new ResourceModel1SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(nameof(id), string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResourceModel1s_Put
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ResourceModel1 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ResourceModel1SPutOperation CreateOrUpdate(string resourceModel1SName, ResourceModel1Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resourceModel1sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, parameters, cancellationToken);
                var operation = new ResourceModel1SPutOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResourceModel1s_Put
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ResourceModel1 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ResourceModel1SPutOperation> CreateOrUpdateAsync(string resourceModel1SName, ResourceModel1Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (resourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel1SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resourceModel1sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResourceModel1SPutOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResourceModel1s_Get
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public virtual Response<ResourceModel1> Get(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            if (resourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.Get");
            scope.Start();
            try
            {
                var response = _resourceModel1sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ResourceModel1(Parent, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s/{resourceModel1sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResourceModel1s_Get
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public async virtual Task<Response<ResourceModel1>> GetAsync(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            if (resourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.Get");
            scope.Start();
            try
            {
                var response = await _resourceModel1sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ResourceModel1(Parent, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public virtual Response<ResourceModel1> GetIfExists(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            if (resourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _resourceModel1sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ResourceModel1>(null, response.GetRawResponse())
                    : Response.FromValue(new ResourceModel1(this, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public async virtual Task<Response<ResourceModel1>> GetIfExistsAsync(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            if (resourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _resourceModel1sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ResourceModel1>(null, response.GetRawResponse())
                    : Response.FromValue(new ResourceModel1(this, response.Value.Id, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public virtual Response<bool> Exists(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            if (resourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(resourceModel1SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resourceModel1SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceModel1SName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string resourceModel1SName, CancellationToken cancellationToken = default)
        {
            if (resourceModel1SName == null)
            {
                throw new ArgumentNullException(nameof(resourceModel1SName));
            }

            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resourceModel1SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResourceModel1s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResourceModel1> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ResourceModel1> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = _resourceModel1sRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceModel1(Parent, value.Id, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/resourceModel1s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: ResourceModel1s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceModel1" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResourceModel1> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ResourceModel1>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.GetAll");
                scope.Start();
                try
                {
                    var response = await _resourceModel1sRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ResourceModel1(Parent, value.Id, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of <see cref="ResourceModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResourceModel1.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ResourceModel1" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ResourceModel1Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ResourceModel1.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResourceModel1> IEnumerable<ResourceModel1>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResourceModel1> IAsyncEnumerable<ResourceModel1>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, ResourceModel1, ResourceModel1Data> Construct() { }
    }
}
