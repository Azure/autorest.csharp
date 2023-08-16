// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machine scale set data disk.
    /// Serialized Name: VirtualMachineScaleSetDataDisk
    /// </summary>
    public partial class VirtualMachineScaleSetDataDisk
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetDataDisk
        ///
        /// </summary>
        /// <param name="lun">
        /// Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.lun
        /// </param>
        /// <param name="createOption">
        /// The create option.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.createOption
        /// </param>
        public VirtualMachineScaleSetDataDisk(int lun, DiskCreateOptionType createOption)
        {
            Lun = lun;
            CreateOption = createOption;
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetDataDisk
        ///
        /// </summary>
        /// <param name="name">
        /// The disk name.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.name
        /// </param>
        /// <param name="lun">
        /// Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.lun
        /// </param>
        /// <param name="caching">
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: VirtualMachineScaleSetDataDisk.caching
        /// </param>
        /// <param name="writeAcceleratorEnabled">
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.writeAcceleratorEnabled
        /// </param>
        /// <param name="createOption">
        /// The create option.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.createOption
        /// </param>
        /// <param name="diskSizeGB">
        /// Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: VirtualMachineScaleSetDataDisk.diskSizeGB
        /// </param>
        /// <param name="managedDisk">
        /// The managed disk parameters.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.managedDisk
        /// </param>
        /// <param name="diskIopsReadWrite">
        /// Specifies the Read-Write IOPS for the managed disk. Should be used only when StorageAccountType is UltraSSD_LRS. If not specified, a default value would be assigned based on diskSizeGB.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.diskIOPSReadWrite
        /// </param>
        /// <param name="diskMBpsReadWrite">
        /// Specifies the bandwidth in MB per second for the managed disk. Should be used only when StorageAccountType is UltraSSD_LRS. If not specified, a default value would be assigned based on diskSizeGB.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.diskMBpsReadWrite
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetDataDisk(string name, int lun, CachingType? caching, bool? writeAcceleratorEnabled, DiskCreateOptionType createOption, int? diskSizeGB, VirtualMachineScaleSetManagedDiskParameters managedDisk, long? diskIopsReadWrite, long? diskMBpsReadWrite, Dictionary<string, BinaryData> rawData)
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
            _rawData = rawData;
        }

        /// <summary>
        /// The disk name.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.lun
        /// </summary>
        public int Lun { get; set; }
        /// <summary>
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: VirtualMachineScaleSetDataDisk.caching
        /// </summary>
        public CachingType? Caching { get; set; }
        /// <summary>
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.writeAcceleratorEnabled
        /// </summary>
        public bool? WriteAcceleratorEnabled { get; set; }
        /// <summary>
        /// The create option.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.createOption
        /// </summary>
        public DiskCreateOptionType CreateOption { get; set; }
        /// <summary>
        /// Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: VirtualMachineScaleSetDataDisk.diskSizeGB
        /// </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary>
        /// The managed disk parameters.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.managedDisk
        /// </summary>
        public VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get; set; }
        /// <summary>
        /// Specifies the Read-Write IOPS for the managed disk. Should be used only when StorageAccountType is UltraSSD_LRS. If not specified, a default value would be assigned based on diskSizeGB.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.diskIOPSReadWrite
        /// </summary>
        public long? DiskIopsReadWrite { get; set; }
        /// <summary>
        /// Specifies the bandwidth in MB per second for the managed disk. Should be used only when StorageAccountType is UltraSSD_LRS. If not specified, a default value would be assigned based on diskSizeGB.
        /// Serialized Name: VirtualMachineScaleSetDataDisk.diskMBpsReadWrite
        /// </summary>
        public long? DiskMBpsReadWrite { get; set; }
    }
}
