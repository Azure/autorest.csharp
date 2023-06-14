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
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A Class representing a VirtualMachineScaleSetVM along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VirtualMachineScaleSetVMResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVirtualMachineScaleSetVMResource method.
    /// Otherwise you can get one from its parent resource <see cref="VirtualMachineScaleSetResource" /> using the GetVirtualMachineScaleSetVM method.
    /// </summary>
    public partial class VirtualMachineScaleSetVMResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VirtualMachineScaleSetVMResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName, string instanceId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _virtualMachineScaleSetVMClientDiagnostics;
        private readonly VirtualMachineScaleSetVMsRestOperations _virtualMachineScaleSetVMRestClient;
        private readonly VirtualMachineScaleSetVMData _data;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVMResource"/> class for mocking. </summary>
        protected VirtualMachineScaleSetVMResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSetVMResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal VirtualMachineScaleSetVMResource(ArmClient client, VirtualMachineScaleSetVMData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVMResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetVMResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineScaleSetVMClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sample", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string virtualMachineScaleSetVMApiVersion);
            _virtualMachineScaleSetVMRestClient = new VirtualMachineScaleSetVMsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineScaleSetVMApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachineScaleSets/virtualmachines";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual VirtualMachineScaleSetVMData Data
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

        /// <summary> Gets a collection of VirtualMachineScaleSetVirtualMachineExtensionResources in the VirtualMachineScaleSetVM. </summary>
        /// <returns> An object representing collection of VirtualMachineScaleSetVirtualMachineExtensionResources and their operations over a VirtualMachineScaleSetVirtualMachineExtensionResource. </returns>
        public virtual VirtualMachineScaleSetVirtualMachineExtensionCollection GetVirtualMachineScaleSetVirtualMachineExtensions()
        {
            return GetCachedClient(Client => new VirtualMachineScaleSetVirtualMachineExtensionCollection(Client, Id));
        }

        /// <summary>
        /// The operation to get the VMSS VM extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<VirtualMachineScaleSetVirtualMachineExtensionResource>> GetVirtualMachineScaleSetVirtualMachineExtensionAsync(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await GetVirtualMachineScaleSetVirtualMachineExtensions().GetAsync(vmExtensionName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The operation to get the VMSS VM extension.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMExtensions_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmExtensionName"> The name of the virtual machine extension. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vmExtensionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vmExtensionName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<VirtualMachineScaleSetVirtualMachineExtensionResource> GetVirtualMachineScaleSetVirtualMachineExtension(string vmExtensionName, string expand = null, CancellationToken cancellationToken = default)
        {
            return GetVirtualMachineScaleSetVirtualMachineExtensions().Get(vmExtensionName, expand, cancellationToken);
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
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<VirtualMachineScaleSetVMResource>> GetAsync(InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken).ConfigureAwait(false);
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
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VirtualMachineScaleSetVMResource> Get(InstanceViewType? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, cancellationToken);
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
        /// Deletes a virtual machine from a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Delete");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Deletes a virtual machine from a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Delete");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Updates a virtual machine of a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVMResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVMData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Update");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation<VirtualMachineScaleSetVMResource>(new VirtualMachineScaleSetVMOperationSource(Client), _virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.Location);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<VirtualMachineScaleSetVMResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetVMData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Update");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken);
                var operation = new SampleArmOperation<VirtualMachineScaleSetVMResource>(new VirtualMachineScaleSetVMOperationSource(Client), _virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data).Request, response, OperationFinalStateVia.Location);
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
        /// Reimages (upgrade the operating system) a specific virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/reimage</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Reimage</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Parameters for the Reimaging Virtual machine in ScaleSet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> ReimageAsync(WaitUntil waitUntil, VirtualMachineScaleSetVMReimageContent content = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Reimage");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.ReimageAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateReimageRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content).Request, response, OperationFinalStateVia.Location);
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
        /// Reimages (upgrade the operating system) a specific virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/reimage</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Reimage</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Parameters for the Reimaging Virtual machine in ScaleSet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Reimage(WaitUntil waitUntil, VirtualMachineScaleSetVMReimageContent content = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Reimage");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Reimage(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, cancellationToken);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateReimageRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content).Request, response, OperationFinalStateVia.Location);
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
        /// Allows you to re-image all the disks ( including data disks ) in the a VM scale set instance. This operation is only supported for managed disks.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/reimageall</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_ReimageAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> ReimageAllAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.ReimageAll");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.ReimageAllAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateReimageAllRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Allows you to re-image all the disks ( including data disks ) in the a VM scale set instance. This operation is only supported for managed disks.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/reimageall</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_ReimageAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation ReimageAll(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.ReimageAll");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.ReimageAll(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateReimageAllRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Deallocates a specific virtual machine in a VM scale set. Shuts down the virtual machine and releases the compute resources it uses. You are not billed for the compute resources of this virtual machine once it is deallocated.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/deallocate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Deallocate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeallocateAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Deallocate");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.DeallocateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateDeallocateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Deallocates a specific virtual machine in a VM scale set. Shuts down the virtual machine and releases the compute resources it uses. You are not billed for the compute resources of this virtual machine once it is deallocated.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/deallocate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Deallocate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Deallocate(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Deallocate");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Deallocate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateDeallocateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the status of a virtual machine from a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/instanceView</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_GetInstanceView</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<VirtualMachineScaleSetVMInstanceView>> GetInstanceViewAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.GetInstanceView");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.GetInstanceViewAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the status of a virtual machine from a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/instanceView</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_GetInstanceView</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VirtualMachineScaleSetVMInstanceView> GetInstanceView(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.GetInstanceView");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.GetInstanceView(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Power off (stop) a virtual machine in a VM scale set. Note that resources are still attached and you are getting charged for the resources. Instead, use deallocate to release resources and avoid charges.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/poweroff</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_PowerOff</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="skipShutdown"> The parameter to request non-graceful VM shutdown. True value for this flag indicates non-graceful shutdown whereas false indicates otherwise. Default value for this flag is false if not specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> PowerOffAsync(WaitUntil waitUntil, bool? skipShutdown = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.PowerOff");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.PowerOffAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipShutdown, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreatePowerOffRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipShutdown).Request, response, OperationFinalStateVia.Location);
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
        /// Power off (stop) a virtual machine in a VM scale set. Note that resources are still attached and you are getting charged for the resources. Instead, use deallocate to release resources and avoid charges.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/poweroff</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_PowerOff</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="skipShutdown"> The parameter to request non-graceful VM shutdown. True value for this flag indicates non-graceful shutdown whereas false indicates otherwise. Default value for this flag is false if not specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation PowerOff(WaitUntil waitUntil, bool? skipShutdown = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.PowerOff");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.PowerOff(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipShutdown, cancellationToken);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreatePowerOffRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipShutdown).Request, response, OperationFinalStateVia.Location);
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
        /// Restarts a virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/restart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Restart</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> RestartAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Restart");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.RestartAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateRestartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Restarts a virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/restart</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Restart</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Restart(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Restart");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Restart(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateRestartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Starts a virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/start</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Start</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> StartAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Start");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.StartAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateStartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Starts a virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/start</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Start</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Start(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Start");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Start(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateStartRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Shuts down the virtual machine in the virtual machine scale set, moves it to a new node, and powers it back on.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/redeploy</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Redeploy</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> RedeployAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Redeploy");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.RedeployAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateRedeployRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Shuts down the virtual machine in the virtual machine scale set, moves it to a new node, and powers it back on.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/redeploy</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Redeploy</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Redeploy(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.Redeploy");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.Redeploy(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreateRedeployRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to retrieve SAS URIs of boot diagnostic logs for a virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/retrieveBootDiagnosticsData</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_RetrieveBootDiagnosticsData</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="sasUriExpirationTimeInMinutes"> Expiration duration in minutes for the SAS URIs with a value between 1 to 1440 minutes. &lt;br&gt;&lt;br&gt;NOTE: If not specified, SAS URIs will be generated with a default expiration duration of 120 minutes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RetrieveBootDiagnosticsDataResult>> RetrieveBootDiagnosticsDataAsync(int? sasUriExpirationTimeInMinutes = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.RetrieveBootDiagnosticsData");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.RetrieveBootDiagnosticsDataAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, sasUriExpirationTimeInMinutes, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to retrieve SAS URIs of boot diagnostic logs for a virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/retrieveBootDiagnosticsData</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_RetrieveBootDiagnosticsData</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="sasUriExpirationTimeInMinutes"> Expiration duration in minutes for the SAS URIs with a value between 1 to 1440 minutes. &lt;br&gt;&lt;br&gt;NOTE: If not specified, SAS URIs will be generated with a default expiration duration of 120 minutes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RetrieveBootDiagnosticsDataResult> RetrieveBootDiagnosticsData(int? sasUriExpirationTimeInMinutes = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.RetrieveBootDiagnosticsData");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.RetrieveBootDiagnosticsData(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, sasUriExpirationTimeInMinutes, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Performs maintenance on a virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/performMaintenance</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_PerformMaintenance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> PerformMaintenanceAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.PerformMaintenance");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.PerformMaintenanceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreatePerformMaintenanceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Performs maintenance on a virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}/performMaintenance</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_PerformMaintenance</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation PerformMaintenance(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.PerformMaintenance");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.PerformMaintenance(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SampleArmOperation(_virtualMachineScaleSetVMClientDiagnostics, Pipeline, _virtualMachineScaleSetVMRestClient.CreatePerformMaintenanceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// The operation to simulate the eviction of spot virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/simulateEviction</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_SimulateEviction</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SimulateEvictionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.SimulateEviction");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVMRestClient.SimulateEvictionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to simulate the eviction of spot virtual machine in a VM scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/simulateEviction</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_SimulateEviction</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SimulateEviction(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.SimulateEviction");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVMRestClient.SimulateEviction(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineScaleSetVMResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _virtualMachineScaleSetVMRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new VirtualMachineScaleSetVMResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags[key] = value;
                    var result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVMResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _virtualMachineScaleSetVMRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, cancellationToken);
                    return Response.FromValue(new VirtualMachineScaleSetVMResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags[key] = value;
                    var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineScaleSetVMResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _virtualMachineScaleSetVMRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new VirtualMachineScaleSetVMResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVMResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _virtualMachineScaleSetVMRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, cancellationToken);
                    return Response.FromValue(new VirtualMachineScaleSetVMResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineScaleSetVMResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _virtualMachineScaleSetVMRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new VirtualMachineScaleSetVMResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.Remove(key);
                    var result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualmachines/{instanceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<VirtualMachineScaleSetVMResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _virtualMachineScaleSetVMClientDiagnostics.CreateScope("VirtualMachineScaleSetVMResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _virtualMachineScaleSetVMRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, null, cancellationToken);
                    return Response.FromValue(new VirtualMachineScaleSetVMResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.Remove(key);
                    var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
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
