// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class BlobProperties
    {
        internal static BlobProperties DeserializeBlobProperties(XElement element)
        {
            DateTimeOffset lastModified = default;
            string etag = default;
            long? contentLength = default;
            string contentType = default;
            string contentEncoding = default;
            string contentLanguage = default;
            string contentMD5 = default;
            string contentDisposition = default;
            string cacheControl = default;
            int? blobSequenceNumber = default;
            BlobType? blobType = default;
            LeaseStatusType? leaseStatus = default;
            LeaseStateType? leaseState = default;
            LeaseDurationType? leaseDuration = default;
            string copyId = default;
            CopyStatusType? copyStatus = default;
            string copySource = default;
            string copyProgress = default;
            DateTimeOffset? copyCompletionTime = default;
            string copyStatusDescription = default;
            bool? serverEncrypted = default;
            bool? incrementalCopy = default;
            string destinationSnapshot = default;
            DateTimeOffset? deletedTime = default;
            int? remainingRetentionDays = default;
            AccessTier? accessTier = default;
            bool? accessTierInferred = default;
            ArchiveStatus? archiveStatus = default;
            if (element.Element("Last-Modified") is XElement lastModifiedElement)
            {
                lastModified = lastModifiedElement.GetDateTimeOffsetValue("R");
            }
            if (element.Element("Etag") is XElement etagElement)
            {
                etag = (string)etagElement;
            }
            if (element.Element("Content-Length") is XElement contentLengthElement)
            {
                contentLength = (long?)contentLengthElement;
            }
            if (element.Element("Content-Type") is XElement contentTypeElement)
            {
                contentType = (string)contentTypeElement;
            }
            if (element.Element("Content-Encoding") is XElement contentEncodingElement)
            {
                contentEncoding = (string)contentEncodingElement;
            }
            if (element.Element("Content-Language") is XElement contentLanguageElement)
            {
                contentLanguage = (string)contentLanguageElement;
            }
            if (element.Element("Content-MD5") is XElement contentMD5Element)
            {
                contentMD5 = (string)contentMD5Element;
            }
            if (element.Element("Content-Disposition") is XElement contentDispositionElement)
            {
                contentDisposition = (string)contentDispositionElement;
            }
            if (element.Element("Cache-Control") is XElement cacheControlElement)
            {
                cacheControl = (string)cacheControlElement;
            }
            if (element.Element("x-ms-blob-sequence-number") is XElement xMsBlobSequenceNumberElement)
            {
                blobSequenceNumber = (int?)xMsBlobSequenceNumberElement;
            }
            if (element.Element("BlobType") is XElement blobTypeElement)
            {
                blobType = blobTypeElement.Value.ToBlobType();
            }
            if (element.Element("LeaseStatus") is XElement leaseStatusElement)
            {
                leaseStatus = leaseStatusElement.Value.ToLeaseStatusType();
            }
            if (element.Element("LeaseState") is XElement leaseStateElement)
            {
                leaseState = leaseStateElement.Value.ToLeaseStateType();
            }
            if (element.Element("LeaseDuration") is XElement leaseDurationElement)
            {
                leaseDuration = leaseDurationElement.Value.ToLeaseDurationType();
            }
            if (element.Element("CopyId") is XElement copyIdElement)
            {
                copyId = (string)copyIdElement;
            }
            if (element.Element("CopyStatus") is XElement copyStatusElement)
            {
                copyStatus = copyStatusElement.Value.ToCopyStatusType();
            }
            if (element.Element("CopySource") is XElement copySourceElement)
            {
                copySource = (string)copySourceElement;
            }
            if (element.Element("CopyProgress") is XElement copyProgressElement)
            {
                copyProgress = (string)copyProgressElement;
            }
            if (element.Element("CopyCompletionTime") is XElement copyCompletionTimeElement)
            {
                copyCompletionTime = copyCompletionTimeElement.GetDateTimeOffsetValue("R");
            }
            if (element.Element("CopyStatusDescription") is XElement copyStatusDescriptionElement)
            {
                copyStatusDescription = (string)copyStatusDescriptionElement;
            }
            if (element.Element("ServerEncrypted") is XElement serverEncryptedElement)
            {
                serverEncrypted = (bool?)serverEncryptedElement;
            }
            if (element.Element("IncrementalCopy") is XElement incrementalCopyElement)
            {
                incrementalCopy = (bool?)incrementalCopyElement;
            }
            if (element.Element("DestinationSnapshot") is XElement destinationSnapshotElement)
            {
                destinationSnapshot = (string)destinationSnapshotElement;
            }
            if (element.Element("DeletedTime") is XElement deletedTimeElement)
            {
                deletedTime = deletedTimeElement.GetDateTimeOffsetValue("R");
            }
            if (element.Element("RemainingRetentionDays") is XElement remainingRetentionDaysElement)
            {
                remainingRetentionDays = (int?)remainingRetentionDaysElement;
            }
            if (element.Element("AccessTier") is XElement accessTierElement)
            {
                accessTier = new AccessTier(accessTierElement.Value);
            }
            if (element.Element("AccessTierInferred") is XElement accessTierInferredElement)
            {
                accessTierInferred = (bool?)accessTierInferredElement;
            }
            if (element.Element("ArchiveStatus") is XElement archiveStatusElement)
            {
                archiveStatus = new ArchiveStatus(archiveStatusElement.Value);
            }
            return new BlobProperties(lastModified, etag, contentLength, contentType, contentEncoding, contentLanguage, contentMD5, contentDisposition, cacheControl, blobSequenceNumber, blobType, leaseStatus, leaseState, leaseDuration, copyId, copyStatus, copySource, copyProgress, copyCompletionTime, copyStatusDescription, serverEncrypted, incrementalCopy, destinationSnapshot, deletedTime, remainingRetentionDays, accessTier, accessTierInferred, archiveStatus);
        }
    }
}
