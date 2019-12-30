// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class AccessPolicy : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Start");
            writer.WriteStringValue(Start, "S");
            writer.WritePropertyName("Expiry");
            writer.WriteStringValue(Expiry, "S");
            writer.WritePropertyName("Permission");
            writer.WriteStringValue(Permission);
            writer.WriteEndObject();
        }
        internal static AccessPolicy DeserializeAccessPolicy(JsonElement element)
        {
            AccessPolicy result = new AccessPolicy();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Start"))
                {
                    result.Start = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("Expiry"))
                {
                    result.Expiry = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("Permission"))
                {
                    result.Permission = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AutoAccessPolicy");
            writer.WriteStartElement("Start");
            writer.WriteValue(Start, "S");
            writer.WriteEndElement();
            writer.WriteStartElement("Expiry");
            writer.WriteValue(Expiry, "S");
            writer.WriteEndElement();
            writer.WriteStartElement("Permission");
            writer.WriteValue(Permission);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        internal static AccessPolicy DeserializeAccessPolicy(XElement element)
        {
            AccessPolicy result = new AccessPolicy();
            var start = element.Element("Start");
            if (start != null)
            {
                result.Start = start.GetDateTimeOffsetValue("S");
            }
            var expiry = element.Element("Expiry");
            if (expiry != null)
            {
                result.Expiry = expiry.GetDateTimeOffsetValue("S");
            }
            var permission = element.Element("Permission");
            if (permission != null)
            {
                result.Permission = (string)permission;
            }
            return result;
        }
    }
}
