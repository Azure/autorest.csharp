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
    /// The List Virtual Machine operation response.
    /// Serialized Name: VirtualMachineListResult
    /// </summary>
    internal partial class VirtualMachineListResult
    {
        /// <summary> Initializes a new instance of VirtualMachineListResult. </summary>
        /// <param name="value">
        /// The list of virtual machines.
        /// Serialized Name: VirtualMachineListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineListResult(IEnumerable<VirtualMachineData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of VirtualMachineListResult. </summary>
        /// <param name="value">
        /// The list of virtual machines.
        /// Serialized Name: VirtualMachineListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The URI to fetch the next page of VMs. Call ListNext() with this URI to fetch the next page of Virtual Machines.
        /// Serialized Name: VirtualMachineListResult.nextLink
        /// </param>
        internal VirtualMachineListResult(IReadOnlyList<VirtualMachineData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// The list of virtual machines.
        /// Serialized Name: VirtualMachineListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineData> Value { get; }
        /// <summary>
        /// The URI to fetch the next page of VMs. Call ListNext() with this URI to fetch the next page of Virtual Machines.
        /// Serialized Name: VirtualMachineListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
