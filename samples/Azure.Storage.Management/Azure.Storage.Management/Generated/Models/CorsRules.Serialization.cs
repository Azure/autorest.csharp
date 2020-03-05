// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class CorsRules : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (CorsRules != null)
            {
                writer.WritePropertyName("corsRules");
                writer.WriteStartArray();
                foreach (var item in CorsRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static CorsRules DeserializeCorsRules(JsonElement element)
        {
            CorsRules result = new CorsRules();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("corsRules"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CorsRules = new List<CorsRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.CorsRules.Add(CorsRule.DeserializeCorsRule(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
