// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a data disk.
    /// Serialized Name: DataDisk
    /// </summary>
    public partial class DataDisk
    {
        /// <summary> Initializes a new instance of DataDisk. </summary>
        /// <param name="lun">
        /// Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
        /// Serialized Name: DataDisk.lun
        /// </param>
        /// <param name="createOption">
        /// Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: DataDisk.createOption
        /// </param>
        public DataDisk(int lun, DiskCreateOptionType createOption)
        {
            Lun = lun;
            CreateOption = createOption;
        }

        /// <summary> Initializes a new instance of DataDisk. </summary>
        /// <param name="lun">
        /// Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
        /// Serialized Name: DataDisk.lun
        /// </param>
        /// <param name="name">
        /// The disk name.
        /// Serialized Name: DataDisk.name
        /// </param>
        /// <param name="vhd">
        /// The virtual hard disk.
        /// Serialized Name: DataDisk.vhd
        /// </param>
        /// <param name="image">
        /// The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist.
        /// Serialized Name: DataDisk.image
        /// </param>
        /// <param name="caching">
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: DataDisk.caching
        /// </param>
        /// <param name="writeAcceleratorEnabled">
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: DataDisk.writeAcceleratorEnabled
        /// </param>
        /// <param name="createOption">
        /// Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: DataDisk.createOption
        /// </param>
        /// <param name="diskSizeGB">
        /// Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: DataDisk.diskSizeGB
        /// </param>
        /// <param name="managedDisk">
        /// The managed disk parameters.
        /// Serialized Name: DataDisk.managedDisk
        /// </param>
        /// <param name="toBeDetached">
        /// Specifies whether the data disk is in process of detachment from the VirtualMachine/VirtualMachineScaleset
        /// Serialized Name: DataDisk.toBeDetached
        /// </param>
        /// <param name="diskIopsReadWrite">
        /// Specifies the Read-Write IOPS for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set.
        /// Serialized Name: DataDisk.diskIOPSReadWrite
        /// </param>
        /// <param name="diskMBpsReadWrite">
        /// Specifies the bandwidth in MB per second for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set.
        /// Serialized Name: DataDisk.diskMBpsReadWrite
        /// </param>
        internal DataDisk(int lun, string name, VirtualHardDisk vhd, VirtualHardDisk image, CachingType? caching, bool? writeAcceleratorEnabled, DiskCreateOptionType createOption, int? diskSizeGB, ManagedDiskParameters managedDisk, bool? toBeDetached, long? diskIopsReadWrite, long? diskMBpsReadWrite)
        {
            Lun = lun;
            Name = name;
            Vhd = vhd;
            Image = image;
            Caching = caching;
            WriteAcceleratorEnabled = writeAcceleratorEnabled;
            CreateOption = createOption;
            DiskSizeGB = diskSizeGB;
            ManagedDisk = managedDisk;
            ToBeDetached = toBeDetached;
            DiskIopsReadWrite = diskIopsReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
        }

        /// <summary>
        /// Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
        /// Serialized Name: DataDisk.lun
        /// </summary>
        public int Lun { get; set; }
        /// <summary>
        /// The disk name.
        /// Serialized Name: DataDisk.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The virtual hard disk.
        /// Serialized Name: DataDisk.vhd
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
        /// Serialized Name: DataDisk.image
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
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: DataDisk.caching
        /// </summary>
        public CachingType? Caching { get; set; }
        /// <summary>
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: DataDisk.writeAcceleratorEnabled
        /// </summary>
        public bool? WriteAcceleratorEnabled { get; set; }
        /// <summary>
        /// Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: DataDisk.createOption
        /// </summary>
        public DiskCreateOptionType CreateOption { get; set; }
        /// <summary>
        /// Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: DataDisk.diskSizeGB
        /// </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary>
        /// The managed disk parameters.
        /// Serialized Name: DataDisk.managedDisk
        /// </summary>
        public ManagedDiskParameters ManagedDisk { get; set; }
        /// <summary>
        /// Specifies whether the data disk is in process of detachment from the VirtualMachine/VirtualMachineScaleset
        /// Serialized Name: DataDisk.toBeDetached
        /// </summary>
        public bool? ToBeDetached { get; set; }
        /// <summary>
        /// Specifies the Read-Write IOPS for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set.
        /// Serialized Name: DataDisk.diskIOPSReadWrite
        /// </summary>
        public long? DiskIopsReadWrite { get; }
        /// <summary>
        /// Specifies the bandwidth in MB per second for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set.
        /// Serialized Name: DataDisk.diskMBpsReadWrite
        /// </summary>
        public long? DiskMBpsReadWrite { get; }
    }
}
