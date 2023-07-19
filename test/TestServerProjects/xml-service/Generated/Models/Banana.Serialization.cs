// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Serialization;

namespace xml_service.Models
{
    public partial class Banana : IXmlSerializable, IXmlModelSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => ((IXmlModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartElement("banana");
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

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeBanana(XElement.Load(data.ToStream()), options);
        }

        internal static Banana DeserializeBanana(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
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
            return new Banana(name, flavor, expiration);
        }
    }
}
