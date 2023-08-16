// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The List Virtual Machine Scale Set VMs operation response.
    /// Serialized Name: VirtualMachineScaleSetVMListResult
    /// </summary>
    internal partial class VirtualMachineScaleSetVMListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachineScaleSetVMListResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets VMs.
        /// Serialized Name: VirtualMachineScaleSetVMListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetVMListResult(IEnumerable<VirtualMachineScaleSetVMData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachineScaleSetVMListResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets VMs.
        /// Serialized Name: VirtualMachineScaleSetVMListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs
        /// Serialized Name: VirtualMachineScaleSetVMListResult.nextLink
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetVMListResult(IReadOnlyList<VirtualMachineScaleSetVMData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary>
        /// The list of virtual machine scale sets VMs.
        /// Serialized Name: VirtualMachineScaleSetVMListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineScaleSetVMData> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs
        /// Serialized Name: VirtualMachineScaleSetVMListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
