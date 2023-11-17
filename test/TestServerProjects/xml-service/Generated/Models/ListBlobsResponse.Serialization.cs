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
    public partial class ListBlobsResponse : IXmlSerializable, IPersistableModel<ListBlobsResponse>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "EnumerationResults");
            if (Optional.IsDefined(ServiceEndpoint))
            {
                writer.WriteStartAttribute("ServiceEndpoint");
                writer.WriteValue(ServiceEndpoint);
                writer.WriteEndAttribute();
            }
            writer.WriteStartAttribute("ContainerName");
            writer.WriteValue(ContainerName);
            writer.WriteEndAttribute();
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
            writer.WriteObjectValue(Blobs, "Blobs");
            writer.WriteStartElement("NextMarker");
            writer.WriteValue(NextMarker);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        internal static ListBlobsResponse DeserializeListBlobsResponse(XElement element, ModelReaderWriterOptions options = null)
        {
            string serviceEndpoint = default;
            string containerName = default;
            string prefix = default;
            string marker = default;
            int maxResults = default;
            string delimiter = default;
            Blobs blobs = default;
            string nextMarker = default;
            if (element.Attribute("ServiceEndpoint") is XAttribute serviceEndpointAttribute)
            {
                serviceEndpoint = (string)serviceEndpointAttribute;
            }
            if (element.Attribute("ContainerName") is XAttribute containerNameAttribute)
            {
                containerName = (string)containerNameAttribute;
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
            if (element.Element("Delimiter") is XElement delimiterElement)
            {
                delimiter = (string)delimiterElement;
            }
            if (element.Element("Blobs") is XElement blobsElement)
            {
                blobs = Blobs.DeserializeBlobs(blobsElement);
            }
            if (element.Element("NextMarker") is XElement nextMarkerElement)
            {
                nextMarker = (string)nextMarkerElement;
            }
            return new ListBlobsResponse(serviceEndpoint, containerName, prefix, marker, maxResults, delimiter, blobs, nextMarker, default);
        }

        BinaryData IPersistableModel<ListBlobsResponse>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<ListBlobsResponse>;
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

        ListBlobsResponse IPersistableModel<ListBlobsResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ListBlobsResponse)} does not support '{options.Format}' format.");
            }

            return DeserializeListBlobsResponse(XElement.Load(data.ToStream()), options);
        }

        string IPersistableModel<ListBlobsResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
