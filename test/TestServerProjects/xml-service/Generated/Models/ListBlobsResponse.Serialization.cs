// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class ListBlobsResponse : IXmlSerializable, IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ServiceEndpoint");
            writer.WriteStringValue(ServiceEndpoint);
            writer.WritePropertyName("ContainerName");
            writer.WriteStringValue(ContainerName);
            writer.WritePropertyName("Prefix");
            writer.WriteStringValue(Prefix);
            writer.WritePropertyName("Marker");
            writer.WriteStringValue(Marker);
            writer.WritePropertyName("MaxResults");
            writer.WriteNumberValue(MaxResults);
            writer.WritePropertyName("Delimiter");
            writer.WriteStringValue(Delimiter);
            writer.WritePropertyName("Blobs");
            writer.WriteObjectValue(Blobs);
            writer.WritePropertyName("NextMarker");
            writer.WriteStringValue(NextMarker);
            writer.WriteEndObject();
        }
        internal static ListBlobsResponse DeserializeListBlobsResponse(JsonElement element)
        {
            ListBlobsResponse result = new ListBlobsResponse();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ServiceEndpoint"))
                {
                    result.ServiceEndpoint = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ContainerName"))
                {
                    result.ContainerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Prefix"))
                {
                    result.Prefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Marker"))
                {
                    result.Marker = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("MaxResults"))
                {
                    result.MaxResults = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("Delimiter"))
                {
                    result.Delimiter = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Blobs"))
                {
                    result.Blobs = Blobs.DeserializeBlobs(property.Value);
                    continue;
                }
                if (property.NameEquals("NextMarker"))
                {
                    result.NextMarker = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "EnumerationResults");
            writer.WriteStartElement("Prefix");
            writer.WriteValue(Prefix);
            writer.WriteEndElement();
            writer.WriteStartElement("Marker");
            writer.WriteValue(Marker);
            writer.WriteEndElement();
            writer.WriteStartElement("MaxResults");
            writer.WriteValue(MaxResults);
            writer.WriteEndElement();
            writer.WriteStartElement("Delimiter");
            writer.WriteValue(Delimiter);
            writer.WriteEndElement();
            writer.WriteStartElement("Blobs");
            writer.WriteObjectValue(Blobs, null);
            writer.WriteEndElement();
            writer.WriteStartElement("NextMarker");
            writer.WriteValue(NextMarker);
            writer.WriteEndElement();
        }
        internal static ListBlobsResponse DeserializeListBlobsResponse(XElement element)
        {
            ListBlobsResponse result = new ListBlobsResponse();
            var serviceEndpoint = element.Attribute("ServiceEndpoint");
            if (serviceEndpoint != null)
            {
                result.ServiceEndpoint = (string)serviceEndpoint;
            }
            var containerName = element.Attribute("ContainerName");
            if (containerName != null)
            {
                result.ContainerName = (string)containerName;
            }
            var prefix = element.Element("Prefix");
            if (prefix != null)
            {
                result.Prefix = (string)prefix;
            }
            var marker = element.Element("Marker");
            if (marker != null)
            {
                result.Marker = (string)marker;
            }
            var maxResults = element.Element("MaxResults");
            if (maxResults != null)
            {
                result.MaxResults = (int)maxResults;
            }
            var delimiter = element.Element("Delimiter");
            if (delimiter != null)
            {
                result.Delimiter = (string)delimiter;
            }
            var blobs = element.Element("Blobs");
            if (blobs != null)
            {
                result.Blobs = Blobs.DeserializeBlobs(blobs);
            }
            var nextMarker = element.Element("NextMarker");
            if (nextMarker != null)
            {
                result.NextMarker = (string)nextMarker;
            }
            return result;
        }
    }
}
