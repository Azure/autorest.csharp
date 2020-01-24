// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class BlobProperties : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Last-Modified");
            writer.WriteStringValue(LastModified, "R");
            writer.WritePropertyName("Etag");
            writer.WriteStringValue(Etag);
            if (ContentLength != null)
            {
                writer.WritePropertyName("Content-Length");
                writer.WriteNumberValue(ContentLength.Value);
            }
            if (ContentType != null)
            {
                writer.WritePropertyName("Content-Type");
                writer.WriteStringValue(ContentType);
            }
            if (ContentEncoding != null)
            {
                writer.WritePropertyName("Content-Encoding");
                writer.WriteStringValue(ContentEncoding);
            }
            if (ContentLanguage != null)
            {
                writer.WritePropertyName("Content-Language");
                writer.WriteStringValue(ContentLanguage);
            }
            if (ContentMd5 != null)
            {
                writer.WritePropertyName("Content-MD5");
                writer.WriteStringValue(ContentMd5);
            }
            if (ContentDisposition != null)
            {
                writer.WritePropertyName("Content-Disposition");
                writer.WriteStringValue(ContentDisposition);
            }
            if (CacheControl != null)
            {
                writer.WritePropertyName("Cache-Control");
                writer.WriteStringValue(CacheControl);
            }
            if (BlobSequenceNumber != null)
            {
                writer.WritePropertyName("x-ms-blob-sequence-number");
                writer.WriteNumberValue(BlobSequenceNumber.Value);
            }
            if (BlobType != null)
            {
                writer.WritePropertyName("BlobType");
                writer.WriteStringValue(BlobType.Value.ToSerialString());
            }
            if (LeaseStatus != null)
            {
                writer.WritePropertyName("LeaseStatus");
                writer.WriteStringValue(LeaseStatus.Value.ToSerialString());
            }
            if (LeaseState != null)
            {
                writer.WritePropertyName("LeaseState");
                writer.WriteStringValue(LeaseState.Value.ToSerialString());
            }
            if (LeaseDuration != null)
            {
                writer.WritePropertyName("LeaseDuration");
                writer.WriteStringValue(LeaseDuration.Value.ToSerialString());
            }
            if (CopyId != null)
            {
                writer.WritePropertyName("CopyId");
                writer.WriteStringValue(CopyId);
            }
            if (CopyStatus != null)
            {
                writer.WritePropertyName("CopyStatus");
                writer.WriteStringValue(CopyStatus.Value.ToSerialString());
            }
            if (CopySource != null)
            {
                writer.WritePropertyName("CopySource");
                writer.WriteStringValue(CopySource);
            }
            if (CopyProgress != null)
            {
                writer.WritePropertyName("CopyProgress");
                writer.WriteStringValue(CopyProgress);
            }
            if (CopyCompletionTime != null)
            {
                writer.WritePropertyName("CopyCompletionTime");
                writer.WriteStringValue(CopyCompletionTime.Value, "R");
            }
            if (CopyStatusDescription != null)
            {
                writer.WritePropertyName("CopyStatusDescription");
                writer.WriteStringValue(CopyStatusDescription);
            }
            if (ServerEncrypted != null)
            {
                writer.WritePropertyName("ServerEncrypted");
                writer.WriteBooleanValue(ServerEncrypted.Value);
            }
            if (IncrementalCopy != null)
            {
                writer.WritePropertyName("IncrementalCopy");
                writer.WriteBooleanValue(IncrementalCopy.Value);
            }
            if (DestinationSnapshot != null)
            {
                writer.WritePropertyName("DestinationSnapshot");
                writer.WriteStringValue(DestinationSnapshot);
            }
            if (DeletedTime != null)
            {
                writer.WritePropertyName("DeletedTime");
                writer.WriteStringValue(DeletedTime.Value, "R");
            }
            if (RemainingRetentionDays != null)
            {
                writer.WritePropertyName("RemainingRetentionDays");
                writer.WriteNumberValue(RemainingRetentionDays.Value);
            }
            if (AccessTier != null)
            {
                writer.WritePropertyName("AccessTier");
                writer.WriteStringValue(AccessTier.Value.ToString());
            }
            if (AccessTierInferred != null)
            {
                writer.WritePropertyName("AccessTierInferred");
                writer.WriteBooleanValue(AccessTierInferred.Value);
            }
            if (ArchiveStatus != null)
            {
                writer.WritePropertyName("ArchiveStatus");
                writer.WriteStringValue(ArchiveStatus.Value.ToString());
            }
            writer.WriteEndObject();
        }
        internal static BlobProperties DeserializeBlobProperties(JsonElement element)
        {
            BlobProperties result = new BlobProperties();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Last-Modified"))
                {
                    result.LastModified = property.Value.GetDateTimeOffset("R");
                    continue;
                }
                if (property.NameEquals("Etag"))
                {
                    result.Etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Content-Length"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ContentLength = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("Content-Type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ContentType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Content-Encoding"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ContentEncoding = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Content-Language"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ContentLanguage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Content-MD5"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ContentMd5 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Content-Disposition"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ContentDisposition = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Cache-Control"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CacheControl = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("x-ms-blob-sequence-number"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.BlobSequenceNumber = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("BlobType"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.BlobType = property.Value.GetString().ToBlobType();
                    continue;
                }
                if (property.NameEquals("LeaseStatus"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.LeaseStatus = property.Value.GetString().ToLeaseStatusType();
                    continue;
                }
                if (property.NameEquals("LeaseState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.LeaseState = property.Value.GetString().ToLeaseStateType();
                    continue;
                }
                if (property.NameEquals("LeaseDuration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.LeaseDuration = property.Value.GetString().ToLeaseDurationType();
                    continue;
                }
                if (property.NameEquals("CopyId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CopyId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("CopyStatus"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CopyStatus = property.Value.GetString().ToCopyStatusType();
                    continue;
                }
                if (property.NameEquals("CopySource"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CopySource = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("CopyProgress"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CopyProgress = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("CopyCompletionTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CopyCompletionTime = property.Value.GetDateTimeOffset("R");
                    continue;
                }
                if (property.NameEquals("CopyStatusDescription"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CopyStatusDescription = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ServerEncrypted"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ServerEncrypted = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("IncrementalCopy"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.IncrementalCopy = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("DestinationSnapshot"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DestinationSnapshot = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("DeletedTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DeletedTime = property.Value.GetDateTimeOffset("R");
                    continue;
                }
                if (property.NameEquals("RemainingRetentionDays"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.RemainingRetentionDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("AccessTier"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.AccessTier = new AccessTier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("AccessTierInferred"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.AccessTierInferred = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("ArchiveStatus"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ArchiveStatus = new ArchiveStatus(property.Value.GetString());
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "BlobProperties");
            writer.WriteStartElement("Last-Modified");
            writer.WriteValue(LastModified, "R");
            writer.WriteEndElement();
            writer.WriteStartElement("Etag");
            writer.WriteValue(Etag);
            writer.WriteEndElement();
            if (ContentLength != null)
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
            if (ContentMd5 != null)
            {
                writer.WriteStartElement("Content-MD5");
                writer.WriteValue(ContentMd5);
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
            if (BlobSequenceNumber != null)
            {
                writer.WriteStartElement("x-ms-blob-sequence-number");
                writer.WriteValue(BlobSequenceNumber.Value);
                writer.WriteEndElement();
            }
            if (BlobType != null)
            {
                writer.WriteStartElement("BlobType");
                writer.WriteValue(BlobType.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (LeaseStatus != null)
            {
                writer.WriteStartElement("LeaseStatus");
                writer.WriteValue(LeaseStatus.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (LeaseState != null)
            {
                writer.WriteStartElement("LeaseState");
                writer.WriteValue(LeaseState.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (LeaseDuration != null)
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
            if (CopyStatus != null)
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
            if (CopyCompletionTime != null)
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
            if (ServerEncrypted != null)
            {
                writer.WriteStartElement("ServerEncrypted");
                writer.WriteValue(ServerEncrypted.Value);
                writer.WriteEndElement();
            }
            if (IncrementalCopy != null)
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
            if (DeletedTime != null)
            {
                writer.WriteStartElement("DeletedTime");
                writer.WriteValue(DeletedTime.Value, "R");
                writer.WriteEndElement();
            }
            if (RemainingRetentionDays != null)
            {
                writer.WriteStartElement("RemainingRetentionDays");
                writer.WriteValue(RemainingRetentionDays.Value);
                writer.WriteEndElement();
            }
            if (AccessTier != null)
            {
                writer.WriteStartElement("AccessTier");
                writer.WriteValue(AccessTier.Value.ToString());
                writer.WriteEndElement();
            }
            if (AccessTierInferred != null)
            {
                writer.WriteStartElement("AccessTierInferred");
                writer.WriteValue(AccessTierInferred.Value);
                writer.WriteEndElement();
            }
            if (ArchiveStatus != null)
            {
                writer.WriteStartElement("ArchiveStatus");
                writer.WriteValue(ArchiveStatus.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static BlobProperties DeserializeBlobProperties(XElement element)
        {
            BlobProperties result = default;
            result = new BlobProperties(); DateTimeOffset value = default;
            var lastModified = element.Element("Last-Modified");
            if (lastModified != null)
            {
                value = lastModified.GetDateTimeOffsetValue("R");
            }
            result.LastModified = value;
            string value0 = default;
            var etag = element.Element("Etag");
            if (etag != null)
            {
                value0 = (string)etag;
            }
            result.Etag = value0;
            long? value1 = default;
            var contentLength = element.Element("Content-Length");
            if (contentLength != null)
            {
                value1 = (long?)contentLength;
            }
            result.ContentLength = value1;
            string value2 = default;
            var contentType = element.Element("Content-Type");
            if (contentType != null)
            {
                value2 = (string)contentType;
            }
            result.ContentType = value2;
            string value3 = default;
            var contentEncoding = element.Element("Content-Encoding");
            if (contentEncoding != null)
            {
                value3 = (string)contentEncoding;
            }
            result.ContentEncoding = value3;
            string value4 = default;
            var contentLanguage = element.Element("Content-Language");
            if (contentLanguage != null)
            {
                value4 = (string)contentLanguage;
            }
            result.ContentLanguage = value4;
            string value5 = default;
            var contentMD5 = element.Element("Content-MD5");
            if (contentMD5 != null)
            {
                value5 = (string)contentMD5;
            }
            result.ContentMd5 = value5;
            string value6 = default;
            var contentDisposition = element.Element("Content-Disposition");
            if (contentDisposition != null)
            {
                value6 = (string)contentDisposition;
            }
            result.ContentDisposition = value6;
            string value7 = default;
            var cacheControl = element.Element("Cache-Control");
            if (cacheControl != null)
            {
                value7 = (string)cacheControl;
            }
            result.CacheControl = value7;
            int? value8 = default;
            var xMsBlobSequenceNumber = element.Element("x-ms-blob-sequence-number");
            if (xMsBlobSequenceNumber != null)
            {
                value8 = (int?)xMsBlobSequenceNumber;
            }
            result.BlobSequenceNumber = value8;
            BlobType? value9 = default;
            var blobType = element.Element("BlobType");
            if (blobType != null)
            {
                value9 = blobType.Value.ToBlobType();
            }
            result.BlobType = value9;
            LeaseStatusType? value10 = default;
            var leaseStatus = element.Element("LeaseStatus");
            if (leaseStatus != null)
            {
                value10 = leaseStatus.Value.ToLeaseStatusType();
            }
            result.LeaseStatus = value10;
            LeaseStateType? value11 = default;
            var leaseState = element.Element("LeaseState");
            if (leaseState != null)
            {
                value11 = leaseState.Value.ToLeaseStateType();
            }
            result.LeaseState = value11;
            LeaseDurationType? value12 = default;
            var leaseDuration = element.Element("LeaseDuration");
            if (leaseDuration != null)
            {
                value12 = leaseDuration.Value.ToLeaseDurationType();
            }
            result.LeaseDuration = value12;
            string value13 = default;
            var copyId = element.Element("CopyId");
            if (copyId != null)
            {
                value13 = (string)copyId;
            }
            result.CopyId = value13;
            CopyStatusType? value14 = default;
            var copyStatus = element.Element("CopyStatus");
            if (copyStatus != null)
            {
                value14 = copyStatus.Value.ToCopyStatusType();
            }
            result.CopyStatus = value14;
            string value15 = default;
            var copySource = element.Element("CopySource");
            if (copySource != null)
            {
                value15 = (string)copySource;
            }
            result.CopySource = value15;
            string value16 = default;
            var copyProgress = element.Element("CopyProgress");
            if (copyProgress != null)
            {
                value16 = (string)copyProgress;
            }
            result.CopyProgress = value16;
            DateTimeOffset? value17 = default;
            var copyCompletionTime = element.Element("CopyCompletionTime");
            if (copyCompletionTime != null)
            {
                value17 = copyCompletionTime.GetDateTimeOffsetValue("R");
            }
            result.CopyCompletionTime = value17;
            string value18 = default;
            var copyStatusDescription = element.Element("CopyStatusDescription");
            if (copyStatusDescription != null)
            {
                value18 = (string)copyStatusDescription;
            }
            result.CopyStatusDescription = value18;
            bool? value19 = default;
            var serverEncrypted = element.Element("ServerEncrypted");
            if (serverEncrypted != null)
            {
                value19 = (bool?)serverEncrypted;
            }
            result.ServerEncrypted = value19;
            bool? value20 = default;
            var incrementalCopy = element.Element("IncrementalCopy");
            if (incrementalCopy != null)
            {
                value20 = (bool?)incrementalCopy;
            }
            result.IncrementalCopy = value20;
            string value21 = default;
            var destinationSnapshot = element.Element("DestinationSnapshot");
            if (destinationSnapshot != null)
            {
                value21 = (string)destinationSnapshot;
            }
            result.DestinationSnapshot = value21;
            DateTimeOffset? value22 = default;
            var deletedTime = element.Element("DeletedTime");
            if (deletedTime != null)
            {
                value22 = deletedTime.GetDateTimeOffsetValue("R");
            }
            result.DeletedTime = value22;
            int? value23 = default;
            var remainingRetentionDays = element.Element("RemainingRetentionDays");
            if (remainingRetentionDays != null)
            {
                value23 = (int?)remainingRetentionDays;
            }
            result.RemainingRetentionDays = value23;
            AccessTier? value24 = default;
            var accessTier = element.Element("AccessTier");
            if (accessTier != null)
            {
                value24 = new AccessTier(accessTier.Value);
            }
            result.AccessTier = value24;
            bool? value25 = default;
            var accessTierInferred = element.Element("AccessTierInferred");
            if (accessTierInferred != null)
            {
                value25 = (bool?)accessTierInferred;
            }
            result.AccessTierInferred = value25;
            ArchiveStatus? value26 = default;
            var archiveStatus = element.Element("ArchiveStatus");
            if (archiveStatus != null)
            {
                value26 = new ArchiveStatus(archiveStatus.Value);
            }
            result.ArchiveStatus = value26;
            return result;
        }
    }
}
