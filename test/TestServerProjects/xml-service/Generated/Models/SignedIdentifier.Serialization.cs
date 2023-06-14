// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class SignedIdentifier : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "SignedIdentifier");
            writer.WriteStartElement("Id");
            writer.WriteValue(Id);
            writer.WriteEndElement();
            writer.WriteObjectValue(AccessPolicy, "AccessPolicy");
            writer.WriteEndElement();
        }

        internal static SignedIdentifier DeserializeSignedIdentifier(XElement element)
        {
            string id = default;
            AccessPolicy accessPolicy = default;
            if (element.Element("Id") is XElement idElement)
            {
                id = (string)idElement;
            }
            if (element.Element("AccessPolicy") is XElement accessPolicyElement)
            {
                accessPolicy = AccessPolicy.DeserializeAccessPolicy(accessPolicyElement);
            }
            return new SignedIdentifier(id, accessPolicy);
        }
    }
}
