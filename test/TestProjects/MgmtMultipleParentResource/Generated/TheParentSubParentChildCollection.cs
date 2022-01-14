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
    public partial class TheParentSubParentChildCollection : ArmCollection, IEnumerable<TheParentSubParentChild>, IAsyncEnumerable<TheParentSubParentChild>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ChildrenRestOperations _childrenRestClient;

        /// <summary> Initializes a new instance of the <see cref="TheParentSubParentChildCollection"/> class for mocking. </summary>
        protected TheParentSubParentChildCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TheParentSubParentChildCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TheParentSubParentChildCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            ClientOptions.TryGetApiVersion(TheParentSubParentChild.ResourceType, out string apiVersion);
            _childrenRestClient = new ChildrenRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri, apiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubParent.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubParent.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}
        /// OperationId: Children_CreateOrUpdate
        /// <summary> The operation to create or update the VMSS VM run command. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="childBody"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> or <paramref name="childBody"/> is null. </exception>
        public virtual TheParentSubParentChildCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string childName, ChildBodyData childBody, CancellationToken cancellationToken = default)
        {
            if (childName == null)
            {
                throw new ArgumentNullException(nameof(childName));
            }
            if (childBody == null)
            {
                throw new ArgumentNullException(nameof(childBody));
            }

            using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _childrenRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, childBody, cancellationToken);
                var operation = new TheParentSubParentChildCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _childrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, childBody).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}
        /// OperationId: Children_CreateOrUpdate
        /// <summary> The operation to create or update the VMSS VM run command. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="childBody"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> or <paramref name="childBody"/> is null. </exception>
        public async virtual Task<TheParentSubParentChildCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string childName, ChildBodyData childBody, CancellationToken cancellationToken = default)
        {
            if (childName == null)
            {
                throw new ArgumentNullException(nameof(childName));
            }
            if (childBody == null)
            {
                throw new ArgumentNullException(nameof(childBody));
            }

            using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _childrenRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, childBody, cancellationToken).ConfigureAwait(false);
                var operation = new TheParentSubParentChildCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _childrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, childBody).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}
        /// OperationId: Children_Get
        /// <summary> The operation to get the VMSS VM run command. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual Response<TheParentSubParentChild> Get(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (childName == null)
            {
                throw new ArgumentNullException(nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = _childrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChild(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}
        /// OperationId: Children_Get
        /// <summary> The operation to get the VMSS VM run command. </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public async virtual Task<Response<TheParentSubParentChild>> GetAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (childName == null)
            {
                throw new ArgumentNullException(nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = await _childrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TheParentSubParentChild(Parent, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual Response<TheParentSubParentChild> GetIfExists(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (childName == null)
            {
                throw new ArgumentNullException(nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _childrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TheParentSubParentChild>(null, response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChild(this, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public async virtual Task<Response<TheParentSubParentChild>> GetIfExistsAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (childName == null)
            {
                throw new ArgumentNullException(nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _childrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TheParentSubParentChild>(null, response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChild(this, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual Response<bool> Exists(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (childName == null)
            {
                throw new ArgumentNullException(nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.Exists");
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
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (childName == null)
            {
                throw new ArgumentNullException(nameof(childName));
            }

            using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.Exists");
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}
        /// OperationId: Children_List
        /// <summary> The operation to get all run commands of an instance in Virtual Machine Scaleset. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TheParentSubParentChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TheParentSubParentChild> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<TheParentSubParentChild> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _childrenRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TheParentSubParentChild(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TheParentSubParentChild> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _childrenRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TheParentSubParentChild(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}
        /// OperationId: Children_List
        /// <summary> The operation to get all run commands of an instance in Virtual Machine Scaleset. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TheParentSubParentChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TheParentSubParentChild> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TheParentSubParentChild>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _childrenRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TheParentSubParentChild(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TheParentSubParentChild>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _childrenRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TheParentSubParentChild(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        IEnumerator<TheParentSubParentChild> IEnumerable<TheParentSubParentChild>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TheParentSubParentChild> IAsyncEnumerable<TheParentSubParentChild>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, TheParentSubParentChild, ChildBodyData> Construct() { }
    }
}
