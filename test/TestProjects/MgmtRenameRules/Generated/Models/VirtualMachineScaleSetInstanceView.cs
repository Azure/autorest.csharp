// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The instance view of a virtual machine scale set.
    /// Serialized Name: VirtualMachineScaleSetInstanceView
    /// </summary>
    public partial class VirtualMachineScaleSetInstanceView
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetInstanceView
        ///
        /// </summary>
        internal VirtualMachineScaleSetInstanceView()
        {
            Extensions = new ChangeTrackingList<VirtualMachineScaleSetVmExtensionsSummary>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
            OrchestrationServices = new ChangeTrackingList<OrchestrationServiceSummary>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetInstanceView
        ///
        /// </summary>
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
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetInstanceView(VirtualMachineScaleSetInstanceViewStatusesSummary virtualMachine, IReadOnlyList<VirtualMachineScaleSetVmExtensionsSummary> extensions, IReadOnlyList<InstanceViewStatus> statuses, IReadOnlyList<OrchestrationServiceSummary> orchestrationServices, Dictionary<string, BinaryData> rawData)
        {
            VirtualMachine = virtualMachine;
            Extensions = extensions;
            Statuses = statuses;
            OrchestrationServices = orchestrationServices;
            _rawData = rawData;
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
        public IReadOnlyList<VirtualMachineScaleSetVmExtensionsSummary> Extensions { get; }
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
