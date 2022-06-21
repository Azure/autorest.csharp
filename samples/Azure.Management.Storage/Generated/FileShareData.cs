// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Models;

namespace Azure.Management.Storage
{
    /// <summary> A class representing the FileShare data model. </summary>
    public partial class FileShareData : AzureEntityResource
    {
        /// <summary> Initializes a new instance of FileShareData. </summary>
        public FileShareData()
        {
            Metadata = new ChangeTrackingDictionary<string, string>();
            SignedIdentifiers = new ChangeTrackingList<SignedIdentifier>();
        }

        /// <summary> Initializes a new instance of FileShareData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <param name="lastModifiedOn"> Returns the date and time the share was last modified. </param>
        /// <param name="metadata"> A name-value pair to associate with the share as metadata. </param>
        /// <param name="shareQuota"> The maximum size of the share, in gigabytes. Must be greater than 0, and less than or equal to 5TB (5120). For Large File Shares, the maximum size is 102400. </param>
        /// <param name="enabledProtocols"> The authentication protocol that is used for the file share. Can only be specified when creating a share. </param>
        /// <param name="rootSquash"> The property is for NFS share only. The default is NoRootSquash. </param>
        /// <param name="version"> The version of the share. </param>
        /// <param name="deleted"> Indicates whether the share was deleted. </param>
        /// <param name="deletedOn"> The deleted time if the share was deleted. </param>
        /// <param name="remainingRetentionDays"> Remaining retention days for share that was soft deleted. </param>
        /// <param name="accessTier"> Access tier for specific share. GpV2 account can choose between TransactionOptimized (default), Hot, and Cool. FileStorage account can choose Premium. </param>
        /// <param name="accessTierChangeOn"> Indicates the last modification time for share access tier. </param>
        /// <param name="accessTierStatus"> Indicates if there is a pending transition for access tier. </param>
        /// <param name="shareUsageBytes"> The approximate size of the data stored on the share. Note that this value may not include all recently created or recently resized files. </param>
        /// <param name="leaseStatus"> The lease status of the share. </param>
        /// <param name="leaseState"> Lease state of the share. </param>
        /// <param name="leaseDuration"> Specifies whether the lease on a share is of infinite or fixed duration, only when the share is leased. </param>
        /// <param name="signedIdentifiers"> List of stored access policies specified on the share. </param>
        /// <param name="snapshotOn"> Creation time of share snapshot returned in the response of list shares with expand param &quot;snapshots&quot;. </param>
        internal FileShareData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, DateTimeOffset? lastModifiedOn, IDictionary<string, string> metadata, int? shareQuota, EnabledProtocols? enabledProtocols, RootSquashType? rootSquash, string version, bool? deleted, DateTimeOffset? deletedOn, int? remainingRetentionDays, ShareAccessTier? accessTier, DateTimeOffset? accessTierChangeOn, string accessTierStatus, long? shareUsageBytes, LeaseStatus? leaseStatus, LeaseState? leaseState, LeaseDuration? leaseDuration, IList<SignedIdentifier> signedIdentifiers, DateTimeOffset? snapshotOn) : base(id, name, resourceType, systemData, etag)
        {
            LastModifiedOn = lastModifiedOn;
            Metadata = metadata;
            ShareQuota = shareQuota;
            EnabledProtocols = enabledProtocols;
            RootSquash = rootSquash;
            Version = version;
            Deleted = deleted;
            DeletedOn = deletedOn;
            RemainingRetentionDays = remainingRetentionDays;
            AccessTier = accessTier;
            AccessTierChangeOn = accessTierChangeOn;
            AccessTierStatus = accessTierStatus;
            ShareUsageBytes = shareUsageBytes;
            LeaseStatus = leaseStatus;
            LeaseState = leaseState;
            LeaseDuration = leaseDuration;
            SignedIdentifiers = signedIdentifiers;
            SnapshotOn = snapshotOn;
        }

        /// <summary> Returns the date and time the share was last modified. </summary>
        public DateTimeOffset? LastModifiedOn { get; }
        /// <summary> A name-value pair to associate with the share as metadata. </summary>
        public IDictionary<string, string> Metadata { get; }
        /// <summary> The maximum size of the share, in gigabytes. Must be greater than 0, and less than or equal to 5TB (5120). For Large File Shares, the maximum size is 102400. </summary>
        public int? ShareQuota { get; set; }
        /// <summary> The authentication protocol that is used for the file share. Can only be specified when creating a share. </summary>
        public EnabledProtocols? EnabledProtocols { get; set; }
        /// <summary> The property is for NFS share only. The default is NoRootSquash. </summary>
        public RootSquashType? RootSquash { get; set; }
        /// <summary> The version of the share. </summary>
        public string Version { get; }
        /// <summary> Indicates whether the share was deleted. </summary>
        public bool? Deleted { get; }
        /// <summary> The deleted time if the share was deleted. </summary>
        public DateTimeOffset? DeletedOn { get; }
        /// <summary> Remaining retention days for share that was soft deleted. </summary>
        public int? RemainingRetentionDays { get; }
        /// <summary> Access tier for specific share. GpV2 account can choose between TransactionOptimized (default), Hot, and Cool. FileStorage account can choose Premium. </summary>
        public ShareAccessTier? AccessTier { get; set; }
        /// <summary> Indicates the last modification time for share access tier. </summary>
        public DateTimeOffset? AccessTierChangeOn { get; }
        /// <summary> Indicates if there is a pending transition for access tier. </summary>
        public string AccessTierStatus { get; }
        /// <summary> The approximate size of the data stored on the share. Note that this value may not include all recently created or recently resized files. </summary>
        public long? ShareUsageBytes { get; }
        /// <summary> The lease status of the share. </summary>
        public LeaseStatus? LeaseStatus { get; }
        /// <summary> Lease state of the share. </summary>
        public LeaseState? LeaseState { get; }
        /// <summary> Specifies whether the lease on a share is of infinite or fixed duration, only when the share is leased. </summary>
        public LeaseDuration? LeaseDuration { get; }
        /// <summary> List of stored access policies specified on the share. </summary>
        public IList<SignedIdentifier> SignedIdentifiers { get; }
        /// <summary> Creation time of share snapshot returned in the response of list shares with expand param &quot;snapshots&quot;. </summary>
        public DateTimeOffset? SnapshotOn { get; }
    }
}
