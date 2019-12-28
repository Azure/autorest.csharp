// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class CorsRule : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("AllowedOrigins");
            writer.WriteStringValue(AllowedOrigins);
            writer.WritePropertyName("AllowedMethods");
            writer.WriteStringValue(AllowedMethods);
            writer.WritePropertyName("AllowedHeaders");
            writer.WriteStringValue(AllowedHeaders);
            writer.WritePropertyName("ExposedHeaders");
            writer.WriteStringValue(ExposedHeaders);
            writer.WritePropertyName("MaxAgeInSeconds");
            writer.WriteNumberValue(MaxAgeInSeconds);
            writer.WriteEndObject();
        }
        internal static CorsRule DeserializeCorsRule(JsonElement element)
        {
            CorsRule result = new CorsRule();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("AllowedOrigins"))
                {
                    result.AllowedOrigins = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("AllowedMethods"))
                {
                    result.AllowedMethods = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("AllowedHeaders"))
                {
                    result.AllowedHeaders = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ExposedHeaders"))
                {
                    result.ExposedHeaders = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("MaxAgeInSeconds"))
                {
                    result.MaxAgeInSeconds = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "CorsRule");
            writer.WriteStartElement("AllowedOrigins");
            writer.WriteValue(AllowedOrigins);
            writer.WriteEndElement();
            writer.WriteStartElement("AllowedMethods");
            writer.WriteValue(AllowedMethods);
            writer.WriteEndElement();
            writer.WriteStartElement("AllowedHeaders");
            writer.WriteValue(AllowedHeaders);
            writer.WriteEndElement();
            writer.WriteStartElement("ExposedHeaders");
            writer.WriteValue(ExposedHeaders);
            writer.WriteEndElement();
            writer.WriteStartElement("MaxAgeInSeconds");
            writer.WriteValue(MaxAgeInSeconds);
            writer.WriteEndElement();
        }
        internal static CorsRule DeserializeCorsRule(XElement element)
        {
            CorsRule result = new CorsRule();
            var allowedOrigins = element.Element("AllowedOrigins");
            if (allowedOrigins != null)
            {
                result.AllowedOrigins = (string)allowedOrigins;
            }
            var allowedMethods = element.Element("AllowedMethods");
            if (allowedMethods != null)
            {
                result.AllowedMethods = (string)allowedMethods;
            }
            var allowedHeaders = element.Element("AllowedHeaders");
            if (allowedHeaders != null)
            {
                result.AllowedHeaders = (string)allowedHeaders;
            }
            var exposedHeaders = element.Element("ExposedHeaders");
            if (exposedHeaders != null)
            {
                result.ExposedHeaders = (string)exposedHeaders;
            }
            var maxAgeInSeconds = element.Element("MaxAgeInSeconds");
            if (maxAgeInSeconds != null)
            {
                result.MaxAgeInSeconds = (int)maxAgeInSeconds;
            }
            return result;
        }
    }
}
