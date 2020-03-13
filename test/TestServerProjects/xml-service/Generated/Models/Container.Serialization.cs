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
    public partial class Container : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Container");
            writer.WriteStartElement("Name");
            writer.WriteValue(Name);
            writer.WriteEndElement();
            writer.WriteObjectValue(Properties, "Properties");
            if (Metadata != null)
            {
                foreach (var pair in Metadata)
                {
                    writer.WriteStartElement("!dictionary-item");
                    writer.WriteValue(pair.Value);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        internal static Container DeserializeContainer(XElement element)
        {
            Container result = default;
            result = new Container(); string value = default;
            var name = element.Element("Name");
            if (name != null)
            {
                value = (string)name;
            }
            result.Name = value;
            ContainerProperties value0 = default;
            var properties = element.Element("Properties");
            if (properties != null)
            {
                value0 = ContainerProperties.DeserializeContainerProperties(properties);
            }
            result.Properties = value0;
            IDictionary<string, string> value1 = default;
            var metadata = element.Element("Metadata");
            if (metadata != null)
            {
                value1 = new Dictionary<string, string>(); var elements = metadata.Elements();
                foreach (var e in elements)
                {
                    string value2 = default;
                    value2 = (string)e;
                    value1.Add(e.Name.LocalName, value2);
                }
            }
            result.Metadata = value1;
            return result;
        }
    }
}
