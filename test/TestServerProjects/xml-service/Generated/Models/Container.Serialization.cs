// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Container : IXmlSerializable, IModel<Container>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Container");
            writer.WriteStartElement("Name");
            writer.WriteValue(Name);
            writer.WriteEndElement();
            writer.WriteObjectValue(Properties, "Properties");
            if (Optional.IsCollectionDefined(Metadata))
            {
                foreach (var pair in Metadata)
                {
                    writer.WriteStartElement("String");
                    writer.WriteValue(pair.Value);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        internal static Container DeserializeContainer(XElement element, ModelReaderWriterOptions options = null)
        {
            string name = default;
            ContainerProperties properties = default;
            IReadOnlyDictionary<string, string> metadata = default;
            if (element.Element("Name") is XElement nameElement)
            {
                name = (string)nameElement;
            }
            if (element.Element("Properties") is XElement propertiesElement)
            {
                properties = ContainerProperties.DeserializeContainerProperties(propertiesElement);
            }
            if (element.Element("Metadata") is XElement metadataElement)
            {
                var dictionary = new Dictionary<string, string>();
                foreach (var e in metadataElement.Elements())
                {
                    dictionary.Add(e.Name.LocalName, (string)e);
                }
                metadata = dictionary;
            }
            return new Container(name, properties, metadata, default);
        }

        BinaryData IModel<Container>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<Container>;
            bool isValid = options.Format == ModelReaderWriterFormat.Json && implementsJson || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
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

        Container IModel<Container>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return DeserializeContainer(XElement.Load(data.ToStream()), options);
        }

        ModelReaderWriterFormat IModel<Container>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Xml;
    }
}
