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
    /// Extensions summary for virtual machines of a virtual machine scale set.
    /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary
    /// </summary>
    public partial class VirtualMachineScaleSetVMExtensionsSummary
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetVMExtensionsSummary"/>. </summary>
        internal VirtualMachineScaleSetVMExtensionsSummary()
        {
            StatusesSummary = new ChangeTrackingList<VirtualMachineStatusCodeCount>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetVMExtensionsSummary"/>. </summary>
        /// <param name="name">
        /// The extension name.
        /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary.name
        /// </param>
        /// <param name="statusesSummary">
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary.statusesSummary
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetVMExtensionsSummary(string name, IReadOnlyList<VirtualMachineStatusCodeCount> statusesSummary, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            StatusesSummary = statusesSummary;
            _rawData = rawData;
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
