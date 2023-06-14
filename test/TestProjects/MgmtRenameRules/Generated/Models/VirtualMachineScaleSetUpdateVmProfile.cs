// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machine scale set virtual machine profile.
    /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateVmProfile
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateVmProfile. </summary>
        public VirtualMachineScaleSetUpdateVmProfile()
        {
        }

        /// <summary>
        /// The virtual machine scale set OS profile.
        /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile.osProfile
        /// </summary>
        public VirtualMachineScaleSetUpdateOSProfile OSProfile { get; set; }
        /// <summary>
        /// The virtual machine scale set storage profile.
        /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile.storageProfile
        /// </summary>
        public VirtualMachineScaleSetUpdateStorageProfile StorageProfile { get; set; }
        /// <summary>
        /// The virtual machine scale set network profile.
        /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile.networkProfile
        /// </summary>
        public VirtualMachineScaleSetUpdateNetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// The virtual machine scale set Security profile
        /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile.securityProfile
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
        /// The virtual machine scale set diagnostics profile.
        /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile.diagnosticsProfile
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
        /// The virtual machine scale set extension profile.
        /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile.extensionProfile
        /// </summary>
        public VirtualMachineScaleSetExtensionProfile ExtensionProfile { get; set; }
        /// <summary>
        /// The license type, which is for bring your own license scenario.
        /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile.licenseType
        /// </summary>
        public string LicenseType { get; set; }
        /// <summary>
        /// Specifies the billing related details of a Azure Spot VMSS. &lt;br&gt;&lt;br&gt;Minimum api-version: 2019-03-01.
        /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile.billingProfile
        /// </summary>
        internal BillingProfile BillingProfile { get; set; }
        /// <summary>
        /// Specifies the maximum price you are willing to pay for a Azure Spot VM/VMSS. This price is in US Dollars. &lt;br&gt;&lt;br&gt; This price will be compared with the current Azure Spot price for the VM size. Also, the prices are compared at the time of create/update of Azure Spot VM/VMSS and the operation will only succeed if  the maxPrice is greater than the current Azure Spot price. &lt;br&gt;&lt;br&gt; The maxPrice will also be used for evicting a Azure Spot VM/VMSS if the current Azure Spot price goes beyond the maxPrice after creation of VM/VMSS. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; - Any decimal value greater than zero. Example: 0.01538 &lt;br&gt;&lt;br&gt; -1 – indicates default price to be up-to on-demand. &lt;br&gt;&lt;br&gt; You can set the maxPrice to -1 to indicate that the Azure Spot VM/VMSS should not be evicted for price reasons. Also, the default max price is -1 if it is not provided by you. &lt;br&gt;&lt;br&gt;Minimum api-version: 2019-03-01.
        /// Serialized Name: BillingProfile.maxPrice
        /// </summary>
        public double? BillingMaxPrice
        {
            get => BillingProfile is null ? default : BillingProfile.MaxPrice;
            set
            {
                if (BillingProfile is null)
                    BillingProfile = new BillingProfile();
                BillingProfile.MaxPrice = value;
            }
        }

        /// <summary>
        /// Specifies Scheduled Event related configurations.
        /// Serialized Name: VirtualMachineScaleSetUpdateVMProfile.scheduledEventsProfile
        /// </summary>
        internal ScheduledEventsProfile ScheduledEventsProfile { get; set; }
        /// <summary>
        /// Specifies Terminate Scheduled Event related configurations.
        /// Serialized Name: ScheduledEventsProfile.terminateNotificationProfile
        /// </summary>
        public TerminateNotificationProfile ScheduledEventsTerminateNotificationProfile
        {
            get => ScheduledEventsProfile is null ? default : ScheduledEventsProfile.TerminateNotificationProfile;
            set
            {
                if (ScheduledEventsProfile is null)
                    ScheduledEventsProfile = new ScheduledEventsProfile();
                ScheduledEventsProfile.TerminateNotificationProfile = value;
            }
        }
    }
}
