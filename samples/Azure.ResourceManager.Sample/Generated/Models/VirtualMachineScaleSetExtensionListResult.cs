// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The List VM scale set extension operation response.
    /// Serialized Name: VirtualMachineScaleSetExtensionListResult
    /// </summary>
    internal partial class VirtualMachineScaleSetExtensionListResult
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionListResult. </summary>
        /// <param name="value">
        /// The list of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetExtensionListResult(IEnumerable<VirtualMachineScaleSetExtensionData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionListResult. </summary>
        /// <param name="value">
        /// The list of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of VM scale set extensions. Call ListNext() with this to fetch the next page of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.nextLink
        /// </param>
        internal VirtualMachineScaleSetExtensionListResult(IReadOnlyList<VirtualMachineScaleSetExtensionData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// The list of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineScaleSetExtensionData> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of VM scale set extensions. Call ListNext() with this to fetch the next page of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
