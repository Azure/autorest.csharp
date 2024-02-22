// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class BlobProperties : IXmlSerializable, IPersistableModel<BlobProperties>
    {
        private void WriteInternal(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "BlobProperties");
            writer.WriteStartElement("Last-Modified");
            writer.WriteValue(LastModified, "R");
            writer.WriteEndElement();
            writer.WriteStartElement("Etag");
            writer.WriteValue(Etag);
            writer.WriteEndElement();
            if (ContentLength.HasValue)
            {
                writer.WriteStartElement("Content-Length");
                writer.WriteValue(ContentLength.Value);
                writer.WriteEndElement();
            }
            if (ContentType != null)
            {
                writer.WriteStartElement("Content-Type");
                writer.WriteValue(ContentType);
                writer.WriteEndElement();
            }
            if (ContentEncoding != null)
            {
                writer.WriteStartElement("Content-Encoding");
                writer.WriteValue(ContentEncoding);
                writer.WriteEndElement();
            }
            if (ContentLanguage != null)
            {
                writer.WriteStartElement("Content-Language");
                writer.WriteValue(ContentLanguage);
                writer.WriteEndElement();
            }
            if (ContentMD5 != null)
            {
                writer.WriteStartElement("Content-MD5");
                writer.WriteValue(ContentMD5);
                writer.WriteEndElement();
            }
            if (ContentDisposition != null)
            {
                writer.WriteStartElement("Content-Disposition");
                writer.WriteValue(ContentDisposition);
                writer.WriteEndElement();
            }
            if (CacheControl != null)
            {
                writer.WriteStartElement("Cache-Control");
                writer.WriteValue(CacheControl);
                writer.WriteEndElement();
            }
            if (BlobSequenceNumber.HasValue)
            {
                writer.WriteStartElement("x-ms-blob-sequence-number");
                writer.WriteValue(BlobSequenceNumber.Value);
                writer.WriteEndElement();
            }
            if (BlobType.HasValue)
            {
                writer.WriteStartElement("BlobType");
                writer.WriteValue(BlobType.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (LeaseStatus.HasValue)
            {
                writer.WriteStartElement("LeaseStatus");
                writer.WriteValue(LeaseStatus.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (LeaseState.HasValue)
            {
                writer.WriteStartElement("LeaseState");
                writer.WriteValue(LeaseState.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (LeaseDuration.HasValue)
            {
                writer.WriteStartElement("LeaseDuration");
                writer.WriteValue(LeaseDuration.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (CopyId != null)
            {
                writer.WriteStartElement("CopyId");
                writer.WriteValue(CopyId);
                writer.WriteEndElement();
            }
            if (CopyStatus.HasValue)
            {
                writer.WriteStartElement("CopyStatus");
                writer.WriteValue(CopyStatus.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (CopySource != null)
            {
                writer.WriteStartElement("CopySource");
                writer.WriteValue(CopySource);
                writer.WriteEndElement();
            }
            if (CopyProgress != null)
            {
                writer.WriteStartElement("CopyProgress");
                writer.WriteValue(CopyProgress);
                writer.WriteEndElement();
            }
            if (CopyCompletionTime.HasValue)
            {
                writer.WriteStartElement("CopyCompletionTime");
                writer.WriteValue(CopyCompletionTime.Value, "R");
                writer.WriteEndElement();
            }
            if (CopyStatusDescription != null)
            {
                writer.WriteStartElement("CopyStatusDescription");
                writer.WriteValue(CopyStatusDescription);
                writer.WriteEndElement();
            }
            if (ServerEncrypted.HasValue)
            {
                writer.WriteStartElement("ServerEncrypted");
                writer.WriteValue(ServerEncrypted.Value);
                writer.WriteEndElement();
            }
            if (IncrementalCopy.HasValue)
            {
                writer.WriteStartElement("IncrementalCopy");
                writer.WriteValue(IncrementalCopy.Value);
                writer.WriteEndElement();
            }
            if (DestinationSnapshot != null)
            {
                writer.WriteStartElement("DestinationSnapshot");
                writer.WriteValue(DestinationSnapshot);
                writer.WriteEndElement();
            }
            if (DeletedTime.HasValue)
            {
                writer.WriteStartElement("DeletedTime");
                writer.WriteValue(DeletedTime.Value, "R");
                writer.WriteEndElement();
            }
            if (RemainingRetentionDays.HasValue)
            {
                writer.WriteStartElement("RemainingRetentionDays");
                writer.WriteValue(RemainingRetentionDays.Value);
                writer.WriteEndElement();
            }
            if (AccessTier.HasValue)
            {
                writer.WriteStartElement("AccessTier");
                writer.WriteValue(AccessTier.Value.ToString());
                writer.WriteEndElement();
            }
            if (AccessTierInferred.HasValue)
            {
                writer.WriteStartElement("AccessTierInferred");
                writer.WriteValue(AccessTierInferred.Value);
                writer.WriteEndElement();
            }
            if (ArchiveStatus.HasValue)
            {
                writer.WriteStartElement("ArchiveStatus");
                writer.WriteValue(ArchiveStatus.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => WriteInternal(writer, nameHint, new ModelReaderWriterOptions("W"));

        internal static BlobProperties DeserializeBlobProperties(XElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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
            return new BlobProperties(lastModified, etag, contentLength, contentType, contentEncoding, contentLanguage, contentMD5, contentDisposition, cacheControl, blobSequenceNumber, blobType, leaseStatus, leaseState, leaseDuration, copyId, copyStatus, copySource, copyProgress, copyCompletionTime, copyStatusDescription, serverEncrypted, incrementalCopy, destinationSnapshot, deletedTime, remainingRetentionDays, accessTier, accessTierInferred, archiveStatus, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<BlobProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BlobProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    {
                        using MemoryStream stream = new MemoryStream();
                        using XmlWriter writer = XmlWriter.Create(stream);
                        WriteInternal(writer, null, options);
                        writer.Flush();
                        return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                    }
                default:
                    throw new FormatException($"The model {nameof(BlobProperties)} does not support '{options.Format}' format.");
            }
        }

        BlobProperties IPersistableModel<BlobProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BlobProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeBlobProperties(XElement.Load(data.ToStream()), options);
                default:
                    throw new FormatException($"The model {nameof(BlobProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<BlobProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
