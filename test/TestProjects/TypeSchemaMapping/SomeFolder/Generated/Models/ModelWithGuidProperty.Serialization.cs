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

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithGuidProperty : IXmlSerializable, IPersistableModel<ModelWithGuidProperty>
    {
        private void WriteInternal(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "ModelWithGuidProperty");
            if (options.Format != "W" && Optional.IsDefined(ModelProperty))
            {
                writer.WriteStartElement("ModelProperty");
                writer.WriteValue(ModelProperty.Value);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => WriteInternal(writer, nameHint, new ModelReaderWriterOptions("W"));

        internal static ModelWithGuidProperty DeserializeModelWithGuidProperty(XElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            Guid? modelProperty = default;
            if (element.Element("ModelProperty") is XElement modelPropertyElement)
            {
                modelProperty = new Guid(modelPropertyElement.Value);
            }
            return new ModelWithGuidProperty(modelProperty, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<ModelWithGuidProperty>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithGuidProperty>)this).GetFormatFromOptions(options) : options.Format;

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
                    throw new FormatException($"The model {nameof(ModelWithGuidProperty)} does not support writing '{options.Format}' format.");
            }
        }

        ModelWithGuidProperty IPersistableModel<ModelWithGuidProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithGuidProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeModelWithGuidProperty(XElement.Load(data.ToStream()), options);
                default:
                    throw new FormatException($"The model {nameof(ModelWithGuidProperty)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelWithGuidProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
