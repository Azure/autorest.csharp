// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineExtension and their operations over its parent. </summary>
    public partial class VirtualMachineExtensionContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly VirtualMachineExtensionsRestOperations _virtualMachineExtensionsRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineExtensionContainer"/> class for mocking. </summary>
        protected VirtualMachineExtensionContainer()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineExtensionContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _virtualMachineExtensionsRestClient = new VirtualMachineExtensionsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => VirtualMachine.ResourceType;

        // Container level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// OperationId: VirtualMachineExtensions_CreateOrUpdate
        /// <summary> The operation to create or update the extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public virtual VirtualMachineExtensionCreateOrUpdateOperation CreateOrUpdate(string vmExtensionName, VirtualMachineExtensionData extensionParameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineExtensionsRestClient.CreateOrUpdate(Id.ResourceGroupName, Id.Name, vmExtensionName, extensionParameters, cancellationToken);
                var operation = new VirtualMachineExtensionCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _virtualMachineExtensionsRestClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Name, vmExtensionName, extensionParameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// OperationId: VirtualMachineExtensions_CreateOrUpdate
        /// <summary> The operation to create or update the extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="extensionParameters"> Parameters supplied to the Create Virtual Machine Extension operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> or <paramref name="extensionParameters"/> is null. </exception>
        public async virtual Task<VirtualMachineExtensionCreateOrUpdateOperation> CreateOrUpdateAsync(string vmExtensionName, VirtualMachineExtensionData extensionParameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }
            if (extensionParameters == null)
            {
                throw new ArgumentNullException(nameof(extensionParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineExtensionsRestClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, vmExtensionName, extensionParameters, cancellationToken).ConfigureAwait(false);
                var operation = new VirtualMachineExtensionCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _virtualMachineExtensionsRestClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Name, vmExtensionName, extensionParameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// OperationId: VirtualMachineExtensions_Get
        /// <summary> The operation to get the extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public virtual Response<VirtualMachineExtension> Get(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineExtensionsRestClient.Get(Id.ResourceGroupName, Id.Name, vmExtensionName, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineExtension(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{vmExtensionName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// OperationId: VirtualMachineExtensions_Get
        /// <summary> The operation to get the extension. </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineExtension>> GetAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineExtensionsRestClient.GetAsync(Id.ResourceGroupName, Id.Name, vmExtensionName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualMachineExtension(Parent, response.Value), response.GetRawResponse());
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
        public virtual Response<VirtualMachineExtension> GetIfExists(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachineExtensionsRestClient.Get(Id.ResourceGroupName, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<VirtualMachineExtension>(null, response.GetRawResponse())
                    : Response.FromValue(new VirtualMachineExtension(this, response.Value), response.GetRawResponse());
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
        public async virtual Task<Response<VirtualMachineExtension>> GetIfExistsAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _virtualMachineExtensionsRestClient.GetAsync(Id.ResourceGroupName, Id.Name, vmExtensionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<VirtualMachineExtension>(null, response.GetRawResponse())
                    : Response.FromValue(new VirtualMachineExtension(this, response.Value), response.GetRawResponse());
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
        public virtual Response<bool> CheckIfExists(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.CheckIfExists");
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
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (vmExtensionName == null)
            {
                throw new ArgumentNullException(nameof(vmExtensionName));
            }

            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.CheckIfExistsAsync");
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// OperationId: VirtualMachineExtensions_List
        /// <summary> The operation to get all extensions of a Virtual Machine. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<VirtualMachineExtension>> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.GetAll");
            scope.Start();
            try
            {
                var response = _virtualMachineExtensionsRestClient.List(Id.ResourceGroupName, Id.Name, expand, cancellationToken);
                return Response.FromValue(response.Value.Value.Select(value => new VirtualMachineExtension(Parent, value)).ToArray() as IReadOnlyList<VirtualMachineExtension>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
        /// OperationId: VirtualMachineExtensions_List
        /// <summary> The operation to get all extensions of a Virtual Machine. </summary>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<IReadOnlyList<VirtualMachineExtension>>> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionContainer.GetAll");
            scope.Start();
            try
            {
                var response = await _virtualMachineExtensionsRestClient.ListAsync(Id.ResourceGroupName, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value.Select(value => new VirtualMachineExtension(Parent, value)).ToArray() as IReadOnlyList<VirtualMachineExtension>, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, VirtualMachineExtension, VirtualMachineExtensionData> Construct() { }
    }
}
