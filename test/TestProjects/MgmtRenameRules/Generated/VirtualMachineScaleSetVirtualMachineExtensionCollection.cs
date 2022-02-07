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
using MgmtRenameRules.Models;

namespace MgmtRenameRules
{
    /// <summary> A class representing collection of VirtualMachineExtension and their operations over its parent. </summary>
    public partial class VirtualMachineScaleSetVirtualMachineExtensionCollection : ArmCollection, IEnumerable<VirtualMachineScaleSetVirtualMachineExtension>, IAsyncEnumerable<VirtualMachineScaleSetVirtualMachineExtension>
    {
        private readonly ClientDiagnostics _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics;
        private readonly VirtualMachineScaleSetVMExtensionsRestOperations _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVirtualMachineExtensionCollection"/> class for mocking. </summary>
        protected VirtualMachineScaleSetVirtualMachineExtensionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVirtualMachineExtensionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualMachineScaleSetVirtualMachineExtensionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics = new ClientDiagnostics("MgmtRenameRules", VirtualMachineScaleSetVirtualMachineExtension.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(VirtualMachineScaleSetVirtualMachineExtension.ResourceType, out string virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsApiVersion);
            _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient = new VirtualMachineScaleSetVMExtensionsRestOperations(_virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VirtualMachineScaleSetVm.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VirtualMachineScaleSetVm.ResourceType), nameof(id));
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// OperationId: VirtualMachineScaleSetVMExtensions_CreateOrUpdate
        /// <summary> The operation to create or update the VMSS VM extension. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public async virtual Task<VirtualMachineScaleSetVirtualMachineExtensionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters, cancellationToken).ConfigureAwait(false);
                var operation = new VirtualMachineScaleSetVirtualMachineExtensionCreateOrUpdateOperation(Client, _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics, Pipeline, _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters).Request, response);
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
        /// OperationId: VirtualMachineScaleSetVMExtensions_CreateOrUpdate
        /// <summary> The operation to create or update the VMSS VM extension. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public virtual VirtualMachineScaleSetVirtualMachineExtensionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string vmExtensionName, VirtualMachineExtensionData extensionParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters, cancellationToken);
                var operation = new VirtualMachineScaleSetVirtualMachineExtensionCreateOrUpdateOperation(Client, _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics, Pipeline, _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, extensionParameters).Request, response);
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
        /// OperationId: VirtualMachineScaleSetVMExtensions_Get
        /// <summary> The operation to get the VMSS VM extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineScaleSetVirtualMachineExtension>> GetAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualMachineScaleSetVirtualMachineExtension(Client, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVirtualMachineExtension> Get(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken);
                if (response.Value == null)
                    throw _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetVirtualMachineExtension(Client, response.Value), response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetVirtualMachineExtension" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSetVirtualMachineExtension> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineScaleSetVirtualMachineExtension>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVirtualMachineExtension(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
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
                using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSetVirtualMachineExtension(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}
        /// OperationId: VirtualMachineScaleSetVMExtensions_Get
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(vmExtensionName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
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
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<bool> Exists(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(vmExtensionName, expand: expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
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
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineScaleSetVirtualMachineExtension>> GetIfExistsAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineScaleSetVirtualMachineExtension>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetVirtualMachineExtension(Client, response.Value), response.GetRawResponse());
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
        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVirtualMachineExtension> GetIfExists(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vmExtensionName, nameof(vmExtensionName));

            using var scope = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsClientDiagnostics.CreateScope("VirtualMachineScaleSetVirtualMachineExtensionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVirtualMachineExtensionVirtualMachineScaleSetVMExtensionsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineScaleSetVirtualMachineExtension>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetVirtualMachineExtension(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
    }
}
