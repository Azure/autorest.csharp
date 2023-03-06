// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtRenameRules.Models;

namespace MgmtRenameRules
{
    /// <summary>
    /// A class representing the VirtualMachineScaleSet data model.
    /// Describes a Virtual Machine Scale Set.
    /// Serialized Name: VirtualMachineScaleSet
    /// </summary>
    public partial class VirtualMachineScaleSetData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetData. </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineScaleSetData(AzureLocation location) : base(location)
        {
            Zones = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku">
        /// The virtual machine scale set sku.
        /// Serialized Name: VirtualMachineScaleSet.sku
        /// </param>
        /// <param name="plan">
        /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**.
        /// Serialized Name: VirtualMachineScaleSet.plan
        /// </param>
        /// <param name="identity">
        /// The identity of the virtual machine scale set, if configured.
        /// Serialized Name: VirtualMachineScaleSet.identity
        /// </param>
        /// <param name="zones">
        /// The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set
        /// Serialized Name: VirtualMachineScaleSet.zones
        /// </param>
        /// <param name="ipsecSomething">
        /// The IPsec
        /// Serialized Name: VirtualMachineScaleSet.properties.ipsecSomething
        /// </param>
        /// <param name="testIPsec">
        /// The IPsec
        /// Serialized Name: VirtualMachineScaleSet.properties.testIPSec
        /// </param>
        /// <param name="p2sServer">
        /// The P2S Server
        /// Serialized Name: VirtualMachineScaleSet.properties.p2sServer
        /// </param>
        /// <param name="upgradePolicy">
        /// The upgrade policy.
        /// Serialized Name: VirtualMachineScaleSet.properties.upgradePolicy
        /// </param>
        /// <param name="automaticRepairsPolicy">
        /// Policy for automatic repairs.
        /// Serialized Name: VirtualMachineScaleSet.properties.automaticRepairsPolicy
        /// </param>
        /// <param name="virtualMachineProfile">
        /// The virtual machine profile.
        /// Serialized Name: VirtualMachineScaleSet.properties.virtualMachineProfile
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSet.properties.provisioningState
        /// </param>
        /// <param name="overprovision">
        /// Specifies whether the Virtual Machine Scale Set should be overprovisioned.
        /// Serialized Name: VirtualMachineScaleSet.properties.overprovision
        /// </param>
        /// <param name="doNotRunExtensionsOnOverprovisionedVms">
        /// When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMs.
        /// Serialized Name: VirtualMachineScaleSet.properties.doNotRunExtensionsOnOverprovisionedVMs
        /// </param>
        /// <param name="uniqueId">
        /// Specifies the ID which uniquely identifies a Virtual Machine Scale Set.
        /// Serialized Name: VirtualMachineScaleSet.properties.uniqueId
        /// </param>
        /// <param name="singlePlacementGroup">
        /// When true this limits the scale set to a single placement group, of max size 100 virtual machines. NOTE: If singlePlacementGroup is true, it may be modified to false. However, if singlePlacementGroup is false, it may not be modified to true.
        /// Serialized Name: VirtualMachineScaleSet.properties.singlePlacementGroup
        /// </param>
        /// <param name="zoneBalance">
        /// Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage.
        /// Serialized Name: VirtualMachineScaleSet.properties.zoneBalance
        /// </param>
        /// <param name="platformFaultDomainCount">
        /// Fault Domain count for each placement group.
        /// Serialized Name: VirtualMachineScaleSet.properties.platformFaultDomainCount
        /// </param>
        /// <param name="proximityPlacementGroup">
        /// Specifies information about the proximity placement group that the virtual machine scale set should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01.
        /// Serialized Name: VirtualMachineScaleSet.properties.proximityPlacementGroup
        /// </param>
        /// <param name="hostGroup">
        /// Specifies information about the dedicated host group that the virtual machine scale set resides in. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: VirtualMachineScaleSet.properties.hostGroup
        /// </param>
        /// <param name="additionalCapabilities">
        /// Specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with UltraSSD_LRS storage account type.
        /// Serialized Name: VirtualMachineScaleSet.properties.additionalCapabilities
        /// </param>
        /// <param name="scaleInPolicy">
        /// Specifies the scale-in policy that decides which virtual machines are chosen for removal when a Virtual Machine Scale Set is scaled-in.
        /// Serialized Name: VirtualMachineScaleSet.properties.scaleInPolicy
        /// </param>
        internal VirtualMachineScaleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, MgmtRenameRulesSku sku, MgmtRenameRulesPlan plan, ManagedServiceIdentity identity, IList<string> zones, string ipsecSomething, string testIPsec, string p2sServer, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetVmProfile virtualMachineProfile, string provisioningState, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVms, string uniqueId, bool? singlePlacementGroup, bool? zoneBalance, int? platformFaultDomainCount, WritableSubResource proximityPlacementGroup, WritableSubResource hostGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy) : base(id, name, resourceType, systemData, tags, location)
        {
            Sku = sku;
            Plan = plan;
            Identity = identity;
            Zones = zones;
            IPsecSomething = ipsecSomething;
            TestIPsec = testIPsec;
            P2SServer = p2sServer;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            ProvisioningState = provisioningState;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVms = doNotRunExtensionsOnOverprovisionedVms;
            UniqueId = uniqueId;
            SinglePlacementGroup = singlePlacementGroup;
            ZoneBalance = zoneBalance;
            PlatformFaultDomainCount = platformFaultDomainCount;
            ProximityPlacementGroup = proximityPlacementGroup;
            HostGroup = hostGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
        }

        /// <summary>
        /// The virtual machine scale set sku.
        /// Serialized Name: VirtualMachineScaleSet.sku
        /// </summary>
        public MgmtRenameRulesSku Sku { get; set; }
        /// <summary>
        /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**.
        /// Serialized Name: VirtualMachineScaleSet.plan
        /// </summary>
        public MgmtRenameRulesPlan Plan { get; set; }
        /// <summary>
        /// The identity of the virtual machine scale set, if configured.
        /// Serialized Name: VirtualMachineScaleSet.identity
        /// </summary>
        public ManagedServiceIdentity Identity { get; set; }
        /// <summary>
        /// The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set
        /// Serialized Name: VirtualMachineScaleSet.zones
        /// </summary>
        public IList<string> Zones { get; }
        /// <summary>
        /// The IPsec
        /// Serialized Name: VirtualMachineScaleSet.properties.ipsecSomething
        /// </summary>
        public string IPsecSomething { get; set; }
        /// <summary>
        /// The IPsec
        /// Serialized Name: VirtualMachineScaleSet.properties.testIPSec
        /// </summary>
        public string TestIPsec { get; set; }
        /// <summary>
        /// The P2S Server
        /// Serialized Name: VirtualMachineScaleSet.properties.p2sServer
        /// </summary>
        public string P2SServer { get; set; }
        /// <summary>
        /// The upgrade policy.
        /// Serialized Name: VirtualMachineScaleSet.properties.upgradePolicy
        /// </summary>
        public UpgradePolicy UpgradePolicy { get; set; }
        /// <summary>
        /// Policy for automatic repairs.
        /// Serialized Name: VirtualMachineScaleSet.properties.automaticRepairsPolicy
        /// </summary>
        public AutomaticRepairsPolicy AutomaticRepairsPolicy { get; set; }
        /// <summary>
        /// The virtual machine profile.
        /// Serialized Name: VirtualMachineScaleSet.properties.virtualMachineProfile
        /// </summary>
        public VirtualMachineScaleSetVmProfile VirtualMachineProfile { get; set; }
        /// <summary>
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSet.properties.provisioningState
        /// </summary>
        public string ProvisioningState { get; }
        /// <summary>
        /// Specifies whether the Virtual Machine Scale Set should be overprovisioned.
        /// Serialized Name: VirtualMachineScaleSet.properties.overprovision
        /// </summary>
        public bool? Overprovision { get; set; }
        /// <summary>
        /// When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMs.
        /// Serialized Name: VirtualMachineScaleSet.properties.doNotRunExtensionsOnOverprovisionedVMs
        /// </summary>
        public bool? DoNotRunExtensionsOnOverprovisionedVms { get; set; }
        /// <summary>
        /// Specifies the ID which uniquely identifies a Virtual Machine Scale Set.
        /// Serialized Name: VirtualMachineScaleSet.properties.uniqueId
        /// </summary>
        public string UniqueId { get; }
        /// <summary>
        /// When true this limits the scale set to a single placement group, of max size 100 virtual machines. NOTE: If singlePlacementGroup is true, it may be modified to false. However, if singlePlacementGroup is false, it may not be modified to true.
        /// Serialized Name: VirtualMachineScaleSet.properties.singlePlacementGroup
        /// </summary>
        public bool? SinglePlacementGroup { get; set; }
        /// <summary>
        /// Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage.
        /// Serialized Name: VirtualMachineScaleSet.properties.zoneBalance
        /// </summary>
        public bool? ZoneBalance { get; set; }
        /// <summary>
        /// Fault Domain count for each placement group.
        /// Serialized Name: VirtualMachineScaleSet.properties.platformFaultDomainCount
        /// </summary>
        public int? PlatformFaultDomainCount { get; set; }
        /// <summary>
        /// Specifies information about the proximity placement group that the virtual machine scale set should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01.
        /// Serialized Name: VirtualMachineScaleSet.properties.proximityPlacementGroup
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

        /// <summary>
        /// Specifies information about the dedicated host group that the virtual machine scale set resides in. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: VirtualMachineScaleSet.properties.hostGroup
        /// </summary>
        internal WritableSubResource HostGroup { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier HostGroupId
        {
            get => HostGroup is null ? default : HostGroup.Id;
            set
            {
                if (HostGroup is null)
                    HostGroup = new WritableSubResource();
                HostGroup.Id = value;
            }
        }

        /// <summary>
        /// Specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with UltraSSD_LRS storage account type.
        /// Serialized Name: VirtualMachineScaleSet.properties.additionalCapabilities
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
        /// Serialized Name: VirtualMachineScaleSet.properties.scaleInPolicy
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
    }
}
