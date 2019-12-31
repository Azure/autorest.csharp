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
            writer.WriteStartElement(nameHint ?? "AppleBarrel");
            if (GoodApples != null)
            {
                writer.WriteStartElement("GoodApples");
                foreach (var item in GoodApples)
                {
                    writer.WriteStartElement("Apple");
                    writer.WriteValue(item);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            if (BadApples != null)
            {
                writer.WriteStartElement("BadApples");
                foreach (var item in BadApples)
                {
                    writer.WriteStartElement("Apple");
                    writer.WriteValue(item);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static AppleBarrel DeserializeAppleBarrel(XElement element)
        {
            AppleBarrel result = default;
            result.GoodApples = new List<string>();
            var goodApples = element.Element("GoodApples");
            result.GoodApples = new List<string>();
            foreach (var e in goodApples.Elements("Apple"))
            {
                string value = default;
                var apple = e.Element("Apple");
                if (apple != null)
                {
                    value = (string)apple;
                }
                result.GoodApples.Add(value);
            }
            result.BadApples = new List<string>();
            var badApples = element.Element("BadApples");
            result.BadApples = new List<string>();
            foreach (var e0 in badApples.Elements("Apple"))
            {
                string value = default;
                var apple = e0.Element("Apple");
                if (apple != null)
                {
                    value = (string)apple;
                }
                result.BadApples.Add(value);
            }
            return result;
        }
    }
}
