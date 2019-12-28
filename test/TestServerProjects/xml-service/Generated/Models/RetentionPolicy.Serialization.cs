// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class RetentionPolicy : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Enabled");
            writer.WriteBooleanValue(Enabled);
            if (Days != null)
            {
                writer.WritePropertyName("Days");
                writer.WriteNumberValue(Days.Value);
            }
            writer.WriteEndObject();
        }
        internal static RetentionPolicy DeserializeRetentionPolicy(JsonElement element)
        {
            RetentionPolicy result = new RetentionPolicy();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Enabled"))
                {
                    result.Enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("Days"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Days = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AutoRetentionPolicy");
            writer.WriteStartElement("Enabled");
            writer.WriteValue(Enabled);
            writer.WriteEndElement();
            if (Days != null)
            {
                writer.WriteStartElement("Days");
                writer.WriteValue(Days.Value);
                writer.WriteEndElement();
            }
        }
        internal static RetentionPolicy DeserializeRetentionPolicy(XElement element)
        {
            RetentionPolicy result = new RetentionPolicy();
            var enabled = element.Element("Enabled");
            if (enabled != null)
            {
                result.Enabled = (bool)enabled;
            }
            var days = element.Element("Days");
            if (days != null)
            {
                result.Days = (int?)days;
            }
            return result;
        }
    }
}
