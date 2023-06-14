// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            if (Optional.IsCollectionDefined(GoodApples))
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
            if (Optional.IsCollectionDefined(BadApples))
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
            IList<string> goodApples = default;
            IList<string> badApples = default;
            if (element.Element("GoodApples") is XElement goodApplesElement)
            {
                var array = new List<string>();
                foreach (var e in goodApplesElement.Elements("Apple"))
                {
                    array.Add((string)e);
                }
                goodApples = array;
            }
            if (element.Element("BadApples") is XElement badApplesElement)
            {
                var array = new List<string>();
                foreach (var e in badApplesElement.Elements("Apple"))
                {
                    array.Add((string)e);
                }
                badApples = array;
            }
            return new AppleBarrel(goodApples, badApples);
        }
    }
}
