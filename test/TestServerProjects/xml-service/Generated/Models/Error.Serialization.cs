// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Error : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Status != null)
            {
                writer.WritePropertyName("status");
                writer.WriteNumberValue(Status.Value);
            }
            if (Message != null)
            {
                writer.WritePropertyName("message");
                writer.WriteStringValue(Message);
            }
            writer.WriteEndObject();
        }
        internal static Error DeserializeError(JsonElement element)
        {
            Error result = new Error();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Status = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Message = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Error");
            if (Status != null)
            {
                writer.WriteStartElement("status");
                writer.WriteValue(Status.Value);
                writer.WriteEndElement();
            }
            if (Message != null)
            {
                writer.WriteStartElement("message");
                writer.WriteValue(Message);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static Error DeserializeError(XElement element)
        {
            Error result = default;
            result = new Error(); int? value = default;
            var status = element.Element("status");
            if (status != null)
            {
                value = (int?)status;
            }
            result.Status = value;
            string value0 = default;
            var message = element.Element("message");
            if (message != null)
            {
                value0 = (string)message;
            }
            result.Message = value0;
            return result;
        }
    }
}
