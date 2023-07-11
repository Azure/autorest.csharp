// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The List Virtual Machine operation response.
    /// Serialized Name: VirtualMachineScaleSetListWithLinkResult
    /// </summary>
    internal partial class VirtualMachineScaleSetListWithLinkResult
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetListWithLinkResult. </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetListWithLinkResult(IEnumerable<VirtualMachineScaleSetData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetListWithLinkResult. </summary>
        /// <param name="value">
        /// The list of virtual machine scale sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of Virtual Machine Scale Sets. Call ListNext() with this to fetch the next page of Virtual Machine Scale Sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.nextLink
        /// </param>
        internal VirtualMachineScaleSetListWithLinkResult(IReadOnlyList<VirtualMachineScaleSetData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// The list of virtual machine scale sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineScaleSetData> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of Virtual Machine Scale Sets. Call ListNext() with this to fetch the next page of Virtual Machine Scale Sets.
        /// Serialized Name: VirtualMachineScaleSetListWithLinkResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
