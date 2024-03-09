// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using xml_service;

namespace xml_service.Models
{
    public partial class ComplexTypeNoMeta : IXmlSerializable, IPersistableModel<ComplexTypeNoMeta>
    {
        private void WriteInternal(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "ComplexTypeNoMeta");
            if (Optional.IsDefined(ID))
            {
                writer.WriteStartElement("ID");
                writer.WriteValue(ID);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => WriteInternal(writer, nameHint, new ModelReaderWriterOptions("W"));

        internal static ComplexTypeNoMeta DeserializeComplexTypeNoMeta(XElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            string id = default;
            if (element.Element("ID") is XElement idElement)
            {
                id = (string)idElement;
            }
            return new ComplexTypeNoMeta(id, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<ComplexTypeNoMeta>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComplexTypeNoMeta>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    {
                        using MemoryStream stream = new MemoryStream();
                        using XmlWriter writer = XmlWriter.Create(stream);
                        WriteInternal(writer, null, options);
                        writer.Flush();
                        return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                    }
                default:
                    throw new FormatException($"The model {nameof(ComplexTypeNoMeta)} does not support '{options.Format}' format.");
            }
        }

        ComplexTypeNoMeta IPersistableModel<ComplexTypeNoMeta>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComplexTypeNoMeta>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeComplexTypeNoMeta(XElement.Load(data.ToStream()), options);
                default:
                    throw new FormatException($"The model {nameof(ComplexTypeNoMeta)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ComplexTypeNoMeta>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
