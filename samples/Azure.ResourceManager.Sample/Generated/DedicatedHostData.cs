// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the DedicatedHost data model. </summary>
    public partial class DedicatedHostData : TrackedResource
    {
        /// <summary> Initializes a new instance of DedicatedHostData. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> SKU of the dedicated host for Hardware Generation and VM family. Only name is required to be set. List Microsoft.Compute SKUs for a list of possible values. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public DedicatedHostData(Location location, Models.Sku sku) : base(location)
        {
            if (sku == null)
            {
                throw new ArgumentNullException(nameof(sku));
            }

            Sku = sku;
            VirtualMachines = new ChangeTrackingList<SubResourceReadOnly>();
        }

        /// <summary> Initializes a new instance of DedicatedHostData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> SKU of the dedicated host for Hardware Generation and VM family. Only name is required to be set. List Microsoft.Compute SKUs for a list of possible values. </param>
        /// <param name="platformFaultDomain"> Fault domain of the dedicated host within a dedicated host group. </param>
        /// <param name="autoReplaceOnFailure"> Specifies whether the dedicated host should be replaced automatically in case of a failure. The value is defaulted to &apos;true&apos; when not provided. </param>
        /// <param name="hostId"> A unique id generated and assigned to the dedicated host by the platform. &lt;br&gt;&lt;br&gt; Does not change throughout the lifetime of the host. </param>
        /// <param name="virtualMachines"> A list of references to all virtual machines in the Dedicated Host. </param>
        /// <param name="licenseType"> Specifies the software license type that will be applied to the VMs deployed on the dedicated host. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **Windows_Server_Hybrid** &lt;br&gt;&lt;br&gt; **Windows_Server_Perpetual** &lt;br&gt;&lt;br&gt; Default: **None**. </param>
        /// <param name="provisioningTime"> The date when the host was first provisioned. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="instanceView"> The dedicated host instance view. </param>
        internal DedicatedHostData(ResourceIdentifier id, string name, ResourceType type, IDictionary<string, string> tags, Location location, Models.Sku sku, int? platformFaultDomain, bool? autoReplaceOnFailure, string hostId, IReadOnlyList<SubResourceReadOnly> virtualMachines, DedicatedHostLicenseTypes? licenseType, DateTimeOffset? provisioningTime, string provisioningState, DedicatedHostInstanceView instanceView) : base(id, name, type, tags, location)
        {
            Sku = sku;
            PlatformFaultDomain = platformFaultDomain;
            AutoReplaceOnFailure = autoReplaceOnFailure;
            HostId = hostId;
            VirtualMachines = virtualMachines;
            LicenseType = licenseType;
            ProvisioningTime = provisioningTime;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
        }

        /// <summary> SKU of the dedicated host for Hardware Generation and VM family. Only name is required to be set. List Microsoft.Compute SKUs for a list of possible values. </summary>
        public Models.Sku Sku { get; set; }
        /// <summary> Fault domain of the dedicated host within a dedicated host group. </summary>
        public int? PlatformFaultDomain { get; set; }
        /// <summary> Specifies whether the dedicated host should be replaced automatically in case of a failure. The value is defaulted to &apos;true&apos; when not provided. </summary>
        public bool? AutoReplaceOnFailure { get; set; }
        /// <summary> A unique id generated and assigned to the dedicated host by the platform. &lt;br&gt;&lt;br&gt; Does not change throughout the lifetime of the host. </summary>
        public string HostId { get; }
        /// <summary> A list of references to all virtual machines in the Dedicated Host. </summary>
        public IReadOnlyList<SubResourceReadOnly> VirtualMachines { get; }
        /// <summary> Specifies the software license type that will be applied to the VMs deployed on the dedicated host. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **Windows_Server_Hybrid** &lt;br&gt;&lt;br&gt; **Windows_Server_Perpetual** &lt;br&gt;&lt;br&gt; Default: **None**. </summary>
        public DedicatedHostLicenseTypes? LicenseType { get; set; }
        /// <summary> The date when the host was first provisioned. </summary>
        public DateTimeOffset? ProvisioningTime { get; }
        /// <summary> The provisioning state, which only appears in the response. </summary>
        public string ProvisioningState { get; }
        /// <summary> The dedicated host instance view. </summary>
        public DedicatedHostInstanceView InstanceView { get; }
    }
}
