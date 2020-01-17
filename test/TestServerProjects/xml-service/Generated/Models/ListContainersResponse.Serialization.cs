// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ListContainersResponse : IUtf8JsonSerializable, IXmlSerializable
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
            if (Containers != null)
            {
                writer.WritePropertyName("Containers");
                writer.WriteStartArray();
                foreach (var item in Containers)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Containers = new List<Container>();
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
            writer.WriteStartAttribute("ServiceEndpoint");
            writer.WriteValue(ServiceEndpoint);
            writer.WriteEndAttribute();
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
            writer.WriteStartElement("NextMarker");
            writer.WriteValue(NextMarker);
            writer.WriteEndElement();
            if (Containers != null)
            {
                writer.WriteStartElement("Containers");
                foreach (var item in Containers)
                {
                    writer.WriteObjectValue(item, "Container");
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static ListContainersResponse DeserializeListContainersResponse(XElement element)
        {
            ListContainersResponse result = default;
            result = new ListContainersResponse(); var serviceEndpoint = element.Attribute("ServiceEndpoint");
            if (serviceEndpoint != null)
            {
                result.ServiceEndpoint = (string)serviceEndpoint;
            }
            string value = default;
            var prefix = element.Element("Prefix");
            if (prefix != null)
            {
                value = (string)prefix;
            }
            result.Prefix = value;
            string? value0 = default;
            var marker = element.Element("Marker");
            if (marker != null)
            {
                value0 = (string?)marker;
            }
            result.Marker = value0;
            int value1 = default;
            var maxResults = element.Element("MaxResults");
            if (maxResults != null)
            {
                value1 = (int)maxResults;
            }
            result.MaxResults = value1;
            string value2 = default;
            var nextMarker = element.Element("NextMarker");
            if (nextMarker != null)
            {
                value2 = (string)nextMarker;
            }
            result.NextMarker = value2;
            var containers = element.Element("Containers");
            if (containers != null)
            {
                result.Containers = new List<Container>();
                foreach (var e in containers.Elements("Container"))
                {
                    Container value3 = default;
                    value3 = Container.DeserializeContainer(e);
                    result.Containers.Add(value3);
                }
            }
            return result;
        }
    }
}
