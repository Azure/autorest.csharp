// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class Blobs : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (BlobPrefix != null)
            {
                writer.WritePropertyName("BlobPrefix");
                writer.WriteStartArray();
                foreach (var item in BlobPrefix)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Blob != null)
            {
                writer.WritePropertyName("Blob");
                writer.WriteStartArray();
                foreach (var item in Blob)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static Blobs DeserializeBlobs(JsonElement element)
        {
            Blobs result = new Blobs();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("BlobPrefix"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.BlobPrefix = new List<BlobPrefix>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.BlobPrefix.Add(V100.BlobPrefix.DeserializeBlobPrefix(item));
                    }
                    continue;
                }
                if (property.NameEquals("Blob"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Blob = new List<Blob>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Blob.Add(V100.Blob.DeserializeBlob(item));
                    }
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Blobs");
            if (BlobPrefix != null)
            {
                foreach (var item in BlobPrefix)
                {
                    writer.WriteObjectValue(item, "BlobPrefix");
                }
            }
            if (Blob != null)
            {
                foreach (var item in Blob)
                {
                    writer.WriteObjectValue(item, "Blob");
                }
            }
            writer.WriteEndElement();
        }
        internal static Blobs DeserializeBlobs(XElement element)
        {
            Blobs result = default;
            result.BlobPrefix = new List<BlobPrefix>();
            result.BlobPrefix = new List<BlobPrefix>();
            foreach (var e in element.Elements("BlobPrefix"))
            {
                BlobPrefix value = default;
                var blobPrefix = e.Element("BlobPrefix");
                if (blobPrefix != null)
                {
                    value = V100.BlobPrefix.DeserializeBlobPrefix(blobPrefix);
                }
                result.BlobPrefix.Add(value);
            }
            result.Blob = new List<Blob>();
            result.Blob = new List<Blob>();
            foreach (var e0 in element.Elements("Blob"))
            {
                Blob value = default;
                var blob = e0.Element("Blob");
                if (blob != null)
                {
                    value = V100.Blob.DeserializeBlob(blob);
                }
                result.Blob.Add(value);
            }
            return result;
        }
    }
}
