// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetInstanceView"/>. </summary>
        internal VirtualMachineScaleSetInstanceView()
        {
            Extensions = new ChangeTrackingList<VirtualMachineScaleSetVmExtensionsSummary>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
            OrchestrationServices = new ChangeTrackingList<OrchestrationServiceSummary>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetInstanceView"/>. </summary>
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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetInstanceView(VirtualMachineScaleSetInstanceViewStatusesSummary virtualMachine, IReadOnlyList<VirtualMachineScaleSetVmExtensionsSummary> extensions, IReadOnlyList<InstanceViewStatus> statuses, IReadOnlyList<OrchestrationServiceSummary> orchestrationServices, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            VirtualMachine = virtualMachine;
            Extensions = extensions;
            Statuses = statuses;
            OrchestrationServices = orchestrationServices;
            _serializedAdditionalRawData = serializedAdditionalRawData;
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
        [WirePath("virtualMachine.statusesSummary")]
        public IReadOnlyList<VirtualMachineStatusCodeCount> VirtualMachineStatusesSummary
        {
            get => VirtualMachine?.StatusesSummary;
        }

        /// <summary>
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.extensions
        /// </summary>
        [WirePath("extensions")]
        public IReadOnlyList<VirtualMachineScaleSetVmExtensionsSummary> Extensions { get; }
        /// <summary>
        /// The resource status information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.statuses
        /// </summary>
        [WirePath("statuses")]
        public IReadOnlyList<InstanceViewStatus> Statuses { get; }
        /// <summary>
        /// The orchestration services information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.orchestrationServices
        /// </summary>
        [WirePath("orchestrationServices")]
        public IReadOnlyList<OrchestrationServiceSummary> OrchestrationServices { get; }
    }
}
