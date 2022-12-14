// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtMultipleParentResource
{
    /// <summary>
    /// A class representing a collection of <see cref="AnotherParentChildResource" /> and their operations.
    /// Each <see cref="AnotherParentChildResource" /> in the collection will belong to the same instance of <see cref="AnotherParentResource" />.
    /// To get an <see cref="AnotherParentChildCollection" /> instance call the GetAnotherParentChildren method from an instance of <see cref="AnotherParentResource" />.
    /// </summary>
    public partial class AnotherParentChildCollection : ArmCollection, IEnumerable<AnotherParentChildResource>, IAsyncEnumerable<AnotherParentChildResource>
    {
        private readonly ClientDiagnostics _anotherParentChildAnotherChildrenClientDiagnostics;
        private readonly AnotherChildrenRestOperations _anotherParentChildAnotherChildrenRestClient;

        /// <summary> Initializes a new instance of the <see cref="AnotherParentChildCollection"/> class for mocking. </summary>
        protected AnotherParentChildCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AnotherParentChildCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AnotherParentChildCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _anotherParentChildAnotherChildrenClientDiagnostics = new ClientDiagnostics("MgmtMultipleParentResource", AnotherParentChildResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AnotherParentChildResource.ResourceType, out string anotherParentChildAnotherChildrenApiVersion);
            _anotherParentChildAnotherChildrenRestClient = new AnotherChildrenRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, anotherParentChildAnotherChildrenApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AnotherParentResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AnotherParentResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// The operation to create or update the run command.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// Operation Id: AnotherChildren_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AnotherParentChildResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string childName, ChildBodyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _anotherParentChildAnotherChildrenClientDiagnostics.CreateScope("AnotherParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _anotherParentChildAnotherChildrenRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMultipleParentResourceArmOperation<AnotherParentChildResource>(new AnotherParentChildOperationSource(Client), _anotherParentChildAnotherChildrenClientDiagnostics, Pipeline, _anotherParentChildAnotherChildrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, data).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to create or update the run command.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// Operation Id: AnotherChildren_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AnotherParentChildResource> CreateOrUpdate(WaitUntil waitUntil, string childName, ChildBodyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _anotherParentChildAnotherChildrenClientDiagnostics.CreateScope("AnotherParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _anotherParentChildAnotherChildrenRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, data, cancellationToken);
                var operation = new MgmtMultipleParentResourceArmOperation<AnotherParentChildResource>(new AnotherParentChildOperationSource(Client), _anotherParentChildAnotherChildrenClientDiagnostics, Pipeline, _anotherParentChildAnotherChildrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, data).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to get the run command.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// Operation Id: AnotherChildren_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual async Task<Response<AnotherParentChildResource>> GetAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _anotherParentChildAnotherChildrenClientDiagnostics.CreateScope("AnotherParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = await _anotherParentChildAnotherChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AnotherParentChildResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get the run command.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// Operation Id: AnotherChildren_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual Response<AnotherParentChildResource> Get(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _anotherParentChildAnotherChildrenClientDiagnostics.CreateScope("AnotherParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = _anotherParentChildAnotherChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AnotherParentChildResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to get all run commands of a Virtual Machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children
        /// Operation Id: AnotherChildren_List
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AnotherParentChildResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AnotherParentChildResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _anotherParentChildAnotherChildrenRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _anotherParentChildAnotherChildrenRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AnotherParentChildResource(Client, ChildBodyData.DeserializeChildBodyData(e)), _anotherParentChildAnotherChildrenClientDiagnostics, Pipeline, "AnotherParentChildCollection.GetAll", "Value", "NextLink");
        }

        /// <summary>
        /// The operation to get all run commands of a Virtual Machine.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children
        /// Operation Id: AnotherChildren_List
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AnotherParentChildResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AnotherParentChildResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _anotherParentChildAnotherChildrenRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _anotherParentChildAnotherChildrenRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AnotherParentChildResource(Client, ChildBodyData.DeserializeChildBodyData(e)), _anotherParentChildAnotherChildrenClientDiagnostics, Pipeline, "AnotherParentChildCollection.GetAll", "Value", "NextLink");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// Operation Id: AnotherChildren_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _anotherParentChildAnotherChildrenClientDiagnostics.CreateScope("AnotherParentChildCollection.Exists");
            scope.Start();
            try
            {
                var response = await _anotherParentChildAnotherChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/anotherParents/{anotherName}/children/{childName}
        /// Operation Id: AnotherChildren_Get
        /// </summary>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> is null. </exception>
        public virtual Response<bool> Exists(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _anotherParentChildAnotherChildrenClientDiagnostics.CreateScope("AnotherParentChildCollection.Exists");
            scope.Start();
            try
            {
                var response = _anotherParentChildAnotherChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, childName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AnotherParentChildResource> IEnumerable<AnotherParentChildResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AnotherParentChildResource> IAsyncEnumerable<AnotherParentChildResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
