// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a Virtual Machine Scale Set VM Reimage Parameters.
    /// Serialized Name: VirtualMachineScaleSetVMReimageParameters
    /// </summary>
    public partial class VirtualMachineScaleSetVmReimageContent : VirtualMachineReimageContent
    {
        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetVmReimageContent
        ///
        /// </summary>
        public VirtualMachineScaleSetVmReimageContent()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetVmReimageContent
        ///
        /// </summary>
        /// <param name="tempDisk">
        /// Specifies whether to reimage temp disk. Default value: false. Note: This temp disk reimage parameter is only supported for VM/VMSS with Ephemeral OS disk.
        /// Serialized Name: VirtualMachineReimageParameters.tempDisk
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetVmReimageContent(bool? tempDisk, Dictionary<string, BinaryData> rawData) : base(tempDisk, rawData)
        {
        }
    }
}
