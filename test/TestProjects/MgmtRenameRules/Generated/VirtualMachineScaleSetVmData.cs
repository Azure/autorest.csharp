// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtRenameRules.Models;

namespace MgmtRenameRules
{
    /// <summary>
    /// A class representing the VirtualMachineScaleSetVm data model.
    /// Describes a virtual machine scale set virtual machine.
    /// Serialized Name: VirtualMachineScaleSetVM
    /// </summary>
    public partial class VirtualMachineScaleSetVmData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVmData. </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineScaleSetVmData(AzureLocation location) : base(location)
        {
            Zones = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVmData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="instanceId">
        /// The virtual machine instance ID.
        /// Serialized Name: VirtualMachineScaleSetVM.instanceId
        /// </param>
        /// <param name="sku">
        /// The virtual machine SKU.
        /// Serialized Name: VirtualMachineScaleSetVM.sku
        /// </param>
        /// <param name="plan">
        /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**.
        /// Serialized Name: VirtualMachineScaleSetVM.plan
        /// </param>
        /// <param name="zones">
        /// The virtual machine zones.
        /// Serialized Name: VirtualMachineScaleSetVM.zones
        /// </param>
        /// <param name="latestModelApplied">
        /// Specifies whether the latest model has been applied to the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.latestModelApplied
        /// </param>
        /// <param name="vmId">
        /// Azure VM unique ID.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.vmId
        /// </param>
        /// <param name="instanceView">
        /// The virtual machine instance view.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.instanceView
        /// </param>
        /// <param name="hardwareProfile">
        /// Specifies the hardware settings for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.hardwareProfile
        /// </param>
        /// <param name="storageProfile">
        /// Specifies the storage settings for the virtual machine disks.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.storageProfile
        /// </param>
        /// <param name="additionalCapabilities">
        /// Specifies additional capabilities enabled or disabled on the virtual machine in the scale set. For instance: whether the virtual machine has the capability to support attaching managed data disks with UltraSSD_LRS storage account type.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.additionalCapabilities
        /// </param>
        /// <param name="osProfile">
        /// Specifies the operating system settings for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.osProfile
        /// </param>
        /// <param name="securityProfile">
        /// Specifies the Security related profile settings for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.securityProfile
        /// </param>
        /// <param name="networkProfile">
        /// Specifies the network interfaces of the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.networkProfile
        /// </param>
        /// <param name="networkProfileConfiguration">
        /// Specifies the network profile configuration of the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.networkProfileConfiguration
        /// </param>
        /// <param name="diagnosticsProfile">
        /// Specifies the boot diagnostic settings state. &lt;br&gt;&lt;br&gt;Minimum api-version: 2015-06-15.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.diagnosticsProfile
        /// </param>
        /// <param name="availabilitySet">
        /// Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Manage the availability of virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-manage-availability?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-planned-maintenance?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to availability set at creation time. An existing VM cannot be added to an availability set.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.availabilitySet
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.provisioningState
        /// </param>
        /// <param name="licenseType">
        /// Specifies that the image or disk that is being used was licensed on-premises. This element is only used for images that contain the Windows Server operating system. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; Windows_Client &lt;br&gt;&lt;br&gt; Windows_Server &lt;br&gt;&lt;br&gt; If this element is included in a request for an update, the value must match the initial value. This value cannot be updated. &lt;br&gt;&lt;br&gt; For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-hybrid-use-benefit-licensing?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15
        /// Serialized Name: VirtualMachineScaleSetVM.properties.licenseType
        /// </param>
        /// <param name="modelDefinitionApplied">
        /// Specifies whether the model applied to the virtual machine is the model of the virtual machine scale set or the customized model for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.modelDefinitionApplied
        /// </param>
        /// <param name="protectionPolicy">
        /// Specifies the protection policy of the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.protectionPolicy
        /// </param>
        internal VirtualMachineScaleSetVmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string instanceId, MgmtRenameRulesSku sku, MgmtRenameRulesPlan plan, IReadOnlyList<string> zones, bool? latestModelApplied, string vmId, VirtualMachineScaleSetVmInstanceView instanceView, HardwareProfile hardwareProfile, StorageProfile storageProfile, AdditionalCapabilities additionalCapabilities, OSProfile osProfile, SecurityProfile securityProfile, NetworkProfile networkProfile, VirtualMachineScaleSetVmNetworkProfileConfiguration networkProfileConfiguration, DiagnosticsProfile diagnosticsProfile, WritableSubResource availabilitySet, string provisioningState, string licenseType, string modelDefinitionApplied, VirtualMachineScaleSetVmProtectionPolicy protectionPolicy) : base(id, name, resourceType, systemData, tags, location)
        {
            InstanceId = instanceId;
            Sku = sku;
            Plan = plan;
            Zones = zones;
            LatestModelApplied = latestModelApplied;
            VmId = vmId;
            InstanceView = instanceView;
            HardwareProfile = hardwareProfile;
            StorageProfile = storageProfile;
            AdditionalCapabilities = additionalCapabilities;
            OSProfile = osProfile;
            SecurityProfile = securityProfile;
            NetworkProfile = networkProfile;
            NetworkProfileConfiguration = networkProfileConfiguration;
            DiagnosticsProfile = diagnosticsProfile;
            AvailabilitySet = availabilitySet;
            ProvisioningState = provisioningState;
            LicenseType = licenseType;
            ModelDefinitionApplied = modelDefinitionApplied;
            ProtectionPolicy = protectionPolicy;
        }

        /// <summary>
        /// The virtual machine instance ID.
        /// Serialized Name: VirtualMachineScaleSetVM.instanceId
        /// </summary>
        public string InstanceId { get; }
        /// <summary>
        /// The virtual machine SKU.
        /// Serialized Name: VirtualMachineScaleSetVM.sku
        /// </summary>
        public MgmtRenameRulesSku Sku { get; }
        /// <summary>
        /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**.
        /// Serialized Name: VirtualMachineScaleSetVM.plan
        /// </summary>
        public MgmtRenameRulesPlan Plan { get; set; }
        /// <summary>
        /// The virtual machine zones.
        /// Serialized Name: VirtualMachineScaleSetVM.zones
        /// </summary>
        public IReadOnlyList<string> Zones { get; }
        /// <summary>
        /// Specifies whether the latest model has been applied to the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.latestModelApplied
        /// </summary>
        public bool? LatestModelApplied { get; }
        /// <summary>
        /// Azure VM unique ID.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.vmId
        /// </summary>
        public string VmId { get; }
        /// <summary>
        /// The virtual machine instance view.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.instanceView
        /// </summary>
        public VirtualMachineScaleSetVmInstanceView InstanceView { get; }
        /// <summary>
        /// Specifies the hardware settings for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.hardwareProfile
        /// </summary>
        internal HardwareProfile HardwareProfile { get; set; }
        /// <summary>
        /// Specifies the size of the virtual machine. For more information about virtual machine sizes, see [Sizes for virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-sizes?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; The available VM sizes depend on region and availability set. For a list of available sizes use these APIs:  &lt;br&gt;&lt;br&gt; [List all available virtual machine sizes in an availability set](https://docs.microsoft.com/rest/api/compute/availabilitysets/listavailablesizes) &lt;br&gt;&lt;br&gt; [List all available virtual machine sizes in a region](https://docs.microsoft.com/rest/api/compute/virtualmachinesizes/list) &lt;br&gt;&lt;br&gt; [List all available virtual machine sizes for resizing](https://docs.microsoft.com/rest/api/compute/virtualmachines/listavailablesizes)
        /// Serialized Name: HardwareProfile.vmSize
        /// </summary>
        public VirtualMachineSizeType? HardwareVmSize
        {
            get => HardwareProfile is null ? default : HardwareProfile.VmSize;
            set
            {
                if (HardwareProfile is null)
                    HardwareProfile = new HardwareProfile();
                HardwareProfile.VmSize = value;
            }
        }

        /// <summary>
        /// Specifies the storage settings for the virtual machine disks.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.storageProfile
        /// </summary>
        public StorageProfile StorageProfile { get; set; }
        /// <summary>
        /// Specifies additional capabilities enabled or disabled on the virtual machine in the scale set. For instance: whether the virtual machine has the capability to support attaching managed data disks with UltraSSD_LRS storage account type.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.additionalCapabilities
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
        /// Specifies the operating system settings for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.osProfile
        /// </summary>
        public OSProfile OSProfile { get; set; }
        /// <summary>
        /// Specifies the Security related profile settings for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.securityProfile
        /// </summary>
        internal SecurityProfile SecurityProfile { get; set; }
        /// <summary>
        /// This property can be used by user in the request to enable or disable the Host Encryption for the virtual machine or virtual machine scale set. This will enable the encryption for all the disks including Resource/Temp disk at host itself. &lt;br&gt;&lt;br&gt; Default: The Encryption at host will be disabled unless this property is set to true for the resource.
        /// Serialized Name: SecurityProfile.encryptionAtHost
        /// </summary>
        public bool? EncryptionAtHost
        {
            get => SecurityProfile is null ? default : SecurityProfile.EncryptionAtHost;
            set
            {
                if (SecurityProfile is null)
                    SecurityProfile = new SecurityProfile();
                SecurityProfile.EncryptionAtHost = value;
            }
        }

        /// <summary>
        /// Specifies the network interfaces of the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.networkProfile
        /// </summary>
        internal NetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the virtual machine.
        /// Serialized Name: NetworkProfile.networkInterfaces
        /// </summary>
        public IList<NetworkInterfaceReference> NetworkInterfaces
        {
            get
            {
                if (NetworkProfile is null)
                    NetworkProfile = new NetworkProfile();
                return NetworkProfile.NetworkInterfaces;
            }
        }

        /// <summary>
        /// Specifies the network profile configuration of the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.networkProfileConfiguration
        /// </summary>
        internal VirtualMachineScaleSetVmNetworkProfileConfiguration NetworkProfileConfiguration { get; set; }
        /// <summary>
        /// The list of network configurations.
        /// Serialized Name: VirtualMachineScaleSetVMNetworkProfileConfiguration.networkInterfaceConfigurations
        /// </summary>
        public IList<VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations
        {
            get
            {
                if (NetworkProfileConfiguration is null)
                    NetworkProfileConfiguration = new VirtualMachineScaleSetVmNetworkProfileConfiguration();
                return NetworkProfileConfiguration.NetworkInterfaceConfigurations;
            }
        }

        /// <summary>
        /// Specifies the boot diagnostic settings state. &lt;br&gt;&lt;br&gt;Minimum api-version: 2015-06-15.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.diagnosticsProfile
        /// </summary>
        internal DiagnosticsProfile DiagnosticsProfile { get; set; }
        /// <summary>
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// Serialized Name: DiagnosticsProfile.bootDiagnostics
        /// </summary>
        public BootDiagnostics BootDiagnostics
        {
            get => DiagnosticsProfile is null ? default : DiagnosticsProfile.BootDiagnostics;
            set
            {
                if (DiagnosticsProfile is null)
                    DiagnosticsProfile = new DiagnosticsProfile();
                DiagnosticsProfile.BootDiagnostics = value;
            }
        }

        /// <summary>
        /// Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Manage the availability of virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-manage-availability?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-planned-maintenance?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to availability set at creation time. An existing VM cannot be added to an availability set.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.availabilitySet
        /// </summary>
        internal WritableSubResource AvailabilitySet { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier AvailabilitySetId
        {
            get => AvailabilitySet is null ? default : AvailabilitySet.Id;
            set
            {
                if (AvailabilitySet is null)
                    AvailabilitySet = new WritableSubResource();
                AvailabilitySet.Id = value;
            }
        }

        /// <summary>
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.provisioningState
        /// </summary>
        public string ProvisioningState { get; }
        /// <summary>
        /// Specifies that the image or disk that is being used was licensed on-premises. This element is only used for images that contain the Windows Server operating system. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; Windows_Client &lt;br&gt;&lt;br&gt; Windows_Server &lt;br&gt;&lt;br&gt; If this element is included in a request for an update, the value must match the initial value. This value cannot be updated. &lt;br&gt;&lt;br&gt; For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-hybrid-use-benefit-licensing?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15
        /// Serialized Name: VirtualMachineScaleSetVM.properties.licenseType
        /// </summary>
        public string LicenseType { get; set; }
        /// <summary>
        /// Specifies whether the model applied to the virtual machine is the model of the virtual machine scale set or the customized model for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.modelDefinitionApplied
        /// </summary>
        public string ModelDefinitionApplied { get; }
        /// <summary>
        /// Specifies the protection policy of the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.protectionPolicy
        /// </summary>
        public VirtualMachineScaleSetVmProtectionPolicy ProtectionPolicy { get; set; }
    }
}
