// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class StorageServiceProperties : IXmlSerializable, IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Logging != null)
            {
                writer.WritePropertyName("Logging");
                writer.WriteObjectValue(Logging);
            }
            if (HourMetrics != null)
            {
                writer.WritePropertyName("HourMetrics");
                writer.WriteObjectValue(HourMetrics);
            }
            if (MinuteMetrics != null)
            {
                writer.WritePropertyName("MinuteMetrics");
                writer.WriteObjectValue(MinuteMetrics);
            }
            writer.WritePropertyName("Cors");
            writer.WriteStartArray();
            foreach (var item in Cors)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (DefaultServiceVersion != null)
            {
                writer.WritePropertyName("DefaultServiceVersion");
                writer.WriteStringValue(DefaultServiceVersion);
            }
            if (DeleteRetentionPolicy != null)
            {
                writer.WritePropertyName("DeleteRetentionPolicy");
                writer.WriteObjectValue(DeleteRetentionPolicy);
            }
            writer.WriteEndObject();
        }
        internal static StorageServiceProperties DeserializeStorageServiceProperties(JsonElement element)
        {
            StorageServiceProperties result = new StorageServiceProperties();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Logging"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Logging = Logging.DeserializeLogging(property.Value);
                    continue;
                }
                if (property.NameEquals("HourMetrics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.HourMetrics = Metrics.DeserializeMetrics(property.Value);
                    continue;
                }
                if (property.NameEquals("MinuteMetrics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MinuteMetrics = Metrics.DeserializeMetrics(property.Value);
                    continue;
                }
                if (property.NameEquals("Cors"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Cors.Add(CorsRule.DeserializeCorsRule(item));
                    }
                    continue;
                }
                if (property.NameEquals("DefaultServiceVersion"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DefaultServiceVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("DeleteRetentionPolicy"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DeleteRetentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(property.Value);
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AutoStorageServiceProperties");
            if (Logging != null)
            {
                writer.WriteStartElement("Logging");
                writer.WriteObjectValue(Logging, null);
                writer.WriteEndElement();
            }
            if (HourMetrics != null)
            {
                writer.WriteStartElement("HourMetrics");
                writer.WriteObjectValue(HourMetrics, null);
                writer.WriteEndElement();
            }
            if (MinuteMetrics != null)
            {
                writer.WriteStartElement("MinuteMetrics");
                writer.WriteObjectValue(MinuteMetrics, null);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("Cors");
            writer.WriteEndElement();
            if (DefaultServiceVersion != null)
            {
                writer.WriteStartElement("DefaultServiceVersion");
                writer.WriteValue(DefaultServiceVersion);
                writer.WriteEndElement();
            }
            if (DeleteRetentionPolicy != null)
            {
                writer.WriteStartElement("DeleteRetentionPolicy");
                writer.WriteObjectValue(DeleteRetentionPolicy, null);
                writer.WriteEndElement();
            }
        }
        internal static StorageServiceProperties DeserializeStorageServiceProperties(XElement element)
        {
            StorageServiceProperties result = new StorageServiceProperties();
            var logging = element.Element("Logging");
            if (logging != null)
            {
                result.Logging = Logging.DeserializeLogging(logging);
            }
            var hourMetrics = element.Element("HourMetrics");
            if (hourMetrics != null)
            {
                result.HourMetrics = Metrics.DeserializeMetrics(hourMetrics);
            }
            var minuteMetrics = element.Element("MinuteMetrics");
            if (minuteMetrics != null)
            {
                result.MinuteMetrics = Metrics.DeserializeMetrics(minuteMetrics);
            }
            var cors = element.Element("Cors");
            if (cors != null)
            {
                ICollection<CorsRule> value = new List<CorsRule>();
                result.Cors = value;
            }
            var defaultServiceVersion = element.Element("DefaultServiceVersion");
            if (defaultServiceVersion != null)
            {
                result.DefaultServiceVersion = (string?)defaultServiceVersion;
            }
            var deleteRetentionPolicy = element.Element("DeleteRetentionPolicy");
            if (deleteRetentionPolicy != null)
            {
                result.DeleteRetentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(deleteRetentionPolicy);
            }
            return result;
        }
    }
}
