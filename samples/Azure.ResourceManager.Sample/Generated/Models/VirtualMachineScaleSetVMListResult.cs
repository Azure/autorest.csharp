// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Sample
{
    /// <summary> The List Virtual Machine Scale Set VMs operation response. </summary>
    public partial class VirtualMachineScaleSetVMListResult
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMListResult. </summary>
        /// <param name="value"> The list of virtual machine scale sets VMs. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetVMListResult(IEnumerable<VirtualMachineScaleSetVMData> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMListResult. </summary>
        /// <param name="value"> The list of virtual machine scale sets VMs. </param>
        /// <param name="nextLink"> The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs. </param>
        internal VirtualMachineScaleSetVMListResult(IReadOnlyList<VirtualMachineScaleSetVMData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of virtual machine scale sets VMs. </summary>
        public IReadOnlyList<VirtualMachineScaleSetVMData> Value { get; }
        /// <summary> The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs. </summary>
        public string NextLink { get; }
    }
}
