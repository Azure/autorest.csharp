// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace compute.Models
{
    /// <summary> Specifies information about the operating system disk used by the virtual machine. &lt;br&gt;&lt;br&gt; For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhds?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). </summary>
    public partial class OSDisk
    {
        /// <summary> Initializes a new instance of OSDisk. </summary>
        /// <param name="createOption"> Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described. </param>
        public OSDisk(DiskCreateOptionTypes createOption)
        {
            CreateOption = createOption;
        }

        /// <summary> Initializes a new instance of OSDisk. </summary>
        /// <param name="osType"> This property allows you to specify the type of the OS that is included in the disk if creating a VM from user-image or a specialized VHD. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**. </param>
        /// <param name="encryptionSettings"> Specifies the encryption settings for the OS Disk. &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15. </param>
        /// <param name="name"> The disk name. </param>
        /// <param name="vhd"> The virtual hard disk. </param>
        /// <param name="image"> The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist. </param>
        /// <param name="caching"> Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None** for Standard storage. **ReadOnly** for Premium storage. </param>
        /// <param name="writeAcceleratorEnabled"> Specifies whether writeAccelerator should be enabled or disabled on the disk. </param>
        /// <param name="diffDiskSettings"> Specifies the ephemeral Disk Settings for the operating system disk used by the virtual machine. </param>
        /// <param name="createOption"> Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described. </param>
        /// <param name="diskSizeGB"> Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB. </param>
        /// <param name="managedDisk"> The managed disk parameters. </param>
        internal OSDisk(OperatingSystemTypes? osType, DiskEncryptionSettings encryptionSettings, string name, VirtualHardDisk vhd, VirtualHardDisk image, CachingTypes? caching, bool? writeAcceleratorEnabled, DiffDiskSettings diffDiskSettings, DiskCreateOptionTypes createOption, int? diskSizeGB, ManagedDiskParameters managedDisk)
        {
            OsType = osType;
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

        /// <summary> This property allows you to specify the type of the OS that is included in the disk if creating a VM from user-image or a specialized VHD. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt; **Linux**. </summary>
        public OperatingSystemTypes? OsType { get; set; }
        /// <summary> Specifies the encryption settings for the OS Disk. &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15. </summary>
        public DiskEncryptionSettings EncryptionSettings { get; set; }
        /// <summary> The disk name. </summary>
        public string Name { get; set; }
        /// <summary> The virtual hard disk. </summary>
        public VirtualHardDisk Vhd { get; set; }
        /// <summary> The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist. </summary>
        public VirtualHardDisk Image { get; set; }
        /// <summary> Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None** for Standard storage. **ReadOnly** for Premium storage. </summary>
        public CachingTypes? Caching { get; set; }
        /// <summary> Specifies whether writeAccelerator should be enabled or disabled on the disk. </summary>
        public bool? WriteAcceleratorEnabled { get; set; }
        /// <summary> Specifies the ephemeral Disk Settings for the operating system disk used by the virtual machine. </summary>
        public DiffDiskSettings DiffDiskSettings { get; set; }
        /// <summary> Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described. </summary>
        public DiskCreateOptionTypes CreateOption { get; set; }
        /// <summary> Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB. </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary> The managed disk parameters. </summary>
        public ManagedDiskParameters ManagedDisk { get; set; }
    }
}
