// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace xml_service.Models
{
    public partial class ListContainersResponse : IXmlSerializable, IModelSerializable<ListContainersResponse>
    {
        private void Serialize(XmlWriter writer, string nameHint, ModelSerializerOptions options)
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

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, nameHint, ModelSerializerOptions.DefaultWireOptions);

        internal static ListContainersResponse DeserializeListContainersResponse(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
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

        BinaryData IModelSerializable<ListContainersResponse>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            options ??= ModelSerializerOptions.DefaultWireOptions;
            using MemoryStream stream = new MemoryStream();
            using XmlWriter writer = XmlWriter.Create(stream);
            Serialize(writer, null, options);
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

        ListContainersResponse IModelSerializable<ListContainersResponse>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeListContainersResponse(XElement.Load(data.ToStream()), options);
        }

        public static implicit operator RequestContent(ListContainersResponse model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ListContainersResponse(Response response)
        {
            if (response is null)
            {
                return null;
            }

            return DeserializeListContainersResponse(XElement.Load(response.ContentStream), ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
