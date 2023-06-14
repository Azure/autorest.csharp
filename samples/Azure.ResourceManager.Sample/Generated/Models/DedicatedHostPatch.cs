// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies information about the dedicated host. Only tags, autoReplaceOnFailure and licenseType may be updated.
    /// Serialized Name: DedicatedHostUpdate
    /// </summary>
    public partial class DedicatedHostPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of DedicatedHostPatch. </summary>
        public DedicatedHostPatch()
        {
            VirtualMachines = new ChangeTrackingList<Resources.Models.SubResource>();
        }

        /// <summary>
        /// Fault domain of the dedicated host within a dedicated host group.
        /// Serialized Name: DedicatedHostUpdate.properties.platformFaultDomain
        /// </summary>
        public int? PlatformFaultDomain { get; set; }
        /// <summary>
        /// Specifies whether the dedicated host should be replaced automatically in case of a failure. The value is defaulted to 'true' when not provided.
        /// Serialized Name: DedicatedHostUpdate.properties.autoReplaceOnFailure
        /// </summary>
        public bool? AutoReplaceOnFailure { get; set; }
        /// <summary>
        /// A unique id generated and assigned to the dedicated host by the platform. &lt;br&gt;&lt;br&gt; Does not change throughout the lifetime of the host.
        /// Serialized Name: DedicatedHostUpdate.properties.hostId
        /// </summary>
        public string HostId { get; }
        /// <summary>
        /// A list of references to all virtual machines in the Dedicated Host.
        /// Serialized Name: DedicatedHostUpdate.properties.virtualMachines
        /// </summary>
        public IReadOnlyList<Resources.Models.SubResource> VirtualMachines { get; }
        /// <summary>
        /// Specifies the software license type that will be applied to the VMs deployed on the dedicated host. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **Windows_Server_Hybrid** &lt;br&gt;&lt;br&gt; **Windows_Server_Perpetual** &lt;br&gt;&lt;br&gt; Default: **None**
        /// Serialized Name: DedicatedHostUpdate.properties.licenseType
        /// </summary>
        public DedicatedHostLicenseType? LicenseType { get; set; }
        /// <summary>
        /// The date when the host was first provisioned.
        /// Serialized Name: DedicatedHostUpdate.properties.provisioningTime
        /// </summary>
        public DateTimeOffset? ProvisioningOn { get; }
        /// <summary>
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: DedicatedHostUpdate.properties.provisioningState
        /// </summary>
        public string ProvisioningState { get; }
        /// <summary>
        /// The dedicated host instance view.
        /// Serialized Name: DedicatedHostUpdate.properties.instanceView
        /// </summary>
        public DedicatedHostInstanceView InstanceView { get; }
    }
}
