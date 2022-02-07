// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary> Describes a virtual machine scale set virtual machine profile. </summary>
    public partial class VirtualMachineScaleSetUpdateVmProfile
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateVmProfile. </summary>
        public VirtualMachineScaleSetUpdateVmProfile()
        {
        }

        /// <summary> The virtual machine scale set OS profile. </summary>
        public VirtualMachineScaleSetUpdateOSProfile OSProfile { get; set; }
        /// <summary> The virtual machine scale set storage profile. </summary>
        public VirtualMachineScaleSetUpdateStorageProfile StorageProfile { get; set; }
        /// <summary> The virtual machine scale set network profile. </summary>
        public VirtualMachineScaleSetUpdateNetworkProfile NetworkProfile { get; set; }
        /// <summary> The virtual machine scale set Security profile. </summary>
        public SecurityProfile SecurityProfile { get; set; }
        /// <summary> The virtual machine scale set diagnostics profile. </summary>
        public DiagnosticsProfile DiagnosticsProfile { get; set; }
        /// <summary> The virtual machine scale set extension profile. </summary>
        public VirtualMachineScaleSetExtensionProfile ExtensionProfile { get; set; }
        /// <summary> The license type, which is for bring your own license scenario. </summary>
        public string LicenseType { get; set; }
        /// <summary> Specifies the billing related details of a Azure Spot VMSS. &lt;br&gt;&lt;br&gt;Minimum api-version: 2019-03-01. </summary>
        public BillingProfile BillingProfile { get; set; }
        /// <summary> Specifies Scheduled Event related configurations. </summary>
        public ScheduledEventsProfile ScheduledEventsProfile { get; set; }
    }
}
