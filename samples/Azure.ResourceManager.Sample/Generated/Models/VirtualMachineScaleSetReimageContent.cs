// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a Virtual Machine Scale Set VM Reimage Parameters.
    /// Serialized Name: VirtualMachineScaleSetReimageParameters
    /// </summary>
    public partial class VirtualMachineScaleSetReimageContent : VirtualMachineScaleSetVMReimageContent
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetReimageContent. </summary>
        public VirtualMachineScaleSetReimageContent()
        {
            InstanceIds = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// The virtual machine scale set instance ids. Omitting the virtual machine scale set instance ids will result in the operation being performed on all virtual machines in the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetReimageParameters.instanceIds
        /// </summary>
        public IList<string> InstanceIds { get; }
    }
}
