// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A class representing the DedicatedHost data model.
    /// Specifies information about the Dedicated host.
    /// Serialized Name: DedicatedHost
    /// </summary>
    public partial class DedicatedHostData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of DedicatedHostData. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="sku">
        /// SKU of the dedicated host for Hardware Generation and VM family. Only name is required to be set. List Microsoft.Compute SKUs for a list of possible values.
        /// Serialized Name: DedicatedHost.sku
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public DedicatedHostData(AzureLocation location, SampleSku sku) : base(location)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            Sku = sku;
            VirtualMachines = new ChangeTrackingList<Resources.Models.SubResource>();
        }

        /// <summary> Initializes a new instance of DedicatedHostData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku">
        /// SKU of the dedicated host for Hardware Generation and VM family. Only name is required to be set. List Microsoft.Compute SKUs for a list of possible values.
        /// Serialized Name: DedicatedHost.sku
        /// </param>
        /// <param name="platformFaultDomain">
        /// Fault domain of the dedicated host within a dedicated host group.
        /// Serialized Name: DedicatedHost.properties.platformFaultDomain
        /// </param>
        /// <param name="autoReplaceOnFailure">
        /// Specifies whether the dedicated host should be replaced automatically in case of a failure. The value is defaulted to 'true' when not provided.
        /// Serialized Name: DedicatedHost.properties.autoReplaceOnFailure
        /// </param>
        /// <param name="hostId">
        /// A unique id generated and assigned to the dedicated host by the platform. &lt;br&gt;&lt;br&gt; Does not change throughout the lifetime of the host.
        /// Serialized Name: DedicatedHost.properties.hostId
        /// </param>
        /// <param name="virtualMachines">
        /// A list of references to all virtual machines in the Dedicated Host.
        /// Serialized Name: DedicatedHost.properties.virtualMachines
        /// </param>
        /// <param name="licenseType">
        /// Specifies the software license type that will be applied to the VMs deployed on the dedicated host. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **Windows_Server_Hybrid** &lt;br&gt;&lt;br&gt; **Windows_Server_Perpetual** &lt;br&gt;&lt;br&gt; Default: **None**
        /// Serialized Name: DedicatedHost.properties.licenseType
        /// </param>
        /// <param name="provisioningOn">
        /// The date when the host was first provisioned.
        /// Serialized Name: DedicatedHost.properties.provisioningTime
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: DedicatedHost.properties.provisioningState
        /// </param>
        /// <param name="instanceView">
        /// The dedicated host instance view.
        /// Serialized Name: DedicatedHost.properties.instanceView
        /// </param>
        internal DedicatedHostData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SampleSku sku, int? platformFaultDomain, bool? autoReplaceOnFailure, string hostId, IReadOnlyList<Resources.Models.SubResource> virtualMachines, DedicatedHostLicenseType? licenseType, DateTimeOffset? provisioningOn, string provisioningState, DedicatedHostInstanceView instanceView) : base(id, name, resourceType, systemData, tags, location)
        {
            Sku = sku;
            PlatformFaultDomain = platformFaultDomain;
            AutoReplaceOnFailure = autoReplaceOnFailure;
            HostId = hostId;
            VirtualMachines = virtualMachines;
            LicenseType = licenseType;
            ProvisioningOn = provisioningOn;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
        }

        /// <summary>
        /// SKU of the dedicated host for Hardware Generation and VM family. Only name is required to be set. List Microsoft.Compute SKUs for a list of possible values.
        /// Serialized Name: DedicatedHost.sku
        /// </summary>
        public SampleSku Sku { get; set; }
        /// <summary>
        /// Fault domain of the dedicated host within a dedicated host group.
        /// Serialized Name: DedicatedHost.properties.platformFaultDomain
        /// </summary>
        public int? PlatformFaultDomain { get; set; }
        /// <summary>
        /// Specifies whether the dedicated host should be replaced automatically in case of a failure. The value is defaulted to 'true' when not provided.
        /// Serialized Name: DedicatedHost.properties.autoReplaceOnFailure
        /// </summary>
        public bool? AutoReplaceOnFailure { get; set; }
        /// <summary>
        /// A unique id generated and assigned to the dedicated host by the platform. &lt;br&gt;&lt;br&gt; Does not change throughout the lifetime of the host.
        /// Serialized Name: DedicatedHost.properties.hostId
        /// </summary>
        public string HostId { get; }
        /// <summary>
        /// A list of references to all virtual machines in the Dedicated Host.
        /// Serialized Name: DedicatedHost.properties.virtualMachines
        /// </summary>
        public IReadOnlyList<Resources.Models.SubResource> VirtualMachines { get; }
        /// <summary>
        /// Specifies the software license type that will be applied to the VMs deployed on the dedicated host. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **Windows_Server_Hybrid** &lt;br&gt;&lt;br&gt; **Windows_Server_Perpetual** &lt;br&gt;&lt;br&gt; Default: **None**
        /// Serialized Name: DedicatedHost.properties.licenseType
        /// </summary>
        public DedicatedHostLicenseType? LicenseType { get; set; }
        /// <summary>
        /// The date when the host was first provisioned.
        /// Serialized Name: DedicatedHost.properties.provisioningTime
        /// </summary>
        public DateTimeOffset? ProvisioningOn { get; }
        /// <summary>
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: DedicatedHost.properties.provisioningState
        /// </summary>
        public string ProvisioningState { get; }
        /// <summary>
        /// The dedicated host instance view.
        /// Serialized Name: DedicatedHost.properties.instanceView
        /// </summary>
        public DedicatedHostInstanceView InstanceView { get; }
    }
}
