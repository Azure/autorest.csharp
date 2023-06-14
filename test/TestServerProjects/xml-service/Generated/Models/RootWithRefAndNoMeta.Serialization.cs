// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class RootWithRefAndNoMeta : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "RootWithRefAndNoMeta");
            if (Optional.IsDefined(RefToModel))
            {
                writer.WriteObjectValue(RefToModel, "RefToModel");
            }
            if (Optional.IsDefined(Something))
            {
                writer.WriteStartElement("Something");
                writer.WriteValue(Something);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static RootWithRefAndNoMeta DeserializeRootWithRefAndNoMeta(XElement element)
        {
            ComplexTypeNoMeta refToModel = default;
            string something = default;
            if (element.Element("RefToModel") is XElement refToModelElement)
            {
                refToModel = ComplexTypeNoMeta.DeserializeComplexTypeNoMeta(refToModelElement);
            }
            if (element.Element("Something") is XElement somethingElement)
            {
                something = (string)somethingElement;
            }
            return new RootWithRefAndNoMeta(refToModel, something);
        }
    }
}
