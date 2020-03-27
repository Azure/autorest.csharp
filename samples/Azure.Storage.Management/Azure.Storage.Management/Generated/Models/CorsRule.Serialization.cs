// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class CorsRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("allowedOrigins");
            writer.WriteStartArray();
            foreach (var item in AllowedOrigins)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("allowedMethods");
            writer.WriteStartArray();
            foreach (var item0 in AllowedMethods)
            {
                writer.WriteStringValue(item0.ToString());
            }
            writer.WriteEndArray();
            writer.WritePropertyName("maxAgeInSeconds");
            writer.WriteNumberValue(MaxAgeInSeconds);
            writer.WritePropertyName("exposedHeaders");
            writer.WriteStartArray();
            foreach (var item1 in ExposedHeaders)
            {
                writer.WriteStringValue(item1);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("allowedHeaders");
            writer.WriteStartArray();
            foreach (var item2 in AllowedHeaders)
            {
                writer.WriteStringValue(item2);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static CorsRule DeserializeCorsRule(JsonElement element)
        {
            IList<string> allowedOrigins = default;
            IList<CorsRuleAllowedMethodsItem> allowedMethods = default;
            int maxAgeInSeconds = default;
            IList<string> exposedHeaders = default;
            IList<string> allowedHeaders = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("allowedOrigins"))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    allowedOrigins = array;
                    continue;
                }
                if (property.NameEquals("allowedMethods"))
                {
                    List<CorsRuleAllowedMethodsItem> array = new List<CorsRuleAllowedMethodsItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new CorsRuleAllowedMethodsItem(item.GetString()));
                    }
                    allowedMethods = array;
                    continue;
                }
                if (property.NameEquals("maxAgeInSeconds"))
                {
                    maxAgeInSeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("exposedHeaders"))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    exposedHeaders = array;
                    continue;
                }
                if (property.NameEquals("allowedHeaders"))
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
