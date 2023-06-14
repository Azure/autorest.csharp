// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a Virtual Machine Scale Set.
    /// Serialized Name: VirtualMachineScaleSetUpdate
    /// </summary>
    public partial class VirtualMachineScaleSetPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetPatch. </summary>
        public VirtualMachineScaleSetPatch()
        {
        }

        /// <summary>
        /// The virtual machine scale set sku.
        /// Serialized Name: VirtualMachineScaleSetUpdate.sku
        /// </summary>
        public SampleSku Sku { get; set; }
        /// <summary>
        /// The purchase plan when deploying a virtual machine scale set from VM Marketplace images.
        /// Serialized Name: VirtualMachineScaleSetUpdate.plan
        /// </summary>
        public SamplePlan Plan { get; set; }
        /// <summary>
        /// The identity of the virtual machine scale set, if configured.
        /// Serialized Name: VirtualMachineScaleSetUpdate.identity
        /// </summary>
        public ManagedServiceIdentity Identity { get; set; }
        /// <summary>
        /// The upgrade policy.
        /// Serialized Name: VirtualMachineScaleSetUpdate.properties.upgradePolicy
        /// </summary>
        public UpgradePolicy UpgradePolicy { get; set; }
        /// <summary>
        /// Policy for automatic repairs.
        /// Serialized Name: VirtualMachineScaleSetUpdate.properties.automaticRepairsPolicy
        /// </summary>
        public AutomaticRepairsPolicy AutomaticRepairsPolicy { get; set; }
        /// <summary>
        /// The virtual machine profile.
        /// Serialized Name: VirtualMachineScaleSetUpdate.properties.virtualMachineProfile
        /// </summary>
        public VirtualMachineScaleSetUpdateVMProfile VirtualMachineProfile { get; set; }
        /// <summary>
        /// Specifies whether the Virtual Machine Scale Set should be overprovisioned.
        /// Serialized Name: VirtualMachineScaleSetUpdate.properties.overprovision
        /// </summary>
        public bool? Overprovision { get; set; }
        /// <summary>
        /// When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMs.
        /// Serialized Name: VirtualMachineScaleSetUpdate.properties.doNotRunExtensionsOnOverprovisionedVMs
        /// </summary>
        public bool? DoNotRunExtensionsOnOverprovisionedVMs { get; set; }
        /// <summary>
        /// When true this limits the scale set to a single placement group, of max size 100 virtual machines. NOTE: If singlePlacementGroup is true, it may be modified to false. However, if singlePlacementGroup is false, it may not be modified to true.
        /// Serialized Name: VirtualMachineScaleSetUpdate.properties.singlePlacementGroup
        /// </summary>
        public bool? SinglePlacementGroup { get; set; }
        /// <summary>
        /// Specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with UltraSSD_LRS storage account type.
        /// Serialized Name: VirtualMachineScaleSetUpdate.properties.additionalCapabilities
        /// </summary>
        internal AdditionalCapabilities AdditionalCapabilities { get; set; }
        /// <summary>
        /// The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS. Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.
        /// Serialized Name: AdditionalCapabilities.ultraSSDEnabled
        /// </summary>
        public bool? UltraSSDEnabled
        {
            get => AdditionalCapabilities is null ? default : AdditionalCapabilities.UltraSSDEnabled;
            set
            {
                if (AdditionalCapabilities is null)
                    AdditionalCapabilities = new AdditionalCapabilities();
                AdditionalCapabilities.UltraSSDEnabled = value;
            }
        }

        /// <summary>
        /// Specifies the scale-in policy that decides which virtual machines are chosen for removal when a Virtual Machine Scale Set is scaled-in.
        /// Serialized Name: VirtualMachineScaleSetUpdate.properties.scaleInPolicy
        /// </summary>
        internal ScaleInPolicy ScaleInPolicy { get; set; }
        /// <summary>
        /// The rules to be followed when scaling-in a virtual machine scale set. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Default** When a virtual machine scale set is scaled in, the scale set will first be balanced across zones if it is a zonal scale set. Then, it will be balanced across Fault Domains as far as possible. Within each Fault Domain, the virtual machines chosen for removal will be the newest ones that are not protected from scale-in. &lt;br&gt;&lt;br&gt; **OldestVM** When a virtual machine scale set is being scaled-in, the oldest virtual machines that are not protected from scale-in will be chosen for removal. For zonal virtual machine scale sets, the scale set will first be balanced across zones. Within each zone, the oldest virtual machines that are not protected will be chosen for removal. &lt;br&gt;&lt;br&gt; **NewestVM** When a virtual machine scale set is being scaled-in, the newest virtual machines that are not protected from scale-in will be chosen for removal. For zonal virtual machine scale sets, the scale set will first be balanced across zones. Within each zone, the newest virtual machines that are not protected will be chosen for removal. &lt;br&gt;&lt;br&gt;
        /// Serialized Name: ScaleInPolicy.rules
        /// </summary>
        public IList<VirtualMachineScaleSetScaleInRule> ScaleInRules
        {
            get
            {
                if (ScaleInPolicy is null)
                    ScaleInPolicy = new ScaleInPolicy();
                return ScaleInPolicy.Rules;
            }
        }

        /// <summary>
        /// Specifies information about the proximity placement group that the virtual machine scale set should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01.
        /// Serialized Name: VirtualMachineScaleSetUpdate.properties.proximityPlacementGroup
        /// </summary>
        internal WritableSubResource ProximityPlacementGroup { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier ProximityPlacementGroupId
        {
            get => ProximityPlacementGroup is null ? default : ProximityPlacementGroup.Id;
            set
            {
                if (ProximityPlacementGroup is null)
                    ProximityPlacementGroup = new WritableSubResource();
                ProximityPlacementGroup.Id = value;
            }
        }
    }
}
