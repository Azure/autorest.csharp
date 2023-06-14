// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a virtual machine scale set operating system disk.
    /// Serialized Name: VirtualMachineScaleSetOSDisk
    /// </summary>
    public partial class VirtualMachineScaleSetOSDisk
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetOSDisk. </summary>
        /// <param name="createOption">
        /// Specifies how the virtual machines in the scale set should be created.&lt;br&gt;&lt;br&gt; The only allowed value is: **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.createOption
        /// </param>
        public VirtualMachineScaleSetOSDisk(DiskCreateOptionType createOption)
        {
            CreateOption = createOption;
            VhdContainers = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetOSDisk. </summary>
        /// <param name="name">
        /// The disk name.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.name
        /// </param>
        /// <param name="caching">
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: VirtualMachineScaleSetOSDisk.caching
        /// </param>
        /// <param name="writeAcceleratorEnabled">
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.writeAcceleratorEnabled
        /// </param>
        /// <param name="createOption">
        /// Specifies how the virtual machines in the scale set should be created.&lt;br&gt;&lt;br&gt; The only allowed value is: **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.createOption
        /// </param>
        /// <param name="diffDiskSettings">
        /// Specifies the ephemeral disk Settings for the operating system disk used by the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.diffDiskSettings
        /// </param>
        /// <param name="diskSizeGB">
        /// Specifies the size of the operating system disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: VirtualMachineScaleSetOSDisk.diskSizeGB
        /// </param>
        /// <param name="osType">
        /// This property allows you to specify the type of the OS that is included in the disk if creating a VM from user-image or a specialized VHD. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**
        /// Serialized Name: VirtualMachineScaleSetOSDisk.osType
        /// </param>
        /// <param name="image">
        /// Specifies information about the unmanaged user image to base the scale set on.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.image
        /// </param>
        /// <param name="vhdContainers">
        /// Specifies the container urls that are used to store operating system disks for the scale set.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.vhdContainers
        /// </param>
        /// <param name="managedDisk">
        /// The managed disk parameters.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.managedDisk
        /// </param>
        internal VirtualMachineScaleSetOSDisk(string name, CachingType? caching, bool? writeAcceleratorEnabled, DiskCreateOptionType createOption, DiffDiskSettings diffDiskSettings, int? diskSizeGB, OperatingSystemType? osType, VirtualHardDisk image, IList<string> vhdContainers, VirtualMachineScaleSetManagedDiskParameters managedDisk)
        {
            Name = name;
            Caching = caching;
            WriteAcceleratorEnabled = writeAcceleratorEnabled;
            CreateOption = createOption;
            DiffDiskSettings = diffDiskSettings;
            DiskSizeGB = diskSizeGB;
            OsType = osType;
            Image = image;
            VhdContainers = vhdContainers;
            ManagedDisk = managedDisk;
        }

        /// <summary>
        /// The disk name.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: VirtualMachineScaleSetOSDisk.caching
        /// </summary>
        public CachingType? Caching { get; set; }
        /// <summary>
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.writeAcceleratorEnabled
        /// </summary>
        public bool? WriteAcceleratorEnabled { get; set; }
        /// <summary>
        /// Specifies how the virtual machines in the scale set should be created.&lt;br&gt;&lt;br&gt; The only allowed value is: **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.createOption
        /// </summary>
        public DiskCreateOptionType CreateOption { get; set; }
        /// <summary>
        /// Specifies the ephemeral disk Settings for the operating system disk used by the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.diffDiskSettings
        /// </summary>
        public DiffDiskSettings DiffDiskSettings { get; set; }
        /// <summary>
        /// Specifies the size of the operating system disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: VirtualMachineScaleSetOSDisk.diskSizeGB
        /// </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary>
        /// This property allows you to specify the type of the OS that is included in the disk if creating a VM from user-image or a specialized VHD. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**
        /// Serialized Name: VirtualMachineScaleSetOSDisk.osType
        /// </summary>
        public OperatingSystemType? OsType { get; set; }
        /// <summary>
        /// Specifies information about the unmanaged user image to base the scale set on.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.image
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
        /// Specifies the container urls that are used to store operating system disks for the scale set.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.vhdContainers
        /// </summary>
        public IList<string> VhdContainers { get; }
        /// <summary>
        /// The managed disk parameters.
        /// Serialized Name: VirtualMachineScaleSetOSDisk.managedDisk
        /// </summary>
        public VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get; set; }
    }
}
