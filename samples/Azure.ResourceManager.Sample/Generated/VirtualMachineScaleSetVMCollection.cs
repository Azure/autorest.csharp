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

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A class representing a collection of <see cref="VirtualMachineScaleSetVMResource" /> and their operations.
    /// Each <see cref="VirtualMachineScaleSetVMResource" /> in the collection will belong to the same instance of <see cref="VirtualMachineScaleSetResource" />.
    /// To get a <see cref="VirtualMachineScaleSetVMCollection" /> instance call the GetVirtualMachineScaleSetVMs method from an instance of <see cref="VirtualMachineScaleSetResource" />.
    /// </summary>
    public partial class VirtualMachineScaleSetVMCollection : ArmCollection, IEnumerable<VirtualMachineScaleSetVMResource>, IAsyncEnumerable<VirtualMachineScaleSetVMResource>
    {
        private readonly ClientDiagnostics _virtualMachineScaleSetVMClientDiagnostics;
        private readonly VirtualMachineScaleSetVMsRestOperations _virtualMachineScaleSetVMRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVMCollection"/> class for mocking. </summary>
        protected VirtualMachineScaleSetVMCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVMCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualMachineScaleSetVMCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineScaleSetVMClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sample", VirtualMachineScaleSetVMResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(VirtualMachineScaleSetVMResource.ResourceType, out string virtualMachineScaleSetVMApiVersion);
            _virtualMachineScaleSetVMRestClient = new VirtualMachineScaleSetVMsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineScaleSetVMApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VirtualMachineScaleSetResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VirtualMachineScaleSetResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Updates a virtual machine of a VM scale set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// Operation Id: VirtualMachineScaleSetVMs_Update
        /// </summary>
        /// <param name="waitUntil"> "WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVMResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string instanceId, VirtualMachineScaleSetVMData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, data, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation<VirtualMachineScaleSetVMResource>(new VirtualMachineScaleSetVMOperationSource(Client), _virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, data).Request, response, OperationFinalStateVia.Location);
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
        /// Updates a virtual machine of a VM scale set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// Operation Id: VirtualMachineScaleSetVMs_Update
        /// </summary>
        /// <param name="waitUntil"> "WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="data"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<VirtualMachineScaleSetVMResource> CreateOrUpdate(WaitUntil waitUntil, string instanceId, VirtualMachineScaleSetVMData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, data, cancellationToken);
                var operation = new SampleArmOperation<VirtualMachineScaleSetVMResource>(new VirtualMachineScaleSetVMOperationSource(Client), _virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, data).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a virtual machine from a VM scale set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// Operation Id: VirtualMachineScaleSetVMs_Get
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineScaleSetVMResource>> GetAsync(string instanceId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetVMResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a virtual machine from a VM scale set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// Operation Id: VirtualMachineScaleSetVMs_Get
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVMResource> Get(string instanceId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetVMResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all virtual machines in a VM scale sets.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines
        /// Operation Id: VirtualMachineScaleSetVMs_List
        /// </summary>
        /// <param name="filter"> The filter to apply to the operation. Allowed values are &apos;startswith(instanceView/statuses/code, &apos;PowerState&apos;) eq true&apos;, &apos;properties/latestModelApplied eq true&apos;, &apos;properties/latestModelApplied eq false&apos;. </param>
        /// <param name="select"> The list parameters. Allowed values are &apos;instanceView&apos;, &apos;instanceView/statuses&apos;. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetVMResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSetVMResource> GetAllAsync(string filter = null, string select = null, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineScaleSetVMResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineScaleSetVMRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVMResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualMachineScaleSetVMResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineScaleSetVMRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVMResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of all virtual machines in a VM scale sets.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines
        /// Operation Id: VirtualMachineScaleSetVMs_List
        /// </summary>
        /// <param name="filter"> The filter to apply to the operation. Allowed values are &apos;startswith(instanceView/statuses/code, &apos;PowerState&apos;) eq true&apos;, &apos;properties/latestModelApplied eq true&apos;, &apos;properties/latestModelApplied eq false&apos;. </param>
        /// <param name="select"> The list parameters. Allowed values are &apos;instanceView&apos;, &apos;instanceView/statuses&apos;. </param>
        /// <param name="expand"> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetVMResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineScaleSetVMResource> GetAll(string filter = null, string select = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<VirtualMachineScaleSetVMResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineScaleSetVMRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVMResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualMachineScaleSetVMResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineScaleSetVMRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, select, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVMResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// Operation Id: VirtualMachineScaleSetVMs_Get
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string instanceId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.Exists");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// Operation Id: VirtualMachineScaleSetVMs_Get
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        public virtual Response<bool> Exists(string instanceId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMCollection.Exists");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, instanceId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualMachineScaleSetVMResource> IEnumerable<VirtualMachineScaleSetVMResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualMachineScaleSetVMResource> IAsyncEnumerable<VirtualMachineScaleSetVMResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
