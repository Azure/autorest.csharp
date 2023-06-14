// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the storage settings for the virtual machine disks.
    /// Serialized Name: StorageProfile
    /// </summary>
    public partial class StorageProfile
    {
        /// <summary> Initializes a new instance of StorageProfile. </summary>
        public StorageProfile()
        {
            DataDisks = new ChangeTrackingList<DataDisk>();
        }

        /// <summary> Initializes a new instance of StorageProfile. </summary>
        /// <param name="imageReference">
        /// Specifies information about the image to use. You can specify information about platform images, marketplace images, or virtual machine images. This element is required when you want to use a platform image, marketplace image, or virtual machine image, but is not used in other creation operations.
        /// Serialized Name: StorageProfile.imageReference
        /// </param>
        /// <param name="osDisk">
        /// Specifies information about the operating system disk used by the virtual machine. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
        /// Serialized Name: StorageProfile.osDisk
        /// </param>
        /// <param name="dataDisks">
        /// Specifies the parameters that are used to add a data disk to a virtual machine. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
        /// Serialized Name: StorageProfile.dataDisks
        /// </param>
        internal StorageProfile(ImageReference imageReference, OSDisk osDisk, IList<DataDisk> dataDisks)
        {
            ImageReference = imageReference;
            OSDisk = osDisk;
            DataDisks = dataDisks;
        }

        /// <summary>
        /// Specifies information about the image to use. You can specify information about platform images, marketplace images, or virtual machine images. This element is required when you want to use a platform image, marketplace image, or virtual machine image, but is not used in other creation operations.
        /// Serialized Name: StorageProfile.imageReference
        /// </summary>
        public ImageReference ImageReference { get; set; }
        /// <summary>
        /// Specifies information about the operating system disk used by the virtual machine. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
        /// Serialized Name: StorageProfile.osDisk
        /// </summary>
        public OSDisk OSDisk { get; set; }
        /// <summary>
        /// Specifies the parameters that are used to add a data disk to a virtual machine. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
        /// Serialized Name: StorageProfile.dataDisks
        /// </summary>
        public IList<DataDisk> DataDisks { get; }
    }
}
