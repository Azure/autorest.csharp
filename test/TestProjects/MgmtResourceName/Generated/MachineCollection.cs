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
using Azure.ResourceManager.Resources;

namespace MgmtResourceName
{
    /// <summary>
    /// A class representing a collection of <see cref="MachineResource" /> and their operations.
    /// Each <see cref="MachineResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="MachineCollection" /> instance call the GetMachines method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class MachineCollection : ArmCollection, IEnumerable<MachineResource>, IAsyncEnumerable<MachineResource>
    {
        private readonly ClientDiagnostics _machineClientDiagnostics;
        private readonly MachinesRestOperations _machineRestClient;

        /// <summary> Initializes a new instance of the <see cref="MachineCollection"/> class for mocking. </summary>
        protected MachineCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MachineCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MachineCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _machineClientDiagnostics = new ClientDiagnostics("MgmtResourceName", MachineResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MachineResource.ResourceType, out string machineApiVersion);
            _machineRestClient = new MachinesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, machineApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines/{machineName}
        /// Operation Id: Machines_Put
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="machineName"> The String to use. </param>
        /// <param name="data"> The Machine to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="machineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="machineName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MachineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string machineName, MachineData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _machineClientDiagnostics.CreateScope("MachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _machineRestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, machineName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtResourceNameArmOperation<MachineResource>(Response.FromValue(new MachineResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines/{machineName}
        /// Operation Id: Machines_Put
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="machineName"> The String to use. </param>
        /// <param name="data"> The Machine to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="machineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="machineName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MachineResource> CreateOrUpdate(WaitUntil waitUntil, string machineName, MachineData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _machineClientDiagnostics.CreateScope("MachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _machineRestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, machineName, data, cancellationToken);
                var operation = new MgmtResourceNameArmOperation<MachineResource>(Response.FromValue(new MachineResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines/{machineName}
        /// Operation Id: Machines_Get
        /// </summary>
        /// <param name="machineName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="machineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="machineName"/> is null. </exception>
        public virtual async Task<Response<MachineResource>> GetAsync(string machineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using var scope = _machineClientDiagnostics.CreateScope("MachineCollection.Get");
            scope.Start();
            try
            {
                var response = await _machineRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, machineName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines/{machineName}
        /// Operation Id: Machines_Get
        /// </summary>
        /// <param name="machineName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="machineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="machineName"/> is null. </exception>
        public virtual Response<MachineResource> Get(string machineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using var scope = _machineClientDiagnostics.CreateScope("MachineCollection.Get");
            scope.Start();
            try
            {
                var response = _machineRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, machineName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines
        /// Operation Id: Machines_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MachineResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _machineRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new MachineResource(Client, MachineData.DeserializeMachineData(e)), _machineClientDiagnostics, Pipeline, "MachineCollection.GetAll", "Value", null);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines
        /// Operation Id: Machines_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MachineResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _machineRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new MachineResource(Client, MachineData.DeserializeMachineData(e)), _machineClientDiagnostics, Pipeline, "MachineCollection.GetAll", "Value", null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines/{machineName}
        /// Operation Id: Machines_Get
        /// </summary>
        /// <param name="machineName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="machineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="machineName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string machineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using var scope = _machineClientDiagnostics.CreateScope("MachineCollection.Exists");
            scope.Start();
            try
            {
                var response = await _machineRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, machineName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/machines/{machineName}
        /// Operation Id: Machines_Get
        /// </summary>
        /// <param name="machineName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="machineName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="machineName"/> is null. </exception>
        public virtual Response<bool> Exists(string machineName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(machineName, nameof(machineName));

            using var scope = _machineClientDiagnostics.CreateScope("MachineCollection.Exists");
            scope.Start();
            try
            {
                var response = _machineRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, machineName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MachineResource> IEnumerable<MachineResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MachineResource> IAsyncEnumerable<MachineResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
