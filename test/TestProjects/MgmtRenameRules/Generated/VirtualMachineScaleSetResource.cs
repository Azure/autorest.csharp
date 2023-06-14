// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtRenameRules.Models;

namespace MgmtRenameRules
{
    /// <summary>
    /// A Class representing a VirtualMachineScaleSet along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VirtualMachineScaleSetResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVirtualMachineScaleSetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetVirtualMachineScaleSet method.
    /// </summary>
    public partial class VirtualMachineScaleSetResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VirtualMachineScaleSetResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _virtualMachineScaleSetClientDiagnostics;
        private readonly VirtualMachineScaleSetsRestOperations _virtualMachineScaleSetRestClient;
        private readonly ClientDiagnostics _virtualMachineScaleSetRollingUpgradeClientDiagnostics;
        private readonly VirtualMachineScaleSetRollingUpgradesRestOperations _virtualMachineScaleSetRollingUpgradeRestClient;
        private readonly VirtualMachineScaleSetData _data;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetResource"/> class for mocking. </summary>
        protected VirtualMachineScaleSetResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSetResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal VirtualMachineScaleSetResource(ArmClient client, VirtualMachineScaleSetData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineScaleSetClientDiagnostics = new ClientDiagnostics("MgmtRenameRules", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string virtualMachineScaleSetApiVersion);
            _virtualMachineScaleSetRestClient = new VirtualMachineScaleSetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineScaleSetApiVersion);
            _virtualMachineScaleSetRollingUpgradeClientDiagnostics = new ClientDiagnostics("MgmtRenameRules", VirtualMachineScaleSetRollingUpgradeResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(VirtualMachineScaleSetRollingUpgradeResource.ResourceType, out string virtualMachineScaleSetRollingUpgradeApiVersion);
            _virtualMachineScaleSetRollingUpgradeRestClient = new VirtualMachineScaleSetRollingUpgradesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineScaleSetRollingUpgradeApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachineScaleSets";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual VirtualMachineScaleSetData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of VirtualMachineScaleSetExtensionResources in the VirtualMachineScaleSet. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSetExtensionResources and their operations over a VirtualMachineScaleSetExtensionResource. </returns>
        public virtual VirtualMachineScaleSetExtensionCollection GetVirtualMachineScaleSetExtensions()
        {
            return GetCachedClient(Client => new VirtualMachineScaleSetExtensionCollection(Client, Id));
        }

        /// <summary>
        /// The operation to get the extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensions/{vmssExtensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmssExtensionName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<VirtualMachineScaleSetExtensionResource>> GetVirtualMachineScaleSetExtensionAsync(string vmssExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await GetVirtualMachineScaleSetExtensions().GetAsync(vmssExtensionName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The operation to get the extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensions/{vmssExtensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmssExtensionName"> The name of the VM scale set extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmssExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmssExtensionName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<VirtualMachineScaleSetExtensionResource> GetVirtualMachineScaleSetExtension(string vmssExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetVirtualMachineScaleSetExtensions().Get(vmssExtensionName, expand, cancellationToken);
        }

        /// <summary> Gets an object representing a VirtualMachineScaleSetRollingUpgradeResource along with the instance operations that can be performed on it in the VirtualMachineScaleSet. </summary>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetRollingUpgradeResource" /> object. </returns>
        public virtual VirtualMachineScaleSetRollingUpgradeResource GetVirtualMachineScaleSetRollingUpgrade()
        {
            return new VirtualMachineScaleSetRollingUpgradeResource(Client, Id.AppendChildResource("rollingUpgrades", "latest"));
        }

        /// <summary> Gets a collection of VirtualMachineScaleSetVmResources in the VirtualMachineScaleSet. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSetVmResources and their operations over a VirtualMachineScaleSetVmResource. </returns>
        public virtual VirtualMachineScaleSetVmCollection GetVirtualMachineScaleSetVms()
        {
            return GetCachedClient(Client => new VirtualMachineScaleSetVmCollection(Client, Id));
        }

        /// <summary>
        /// Gets a virtual machine from a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<VirtualMachineScaleSetVmResource>> GetVirtualMachineScaleSetVmAsync(string instanceId, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return await GetVirtualMachineScaleSetVms().GetAsync(instanceId, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a virtual machine from a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instanceId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<VirtualMachineScaleSetVmResource> GetVirtualMachineScaleSetVm(string instanceId, InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            return GetVirtualMachineScaleSetVms().Get(instanceId, expand, cancellationToken);
        }

        /// <summary>
        /// Display information about a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<VirtualMachineScaleSetResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Display information about a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VirtualMachineScaleSetResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Delete");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Delete");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The scale set object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Update");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation<VirtualMachineScaleSetResource>(new VirtualMachineScaleSetOperationSource(Client), _virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch).Request, response, OperationFinalStateVia.Location);
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
        /// Update a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="patch"> The scale set object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual ArmOperation<VirtualMachineScaleSetResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Update");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation<VirtualMachineScaleSetResource>(new VirtualMachineScaleSetOperationSource(Client), _virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch).Request, response, OperationFinalStateVia.Location);
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
        /// Deallocates specific virtual machines in a VM scale set. Shuts down the virtual machines and releases the compute resources. You are not billed for the compute resources that this virtual machine scale set deallocates.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/deallocate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Deallocate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeallocateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Deallocate");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.DeallocateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateDeallocateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deallocates specific virtual machines in a VM scale set. Shuts down the virtual machines and releases the compute resources. You are not billed for the compute resources that this virtual machine scale set deallocates.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/deallocate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Deallocate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Deallocate(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Deallocate");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Deallocate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateDeallocateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes virtual machines in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/delete</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_DeleteInstances</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmInstanceIds"/> is null. </exception>
        public virtual async Task<ArmOperation> DeleteInstancesAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(vmInstanceIds, nameof(vmInstanceIds));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.DeleteInstances");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.DeleteInstancesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateDeleteInstancesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes virtual machines in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/delete</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_DeleteInstances</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmInstanceIds"/> is null. </exception>
        public virtual ArmOperation DeleteInstances(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(vmInstanceIds, nameof(vmInstanceIds));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.DeleteInstances");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.DeleteInstances(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateDeleteInstancesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the status of a VM scale set instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/instanceView</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetInstanceView</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<VirtualMachineScaleSetInstanceView>> GetInstanceViewAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.GetInstanceView");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.GetInstanceViewAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the status of a VM scale set instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/instanceView</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetInstanceView</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VirtualMachineScaleSetInstanceView> GetInstanceView(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.GetInstanceView");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.GetInstanceView(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of SKUs available for your VM scale set, including the minimum and maximum VM instances allowed for each SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListSkus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSetSku" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineScaleSetSku> GetSkusAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetRestClient.CreateListSkusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetRestClient.CreateListSkusNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, VirtualMachineScaleSetSku.DeserializeVirtualMachineScaleSetSku, _virtualMachineScaleSetClientDiagnostics, Pipeline, "VirtualMachineScaleSetResource.GetSkus", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of SKUs available for your VM scale set, including the minimum and maximum VM instances allowed for each SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListSkus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSetSku" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineScaleSetSku> GetSkus(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetRestClient.CreateListSkusRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetRestClient.CreateListSkusNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, VirtualMachineScaleSetSku.DeserializeVirtualMachineScaleSetSku, _virtualMachineScaleSetClientDiagnostics, Pipeline, "VirtualMachineScaleSetResource.GetSkus", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets list of OS upgrades on a VM scale set instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/osUpgradeHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetOSUpgradeHistory</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="UpgradeOperationHistoricalStatusInfo" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistoryAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetRestClient.CreateGetOSUpgradeHistoryRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetRestClient.CreateGetOSUpgradeHistoryNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, UpgradeOperationHistoricalStatusInfo.DeserializeUpgradeOperationHistoricalStatusInfo, _virtualMachineScaleSetClientDiagnostics, Pipeline, "VirtualMachineScaleSetResource.GetOSUpgradeHistory", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets list of OS upgrades on a VM scale set instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/osUpgradeHistory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetOSUpgradeHistory</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="UpgradeOperationHistoricalStatusInfo" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistory(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetRestClient.CreateGetOSUpgradeHistoryRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetRestClient.CreateGetOSUpgradeHistoryNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, UpgradeOperationHistoricalStatusInfo.DeserializeUpgradeOperationHistoricalStatusInfo, _virtualMachineScaleSetClientDiagnostics, Pipeline, "VirtualMachineScaleSetResource.GetOSUpgradeHistory", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Power off (stop) one or more virtual machines in a VM scale set. Note that resources are still attached and you are getting charged for the resources. Instead, use deallocate to release resources and avoid charges.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/poweroff</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_PowerOff</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="skipShutdown"> The parameter to request non-graceful VM shutdown. True value for this flag indicates non-graceful shutdown whereas false indicates otherwise. Default value for this flag is false if not specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> PowerOffAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? skipShutdown = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.PowerOff");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.PowerOffAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, skipShutdown, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreatePowerOffRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, skipShutdown).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Power off (stop) one or more virtual machines in a VM scale set. Note that resources are still attached and you are getting charged for the resources. Instead, use deallocate to release resources and avoid charges.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/poweroff</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_PowerOff</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="skipShutdown"> The parameter to request non-graceful VM shutdown. True value for this flag indicates non-graceful shutdown whereas false indicates otherwise. Default value for this flag is false if not specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation PowerOff(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? skipShutdown = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.PowerOff");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.PowerOff(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, skipShutdown, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreatePowerOffRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, skipShutdown).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restarts one or more virtual machines in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/restart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Restart</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> RestartAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Restart");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.RestartAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateRestartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restarts one or more virtual machines in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/restart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Restart</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Restart(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Restart");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Restart(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateRestartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts one or more virtual machines in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/start</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Start</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> StartAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Start");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.StartAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateStartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts one or more virtual machines in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/start</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Start</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Start(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Start");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Start(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateStartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Shuts down all the virtual machines in the virtual machine scale set, moves them to a new node, and powers them back on.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/redeploy</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Redeploy</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> RedeployAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Redeploy");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.RedeployAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateRedeployRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Shuts down all the virtual machines in the virtual machine scale set, moves them to a new node, and powers them back on.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/redeploy</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Redeploy</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Redeploy(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Redeploy");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Redeploy(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateRedeployRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Perform maintenance on one or more virtual machines in a VM scale set. Operation on instances which are not eligible for perform maintenance will be failed. Please refer to best practices for more details: https://docs.microsoft.com/en-us/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-maintenance-notifications
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/performMaintenance</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_PerformMaintenance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> PerformMaintenanceAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.PerformMaintenance");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.PerformMaintenanceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreatePerformMaintenanceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Perform maintenance on one or more virtual machines in a VM scale set. Operation on instances which are not eligible for perform maintenance will be failed. Please refer to best practices for more details: https://docs.microsoft.com/en-us/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-maintenance-notifications
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/performMaintenance</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_PerformMaintenance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation PerformMaintenance(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.PerformMaintenance");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.PerformMaintenance(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreatePerformMaintenanceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Upgrades one or more virtual machines to the latest SKU set in the VM scale set model.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/manualupgrade</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_UpdateInstances</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmInstanceIds"/> is null. </exception>
        public virtual async Task<ArmOperation> UpdateInstancesAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(vmInstanceIds, nameof(vmInstanceIds));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.UpdateInstances");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.UpdateInstancesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateUpdateInstancesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Upgrades one or more virtual machines to the latest SKU set in the VM scale set model.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/manualupgrade</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_UpdateInstances</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmInstanceIds"/> is null. </exception>
        public virtual ArmOperation UpdateInstances(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(vmInstanceIds, nameof(vmInstanceIds));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.UpdateInstances");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.UpdateInstances(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateUpdateInstancesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reimages (upgrade the operating system) one or more virtual machines in a VM scale set which don't have a ephemeral OS disk, for virtual machines who have a ephemeral OS disk the virtual machine is reset to initial state.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/reimage</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Reimage</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Parameters for Reimaging VM ScaleSet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> ReimageAsync(WaitUntil waitUntil, VirtualMachineScaleSetReimageContent content = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Reimage");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.ReimageAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateReimageRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reimages (upgrade the operating system) one or more virtual machines in a VM scale set which don't have a ephemeral OS disk, for virtual machines who have a ephemeral OS disk the virtual machine is reset to initial state.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/reimage</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Reimage</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Parameters for Reimaging VM ScaleSet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Reimage(WaitUntil waitUntil, VirtualMachineScaleSetReimageContent content = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Reimage");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Reimage(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateReimageRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reimages all the disks ( including data disks ) in the virtual machines in a VM scale set. This operation is only supported for managed disks.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/reimageall</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ReimageAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> ReimageAllAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.ReimageAll");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.ReimageAllAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateReimageAllRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reimages all the disks ( including data disks ) in the virtual machines in a VM scale set. This operation is only supported for managed disks.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/reimageall</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ReimageAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="vmInstanceIds"> A list of virtual machine instance IDs from the VM scale set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation ReimageAll(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.ReimageAll");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.ReimageAll(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateReimageAllRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Manual platform update domain walk to update virtual machines in a service fabric virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/forceRecoveryServiceFabricPlatformUpdateDomainWalk</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ForceRecoveryServiceFabricPlatformUpdateDomainWalk</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="platformUpdateDomain"> The platform update domain for which a manual recovery walk is requested. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RecoveryWalkResponse>> ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(int platformUpdateDomain, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.ForceRecoveryServiceFabricPlatformUpdateDomainWalk");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, platformUpdateDomain, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Manual platform update domain walk to update virtual machines in a service fabric virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/forceRecoveryServiceFabricPlatformUpdateDomainWalk</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ForceRecoveryServiceFabricPlatformUpdateDomainWalk</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="platformUpdateDomain"> The platform update domain for which a manual recovery walk is requested. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RecoveryWalkResponse> ForceRecoveryServiceFabricPlatformUpdateDomainWalk(int platformUpdateDomain, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.ForceRecoveryServiceFabricPlatformUpdateDomainWalk");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.ForceRecoveryServiceFabricPlatformUpdateDomainWalk(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, platformUpdateDomain, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Converts SinglePlacementGroup property to false for a existing virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/convertToSinglePlacementGroup</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ConvertToSinglePlacementGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The input object for ConvertToSinglePlacementGroup API. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response> ConvertToSinglePlacementGroupAsync(VmScaleSetConvertToSinglePlacementGroupContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.ConvertToSinglePlacementGroup");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.ConvertToSinglePlacementGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Converts SinglePlacementGroup property to false for a existing virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/convertToSinglePlacementGroup</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ConvertToSinglePlacementGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The input object for ConvertToSinglePlacementGroup API. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response ConvertToSinglePlacementGroup(VmScaleSetConvertToSinglePlacementGroupContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.ConvertToSinglePlacementGroup");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.ConvertToSinglePlacementGroup(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Changes ServiceState property for a given service
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/setOrchestrationServiceState</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_SetOrchestrationServiceState</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The input object for SetOrchestrationServiceState API. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation> SetOrchestrationServiceStateAsync(WaitUntil waitUntil, OrchestrationServiceStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.SetOrchestrationServiceState");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.SetOrchestrationServiceStateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateSetOrchestrationServiceStateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Changes ServiceState property for a given service
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/setOrchestrationServiceState</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_SetOrchestrationServiceState</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The input object for SetOrchestrationServiceState API. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation SetOrchestrationServiceState(WaitUntil waitUntil, OrchestrationServiceStateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.SetOrchestrationServiceState");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.SetOrchestrationServiceState(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateSetOrchestrationServiceStateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Cancels the current virtual machine scale set rolling upgrade.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/rollingUpgrades/cancel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetRollingUpgrades_Cancel</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> CancelVirtualMachineScaleSetRollingUpgradeAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetRollingUpgradeClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.CancelVirtualMachineScaleSetRollingUpgrade");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRollingUpgradeRestClient.CancelAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetRollingUpgradeClientDiagnostics, Pipeline, _virtualMachineScaleSetRollingUpgradeRestClient.CreateCancelRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Cancels the current virtual machine scale set rolling upgrade.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/rollingUpgrades/cancel</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetRollingUpgrades_Cancel</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation CancelVirtualMachineScaleSetRollingUpgrade(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetRollingUpgradeClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.CancelVirtualMachineScaleSetRollingUpgrade");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRollingUpgradeRestClient.Cancel(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetRollingUpgradeClientDiagnostics, Pipeline, _virtualMachineScaleSetRollingUpgradeRestClient.CreateCancelRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a rolling upgrade to move all virtual machine scale set instances to the latest available Platform Image OS version. Instances which are already running the latest available OS version are not affected.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/osRollingUpgrade</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetRollingUpgrades_StartOSUpgrade</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> StartOSUpgradeVirtualMachineScaleSetRollingUpgradeAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetRollingUpgradeClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.StartOSUpgradeVirtualMachineScaleSetRollingUpgrade");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRollingUpgradeRestClient.StartOSUpgradeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetRollingUpgradeClientDiagnostics, Pipeline, _virtualMachineScaleSetRollingUpgradeRestClient.CreateStartOSUpgradeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a rolling upgrade to move all virtual machine scale set instances to the latest available Platform Image OS version. Instances which are already running the latest available OS version are not affected.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/osRollingUpgrade</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetRollingUpgrades_StartOSUpgrade</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation StartOSUpgradeVirtualMachineScaleSetRollingUpgrade(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetRollingUpgradeClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.StartOSUpgradeVirtualMachineScaleSetRollingUpgrade");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRollingUpgradeRestClient.StartOSUpgrade(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetRollingUpgradeClientDiagnostics, Pipeline, _virtualMachineScaleSetRollingUpgradeRestClient.CreateStartOSUpgradeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a rolling upgrade to move all extensions for all virtual machine scale set instances to the latest available extension version. Instances which are already running the latest extension versions are not affected.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensionRollingUpgrade</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetRollingUpgrades_StartExtensionUpgrade</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> StartExtensionUpgradeVirtualMachineScaleSetRollingUpgradeAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetRollingUpgradeClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.StartExtensionUpgradeVirtualMachineScaleSetRollingUpgrade");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRollingUpgradeRestClient.StartExtensionUpgradeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetRollingUpgradeClientDiagnostics, Pipeline, _virtualMachineScaleSetRollingUpgradeRestClient.CreateStartExtensionUpgradeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a rolling upgrade to move all extensions for all virtual machine scale set instances to the latest available extension version. Instances which are already running the latest extension versions are not affected.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensionRollingUpgrade</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetRollingUpgrades_StartExtensionUpgrade</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation StartExtensionUpgradeVirtualMachineScaleSetRollingUpgrade(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetRollingUpgradeClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.StartExtensionUpgradeVirtualMachineScaleSetRollingUpgrade");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRollingUpgradeRestClient.StartExtensionUpgrade(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new MgmtRenameRulesArmOperation(_virtualMachineScaleSetRollingUpgradeClientDiagnostics, Pipeline, _virtualMachineScaleSetRollingUpgradeRestClient.CreateStartExtensionUpgradeRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineScaleSetResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _virtualMachineScaleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new VirtualMachineScaleSetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new VirtualMachineScaleSetPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _virtualMachineScaleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                    return Response.FromValue(new VirtualMachineScaleSetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new VirtualMachineScaleSetPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineScaleSetResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _virtualMachineScaleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new VirtualMachineScaleSetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new VirtualMachineScaleSetPatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _virtualMachineScaleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                    return Response.FromValue(new VirtualMachineScaleSetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new VirtualMachineScaleSetPatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineScaleSetResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _virtualMachineScaleSetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new VirtualMachineScaleSetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new VirtualMachineScaleSetPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _virtualMachineScaleSetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                    return Response.FromValue(new VirtualMachineScaleSetResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new VirtualMachineScaleSetPatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
