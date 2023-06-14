// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies a list of virtual machine instance IDs from the VM scale set.
    /// Serialized Name: VirtualMachineScaleSetVMInstanceIDs
    /// </summary>
    public partial class VirtualMachineScaleSetVmInstanceIds
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVmInstanceIds. </summary>
        public VirtualMachineScaleSetVmInstanceIds()
        {
            InstanceIds = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// The virtual machine scale set instance ids. Omitting the virtual machine scale set instance ids will result in the operation being performed on all virtual machines in the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceIDs.instanceIds
        /// </summary>
        public IList<string> InstanceIds { get; }
    }
}
