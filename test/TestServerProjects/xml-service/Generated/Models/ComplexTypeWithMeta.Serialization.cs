// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ComplexTypeWithMeta : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "XMLComplexTypeWithMeta");
            if (Optional.IsDefined(ID))
            {
                writer.WriteStartElement("ID");
                writer.WriteValue(ID);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static ComplexTypeWithMeta DeserializeComplexTypeWithMeta(XElement element)
        {
            string id = default;
            if (element.Element("ID") is XElement idElement)
            {
                id = (string)idElement;
            }
            return new ComplexTypeWithMeta(id);
        }
    }
}
