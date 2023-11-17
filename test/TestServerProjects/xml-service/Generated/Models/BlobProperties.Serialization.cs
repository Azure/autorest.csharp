// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class BlobProperties : IXmlSerializable, IPersistableModel<BlobProperties>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "BlobProperties");
            writer.WriteStartElement("Last-Modified");
            writer.WriteValue(LastModified, "R");
            writer.WriteEndElement();
            writer.WriteStartElement("Etag");
            writer.WriteValue(Etag);
            writer.WriteEndElement();
            if (Optional.IsDefined(ContentLength))
            {
                writer.WriteStartElement("Content-Length");
                writer.WriteValue(ContentLength.Value);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(ContentType))
            {
                writer.WriteStartElement("Content-Type");
                writer.WriteValue(ContentType);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(ContentEncoding))
            {
                writer.WriteStartElement("Content-Encoding");
                writer.WriteValue(ContentEncoding);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(ContentLanguage))
            {
                writer.WriteStartElement("Content-Language");
                writer.WriteValue(ContentLanguage);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(ContentMD5))
            {
                writer.WriteStartElement("Content-MD5");
                writer.WriteValue(ContentMD5);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(ContentDisposition))
            {
                writer.WriteStartElement("Content-Disposition");
                writer.WriteValue(ContentDisposition);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(CacheControl))
            {
                writer.WriteStartElement("Cache-Control");
                writer.WriteValue(CacheControl);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(BlobSequenceNumber))
            {
                writer.WriteStartElement("x-ms-blob-sequence-number");
                writer.WriteValue(BlobSequenceNumber.Value);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(BlobType))
            {
                writer.WriteStartElement("BlobType");
                writer.WriteValue(BlobType.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(LeaseStatus))
            {
                writer.WriteStartElement("LeaseStatus");
                writer.WriteValue(LeaseStatus.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(LeaseState))
            {
                writer.WriteStartElement("LeaseState");
                writer.WriteValue(LeaseState.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(LeaseDuration))
            {
                writer.WriteStartElement("LeaseDuration");
                writer.WriteValue(LeaseDuration.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(CopyId))
            {
                writer.WriteStartElement("CopyId");
                writer.WriteValue(CopyId);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(CopyStatus))
            {
                writer.WriteStartElement("CopyStatus");
                writer.WriteValue(CopyStatus.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(CopySource))
            {
                writer.WriteStartElement("CopySource");
                writer.WriteValue(CopySource);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(CopyProgress))
            {
                writer.WriteStartElement("CopyProgress");
                writer.WriteValue(CopyProgress);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(CopyCompletionTime))
            {
                writer.WriteStartElement("CopyCompletionTime");
                writer.WriteValue(CopyCompletionTime.Value, "R");
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(CopyStatusDescription))
            {
                writer.WriteStartElement("CopyStatusDescription");
                writer.WriteValue(CopyStatusDescription);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(ServerEncrypted))
            {
                writer.WriteStartElement("ServerEncrypted");
                writer.WriteValue(ServerEncrypted.Value);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(IncrementalCopy))
            {
                writer.WriteStartElement("IncrementalCopy");
                writer.WriteValue(IncrementalCopy.Value);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(DestinationSnapshot))
            {
                writer.WriteStartElement("DestinationSnapshot");
                writer.WriteValue(DestinationSnapshot);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(DeletedTime))
            {
                writer.WriteStartElement("DeletedTime");
                writer.WriteValue(DeletedTime.Value, "R");
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(RemainingRetentionDays))
            {
                writer.WriteStartElement("RemainingRetentionDays");
                writer.WriteValue(RemainingRetentionDays.Value);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(AccessTier))
            {
                writer.WriteStartElement("AccessTier");
                writer.WriteValue(AccessTier.Value.ToString());
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(AccessTierInferred))
            {
                writer.WriteStartElement("AccessTierInferred");
                writer.WriteValue(AccessTierInferred.Value);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(ArchiveStatus))
            {
                writer.WriteStartElement("ArchiveStatus");
                writer.WriteValue(ArchiveStatus.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static BlobProperties DeserializeBlobProperties(XElement element, ModelReaderWriterOptions options = null)
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
            return new BlobProperties(lastModified, etag, contentLength, contentType, contentEncoding, contentLanguage, contentMD5, contentDisposition, cacheControl, blobSequenceNumber, blobType, leaseStatus, leaseState, leaseDuration, copyId, copyStatus, copySource, copyProgress, copyCompletionTime, copyStatusDescription, serverEncrypted, incrementalCopy, destinationSnapshot, deletedTime, remainingRetentionDays, accessTier, accessTierInferred, archiveStatus, default);
        }

        BinaryData IPersistableModel<BlobProperties>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<BlobProperties>;
            bool isValid = options.Format == "J" && implementsJson || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using MemoryStream stream = new MemoryStream();
            using XmlWriter writer = XmlWriter.Create(stream);
            ((IXmlSerializable)this).Write(writer, null);
            writer.Flush();
            if (stream.Position > int.MaxValue)
            {
                return BinaryData.FromStream(stream);
            }
            else
            {
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
        }

        BlobProperties IPersistableModel<BlobProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BlobProperties)} does not support '{options.Format}' format.");
            }

            return DeserializeBlobProperties(XElement.Load(data.ToStream()), options);
        }

        string IPersistableModel<BlobProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
