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
    public partial class Banana : IXmlSerializable, IPersistableModel<Banana>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "banana");
            if (Optional.IsDefined(Name))
            {
                writer.WriteStartElement("name");
                writer.WriteValue(Name);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(Flavor))
            {
                writer.WriteStartElement("flavor");
                writer.WriteValue(Flavor);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(Expiration))
            {
                writer.WriteStartElement("expiration");
                writer.WriteValue(Expiration.Value, "O");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static Banana DeserializeBanana(XElement element, ModelReaderWriterOptions options = null)
        {
            string name = default;
            string flavor = default;
            DateTimeOffset? expiration = default;
            if (element.Element("name") is XElement nameElement)
            {
                name = (string)nameElement;
            }
            if (element.Element("flavor") is XElement flavorElement)
            {
                flavor = (string)flavorElement;
            }
            if (element.Element("expiration") is XElement expirationElement)
            {
                expiration = expirationElement.GetDateTimeOffsetValue("O");
            }
            return new Banana(name, flavor, expiration, default);
        }

        BinaryData IPersistableModel<Banana>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<Banana>;
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

        Banana IPersistableModel<Banana>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Banana)} does not support '{options.Format}' format.");
            }

            return DeserializeBanana(XElement.Load(data.ToStream()), options);
        }

        string IPersistableModel<Banana>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
