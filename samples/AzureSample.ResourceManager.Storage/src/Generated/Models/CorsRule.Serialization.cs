// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace AzureSample.ResourceManager.Storage.Models
{
    public partial class CorsRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("allowedOrigins"u8);
            writer.WriteStartArray();
            foreach (var item in AllowedOrigins)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("allowedMethods"u8);
            writer.WriteStartArray();
            foreach (var item in AllowedMethods)
            {
                writer.WriteStringValue(item.ToString());
            }
            writer.WriteEndArray();
            writer.WritePropertyName("maxAgeInSeconds"u8);
            writer.WriteNumberValue(MaxAgeInSeconds);
            writer.WritePropertyName("exposedHeaders"u8);
            writer.WriteStartArray();
            foreach (var item in ExposedHeaders)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("allowedHeaders"u8);
            writer.WriteStartArray();
            foreach (var item in AllowedHeaders)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static CorsRule DeserializeCorsRule(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> allowedOrigins = default;
            IList<CorsRuleAllowedMethodsItem> allowedMethods = default;
            int maxAgeInSeconds = default;
            IList<string> exposedHeaders = default;
            IList<string> allowedHeaders = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("allowedOrigins"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    allowedOrigins = array;
                    continue;
                }
                if (property.NameEquals("allowedMethods"u8))
                {
                    List<CorsRuleAllowedMethodsItem> array = new List<CorsRuleAllowedMethodsItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new CorsRuleAllowedMethodsItem(item.GetString()));
                    }
                    allowedMethods = array;
                    continue;
                }
                if (property.NameEquals("maxAgeInSeconds"u8))
                {
                    maxAgeInSeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("exposedHeaders"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    exposedHeaders = array;
                    continue;
                }
                if (property.NameEquals("allowedHeaders"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    allowedHeaders = array;
                    continue;
                }
            }
            return new CorsRule(allowedOrigins, allowedMethods, maxAgeInSeconds, exposedHeaders, allowedHeaders);
        }
    }
}
