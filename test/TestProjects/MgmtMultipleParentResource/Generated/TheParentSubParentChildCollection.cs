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

namespace MgmtMultipleParentResource
{
    /// <summary> A class representing collection of TheParentSubParentChild and their operations over its parent. </summary>
    public partial class TheParentSubParentChildCollection : ArmCollection, IEnumerable<TheParentSubParentChild>, IAsyncEnumerable<TheParentSubParentChild>
    {
        private readonly ClientDiagnostics _theParentSubParentChildChildrenClientDiagnostics;
        private readonly ChildrenRestOperations _theParentSubParentChildChildrenRestClient;

        /// <summary> Initializes a new instance of the <see cref="TheParentSubParentChildCollection"/> class for mocking. </summary>
        protected TheParentSubParentChildCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TheParentSubParentChildCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TheParentSubParentChildCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _theParentSubParentChildChildrenClientDiagnostics = new ClientDiagnostics("MgmtMultipleParentResource", TheParentSubParentChild.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(TheParentSubParentChild.ResourceType, out string theParentSubParentChildChildrenApiVersion);
            _theParentSubParentChildChildrenRestClient = new ChildrenRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, theParentSubParentChildChildrenApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubParent.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubParent.ResourceType), nameof(id));
        }

        /// <summary>
        /// The operation to create or update the VMSS VM run command.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// Operation Id: Children_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="childBody"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> or <paramref name="childBody"/> is null. </exception>
        public virtual async Task<ArmOperation<TheParentSubParentChild>> CreateOrUpdateAsync(WaitUntil waitUntil, string childName, ChildBodyData childBody, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));
            Argument.AssertNotNull(childBody, nameof(childBody));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _theParentSubParentChildChildrenRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, childBody, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMultipleParentResourceArmOperation<TheParentSubParentChild>(new TheParentSubParentChildOperationSource(Client), _theParentSubParentChildChildrenClientDiagnostics, Pipeline, _theParentSubParentChildChildrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, childBody).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to create or update the VMSS VM run command.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// Operation Id: Children_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="childBody"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> or <paramref name="childBody"/> is null. </exception>
        public virtual ArmOperation<TheParentSubParentChild> CreateOrUpdate(WaitUntil waitUntil, string childName, ChildBodyData childBody, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));
            Argument.AssertNotNull(childBody, nameof(childBody));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _theParentSubParentChildChildrenRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, childBody, cancellationToken);
                var operation = new MgmtMultipleParentResourceArmOperation<TheParentSubParentChild>(new TheParentSubParentChildOperationSource(Client), _theParentSubParentChildChildrenClientDiagnostics, Pipeline, _theParentSubParentChildChildrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, childBody).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get the VMSS VM run command.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// Operation Id: Children_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual async Task<Response<TheParentSubParentChild>> GetAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = await _theParentSubParentChildChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChild(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get the VMSS VM run command.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// Operation Id: Children_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual Response<TheParentSubParentChild> Get(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = _theParentSubParentChildChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChild(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get all run commands of an instance in Virtual Machine Scaleset.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children
        /// Operation Id: Children_List
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TheParentSubParentChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TheParentSubParentChild> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TheParentSubParentChild>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _theParentSubParentChildChildrenRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TheParentSubParentChild(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TheParentSubParentChild>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _theParentSubParentChildChildrenRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TheParentSubParentChild(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// The operation to get all run commands of an instance in Virtual Machine Scaleset.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children
        /// Operation Id: Children_List
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TheParentSubParentChild" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TheParentSubParentChild> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<TheParentSubParentChild> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _theParentSubParentChildChildrenRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TheParentSubParentChild(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TheParentSubParentChild> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _theParentSubParentChildChildrenRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TheParentSubParentChild(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// Operation Id: Children_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(childName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// Operation Id: Children_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual Response<bool> Exists(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(childName, expand: expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// Operation Id: Children_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual async Task<Response<TheParentSubParentChild>> GetIfExistsAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _theParentSubParentChildChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TheParentSubParentChild>(null, response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChild(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// Operation Id: Children_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual Response<TheParentSubParentChild> GetIfExists(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _theParentSubParentChildChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TheParentSubParentChild>(null, response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChild(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
    }
}
