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
    public partial class ComplexTypeWithMeta : IXmlSerializable, IModelSerializable<ComplexTypeWithMeta>
    {
        private void Serialize(XmlWriter writer, string nameHint, ModelSerializerOptions options)
        {
            writer.WriteStartElement(nameHint ?? "XMLComplexTypeWithMeta");
            if (Optional.IsDefined(ID))
            {
                writer.WriteStartElement("ID");
                writer.WriteValue(ID);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, nameHint, ModelSerializerOptions.DefaultWireOptions);

        internal static ComplexTypeWithMeta DeserializeComplexTypeWithMeta(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
            string id = default;
            if (element.Element("ID") is XElement idElement)
            {
                id = (string)idElement;
            }
            return new ComplexTypeWithMeta(id, default);
        }

        BinaryData IModelSerializable<ComplexTypeWithMeta>.Serialize(ModelSerializerOptions options)
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

        ComplexTypeWithMeta IModelSerializable<ComplexTypeWithMeta>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeComplexTypeWithMeta(XElement.Load(data.ToStream()), options);
        }

        /// <summary> Converts a <see cref="ComplexTypeWithMeta"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ComplexTypeWithMeta"/> to convert. </param>
        public static implicit operator RequestContent(ComplexTypeWithMeta model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ComplexTypeWithMeta"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ComplexTypeWithMeta(Response response)
        {
            if (response is null)
            {
                return null;
            }

            return DeserializeComplexTypeWithMeta(XElement.Load(response.ContentStream), ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
