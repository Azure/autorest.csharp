// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class Logging : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Version");
            writer.WriteStringValue(Version);
            writer.WritePropertyName("Delete");
            writer.WriteBooleanValue(Delete);
            writer.WritePropertyName("Read");
            writer.WriteBooleanValue(Read);
            writer.WritePropertyName("Write");
            writer.WriteBooleanValue(Write);
            writer.WritePropertyName("RetentionPolicy");
            writer.WriteObjectValue(RetentionPolicy);
            writer.WriteEndObject();
        }
        internal static Logging DeserializeLogging(JsonElement element)
        {
            Logging result = new Logging();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Version"))
                {
                    result.Version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Delete"))
                {
                    result.Delete = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("Read"))
                {
                    result.Read = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("Write"))
                {
                    result.Write = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("RetentionPolicy"))
                {
                    result.RetentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(property.Value);
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AutoLogging");
            writer.WriteStartElement("Version");
            writer.WriteValue(Version);
            writer.WriteEndElement();
            writer.WriteStartElement("Delete");
            writer.WriteValue(Delete);
            writer.WriteEndElement();
            writer.WriteStartElement("Read");
            writer.WriteValue(Read);
            writer.WriteEndElement();
            writer.WriteStartElement("Write");
            writer.WriteValue(Write);
            writer.WriteEndElement();
            writer.WriteStartElement("RetentionPolicy");
            writer.WriteObjectValue(RetentionPolicy, null);
            writer.WriteEndElement();
        }
        internal static Logging DeserializeLogging(XElement element)
        {
            Logging result = new Logging();
            var version = element.Element("Version");
            if (version != null)
            {
                result.Version = (string)version;
            }
            var delete = element.Element("Delete");
            if (delete != null)
            {
                result.Delete = (bool)delete;
            }
            var read = element.Element("Read");
            if (read != null)
            {
                result.Read = (bool)read;
            }
            var write = element.Element("Write");
            if (write != null)
            {
                result.Write = (bool)write;
            }
            var retentionPolicy = element.Element("RetentionPolicy");
            if (retentionPolicy != null)
            {
                result.RetentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(retentionPolicy);
            }
            return result;
        }
    }
}
