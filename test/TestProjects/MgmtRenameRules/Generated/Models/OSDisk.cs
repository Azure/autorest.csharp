// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies information about the operating system disk used by the virtual machine. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
    /// Serialized Name: OSDisk
    /// </summary>
    public partial class OSDisk
    {
        /// <summary> Initializes a new instance of OSDisk. </summary>
        /// <param name="createOption">
        /// Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: OSDisk.createOption
        /// </param>
        public OSDisk(DiskCreateOptionType createOption)
        {
            CreateOption = createOption;
        }

        /// <summary> Initializes a new instance of OSDisk. </summary>
        /// <param name="osType">
        /// This property allows you to specify the type of the OS that is included in the disk if creating a VM from user-image or a specialized VHD. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**
        /// Serialized Name: OSDisk.osType
        /// </param>
        /// <param name="encryptionSettings">
        /// Specifies the encryption settings for the OS Disk. &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15
        /// Serialized Name: OSDisk.encryptionSettings
        /// </param>
        /// <param name="name">
        /// The disk name.
        /// Serialized Name: OSDisk.name
        /// </param>
        /// <param name="vhd">
        /// The virtual hard disk.
        /// Serialized Name: OSDisk.vhd
        /// </param>
        /// <param name="image">
        /// The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist.
        /// Serialized Name: OSDisk.image
        /// </param>
        /// <param name="caching">
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None** for Standard storage. **ReadOnly** for Premium storage.
        /// Serialized Name: OSDisk.caching
        /// </param>
        /// <param name="writeAcceleratorEnabled">
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: OSDisk.writeAcceleratorEnabled
        /// </param>
        /// <param name="diffDiskSettings">
        /// Specifies the ephemeral Disk Settings for the operating system disk used by the virtual machine.
        /// Serialized Name: OSDisk.diffDiskSettings
        /// </param>
        /// <param name="createOption">
        /// Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: OSDisk.createOption
        /// </param>
        /// <param name="diskSizeGB">
        /// Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: OSDisk.diskSizeGB
        /// </param>
        /// <param name="managedDisk">
        /// The managed disk parameters.
        /// Serialized Name: OSDisk.managedDisk
        /// </param>
        internal OSDisk(OperatingSystemType? osType, DiskEncryptionSettings encryptionSettings, string name, VirtualHardDisk vhd, VirtualHardDisk image, CachingType? caching, bool? writeAcceleratorEnabled, DiffDiskSettings diffDiskSettings, DiskCreateOptionType createOption, int? diskSizeGB, ManagedDiskParameters managedDisk)
        {
            OSType = osType;
            EncryptionSettings = encryptionSettings;
            Name = name;
            Vhd = vhd;
            Image = image;
            Caching = caching;
            WriteAcceleratorEnabled = writeAcceleratorEnabled;
            DiffDiskSettings = diffDiskSettings;
            CreateOption = createOption;
            DiskSizeGB = diskSizeGB;
            ManagedDisk = managedDisk;
        }

        /// <summary>
        /// This property allows you to specify the type of the OS that is included in the disk if creating a VM from user-image or a specialized VHD. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**
        /// Serialized Name: OSDisk.osType
        /// </summary>
        public OperatingSystemType? OSType { get; set; }
        /// <summary>
        /// Specifies the encryption settings for the OS Disk. &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15
        /// Serialized Name: OSDisk.encryptionSettings
        /// </summary>
        public DiskEncryptionSettings EncryptionSettings { get; set; }
        /// <summary>
        /// The disk name.
        /// Serialized Name: OSDisk.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The virtual hard disk.
        /// Serialized Name: OSDisk.vhd
        /// </summary>
        internal VirtualHardDisk Vhd { get; set; }
        /// <summary>
        /// Specifies the virtual hard disk's uri.
        /// Serialized Name: VirtualHardDisk.uri
        /// </summary>
        public Uri VhdUri
        {
            get => Vhd is null ? default : Vhd.Uri;
            set
            {
                if (Vhd is null)
                    Vhd = new VirtualHardDisk();
                Vhd.Uri = value;
            }
        }

        /// <summary>
        /// The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist.
        /// Serialized Name: OSDisk.image
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
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None** for Standard storage. **ReadOnly** for Premium storage.
        /// Serialized Name: OSDisk.caching
        /// </summary>
        public CachingType? Caching { get; set; }
        /// <summary>
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: OSDisk.writeAcceleratorEnabled
        /// </summary>
        public bool? WriteAcceleratorEnabled { get; set; }
        /// <summary>
        /// Specifies the ephemeral Disk Settings for the operating system disk used by the virtual machine.
        /// Serialized Name: OSDisk.diffDiskSettings
        /// </summary>
        public DiffDiskSettings DiffDiskSettings { get; set; }
        /// <summary>
        /// Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: OSDisk.createOption
        /// </summary>
        public DiskCreateOptionType CreateOption { get; set; }
        /// <summary>
        /// Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: OSDisk.diskSizeGB
        /// </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary>
        /// The managed disk parameters.
        /// Serialized Name: OSDisk.managedDisk
        /// </summary>
        public ManagedDiskParameters ManagedDisk { get; set; }
    }
}
