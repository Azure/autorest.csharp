// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The instance view of a virtual machine scale set.
    /// Serialized Name: VirtualMachineScaleSetInstanceView
    /// </summary>
    public partial class VirtualMachineScaleSetInstanceView
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetInstanceView. </summary>
        internal VirtualMachineScaleSetInstanceView()
        {
            Extensions = new ChangeTrackingList<VirtualMachineScaleSetVMExtensionsSummary>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
            OrchestrationServices = new ChangeTrackingList<OrchestrationServiceSummary>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetInstanceView. </summary>
        /// <param name="virtualMachine">
        /// The instance view status summary for the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.virtualMachine
        /// </param>
        /// <param name="extensions">
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.extensions
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.statuses
        /// </param>
        /// <param name="orchestrationServices">
        /// The orchestration services information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.orchestrationServices
        /// </param>
        internal VirtualMachineScaleSetInstanceView(VirtualMachineScaleSetInstanceViewStatusesSummary virtualMachine, IReadOnlyList<VirtualMachineScaleSetVMExtensionsSummary> extensions, IReadOnlyList<InstanceViewStatus> statuses, IReadOnlyList<OrchestrationServiceSummary> orchestrationServices)
        {
            VirtualMachine = virtualMachine;
            Extensions = extensions;
            Statuses = statuses;
            OrchestrationServices = orchestrationServices;
        }

        /// <summary>
        /// The instance view status summary for the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.virtualMachine
        /// </summary>
        internal VirtualMachineScaleSetInstanceViewStatusesSummary VirtualMachine { get; }
        /// <summary>
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetInstanceViewStatusesSummary.statusesSummary
        /// </summary>
        public IReadOnlyList<VirtualMachineStatusCodeCount> VirtualMachineStatusesSummary
        {
            get => VirtualMachine?.StatusesSummary;
        }

        /// <summary>
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.extensions
        /// </summary>
        public IReadOnlyList<VirtualMachineScaleSetVMExtensionsSummary> Extensions { get; }
        /// <summary>
        /// The resource status information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.statuses
        /// </summary>
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }
        /// <summary>
        /// The orchestration services information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.orchestrationServices
        /// </summary>
        public IReadOnlyList<OrchestrationServiceSummary> OrchestrationServices { get; }
    }
}
