// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class Blobs : IXmlSerializable, IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("BlobPrefix");
            writer.WriteStartArray();
            foreach (var item in BlobPrefix)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("Blob");
            writer.WriteStartArray();
            foreach (var item0 in Blob)
            {
                writer.WriteObjectValue(item0);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static Blobs DeserializeBlobs(JsonElement element)
        {
            Blobs result = new Blobs();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("BlobPrefix"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.BlobPrefix.Add(V100.BlobPrefix.DeserializeBlobPrefix(item));
                    }
                    continue;
                }
                if (property.NameEquals("Blob"))
                {
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
            writer.WriteStartElement(nameHint ?? "AutoBlobs");
            writer.WriteStartElement("BlobPrefix");
            writer.WriteEndElement();
            writer.WriteStartElement("Blob");
            writer.WriteEndElement();
        }
        internal static Blobs DeserializeBlobs(XElement element)
        {
            Blobs result = new Blobs();
            var blobPrefix = element.Element("BlobPrefix");
            if (blobPrefix != null)
            {
                ICollection<BlobPrefix> value = new List<BlobPrefix>();
                result.BlobPrefix = value;
            }
            var blob = element.Element("Blob");
            if (blob != null)
            {
                ICollection<Blob> value = new List<Blob>();
                result.Blob = value;
            }
            return result;
        }
    }
}
