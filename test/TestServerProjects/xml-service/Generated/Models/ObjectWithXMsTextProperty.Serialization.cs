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

namespace xml_service.Models
{
    public partial class ObjectWithXMsTextProperty : IXmlSerializable, IPersistableModel<ObjectWithXMsTextProperty>
    {
        private void WriteInternal(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "Data");
            if (Optional.IsDefined(Language))
            {
                writer.WriteStartAttribute("language");
                writer.WriteValue(Language);
                writer.WriteEndAttribute();
            }
            writer.WriteValue(Content);
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => WriteInternal(writer, nameHint, ModelSerializationExtensions.WireOptions);

        internal static ObjectWithXMsTextProperty DeserializeObjectWithXMsTextProperty(XElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            string language = default;
            string content = default;
            if (element.Attribute("language") is XAttribute languageAttribute)
            {
                language = (string)languageAttribute;
            }
            content = (string)element;
            return new ObjectWithXMsTextProperty(language, content, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<ObjectWithXMsTextProperty>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ObjectWithXMsTextProperty>)this).GetFormatFromOptions(options) : options.Format;

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
                    throw new FormatException($"The model {nameof(ObjectWithXMsTextProperty)} does not support writing '{options.Format}' format.");
            }
        }

        ObjectWithXMsTextProperty IPersistableModel<ObjectWithXMsTextProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ObjectWithXMsTextProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeObjectWithXMsTextProperty(XElement.Load(data.ToStream()), options);
                default:
                    throw new FormatException($"The model {nameof(ObjectWithXMsTextProperty)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ObjectWithXMsTextProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
