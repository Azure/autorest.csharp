// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The protection policy of a virtual machine scale set VM.
    /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy
    /// </summary>
    public partial class VirtualMachineScaleSetVMProtectionPolicy
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMProtectionPolicy. </summary>
        public VirtualMachineScaleSetVMProtectionPolicy()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMProtectionPolicy. </summary>
        /// <param name="protectFromScaleIn">
        /// Indicates that the virtual machine scale set VM shouldn't be considered for deletion during a scale-in operation.
        /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy.protectFromScaleIn
        /// </param>
        /// <param name="protectFromScaleSetActions">
        /// Indicates that model updates or actions (including scale-in) initiated on the virtual machine scale set should not be applied to the virtual machine scale set VM.
        /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy.protectFromScaleSetActions
        /// </param>
        internal VirtualMachineScaleSetVMProtectionPolicy(bool? protectFromScaleIn, bool? protectFromScaleSetActions)
        {
            ProtectFromScaleIn = protectFromScaleIn;
            ProtectFromScaleSetActions = protectFromScaleSetActions;
        }

        /// <summary>
        /// Indicates that the virtual machine scale set VM shouldn't be considered for deletion during a scale-in operation.
        /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy.protectFromScaleIn
        /// </summary>
        public bool? ProtectFromScaleIn { get; set; }
        /// <summary>
        /// Indicates that model updates or actions (including scale-in) initiated on the virtual machine scale set should not be applied to the virtual machine scale set VM.
        /// Serialized Name: VirtualMachineScaleSetVMProtectionPolicy.protectFromScaleSetActions
        /// </summary>
        public bool? ProtectFromScaleSetActions { get; set; }
    }
}
