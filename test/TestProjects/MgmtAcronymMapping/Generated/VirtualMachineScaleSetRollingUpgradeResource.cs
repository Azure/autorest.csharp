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

namespace MgmtAcronymMapping
{
    /// <summary>
    /// A Class representing a VirtualMachineScaleSetRollingUpgrade along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VirtualMachineScaleSetRollingUpgradeResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVirtualMachineScaleSetRollingUpgradeResource method.
    /// Otherwise you can get one from its parent resource <see cref="VirtualMachineScaleSetResource" /> using the GetVirtualMachineScaleSetRollingUpgrade method.
    /// </summary>
    public partial class VirtualMachineScaleSetRollingUpgradeResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VirtualMachineScaleSetRollingUpgradeResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="vmScaleSetName"> The vmScaleSetName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/rollingUpgrades/latest";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _virtualMachineScaleSetRollingUpgradeClientDiagnostics;
        private readonly VirtualMachineScaleSetRollingUpgradesRestOperations _virtualMachineScaleSetRollingUpgradeRestClient;
        private readonly VirtualMachineScaleSetRollingUpgradeData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachineScaleSets/rollingUpgrades";

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetRollingUpgradeResource"/> class for mocking. </summary>
        protected VirtualMachineScaleSetRollingUpgradeResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSetRollingUpgradeResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal VirtualMachineScaleSetRollingUpgradeResource(ArmClient client, VirtualMachineScaleSetRollingUpgradeData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetRollingUpgradeResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetRollingUpgradeResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineScaleSetRollingUpgradeClientDiagnostics = new ClientDiagnostics("MgmtAcronymMapping", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string virtualMachineScaleSetRollingUpgradeApiVersion);
            _virtualMachineScaleSetRollingUpgradeRestClient = new VirtualMachineScaleSetRollingUpgradesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineScaleSetRollingUpgradeApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual VirtualMachineScaleSetRollingUpgradeData Data
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

        /// <summary>
        /// Gets the status of the latest virtual machine scale set rolling upgrade.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/rollingUpgrades/latest</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetRollingUpgrades_GetLatest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<VirtualMachineScaleSetRollingUpgradeResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetRollingUpgradeClientDiagnostics.CreateScope("VirtualMachineScaleSetRollingUpgradeResource.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRollingUpgradeRestClient.GetLatestAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetRollingUpgradeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the status of the latest virtual machine scale set rolling upgrade.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/rollingUpgrades/latest</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetRollingUpgrades_GetLatest</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VirtualMachineScaleSetRollingUpgradeResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetRollingUpgradeClientDiagnostics.CreateScope("VirtualMachineScaleSetRollingUpgradeResource.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRollingUpgradeRestClient.GetLatest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineScaleSetRollingUpgradeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
