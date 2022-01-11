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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineExtension and their operations over its parent. </summary>
    public partial class VirtualMachineScaleSetVirtualMachineExtensionCollection : ArmCollection, IEnumerable<VirtualMachineScaleSetVirtualMachineExtension>, IAsyncEnumerable<VirtualMachineScaleSetVirtualMachineExtension>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly VirtualMachineScaleSetVMExtensionsRestOperations _virtualMachineScaleSetVMExtensionsRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVirtualMachineExtensionCollection"/> class for mocking. </summary>
        protected VirtualMachineScaleSetVirtualMachineExtensionCollection()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVirtualMachineExtensionCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineScaleSetVirtualMachineExtensionCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _virtualMachineScaleSetVMExtensionsRestClient = new VirtualMachineScaleSetVMExtensionsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => VirtualMachineScaleSetVM.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// OperationId: VirtualMachineScaleSetVMExtensions_CreateOrUpdate
        /// <summary> The operation to create or update the VMSS VM extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public virtual VirtualMachineScaleSetVMExtensionCreateOrUpdateOperation CreateOrUpdate(string vmExtensionName, VirtualMachineExtensionData extensionParameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMExtensionsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters, cancellationToken);
                var operation = new VirtualMachineScaleSetVMExtensionCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _virtualMachineScaleSetVMExtensionsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// OperationId: VirtualMachineScaleSetVMExtensions_CreateOrUpdate
        /// <summary> The operation to create or update the VMSS VM extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public async virtual Task<VirtualMachineScaleSetVMExtensionCreateOrUpdateOperation> CreateOrUpdateAsync(string vmExtensionName, VirtualMachineExtensionData extensionParameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMExtensionsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters, cancellationToken).ConfigureAwait(false);
                var operation = new VirtualMachineScaleSetVMExtensionCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _virtualMachineScaleSetVMExtensionsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// OperationId: VirtualMachineScaleSetVMExtensions_Get
        /// <summary> The operation to get the VMSS VM extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVirtualMachineExtension> Get(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMExtensionsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetVirtualMachineExtension(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// OperationId: VirtualMachineScaleSetVMExtensions_Get
        /// <summary> The operation to get the VMSS VM extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineScaleSetVirtualMachineExtension>> GetAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMExtensionsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualMachineScaleSetVirtualMachineExtension(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVirtualMachineExtension> GetIfExists(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMExtensionsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineScaleSetVirtualMachineExtension>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetVirtualMachineExtension(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineScaleSetVirtualMachineExtension>> GetIfExistsAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMExtensionsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineScaleSetVirtualMachineExtension>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetVirtualMachineExtension(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<bool> Exists(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(vmExtensionName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(vmExtensionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// OperationId: VirtualMachineScaleSetVMExtensions_List
        /// <summary> The operation to get all extensions of an instance in Virtual Machine Scaleset. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetVirtualMachineExtension" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineScaleSetVirtualMachineExtension> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<VirtualMachineScaleSetVirtualMachineExtension> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineScaleSetVMExtensionsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVirtualMachineExtension(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// OperationId: VirtualMachineScaleSetVMExtensions_List
        /// <summary> The operation to get all extensions of an instance in Virtual Machine Scaleset. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetVirtualMachineExtension" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSetVirtualMachineExtension> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineScaleSetVirtualMachineExtension>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineScaleSetVMExtensionsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVirtualMachineExtension(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        IEnumerator<VirtualMachineScaleSetVirtualMachineExtension> IEnumerable<VirtualMachineScaleSetVirtualMachineExtension>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualMachineScaleSetVirtualMachineExtension> IAsyncEnumerable<VirtualMachineScaleSetVirtualMachineExtension>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, VirtualMachineScaleSetVirtualMachineExtension, VirtualMachineExtensionData> Construct() { }
    }
}
