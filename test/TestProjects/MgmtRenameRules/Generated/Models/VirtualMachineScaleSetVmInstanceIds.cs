// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetVmInstanceIds
        ///
        /// </summary>
        public VirtualMachineScaleSetVmInstanceIds()
        {
            InstanceIds = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetVmInstanceIds
        ///
        /// </summary>
        /// <param name="instanceIds">
        /// The virtual machine scale set instance ids. Omitting the virtual machine scale set instance ids will result in the operation being performed on all virtual machines in the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceIDs.instanceIds
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetVmInstanceIds(IList<string> instanceIds, Dictionary<string, BinaryData> rawData)
        {
            InstanceIds = instanceIds;
            _rawData = rawData;
        }

        /// <summary>
        /// The virtual machine scale set instance ids. Omitting the virtual machine scale set instance ids will result in the operation being performed on all virtual machines in the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceIDs.instanceIds
        /// </summary>
        public IList<string> InstanceIds { get; }
    }
}
