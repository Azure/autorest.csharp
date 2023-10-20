// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtAcronymMapping;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// The List Virtual Machine operation response.
    /// Serialized Name: VirtualMachineScaleSetListResult
    /// </summary>
    internal partial class VirtualMachineScaleSetListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListResult"/>. </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets.
        /// Serialized Name: VirtualMachineScaleSetListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetListResult(IEnumerable<VirtualMachineScaleSetData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListResult"/>. </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets.
        /// Serialized Name: VirtualMachineScaleSetListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of Virtual Machine Scale Sets. Call ListNext() with this to fetch the next page of VMSS.
        /// Serialized Name: VirtualMachineScaleSetListResult.nextLink
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetListResult(IReadOnlyList<VirtualMachineScaleSetData> value, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListResult"/> for deserialization. </summary>
        internal VirtualMachineScaleSetListResult()
        {
        }

        /// <summary>
        /// The list of virtual machine scale sets.
        /// Serialized Name: VirtualMachineScaleSetListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineScaleSetData> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of Virtual Machine Scale Sets. Call ListNext() with this to fetch the next page of VMSS.
        /// Serialized Name: VirtualMachineScaleSetListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
