// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Serialization;

namespace xml_service.Models
{
    public partial class ListContainersResponse : IXmlSerializable, IXmlModelSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => ((IXmlModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartElement("EnumerationResults");
            writer.WriteStartAttribute("ServiceEndpoint");
            writer.WriteValue(ServiceEndpoint);
            writer.WriteEndAttribute();
            writer.WriteStartElement("Prefix");
            writer.WriteValue(Prefix);
            writer.WriteEndElement();
            if (Optional.IsDefined(Marker))
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
            if (Optional.IsCollectionDefined(Containers))
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

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeListContainersResponse(XElement.Load(data.ToStream()), options);
        }

        internal static ListContainersResponse DeserializeListContainersResponse(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            string serviceEndpoint = default;
            string prefix = default;
            string marker = default;
            int maxResults = default;
            string nextMarker = default;
            IReadOnlyList<Container> containers = default;
            if (element.Attribute("ServiceEndpoint") is XAttribute serviceEndpointAttribute)
            {
                serviceEndpoint = (string)serviceEndpointAttribute;
            }
            if (element.Element("Prefix") is XElement prefixElement)
            {
                prefix = (string)prefixElement;
            }
            if (element.Element("Marker") is XElement markerElement)
            {
                marker = (string)markerElement;
            }
            if (element.Element("MaxResults") is XElement maxResultsElement)
            {
                maxResults = (int)maxResultsElement;
            }
            if (element.Element("NextMarker") is XElement nextMarkerElement)
            {
                nextMarker = (string)nextMarkerElement;
            }
            if (element.Element("Containers") is XElement containersElement)
            {
                var array = new List<Container>();
                foreach (var e in containersElement.Elements("Container"))
                {
                    array.Add(Container.DeserializeContainer(e));
                }
                containers = array;
            }
            return new ListContainersResponse(serviceEndpoint, prefix, marker, maxResults, containers, nextMarker);
        }
    }
}
