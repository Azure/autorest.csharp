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
    public partial class RootWithRefAndNoMeta : IXmlSerializable, IModelSerializable<RootWithRefAndNoMeta>
    {
        private void Serialize(XmlWriter writer, string nameHint, ModelSerializerOptions options)
        {
            writer.WriteStartElement(nameHint ?? "RootWithRefAndNoMeta");
            if (Optional.IsDefined(RefToModel))
            {
                writer.WriteObjectValue(RefToModel, "RefToModel");
            }
            if (Optional.IsDefined(Something))
            {
                writer.WriteStartElement("Something");
                writer.WriteValue(Something);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, nameHint, ModelSerializerOptions.DefaultWireOptions);

        internal static RootWithRefAndNoMeta DeserializeRootWithRefAndNoMeta(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
            ComplexTypeNoMeta refToModel = default;
            string something = default;
            if (element.Element("RefToModel") is XElement refToModelElement)
            {
                refToModel = ComplexTypeNoMeta.DeserializeComplexTypeNoMeta(refToModelElement);
            }
            if (element.Element("Something") is XElement somethingElement)
            {
                something = (string)somethingElement;
            }
            return new RootWithRefAndNoMeta(refToModel, something, default);
        }

        BinaryData IModelSerializable<RootWithRefAndNoMeta>.Serialize(ModelSerializerOptions options)
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

        RootWithRefAndNoMeta IModelSerializable<RootWithRefAndNoMeta>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeRootWithRefAndNoMeta(XElement.Load(data.ToStream()), options);
        }

        /// <summary> Converts a <see cref="RootWithRefAndNoMeta"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="RootWithRefAndNoMeta"/> to convert. </param>
        public static implicit operator RequestContent(RootWithRefAndNoMeta model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="RootWithRefAndNoMeta"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator RootWithRefAndNoMeta(Response response)
        {
            if (response is null)
            {
                return null;
            }

            return DeserializeRootWithRefAndNoMeta(XElement.Load(response.ContentStream), ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
