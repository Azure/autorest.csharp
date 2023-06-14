// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtParamOrdering;

namespace MgmtParamOrdering.Models
{
    /// <summary> The List Virtual Machine operation response. </summary>
    internal partial class VirtualMachineScaleSetListResult
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetListResult. </summary>
        /// <param name="value"> The list of virtual machine scale sets. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetListResult(IEnumerable<VirtualMachineScaleSetData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetListResult. </summary>
        /// <param name="value"> The list of virtual machine scale sets. </param>
        /// <param name="nextLink"> The uri to fetch the next page of Virtual Machine Scale Sets. Call ListNext() with this to fetch the next page of VMSS. </param>
        internal VirtualMachineScaleSetListResult(IReadOnlyList<VirtualMachineScaleSetData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of virtual machine scale sets. </summary>
        public IReadOnlyList<VirtualMachineScaleSetData> Value { get; }
        /// <summary> The uri to fetch the next page of Virtual Machine Scale Sets. Call ListNext() with this to fetch the next page of VMSS. </summary>
        public string NextLink { get; }
    }
}
