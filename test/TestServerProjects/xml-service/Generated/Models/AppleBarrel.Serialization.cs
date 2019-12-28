// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class AppleBarrel : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (GoodApples != null)
            {
                writer.WritePropertyName("GoodApples");
                writer.WriteStartArray();
                foreach (var item in GoodApples)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (BadApples != null)
            {
                writer.WritePropertyName("BadApples");
                writer.WriteStartArray();
                foreach (var item in BadApples)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static AppleBarrel DeserializeAppleBarrel(JsonElement element)
        {
            AppleBarrel result = new AppleBarrel();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("GoodApples"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.GoodApples = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.GoodApples.Add(item.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("BadApples"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.BadApples = new List<string>();
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
            if (GoodApples != null)
            {
                writer.WriteStartElement("GoodApples");
                writer.WriteEndElement();
            }
            if (BadApples != null)
            {
                writer.WriteStartElement("BadApples");
                writer.WriteEndElement();
            }
        }
        internal static AppleBarrel DeserializeAppleBarrel(XElement element)
        {
            AppleBarrel result = new AppleBarrel();
            var goodApples = element.Element("GoodApples");
            if (goodApples != null)
            {
                ICollection<string>? value = new List<string>();
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
                ICollection<string>? value = new List<string>();
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
