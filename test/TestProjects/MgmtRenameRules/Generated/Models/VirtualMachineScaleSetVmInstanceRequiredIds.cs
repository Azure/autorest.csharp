// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies a list of virtual machine instance IDs from the VM scale set.
    /// Serialized Name: VirtualMachineScaleSetVMInstanceRequiredIDs
    /// </summary>
    public partial class VirtualMachineScaleSetVmInstanceRequiredIds
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVmInstanceRequiredIds. </summary>
        /// <param name="instanceIds">
        /// The virtual machine scale set instance ids.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceRequiredIDs.instanceIds
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="instanceIds"/> is null. </exception>
        public VirtualMachineScaleSetVmInstanceRequiredIds(IEnumerable<string> instanceIds)
        {
            Argument.AssertNotNull(instanceIds, nameof(instanceIds));

            InstanceIds = instanceIds.ToList();
        }

        /// <summary>
        /// The virtual machine scale set instance ids.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceRequiredIDs.instanceIds
        /// </summary>
        public IList<string> InstanceIds { get; }
    }
}
