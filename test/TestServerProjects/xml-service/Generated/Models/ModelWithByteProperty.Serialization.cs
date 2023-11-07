// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ModelWithByteProperty : IXmlSerializable, IModel<ModelWithByteProperty>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "ModelWithByteProperty");
            if (Optional.IsDefined(Bytes))
            {
                writer.WriteStartElement("Bytes");
                writer.WriteValue(Bytes, "D");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static ModelWithByteProperty DeserializeModelWithByteProperty(XElement element, ModelReaderWriterOptions options = null)
        {
            byte[] bytes = default;
            if (element.Element("Bytes") is XElement bytesElement)
            {
                bytes = bytesElement.GetBytesFromBase64Value("D");
            }
            return new ModelWithByteProperty(bytes, default);
        }

        BinaryData IModel<ModelWithByteProperty>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<ModelWithByteProperty>;
            bool isValid = options.Format == ModelReaderWriterFormat.Json && implementsJson || options.Format == ModelReaderWriterFormat.Wire;
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

        ModelWithByteProperty IModel<ModelWithByteProperty>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithByteProperty)} does not support '{options.Format}' format.");
            }

            return DeserializeModelWithByteProperty(XElement.Load(data.ToStream()), options);
        }

        ModelReaderWriterFormat IModel<ModelWithByteProperty>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Xml;
    }
}
