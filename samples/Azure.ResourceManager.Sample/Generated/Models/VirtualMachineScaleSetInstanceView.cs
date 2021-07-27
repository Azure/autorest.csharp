// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> The instance view of a virtual machine scale set. </summary>
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
        /// <param name="virtualMachine"> The instance view status summary for the virtual machine scale set. </param>
        /// <param name="extensions"> The extensions information. </param>
        /// <param name="statuses"> The resource status information. </param>
        /// <param name="orchestrationServices"> The orchestration services information. </param>
        internal VirtualMachineScaleSetInstanceView(VirtualMachineScaleSetInstanceViewStatusesSummary virtualMachine, IReadOnlyList<VirtualMachineScaleSetVMExtensionsSummary> extensions, IReadOnlyList<InstanceViewStatus> statuses, IReadOnlyList<OrchestrationServiceSummary> orchestrationServices)
        {
            VirtualMachine = virtualMachine;
            Extensions = extensions;
            Statuses = statuses;
            OrchestrationServices = orchestrationServices;
        }

        /// <summary> The instance view status summary for the virtual machine scale set. </summary>
        public VirtualMachineScaleSetInstanceViewStatusesSummary VirtualMachine { get; }
        /// <summary> The extensions information. </summary>
        public IReadOnlyList<VirtualMachineScaleSetVMExtensionsSummary> Extensions { get; }
        /// <summary> The resource status information. </summary>
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }
        /// <summary> The orchestration services information. </summary>
        public IReadOnlyList<OrchestrationServiceSummary> OrchestrationServices { get; }
    }
}
