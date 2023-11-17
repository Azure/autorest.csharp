// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ListContainersResponse : IXmlSerializable, IPersistableModel<ListContainersResponse>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "EnumerationResults");
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

        internal static ListContainersResponse DeserializeListContainersResponse(XElement element, ModelReaderWriterOptions options = null)
        {
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
            return new ListContainersResponse(serviceEndpoint, prefix, marker, maxResults, containers, nextMarker, default);
        }

        BinaryData IPersistableModel<ListContainersResponse>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<ListContainersResponse>;
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

        ListContainersResponse IPersistableModel<ListContainersResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ListContainersResponse)} does not support '{options.Format}' format.");
            }

            return DeserializeListContainersResponse(XElement.Load(data.ToStream()), options);
        }

        string IPersistableModel<ListContainersResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
