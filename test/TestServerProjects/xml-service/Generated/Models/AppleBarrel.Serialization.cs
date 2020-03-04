// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class AppleBarrel : IXmlSerializable
    {
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
            result = new AppleBarrel(); var goodApples = element.Element("GoodApples");
            if (goodApples != null)
            {
                result.GoodApples = new List<string>();
                foreach (var e in goodApples.Elements("Apple"))
                {
                    string value = default;
                    value = (string)e;
                    result.GoodApples.Add(value);
                }
            }
            var badApples = element.Element("BadApples");
            if (badApples != null)
            {
                result.BadApples = new List<string>();
                foreach (var e in badApples.Elements("Apple"))
                {
                    string value = default;
                    value = (string)e;
                    result.BadApples.Add(value);
                }
            }
            return result;
        }
    }
}
