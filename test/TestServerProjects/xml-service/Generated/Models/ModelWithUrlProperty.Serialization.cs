// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ModelWithUrlProperty : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "ModelWithUrlProperty");
            if (Optional.IsDefined(Url))
            {
                writer.WriteStartElement("Url");
                writer.WriteValue(Url);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static ModelWithUrlProperty DeserializeModelWithUrlProperty(XElement element)
        {
            Uri url = default;
            if (element.Element("Url") is XElement urlElement)
            {
                url = new Uri((string)urlElement);
            }
            return new ModelWithUrlProperty(url);
        }
    }
}
