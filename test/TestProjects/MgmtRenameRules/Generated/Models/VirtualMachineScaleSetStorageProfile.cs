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
    /// Describes a virtual machine scale set storage profile.
    /// Serialized Name: VirtualMachineScaleSetStorageProfile
    /// </summary>
    public partial class VirtualMachineScaleSetStorageProfile
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetStorageProfile"/>. </summary>
        public VirtualMachineScaleSetStorageProfile()
        {
            DataDisks = new ChangeTrackingList<VirtualMachineScaleSetDataDisk>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetStorageProfile"/>. </summary>
        /// <param name="imageReference">
        /// Specifies information about the image to use. You can specify information about platform images, marketplace images, or virtual machine images. This element is required when you want to use a platform image, marketplace image, or virtual machine image, but is not used in other creation operations.
        /// Serialized Name: VirtualMachineScaleSetStorageProfile.imageReference
        /// </param>
        /// <param name="osDisk">
        /// Specifies information about the operating system disk used by the virtual machines in the scale set. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
        /// Serialized Name: VirtualMachineScaleSetStorageProfile.osDisk
        /// </param>
        /// <param name="dataDisks">
        /// Specifies the parameters that are used to add data disks to the virtual machines in the scale set. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
        /// Serialized Name: VirtualMachineScaleSetStorageProfile.dataDisks
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetStorageProfile(ImageReference imageReference, VirtualMachineScaleSetOSDisk osDisk, IList<VirtualMachineScaleSetDataDisk> dataDisks, Dictionary<string, BinaryData> rawData)
        {
            ImageReference = imageReference;
            OSDisk = osDisk;
            DataDisks = dataDisks;
            _rawData = rawData;
        }

        /// <summary>
        /// Specifies information about the image to use. You can specify information about platform images, marketplace images, or virtual machine images. This element is required when you want to use a platform image, marketplace image, or virtual machine image, but is not used in other creation operations.
        /// Serialized Name: VirtualMachineScaleSetStorageProfile.imageReference
        /// </summary>
        public ImageReference ImageReference { get; set; }
        /// <summary>
        /// Specifies information about the operating system disk used by the virtual machines in the scale set. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
        /// Serialized Name: VirtualMachineScaleSetStorageProfile.osDisk
        /// </summary>
        public VirtualMachineScaleSetOSDisk OSDisk { get; set; }
        /// <summary>
        /// Specifies the parameters that are used to add data disks to the virtual machines in the scale set. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
        /// Serialized Name: VirtualMachineScaleSetStorageProfile.dataDisks
        /// </summary>
        public IList<VirtualMachineScaleSetDataDisk> DataDisks { get; }
    }
}
