// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class SignedIdentifier : IXmlSerializable, IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("AccessPolicy");
            writer.WriteObjectValue(AccessPolicy);
            writer.WriteEndObject();
        }
        internal static SignedIdentifier DeserializeSignedIdentifier(JsonElement element)
        {
            SignedIdentifier result = new SignedIdentifier();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("AccessPolicy"))
                {
                    result.AccessPolicy = AccessPolicy.DeserializeAccessPolicy(property.Value);
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "SignedIdentifier");
            writer.WriteStartElement("Id");
            writer.WriteValue(Id);
            writer.WriteEndElement();
            writer.WriteStartElement("AccessPolicy");
            writer.WriteObjectValue(AccessPolicy, null);
            writer.WriteEndElement();
        }
        internal static SignedIdentifier DeserializeSignedIdentifier(XElement element)
        {
            SignedIdentifier result = new SignedIdentifier();
            var id = element.Element("Id");
            if (id != null)
            {
                result.Id = (string)id;
            }
            var accessPolicy = element.Element("AccessPolicy");
            if (accessPolicy != null)
            {
                result.AccessPolicy = AccessPolicy.DeserializeAccessPolicy(accessPolicy);
            }
            return result;
        }
    }
}
