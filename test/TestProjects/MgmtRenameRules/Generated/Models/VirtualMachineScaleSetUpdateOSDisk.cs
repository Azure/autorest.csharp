// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes virtual machine scale set operating system disk Update Object. This should be used for Updating VMSS OS Disk.
    /// Serialized Name: VirtualMachineScaleSetUpdateOSDisk
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateOSDisk
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateOSDisk. </summary>
        public VirtualMachineScaleSetUpdateOSDisk()
        {
            VhdContainers = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// The caching type.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSDisk.caching
        /// </summary>
        public CachingType? Caching { get; set; }
        /// <summary>
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSDisk.writeAcceleratorEnabled
        /// </summary>
        public bool? WriteAcceleratorEnabled { get; set; }
        /// <summary>
        /// Specifies the size of the operating system disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: VirtualMachineScaleSetUpdateOSDisk.diskSizeGB
        /// </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary>
        /// The Source User Image VirtualHardDisk. This VirtualHardDisk will be copied before using it to attach to the Virtual Machine. If SourceImage is provided, the destination VirtualHardDisk should not exist.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSDisk.image
        /// </summary>
        internal VirtualHardDisk Image { get; set; }
        /// <summary>
        /// Specifies the virtual hard disk's uri.
        /// Serialized Name: VirtualHardDisk.uri
        /// </summary>
        public Uri ImageUri
        {
            get => Image is null ? default : Image.Uri;
            set
            {
                if (Image is null)
                    Image = new VirtualHardDisk();
                Image.Uri = value;
            }
        }

        /// <summary>
        /// The list of virtual hard disk container uris.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSDisk.vhdContainers
        /// </summary>
        public IList<string> VhdContainers { get; }
        /// <summary>
        /// The managed disk parameters.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSDisk.managedDisk
        /// </summary>
        public VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get; set; }
    }
}
