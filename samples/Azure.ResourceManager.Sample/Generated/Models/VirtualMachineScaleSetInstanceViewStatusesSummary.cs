// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Instance view statuses summary for virtual machines of a virtual machine scale set.
    /// Serialized Name: VirtualMachineScaleSetInstanceViewStatusesSummary
    /// </summary>
    internal partial class VirtualMachineScaleSetInstanceViewStatusesSummary
    {
        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetInstanceViewStatusesSummary"/>. </summary>
        internal VirtualMachineScaleSetInstanceViewStatusesSummary()
        {
            StatusesSummary = new ChangeTrackingList<VirtualMachineStatusCodeCount>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetInstanceViewStatusesSummary"/>. </summary>
        /// <param name="statusesSummary">
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetInstanceViewStatusesSummary.statusesSummary
        /// </param>
        internal VirtualMachineScaleSetInstanceViewStatusesSummary(IReadOnlyList<VirtualMachineStatusCodeCount> statusesSummary)
        {
            StatusesSummary = statusesSummary;
        }

        /// <summary>
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetInstanceViewStatusesSummary.statusesSummary
        /// </summary>
        public IReadOnlyList<VirtualMachineStatusCodeCount> StatusesSummary { get; }
    }
}
