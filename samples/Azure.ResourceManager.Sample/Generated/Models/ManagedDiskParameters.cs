// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> The parameters of a managed disk. </summary>
    public partial class ManagedDiskParameters : SubResource
    {
        /// <summary> Initializes a new instance of ManagedDiskParameters. </summary>
        public ManagedDiskParameters()
        {
        }

        /// <summary> Initializes a new instance of ManagedDiskParameters. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="storageAccountType"> Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk. </param>
        /// <param name="diskEncryptionSet"> Specifies the customer managed disk encryption set resource id for the managed disk. </param>
        internal ManagedDiskParameters(string id, StorageAccountType? storageAccountType, WritableSubResource diskEncryptionSet) : base(id)
        {
            StorageAccountType = storageAccountType;
            DiskEncryptionSet = diskEncryptionSet;
        }

        /// <summary> Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk. </summary>
        public StorageAccountType? StorageAccountType { get; set; }
        /// <summary> Specifies the customer managed disk encryption set resource id for the managed disk. </summary>
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
