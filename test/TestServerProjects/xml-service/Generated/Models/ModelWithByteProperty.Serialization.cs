// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ModelWithByteProperty : IXmlSerializable
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

        internal static ModelWithByteProperty DeserializeModelWithByteProperty(XElement element)
        {
            byte[] bytes = default;
            if (element.Element("Bytes") is XElement bytesElement)
            {
                bytes = bytesElement.GetBytesFromBase64Value("D");
            }
            return new ModelWithByteProperty(bytes);
        }
    }
}
