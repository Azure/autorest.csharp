// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Serialization;

namespace xml_service.Models
{
    public partial class ListBlobsResponse : IXmlSerializable, IXmlModelSerializable
    {
        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options) => ((IXmlSerializable)this).Write(writer, null, options);

        void IXmlSerializable.Write(XmlWriter writer, string nameHint, ModelSerializerOptions options)
        {
            writer.WriteStartElement("EnumerationResults");
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
            writer.WriteObjectValue(Blobs, "Blobs", options);
            writer.WriteStartElement("NextMarker");
            writer.WriteValue(NextMarker);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeListBlobsResponse(XElement.Load(data.ToStream()), options);
        }

        internal static ListBlobsResponse DeserializeListBlobsResponse(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
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
            return new ListBlobsResponse(serviceEndpoint, containerName, prefix, marker, maxResults, delimiter, blobs, nextMarker);
        }
    }
}
