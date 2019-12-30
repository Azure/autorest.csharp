// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class Banana : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Flavor != null)
            {
                writer.WritePropertyName("flavor");
                writer.WriteStringValue(Flavor);
            }
            if (Expiration != null)
            {
                writer.WritePropertyName("expiration");
                writer.WriteStringValue(Expiration.Value, "S");
            }
            writer.WriteEndObject();
        }
        internal static Banana DeserializeBanana(JsonElement element)
        {
            Banana result = new Banana();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("flavor"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Flavor = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("expiration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Expiration = property.Value.GetDateTimeOffset("S");
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "banana");
            if (Name != null)
            {
                writer.WriteStartElement("name");
                writer.WriteValue(Name);
                writer.WriteEndElement();
            }
            if (Flavor != null)
            {
                writer.WriteStartElement("flavor");
                writer.WriteValue(Flavor);
                writer.WriteEndElement();
            }
            if (Expiration != null)
            {
                writer.WriteStartElement("expiration");
                writer.WriteValue(Expiration.Value, "S");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static Banana DeserializeBanana(XElement element)
        {
            Banana result = new Banana();
            var name = element.Element("name");
            if (name != null)
            {
                result.Name = (string?)name;
            }
            var flavor = element.Element("flavor");
            if (flavor != null)
            {
                result.Flavor = (string?)flavor;
            }
            var expiration = element.Element("expiration");
            if (expiration != null)
            {
                result.Expiration = expiration.GetDateTimeOffsetValue("S");
            }
            return result;
        }
    }
}
