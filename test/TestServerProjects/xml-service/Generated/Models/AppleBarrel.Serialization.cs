// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class AppleBarrel : IXmlSerializable, IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("GoodApples");
            writer.WriteStartArray();
            foreach (var item in GoodApples)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("BadApples");
            writer.WriteStartArray();
            foreach (var item0 in BadApples)
            {
                writer.WriteStringValue(item0);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static AppleBarrel DeserializeAppleBarrel(JsonElement element)
        {
            AppleBarrel result = new AppleBarrel();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("GoodApples"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.GoodApples.Add(item.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("BadApples"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.BadApples.Add(item.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AutoAppleBarrel");
            writer.WriteStartElement("GoodApples");
            writer.WriteEndElement();
            writer.WriteStartElement("BadApples");
            writer.WriteEndElement();
        }
        internal static AppleBarrel DeserializeAppleBarrel(XElement element)
        {
            AppleBarrel result = new AppleBarrel();
            var goodApples = element.Element("GoodApples");
            if (goodApples != null)
            {
                ICollection<string> value = new List<string>();
                var elements = goodApples.Elements("Apple");
                foreach (var e in elements)
                {
                    value.Add((string)e);
                }
                result.GoodApples = value;
            }
            var badApples = element.Element("BadApples");
            if (badApples != null)
            {
                ICollection<string> value = new List<string>();
                var elements = badApples.Elements("Apple");
                foreach (var e in elements)
                {
                    value.Add((string)e);
                }
                result.BadApples = value;
            }
            return result;
        }
    }
}
