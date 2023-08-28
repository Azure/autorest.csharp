// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace xml_service.Models
{
    public partial class ModelWithByteProperty : IXmlSerializable, IModelSerializable<ModelWithByteProperty>
    {
        private void Serialize(XmlWriter writer, string nameHint, ModelSerializerOptions options)
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

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, nameHint, ModelSerializerOptions.DefaultWireOptions);

        internal static ModelWithByteProperty DeserializeModelWithByteProperty(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
            byte[] bytes = default;
            if (element.Element("Bytes") is XElement bytesElement)
            {
                bytes = bytesElement.GetBytesFromBase64Value("D");
            }
            return new ModelWithByteProperty(bytes, default);
        }

        BinaryData IModelSerializable<ModelWithByteProperty>.Serialize(ModelSerializerOptions options)
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

        ModelWithByteProperty IModelSerializable<ModelWithByteProperty>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeModelWithByteProperty(XElement.Load(data.ToStream()), options);
        }

        public static implicit operator RequestContent(ModelWithByteProperty model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ModelWithByteProperty(Response response)
        {
            if (response is null)
            {
                return null;
            }

            return DeserializeModelWithByteProperty(XElement.Load(response.ContentStream), ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
