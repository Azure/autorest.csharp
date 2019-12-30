// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class Metrics : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Version != null)
            {
                writer.WritePropertyName("Version");
                writer.WriteStringValue(Version);
            }
            writer.WritePropertyName("Enabled");
            writer.WriteBooleanValue(Enabled);
            if (IncludeAPIs != null)
            {
                writer.WritePropertyName("IncludeAPIs");
                writer.WriteBooleanValue(IncludeAPIs.Value);
            }
            if (RetentionPolicy != null)
            {
                writer.WritePropertyName("RetentionPolicy");
                writer.WriteObjectValue(RetentionPolicy);
            }
            writer.WriteEndObject();
        }
        internal static Metrics DeserializeMetrics(JsonElement element)
        {
            Metrics result = new Metrics();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Version"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Enabled"))
                {
                    result.Enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("IncludeAPIs"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.IncludeAPIs = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("RetentionPolicy"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.RetentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(property.Value);
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AutoMetrics");
            if (Version != null)
            {
                writer.WriteStartElement("Version");
                writer.WriteValue(Version);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("Enabled");
            writer.WriteValue(Enabled);
            writer.WriteEndElement();
            if (IncludeAPIs != null)
            {
                writer.WriteStartElement("IncludeAPIs");
                writer.WriteValue(IncludeAPIs.Value);
                writer.WriteEndElement();
            }
            if (RetentionPolicy != null)
            {
                writer.WriteStartElement("RetentionPolicy");
                writer.WriteObjectValue(RetentionPolicy, null);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static Metrics DeserializeMetrics(XElement element)
        {
            Metrics result = new Metrics();
            var version = element.Element("Version");
            if (version != null)
            {
                result.Version = (string?)version;
            }
            var enabled = element.Element("Enabled");
            if (enabled != null)
            {
                result.Enabled = (bool)enabled;
            }
            var includeAPIs = element.Element("IncludeAPIs");
            if (includeAPIs != null)
            {
                result.IncludeAPIs = (bool?)includeAPIs;
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
