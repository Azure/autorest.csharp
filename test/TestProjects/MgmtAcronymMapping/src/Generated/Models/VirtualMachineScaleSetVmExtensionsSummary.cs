// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// Extensions summary for virtual machines of a virtual machine scale set.
    /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary
    /// </summary>
    public partial class VirtualMachineScaleSetVmExtensionsSummary
    {
        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetVmExtensionsSummary"/>. </summary>
        internal VirtualMachineScaleSetVmExtensionsSummary()
        {
            StatusesSummary = new ChangeTrackingList<VirtualMachineStatusCodeCount>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetVmExtensionsSummary"/>. </summary>
        /// <param name="name">
        /// The extension name.
        /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary.name
        /// </param>
        /// <param name="statusesSummary">
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary.statusesSummary
        /// </param>
        internal VirtualMachineScaleSetVmExtensionsSummary(string name, IReadOnlyList<VirtualMachineStatusCodeCount> statusesSummary)
        {
            Name = name;
            StatusesSummary = statusesSummary;
        }

        /// <summary>
        /// The extension name.
        /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary.name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary.statusesSummary
        /// </summary>
        public IReadOnlyList<VirtualMachineStatusCodeCount> StatusesSummary { get; }
    }
}
