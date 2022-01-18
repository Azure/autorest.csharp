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
using Azure.ResourceManager.Core;
using MgmtMultipleParentResource.Models;

namespace MgmtMultipleParentResource
{
    /// <summary> A class representing collection of ChildBody and their operations over its parent. </summary>
    public partial class AnotherParentChildCollection : ArmCollection, IEnumerable<AnotherParentChild>, IAsyncEnumerable<AnotherParentChild>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AnotherChildrenRestOperations _anotherChildrenRestClient;

        /// <summary> Initializes a new instance of the <see cref="AnotherParentChildCollection"/> class for mocking. </summary>
        protected AnotherParentChildCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AnotherParentChildCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal AnotherParentChildCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(AnotherParentChild.ResourceType, out string apiVersion);
            _anotherChildrenRestClient = new AnotherChildrenRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AnotherParent.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AnotherParent.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// OperationId: AnotherChildren_CreateOrUpdate
        /// <summary> The operation to create or update the run command. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="childBody"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is null or empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childBody"/> is null. </exception>
        public virtual AnotherParentChildCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string childName, ChildBodyData childBody, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(childName))
            {
                throw new ArgumentException($"Parameter {nameof(childName)} cannot be null or empty", nameof(childName));
            }
            if (childBody == null)
            {
                throw new ArgumentNullException(nameof(childBody));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _anotherChildrenRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, childBody, cancellationToken);
                var operation = new AnotherParentChildCreateOrUpdateOperation(this, _clientDiagnostics, Pipeline, _anotherChildrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, childBody).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// OperationId: AnotherChildren_CreateOrUpdate
        /// <summary> The operation to create or update the run command. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="childBody"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is null or empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childBody"/> is null. </exception>
        public async virtual Task<AnotherParentChildCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string childName, ChildBodyData childBody, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(childName))
            {
                throw new ArgumentException($"Parameter {nameof(childName)} cannot be null or empty", nameof(childName));
            }
            if (childBody == null)
            {
                throw new ArgumentNullException(nameof(childBody));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _anotherChildrenRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, childBody, cancellationToken).ConfigureAwait(false);
                var operation = new AnotherParentChildCreateOrUpdateOperation(this, _clientDiagnostics, Pipeline, _anotherChildrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, childBody).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// OperationId: AnotherChildren_Get
        /// <summary> The operation to get the run command. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is null or empty. </exception>
        public virtual Response<AnotherParentChild> Get(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(childName))
            {
                throw new ArgumentException($"Parameter {nameof(childName)} cannot be null or empty", nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = _anotherChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AnotherParentChild(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// OperationId: AnotherChildren_Get
        /// <summary> The operation to get the run command. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is null or empty. </exception>
        public async virtual Task<Response<AnotherParentChild>> GetAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(childName))
            {
                throw new ArgumentException($"Parameter {nameof(childName)} cannot be null or empty", nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = await _anotherChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new AnotherParentChild(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is null or empty. </exception>
        public virtual Response<AnotherParentChild> GetIfExists(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(childName))
            {
                throw new ArgumentException($"Parameter {nameof(childName)} cannot be null or empty", nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _anotherChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<AnotherParentChild>(null, response.GetRawResponse());
                return Response.FromValue(new AnotherParentChild(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is null or empty. </exception>
        public async virtual Task<Response<AnotherParentChild>> GetIfExistsAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(childName))
            {
                throw new ArgumentException($"Parameter {nameof(childName)} cannot be null or empty", nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _anotherChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<AnotherParentChild>(null, response.GetRawResponse());
                return Response.FromValue(new AnotherParentChild(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is null or empty. </exception>
        public virtual Response<bool> Exists(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(childName))
            {
                throw new ArgumentException($"Parameter {nameof(childName)} cannot be null or empty", nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(childName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is null or empty. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(childName))
            {
                throw new ArgumentException($"Parameter {nameof(childName)} cannot be null or empty", nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(childName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// OperationId: AnotherChildren_List
        /// <summary> The operation to get all run commands of a Virtual Machine. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AnotherParentChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AnotherParentChild> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<AnotherParentChild> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _anotherChildrenRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AnotherParentChild(this, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AnotherParentChild> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _anotherChildrenRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AnotherParentChild(this, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}
        /// OperationId: AnotherChildren_List
        /// <summary> The operation to get all run commands of a Virtual Machine. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AnotherParentChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AnotherParentChild> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<AnotherParentChild>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _anotherChildrenRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AnotherParentChild(this, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AnotherParentChild>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("AnotherParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _anotherChildrenRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AnotherParentChild(this, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<AnotherParentChild> IEnumerable<AnotherParentChild>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AnotherParentChild> IAsyncEnumerable<AnotherParentChild>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, AnotherParentChild, ChildBodyData> Construct() { }
    }
}
