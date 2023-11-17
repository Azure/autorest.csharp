// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class SignedIdentifier : IXmlSerializable, IPersistableModel<SignedIdentifier>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "SignedIdentifier");
            writer.WriteStartElement("Id");
            writer.WriteValue(Id);
            writer.WriteEndElement();
            writer.WriteObjectValue(AccessPolicy, "AccessPolicy");
            writer.WriteEndElement();
        }

        internal static SignedIdentifier DeserializeSignedIdentifier(XElement element, ModelReaderWriterOptions options = null)
        {
            string id = default;
            AccessPolicy accessPolicy = default;
            if (element.Element("Id") is XElement idElement)
            {
                id = (string)idElement;
            }
            if (element.Element("AccessPolicy") is XElement accessPolicyElement)
            {
                accessPolicy = AccessPolicy.DeserializeAccessPolicy(accessPolicyElement);
            }
            return new SignedIdentifier(id, accessPolicy, default);
        }

        BinaryData IPersistableModel<SignedIdentifier>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<SignedIdentifier>;
            bool isValid = options.Format == "J" && implementsJson || options.Format == "W";
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

        SignedIdentifier IPersistableModel<SignedIdentifier>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SignedIdentifier)} does not support '{options.Format}' format.");
            }

            return DeserializeSignedIdentifier(XElement.Load(data.ToStream()), options);
        }

        string IPersistableModel<SignedIdentifier>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
