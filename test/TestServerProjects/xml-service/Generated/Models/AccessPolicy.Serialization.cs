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
    public partial class AccessPolicy : IXmlSerializable, IModel<AccessPolicy>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AccessPolicy");
            writer.WriteStartElement("Start");
            writer.WriteValue(Start, "O");
            writer.WriteEndElement();
            writer.WriteStartElement("Expiry");
            writer.WriteValue(Expiry, "O");
            writer.WriteEndElement();
            writer.WriteStartElement("Permission");
            writer.WriteValue(Permission);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        internal static AccessPolicy DeserializeAccessPolicy(XElement element, ModelReaderWriterOptions options = null)
        {
            DateTimeOffset start = default;
            DateTimeOffset expiry = default;
            string permission = default;
            if (element.Element("Start") is XElement startElement)
            {
                start = startElement.GetDateTimeOffsetValue("O");
            }
            if (element.Element("Expiry") is XElement expiryElement)
            {
                expiry = expiryElement.GetDateTimeOffsetValue("O");
            }
            if (element.Element("Permission") is XElement permissionElement)
            {
                permission = (string)permissionElement;
            }
            return new AccessPolicy(start, expiry, permission, default);
        }

        BinaryData IModel<AccessPolicy>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<AccessPolicy>;
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

        AccessPolicy IModel<AccessPolicy>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AccessPolicy)} does not support '{options.Format}' format.");
            }

            return DeserializeAccessPolicy(XElement.Load(data.ToStream()), options);
        }

        ModelReaderWriterFormat IModel<AccessPolicy>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Xml;
    }
}
