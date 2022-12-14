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
    /// A class representing a collection of <see cref="TheParentSubParentChildResource" /> and their operations.
    /// Each <see cref="TheParentSubParentChildResource" /> in the collection will belong to the same instance of <see cref="SubParentResource" />.
    /// To get a <see cref="TheParentSubParentChildCollection" /> instance call the GetTheParentSubParentChildren method from an instance of <see cref="SubParentResource" />.
    /// </summary>
    public partial class TheParentSubParentChildCollection : ArmCollection, IEnumerable<TheParentSubParentChildResource>, IAsyncEnumerable<TheParentSubParentChildResource>
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
            _theParentSubParentChildChildrenClientDiagnostics = new ClientDiagnostics("MgmtMultipleParentResource", TheParentSubParentChildResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(TheParentSubParentChildResource.ResourceType, out string theParentSubParentChildChildrenApiVersion);
            _theParentSubParentChildChildrenRestClient = new ChildrenRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, theParentSubParentChildChildrenApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubParentResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubParentResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// The operation to create or update the VMSS VM run command.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children/{childName}
        /// Operation Id: Children_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<TheParentSubParentChildResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string childName, ChildBodyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _theParentSubParentChildChildrenRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMultipleParentResourceArmOperation<TheParentSubParentChildResource>(new TheParentSubParentChildOperationSource(Client), _theParentSubParentChildChildrenClientDiagnostics, Pipeline, _theParentSubParentChildChildrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, data).Request, response, OperationFinalStateVia.Location);
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
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="childName"> The name of the virtual machine run command. </param>
        /// <param name="data"> Parameters supplied to the Create Virtual Machine RunCommand operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="childName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="childName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<TheParentSubParentChildResource> CreateOrUpdate(WaitUntil waitUntil, string childName, ChildBodyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _theParentSubParentChildChildrenRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, data, cancellationToken);
                var operation = new MgmtMultipleParentResourceArmOperation<TheParentSubParentChildResource>(new TheParentSubParentChildOperationSource(Client), _theParentSubParentChildChildrenClientDiagnostics, Pipeline, _theParentSubParentChildChildrenRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, data).Request, response, OperationFinalStateVia.Location);
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
        public virtual async Task<Response<TheParentSubParentChildResource>> GetAsync(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = await _theParentSubParentChildChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChildResource(Client, response.Value), response.GetRawResponse());
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
        public virtual Response<TheParentSubParentChildResource> Get(string childName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(childName, nameof(childName));

            using var scope = _theParentSubParentChildChildrenClientDiagnostics.CreateScope("TheParentSubParentChildCollection.Get");
            scope.Start();
            try
            {
                var response = _theParentSubParentChildChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TheParentSubParentChildResource(Client, response.Value), response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="TheParentSubParentChildResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TheParentSubParentChildResource> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _theParentSubParentChildChildrenRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _theParentSubParentChildChildrenRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new TheParentSubParentChildResource(Client, ChildBodyData.DeserializeChildBodyData(e)), _theParentSubParentChildChildrenClientDiagnostics, Pipeline, "TheParentSubParentChildCollection.GetAll", "Value", "NextLink");
        }

        /// <summary>
        /// The operation to get all run commands of an instance in Virtual Machine Scaleset.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/theParents/{theParentName}/subParents/{instanceId}/children
        /// Operation Id: Children_List
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TheParentSubParentChildResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TheParentSubParentChildResource> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _theParentSubParentChildChildrenRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _theParentSubParentChildChildrenRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new TheParentSubParentChildResource(Client, ChildBodyData.DeserializeChildBodyData(e)), _theParentSubParentChildChildrenClientDiagnostics, Pipeline, "TheParentSubParentChildCollection.GetAll", "Value", "NextLink");
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
                var response = await _theParentSubParentChildChildrenRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                var response = _theParentSubParentChildChildrenRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, childName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TheParentSubParentChildResource> IEnumerable<TheParentSubParentChildResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TheParentSubParentChildResource> IAsyncEnumerable<TheParentSubParentChildResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
