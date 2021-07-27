// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Describes a data disk. </summary>
    public partial class DataDisk
    {
        /// <summary> Initializes a new instance of DataDisk. </summary>
        /// <param name="lun"> Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM. </param>
        /// <param name="createOption"> Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described. </param>
        public DataDisk(int lun, DiskCreateOptionTypes createOption)
        {
            Lun = lun;
            CreateOption = createOption;
        }

        /// <summary> Initializes a new instance of DataDisk. </summary>
        /// <param name="lun"> Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM. </param>
        /// <param name="name"> The disk name. </param>
        /// <param name="vhd"> The virtual hard disk. </param>
        /// <param name="image"> The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist. </param>
        /// <param name="caching"> Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**. </param>
        /// <param name="writeAcceleratorEnabled"> Specifies whether writeAccelerator should be enabled or disabled on the disk. </param>
        /// <param name="createOption"> Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described. </param>
        /// <param name="diskSizeGB"> Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB. </param>
        /// <param name="managedDisk"> The managed disk parameters. </param>
        /// <param name="toBeDetached"> Specifies whether the data disk is in process of detachment from the VirtualMachine/VirtualMachineScaleset. </param>
        /// <param name="diskIopsReadWrite"> Specifies the Read-Write IOPS for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set. </param>
        /// <param name="diskMBpsReadWrite"> Specifies the bandwidth in MB per second for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set. </param>
        internal DataDisk(int lun, string name, VirtualHardDisk vhd, VirtualHardDisk image, CachingTypes? caching, bool? writeAcceleratorEnabled, DiskCreateOptionTypes createOption, int? diskSizeGB, ManagedDiskParameters managedDisk, bool? toBeDetached, long? diskIopsReadWrite, long? diskMBpsReadWrite)
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

        /// <summary> Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM. </summary>
        public int Lun { get; set; }
        /// <summary> The disk name. </summary>
        public string Name { get; set; }
        /// <summary> The virtual hard disk. </summary>
        public VirtualHardDisk Vhd { get; set; }
        /// <summary> The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist. </summary>
        public VirtualHardDisk Image { get; set; }
        /// <summary> Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**. </summary>
        public CachingTypes? Caching { get; set; }
        /// <summary> Specifies whether writeAccelerator should be enabled or disabled on the disk. </summary>
        public bool? WriteAcceleratorEnabled { get; set; }
        /// <summary> Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described. </summary>
        public DiskCreateOptionTypes CreateOption { get; set; }
        /// <summary> Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB. </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary> The managed disk parameters. </summary>
        public ManagedDiskParameters ManagedDisk { get; set; }
        /// <summary> Specifies whether the data disk is in process of detachment from the VirtualMachine/VirtualMachineScaleset. </summary>
        public bool? ToBeDetached { get; set; }
        /// <summary> Specifies the Read-Write IOPS for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set. </summary>
        public long? DiskIopsReadWrite { get; }
        /// <summary> Specifies the bandwidth in MB per second for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set. </summary>
        public long? DiskMBpsReadWrite { get; }
    }
}
