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
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using SupersetInheritance.Models;

namespace SupersetInheritance
{
    /// <summary> A class representing collection of SupersetModel4 and their operations over its parent. </summary>
    public partial class SupersetModel4Collection : ArmCollection, IEnumerable<SupersetModel4>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SupersetModel4SRestOperations _supersetModel4sRestClient;

        /// <summary> Initializes a new instance of the <see cref="SupersetModel4Collection"/> class for mocking. </summary>
        protected SupersetModel4Collection()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel4Collection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SupersetModel4Collection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _supersetModel4sRestClient = new SupersetModel4SRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel4s_Put
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SupersetModel4SPutOperation CreateOrUpdate(string supersetModel4SName, SupersetModel4Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (supersetModel4SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel4SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _supersetModel4sRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, parameters, cancellationToken);
                var operation = new SupersetModel4SPutOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel4s_Put
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SupersetModel4SPutOperation> CreateOrUpdateAsync(string supersetModel4SName, SupersetModel4Data parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (supersetModel4SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel4SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _supersetModel4sRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SupersetModel4SPutOperation(Parent, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel4s_Get
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public virtual Response<SupersetModel4> Get(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            if (supersetModel4SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel4SName));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.Get");
            scope.Start();
            try
            {
                var response = _supersetModel4sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel4(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel4s_Get
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public async virtual Task<Response<SupersetModel4>> GetAsync(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            if (supersetModel4SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel4SName));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.Get");
            scope.Start();
            try
            {
                var response = await _supersetModel4sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SupersetModel4(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public virtual Response<SupersetModel4> GetIfExists(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            if (supersetModel4SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel4SName));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.GetIfExists");
            scope.Start();
            try
            {
                var response = _supersetModel4sRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<SupersetModel4>(null, response.GetRawResponse())
                    : Response.FromValue(new SupersetModel4(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public async virtual Task<Response<SupersetModel4>> GetIfExistsAsync(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            if (supersetModel4SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel4SName));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _supersetModel4sRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<SupersetModel4>(null, response.GetRawResponse())
                    : Response.FromValue(new SupersetModel4(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            if (supersetModel4SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel4SName));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.CheckIfExists");
            scope.Start();
            try
            {
                var response = GetIfExists(supersetModel4SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            if (supersetModel4SName == null)
            {
                throw new ArgumentNullException(nameof(supersetModel4SName));
            }

            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.CheckIfExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(supersetModel4SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel4s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<SupersetModel4>> GetAll(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.GetAll");
            scope.Start();
            try
            {
                var response = _supersetModel4sRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(value => new SupersetModel4(Parent, value)).ToArray() as IReadOnlyList<SupersetModel4>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel4s_List
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<IReadOnlyList<SupersetModel4>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.GetAll");
            scope.Start();
            try
            {
                var response = await _supersetModel4sRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(value => new SupersetModel4(Parent, value)).ToArray() as IReadOnlyList<SupersetModel4>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SupersetModel4" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel4.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SupersetModel4" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Collection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel4.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SupersetModel4> IEnumerable<SupersetModel4>.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, SupersetModel4, SupersetModel4Data> Construct() { }
    }
}
