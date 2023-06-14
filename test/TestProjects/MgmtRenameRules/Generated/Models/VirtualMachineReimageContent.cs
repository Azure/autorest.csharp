// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Parameters for Reimaging Virtual Machine. NOTE: Virtual Machine OS disk will always be reimaged
    /// Serialized Name: VirtualMachineReimageParameters
    /// </summary>
    public partial class VirtualMachineReimageContent
    {
        /// <summary> Initializes a new instance of VirtualMachineReimageContent. </summary>
        public VirtualMachineReimageContent()
        {
        }

        /// <summary>
        /// Specifies whether to reimage temp disk. Default value: false. Note: This temp disk reimage parameter is only supported for VM/VMSS with Ephemeral OS disk.
        /// Serialized Name: VirtualMachineReimageParameters.tempDisk
        /// </summary>
        public bool? TempDisk { get; set; }
    }
}
