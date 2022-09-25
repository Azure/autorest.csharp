// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtPolymorphicResources
{
    /// <summary>
    /// A Class representing a VirtualMachineScaleSetGuestConfigurationAssignment along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VirtualMachineScaleSetGuestConfigurationAssignmentResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVirtualMachineScaleSetGuestConfigurationAssignmentResource method.
    /// Otherwise you can get one from its parent resource <see cref="VirtualMachineScaleSetResource" /> using the GetVirtualMachineScaleSetGuestConfigurationAssignment method.
    /// </summary>
    public partial class VirtualMachineScaleSetGuestConfigurationAssignmentResource : GuestConfigurationAssignmentResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VirtualMachineScaleSetGuestConfigurationAssignmentResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmssName, string name)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSClientDiagnostics;
        private readonly GuestConfigurationAssignmentsVmssRestOperations _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetGuestConfigurationAssignmentResource"/> class for mocking. </summary>
        protected VirtualMachineScaleSetGuestConfigurationAssignmentResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSetGuestConfigurationAssignmentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal VirtualMachineScaleSetGuestConfigurationAssignmentResource(ArmClient client, GuestConfigurationAssignmentData data) : base(client, data)
        {
            _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSClientDiagnostics = new ClientDiagnostics("MgmtPolymorphicResources", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSApiVersion);
            _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSRestClient = new GuestConfigurationAssignmentsVmssRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetGuestConfigurationAssignmentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetGuestConfigurationAssignmentResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSClientDiagnostics = new ClientDiagnostics("MgmtPolymorphicResources", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSApiVersion);
            _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSRestClient = new GuestConfigurationAssignmentsVmssRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.GuestConfiguration/guestConfigurationAssignments";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Get information about a guest configuration assignment for VMSS
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}
        /// Operation Id: GuestConfigurationAssignmentsVMSS_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        protected override async Task<Response<GuestConfigurationAssignmentResource>> GetCoreAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSClientDiagnostics.CreateScope("VirtualMachineScaleSetGuestConfigurationAssignmentResource.GetCore");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(GetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get information about a guest configuration assignment for VMSS
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}
        /// Operation Id: GuestConfigurationAssignmentsVMSS_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public new async Task<Response<VirtualMachineScaleSetGuestConfigurationAssignmentResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            var result = await GetCoreAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue((VirtualMachineScaleSetGuestConfigurationAssignmentResource)result.Value, result.GetRawResponse());
        }

        /// <summary>
        /// Get information about a guest configuration assignment for VMSS
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}
        /// Operation Id: GuestConfigurationAssignmentsVMSS_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        protected override Response<GuestConfigurationAssignmentResource> GetCore(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSClientDiagnostics.CreateScope("VirtualMachineScaleSetGuestConfigurationAssignmentResource.GetCore");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(GetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get information about a guest configuration assignment for VMSS
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}
        /// Operation Id: GuestConfigurationAssignmentsVMSS_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public new Response<VirtualMachineScaleSetGuestConfigurationAssignmentResource> Get(CancellationToken cancellationToken = default)
        {
            var result = GetCore(cancellationToken);
            return Response.FromValue((VirtualMachineScaleSetGuestConfigurationAssignmentResource)result.Value, result.GetRawResponse());
        }

        /// <summary>
        /// Delete a guest configuration assignment for VMSS
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}
        /// Operation Id: GuestConfigurationAssignmentsVMSS_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<VirtualMachineScaleSetGuestConfigurationAssignmentResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSClientDiagnostics.CreateScope("VirtualMachineScaleSetGuestConfigurationAssignmentResource.Delete");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtPolymorphicResourcesArmOperation<VirtualMachineScaleSetGuestConfigurationAssignmentResource>(Response.FromValue(new VirtualMachineScaleSetGuestConfigurationAssignmentResource(Client, response), response.GetRawResponse()));
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
        /// Delete a guest configuration assignment for VMSS
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}
        /// Operation Id: GuestConfigurationAssignmentsVMSS_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<VirtualMachineScaleSetGuestConfigurationAssignmentResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSClientDiagnostics.CreateScope("VirtualMachineScaleSetGuestConfigurationAssignmentResource.Delete");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetGuestConfigurationAssignmentGuestConfigurationAssignmentsVMSSRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new MgmtPolymorphicResourcesArmOperation<VirtualMachineScaleSetGuestConfigurationAssignmentResource>(Response.FromValue(new VirtualMachineScaleSetGuestConfigurationAssignmentResource(Client, response), response.GetRawResponse()));
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
    }
}
