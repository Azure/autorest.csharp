// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtRenameRules;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The List Virtual Machine Scale Set VMs operation response.
    /// Serialized Name: VirtualMachineScaleSetVMListResult
    /// </summary>
    internal partial class VirtualMachineScaleSetVmListResult
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVmListResult. </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets VMs.
        /// Serialized Name: VirtualMachineScaleSetVMListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetVmListResult(IEnumerable<VirtualMachineScaleSetVmData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVmListResult. </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets VMs.
        /// Serialized Name: VirtualMachineScaleSetVMListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs
        /// Serialized Name: VirtualMachineScaleSetVMListResult.nextLink
        /// </param>
        internal VirtualMachineScaleSetVmListResult(IReadOnlyList<VirtualMachineScaleSetVmData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// The list of virtual machine scale sets VMs.
        /// Serialized Name: VirtualMachineScaleSetVMListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineScaleSetVmData> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs
        /// Serialized Name: VirtualMachineScaleSetVMListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
