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
using MgmtPropertyChooser.Models;

namespace MgmtPropertyChooser
{
    /// <summary> A class representing collection of VirtualMachine and their operations over its parent. </summary>
    public partial class VirtualMachineCollection : ArmCollection, IEnumerable<VirtualMachine>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly VirtualMachinesRestOperations _virtualMachinesRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineCollection"/> class for mocking. </summary>
        protected VirtualMachineCollection()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _virtualMachinesRestClient = new VirtualMachinesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: VirtualMachines_CreateOrUpdate
        /// <summary> The operation to create or update a virtual machine. Please note some properties can be set only during virtual machine creation. </summary>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual VirtualMachineCreateOrUpdateOperation CreateOrUpdate(string vmName, VirtualMachineData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachinesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, vmName, parameters, cancellationToken);
                var operation = new VirtualMachineCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _virtualMachinesRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, vmName, parameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: VirtualMachines_CreateOrUpdate
        /// <summary> The operation to create or update a virtual machine. Please note some properties can be set only during virtual machine creation. </summary>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<VirtualMachineCreateOrUpdateOperation> CreateOrUpdateAsync(string vmName, VirtualMachineData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachinesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, vmName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new VirtualMachineCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _virtualMachinesRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, vmName, parameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: VirtualMachines_Get
        /// <summary> Retrieves information about the model view or the instance view of a virtual machine. </summary>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        public virtual Response<VirtualMachine> Get(string vmName, CancellationToken cancellationToken = default)
        {
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualMachinesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vmName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachine(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: VirtualMachines_Get
        /// <summary> Retrieves information about the model view or the instance view of a virtual machine. </summary>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        public async virtual Task<Response<VirtualMachine>> GetAsync(string vmName, CancellationToken cancellationToken = default)
        {
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachinesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vmName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualMachine(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        public virtual Response<VirtualMachine> GetIfExists(string vmName, CancellationToken cancellationToken = default)
        {
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachinesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, vmName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<VirtualMachine>(null, response.GetRawResponse())
                    : Response.FromValue(new VirtualMachine(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        public async virtual Task<Response<VirtualMachine>> GetIfExistsAsync(string vmName, CancellationToken cancellationToken = default)
        {
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _virtualMachinesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, vmName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<VirtualMachine>(null, response.GetRawResponse())
                    : Response.FromValue(new VirtualMachine(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        public virtual Response<bool> CheckIfExists(string vmName, CancellationToken cancellationToken = default)
        {
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.CheckIfExists");
            scope.Start();
            try
            {
                var response = GetIfExists(vmName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmName"/> is null. </exception>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string vmName, CancellationToken cancellationToken = default)
        {
            if (vmName == null)
            {
                throw new ArgumentNullException(nameof(vmName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.CheckIfExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(vmName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: VirtualMachines_List
        /// <summary> Retrieves information about the model view or the instance view of a virtual machine. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<VirtualMachine>> GetAll(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.GetAll");
            scope.Start();
            try
            {
                var response = _virtualMachinesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(value => new VirtualMachine(Parent, value)).ToArray() as IReadOnlyList<VirtualMachine>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: VirtualMachines_List
        /// <summary> Retrieves information about the model view or the instance view of a virtual machine. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<IReadOnlyList<VirtualMachine>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.GetAll");
            scope.Start();
            try
            {
                var response = await _virtualMachinesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(value => new VirtualMachine(Parent, value)).ToArray() as IReadOnlyList<VirtualMachine>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachine" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachine.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachine" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachine.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualMachine> IEnumerable<VirtualMachine>.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().Value.GetEnumerator();
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, VirtualMachine, VirtualMachineData> Construct() { }
    }
}
