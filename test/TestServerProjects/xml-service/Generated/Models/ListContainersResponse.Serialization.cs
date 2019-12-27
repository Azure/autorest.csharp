// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class ListContainersResponse : IXmlSerializable, IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ServiceEndpoint");
            writer.WriteStringValue(ServiceEndpoint);
            writer.WritePropertyName("Prefix");
            writer.WriteStringValue(Prefix);
            if (Marker != null)
            {
                writer.WritePropertyName("Marker");
                writer.WriteStringValue(Marker);
            }
            writer.WritePropertyName("MaxResults");
            writer.WriteNumberValue(MaxResults);
            writer.WritePropertyName("Containers");
            writer.WriteStartArray();
            foreach (var item in Containers)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("NextMarker");
            writer.WriteStringValue(NextMarker);
            writer.WriteEndObject();
        }
        internal static ListContainersResponse DeserializeListContainersResponse(JsonElement element)
        {
            ListContainersResponse result = new ListContainersResponse();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ServiceEndpoint"))
                {
                    result.ServiceEndpoint = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Prefix"))
                {
                    result.Prefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Marker"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Marker = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("MaxResults"))
                {
                    result.MaxResults = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("Containers"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Containers.Add(Container.DeserializeContainer(item));
                    }
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
            if (Marker != null)
            {
                writer.WriteStartElement("Marker");
                writer.WriteValue(Marker);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("MaxResults");
            writer.WriteValue(MaxResults);
            writer.WriteEndElement();
            writer.WriteStartElement("Containers");
            writer.WriteEndElement();
            writer.WriteStartElement("NextMarker");
            writer.WriteValue(NextMarker);
            writer.WriteEndElement();
        }
        internal static ListContainersResponse DeserializeListContainersResponse(XElement element)
        {
            ListContainersResponse result = new ListContainersResponse();
            var serviceEndpoint = element.Attribute("ServiceEndpoint");
            if (serviceEndpoint != null)
            {
                result.ServiceEndpoint = (string)serviceEndpoint;
            }
            var prefix = element.Element("Prefix");
            if (prefix != null)
            {
                result.Prefix = (string)prefix;
            }
            var marker = element.Element("Marker");
            if (marker != null)
            {
                result.Marker = (string?)marker;
            }
            var maxResults = element.Element("MaxResults");
            if (maxResults != null)
            {
                result.MaxResults = (int)maxResults;
            }
            var containers = element.Element("Containers");
            if (containers != null)
            {
                ICollection<Container> value = new List<Container>();
                result.Containers = value;
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
