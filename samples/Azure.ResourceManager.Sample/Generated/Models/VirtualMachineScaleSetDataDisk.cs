// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Describes a virtual machine scale set data disk. </summary>
    public partial class VirtualMachineScaleSetDataDisk
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetDataDisk. </summary>
        /// <param name="lun"> Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM. </param>
        /// <param name="createOption"> The create option. </param>
        public VirtualMachineScaleSetDataDisk(int lun, DiskCreateOptionType createOption)
        {
            Lun = lun;
            CreateOption = createOption;
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetDataDisk. </summary>
        /// <param name="name"> The disk name. </param>
        /// <param name="lun"> Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM. </param>
        /// <param name="caching"> Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**. </param>
        /// <param name="writeAcceleratorEnabled"> Specifies whether writeAccelerator should be enabled or disabled on the disk. </param>
        /// <param name="createOption"> The create option. </param>
        /// <param name="diskSizeGB"> Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB. </param>
        /// <param name="managedDisk"> The managed disk parameters. </param>
        /// <param name="diskIopsReadWrite"> Specifies the Read-Write IOPS for the managed disk. Should be used only when StorageAccountType is UltraSSD_LRS. If not specified, a default value would be assigned based on diskSizeGB. </param>
        /// <param name="diskMBpsReadWrite"> Specifies the bandwidth in MB per second for the managed disk. Should be used only when StorageAccountType is UltraSSD_LRS. If not specified, a default value would be assigned based on diskSizeGB. </param>
        internal VirtualMachineScaleSetDataDisk(string name, int lun, CachingType? caching, bool? writeAcceleratorEnabled, DiskCreateOptionType createOption, int? diskSizeGB, VirtualMachineScaleSetManagedDiskParameters managedDisk, long? diskIopsReadWrite, long? diskMBpsReadWrite)
        {
            Name = name;
            Lun = lun;
            Caching = caching;
            WriteAcceleratorEnabled = writeAcceleratorEnabled;
            CreateOption = createOption;
            DiskSizeGB = diskSizeGB;
            ManagedDisk = managedDisk;
            DiskIopsReadWrite = diskIopsReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
        }

        /// <summary> The disk name. </summary>
        public string Name { get; set; }
        /// <summary> Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM. </summary>
        public int Lun { get; set; }
        /// <summary> Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**. </summary>
        public CachingType? Caching { get; set; }
        /// <summary> Specifies whether writeAccelerator should be enabled or disabled on the disk. </summary>
        public bool? WriteAcceleratorEnabled { get; set; }
        /// <summary> The create option. </summary>
        public DiskCreateOptionType CreateOption { get; set; }
        /// <summary> Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB. </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary> The managed disk parameters. </summary>
        public VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get; set; }
        /// <summary> Specifies the Read-Write IOPS for the managed disk. Should be used only when StorageAccountType is UltraSSD_LRS. If not specified, a default value would be assigned based on diskSizeGB. </summary>
        public long? DiskIopsReadWrite { get; set; }
        /// <summary> Specifies the bandwidth in MB per second for the managed disk. Should be used only when StorageAccountType is UltraSSD_LRS. If not specified, a default value would be assigned based on diskSizeGB. </summary>
        public long? DiskMBpsReadWrite { get; set; }
    }
}
