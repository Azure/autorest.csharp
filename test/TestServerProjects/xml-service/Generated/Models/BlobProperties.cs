// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> Properties of a blob. </summary>
    public partial class BlobProperties
    {
        /// <summary> Initializes a new instance of BlobProperties. </summary>
        /// <param name="lastModified"></param>
        /// <param name="etag"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="etag"/> is null. </exception>
        internal BlobProperties(DateTimeOffset lastModified, string etag)
        {
            Argument.AssertNotNull(etag, nameof(etag));

            LastModified = lastModified;
            Etag = etag;
        }

        /// <summary> Initializes a new instance of BlobProperties. </summary>
        /// <param name="lastModified"></param>
        /// <param name="etag"></param>
        /// <param name="contentLength"> Size in bytes. </param>
        /// <param name="contentType"></param>
        /// <param name="contentEncoding"></param>
        /// <param name="contentLanguage"></param>
        /// <param name="contentMD5"></param>
        /// <param name="contentDisposition"></param>
        /// <param name="cacheControl"></param>
        /// <param name="blobSequenceNumber"></param>
        /// <param name="blobType"></param>
        /// <param name="leaseStatus"></param>
        /// <param name="leaseState"></param>
        /// <param name="leaseDuration"></param>
        /// <param name="copyId"></param>
        /// <param name="copyStatus"></param>
        /// <param name="copySource"></param>
        /// <param name="copyProgress"></param>
        /// <param name="copyCompletionTime"></param>
        /// <param name="copyStatusDescription"></param>
        /// <param name="serverEncrypted"></param>
        /// <param name="incrementalCopy"></param>
        /// <param name="destinationSnapshot"></param>
        /// <param name="deletedTime"></param>
        /// <param name="remainingRetentionDays"></param>
        /// <param name="accessTier"></param>
        /// <param name="accessTierInferred"></param>
        /// <param name="archiveStatus"></param>
        internal BlobProperties(DateTimeOffset lastModified, string etag, long? contentLength, string contentType, string contentEncoding, string contentLanguage, string contentMD5, string contentDisposition, string cacheControl, int? blobSequenceNumber, BlobType? blobType, LeaseStatusType? leaseStatus, LeaseStateType? leaseState, LeaseDurationType? leaseDuration, string copyId, CopyStatusType? copyStatus, string copySource, string copyProgress, DateTimeOffset? copyCompletionTime, string copyStatusDescription, bool? serverEncrypted, bool? incrementalCopy, string destinationSnapshot, DateTimeOffset? deletedTime, int? remainingRetentionDays, AccessTier? accessTier, bool? accessTierInferred, ArchiveStatus? archiveStatus)
        {
            LastModified = lastModified;
            Etag = etag;
            ContentLength = contentLength;
            ContentType = contentType;
            ContentEncoding = contentEncoding;
            ContentLanguage = contentLanguage;
            ContentMD5 = contentMD5;
            ContentDisposition = contentDisposition;
            CacheControl = cacheControl;
            BlobSequenceNumber = blobSequenceNumber;
            BlobType = blobType;
            LeaseStatus = leaseStatus;
            LeaseState = leaseState;
            LeaseDuration = leaseDuration;
            CopyId = copyId;
            CopyStatus = copyStatus;
            CopySource = copySource;
            CopyProgress = copyProgress;
            CopyCompletionTime = copyCompletionTime;
            CopyStatusDescription = copyStatusDescription;
            ServerEncrypted = serverEncrypted;
            IncrementalCopy = incrementalCopy;
            DestinationSnapshot = destinationSnapshot;
            DeletedTime = deletedTime;
            RemainingRetentionDays = remainingRetentionDays;
            AccessTier = accessTier;
            AccessTierInferred = accessTierInferred;
            ArchiveStatus = archiveStatus;
        }

        /// <summary> Gets the last modified. </summary>
        public DateTimeOffset LastModified { get; }
        /// <summary> Gets the etag. </summary>
        public string Etag { get; }
        /// <summary> Size in bytes. </summary>
        public long? ContentLength { get; }
        /// <summary> Gets the content type. </summary>
        public string ContentType { get; }
        /// <summary> Gets the content encoding. </summary>
        public string ContentEncoding { get; }
        /// <summary> Gets the content language. </summary>
        public string ContentLanguage { get; }
        /// <summary> Gets the content md 5. </summary>
        public string ContentMD5 { get; }
        /// <summary> Gets the content disposition. </summary>
        public string ContentDisposition { get; }
        /// <summary> Gets the cache control. </summary>
        public string CacheControl { get; }
        /// <summary> Gets the blob sequence number. </summary>
        public int? BlobSequenceNumber { get; }
        /// <summary> Gets the blob type. </summary>
        public BlobType? BlobType { get; }
        /// <summary> Gets the lease status. </summary>
        public LeaseStatusType? LeaseStatus { get; }
        /// <summary> Gets the lease state. </summary>
        public LeaseStateType? LeaseState { get; }
        /// <summary> Gets the lease duration. </summary>
        public LeaseDurationType? LeaseDuration { get; }
        /// <summary> Gets the copy id. </summary>
        public string CopyId { get; }
        /// <summary> Gets the copy status. </summary>
        public CopyStatusType? CopyStatus { get; }
        /// <summary> Gets the copy source. </summary>
        public string CopySource { get; }
        /// <summary> Gets the copy progress. </summary>
        public string CopyProgress { get; }
        /// <summary> Gets the copy completion time. </summary>
        public DateTimeOffset? CopyCompletionTime { get; }
        /// <summary> Gets the copy status description. </summary>
        public string CopyStatusDescription { get; }
        /// <summary> Gets the server encrypted. </summary>
        public bool? ServerEncrypted { get; }
        /// <summary> Gets the incremental copy. </summary>
        public bool? IncrementalCopy { get; }
        /// <summary> Gets the destination snapshot. </summary>
        public string DestinationSnapshot { get; }
        /// <summary> Gets the deleted time. </summary>
        public DateTimeOffset? DeletedTime { get; }
        /// <summary> Gets the remaining retention days. </summary>
        public int? RemainingRetentionDays { get; }
        /// <summary> Gets the access tier. </summary>
        public AccessTier? AccessTier { get; }
        /// <summary> Gets the access tier inferred. </summary>
        public bool? AccessTierInferred { get; }
        /// <summary> Gets the archive status. </summary>
        public ArchiveStatus? ArchiveStatus { get; }
    }
}
