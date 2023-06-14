// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes the parameters of a ScaleSet managed disk.
    /// Serialized Name: VirtualMachineScaleSetManagedDiskParameters
    /// </summary>
    public partial class VirtualMachineScaleSetManagedDiskParameters
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetManagedDiskParameters. </summary>
        public VirtualMachineScaleSetManagedDiskParameters()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetManagedDiskParameters. </summary>
        /// <param name="storageAccountType">
        /// Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
        /// Serialized Name: VirtualMachineScaleSetManagedDiskParameters.storageAccountType
        /// </param>
        /// <param name="diskEncryptionSet">
        /// Specifies the customer managed disk encryption set resource id for the managed disk.
        /// Serialized Name: VirtualMachineScaleSetManagedDiskParameters.diskEncryptionSet
        /// </param>
        internal VirtualMachineScaleSetManagedDiskParameters(StorageAccountType? storageAccountType, WritableSubResource diskEncryptionSet)
        {
            StorageAccountType = storageAccountType;
            DiskEncryptionSet = diskEncryptionSet;
        }

        /// <summary>
        /// Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
        /// Serialized Name: VirtualMachineScaleSetManagedDiskParameters.storageAccountType
        /// </summary>
        public StorageAccountType? StorageAccountType { get; set; }
        /// <summary>
        /// Specifies the customer managed disk encryption set resource id for the managed disk.
        /// Serialized Name: VirtualMachineScaleSetManagedDiskParameters.diskEncryptionSet
        /// </summary>
        internal WritableSubResource DiskEncryptionSet { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier DiskEncryptionSetId
        {
            get => DiskEncryptionSet is null ? default : DiskEncryptionSet.Id;
            set
            {
                if (DiskEncryptionSet is null)
                    DiskEncryptionSet = new WritableSubResource();
                DiskEncryptionSet.Id = value;
            }
        }
    }
}
