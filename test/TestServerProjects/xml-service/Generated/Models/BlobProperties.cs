// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace xml_service.Models.V100
{
    /// <summary> Properties of a blob. </summary>
    public partial class BlobProperties
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-DATETIME. </summary>
        public DateTimeOffset LastModified { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string Etag { get; set; }
        /// <summary> Size in bytes. </summary>
        public long? ContentLength { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? ContentType { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? ContentEncoding { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? ContentLanguage { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? ContentMD5 { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? ContentDisposition { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
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
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? CopyId { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public CopyStatusType? CopyStatus { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? CopySource { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? CopyProgress { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-DATETIME. </summary>
        public DateTimeOffset? CopyCompletionTime { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? CopyStatusDescription { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? ServerEncrypted { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? IncrementalCopy { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
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
