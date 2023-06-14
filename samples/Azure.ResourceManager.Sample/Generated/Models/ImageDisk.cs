// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a image disk.
    /// Serialized Name: ImageDisk
    /// </summary>
    public partial class ImageDisk
    {
        /// <summary> Initializes a new instance of ImageDisk. </summary>
        public ImageDisk()
        {
        }

        /// <summary> Initializes a new instance of ImageDisk. </summary>
        /// <param name="snapshot">
        /// The snapshot.
        /// Serialized Name: ImageDisk.snapshot
        /// </param>
        /// <param name="managedDisk">
        /// The managedDisk.
        /// Serialized Name: ImageDisk.managedDisk
        /// </param>
        /// <param name="blobUri">
        /// The Virtual Hard Disk.
        /// Serialized Name: ImageDisk.blobUri
        /// </param>
        /// <param name="caching">
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: ImageDisk.caching
        /// </param>
        /// <param name="diskSizeGB">
        /// Specifies the size of empty data disks in gigabytes. This element can be used to overwrite the name of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: ImageDisk.diskSizeGB
        /// </param>
        /// <param name="storageAccountType">
        /// Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
        /// Serialized Name: ImageDisk.storageAccountType
        /// </param>
        /// <param name="diskEncryptionSet">
        /// Specifies the customer managed disk encryption set resource id for the managed image disk.
        /// Serialized Name: ImageDisk.diskEncryptionSet
        /// </param>
        internal ImageDisk(WritableSubResource snapshot, WritableSubResource managedDisk, Uri blobUri, CachingType? caching, int? diskSizeGB, StorageAccountType? storageAccountType, WritableSubResource diskEncryptionSet)
        {
            Snapshot = snapshot;
            ManagedDisk = managedDisk;
            BlobUri = blobUri;
            Caching = caching;
            DiskSizeGB = diskSizeGB;
            StorageAccountType = storageAccountType;
            DiskEncryptionSet = diskEncryptionSet;
        }

        /// <summary>
        /// The snapshot.
        /// Serialized Name: ImageDisk.snapshot
        /// </summary>
        internal WritableSubResource Snapshot { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SnapshotId
        {
            get => Snapshot is null ? default : Snapshot.Id;
            set
            {
                if (Snapshot is null)
                    Snapshot = new WritableSubResource();
                Snapshot.Id = value;
            }
        }

        /// <summary>
        /// The managedDisk.
        /// Serialized Name: ImageDisk.managedDisk
        /// </summary>
        internal WritableSubResource ManagedDisk { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier ManagedDiskId
        {
            get => ManagedDisk is null ? default : ManagedDisk.Id;
            set
            {
                if (ManagedDisk is null)
                    ManagedDisk = new WritableSubResource();
                ManagedDisk.Id = value;
            }
        }

        /// <summary>
        /// The Virtual Hard Disk.
        /// Serialized Name: ImageDisk.blobUri
        /// </summary>
        public Uri BlobUri { get; set; }
        /// <summary>
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: ImageDisk.caching
        /// </summary>
        public CachingType? Caching { get; set; }
        /// <summary>
        /// Specifies the size of empty data disks in gigabytes. This element can be used to overwrite the name of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: ImageDisk.diskSizeGB
        /// </summary>
        public int? DiskSizeGB { get; set; }
        /// <summary>
        /// Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
        /// Serialized Name: ImageDisk.storageAccountType
        /// </summary>
        public StorageAccountType? StorageAccountType { get; set; }
        /// <summary>
        /// Specifies the customer managed disk encryption set resource id for the managed image disk.
        /// Serialized Name: ImageDisk.diskEncryptionSet
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
