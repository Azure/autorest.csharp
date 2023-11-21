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
            var format = options.Format == "W" ? ((IPersistableModel<Banana>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    {
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
                default:
                    throw new InvalidOperationException($"The model {nameof(Banana)} does not support '{options.Format}' format.");
            }
        }

        Banana IPersistableModel<Banana>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Banana>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeBanana(XElement.Load(data.ToStream()), options);
                default:
                    throw new InvalidOperationException($"The model {nameof(Banana)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<Banana>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
