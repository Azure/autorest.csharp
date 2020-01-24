// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace xml_service.Models
{
    /// <summary> Properties of a blob. </summary>
    public partial class BlobProperties
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-DATETIME. </summary>
        public DateTimeOffset LastModified { get; set; }
        public string Etag { get; set; }
        /// <summary> Size in bytes. </summary>
        public long? ContentLength { get; set; }
        public string? ContentType { get; set; }
        public string? ContentEncoding { get; set; }
        public string? ContentLanguage { get; set; }
        public string? ContentMd5 { get; set; }
        public string? ContentDisposition { get; set; }
        public string? CacheControl { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int? BlobSequenceNumber { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public BlobType? BlobType { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public LeaseStatusType? LeaseStatus { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public LeaseStateType? LeaseState { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public LeaseDurationType? LeaseDuration { get; set; }
        public string? CopyId { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public CopyStatusType? CopyStatus { get; set; }
        public string? CopySource { get; set; }
        public string? CopyProgress { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-DATETIME. </summary>
        public DateTimeOffset? CopyCompletionTime { get; set; }
        public string? CopyStatusDescription { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? ServerEncrypted { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? IncrementalCopy { get; set; }
        public string? DestinationSnapshot { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-DATETIME. </summary>
        public DateTimeOffset? DeletedTime { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int? RemainingRetentionDays { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public AccessTier? AccessTier { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? AccessTierInferred { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public ArchiveStatus? ArchiveStatus { get; set; }
    }
}
