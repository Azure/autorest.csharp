// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class CorsRules : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(CorsRulesValue))
            {
                writer.WritePropertyName("corsRules"u8);
                writer.WriteStartArray();
                foreach (var item in CorsRulesValue)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static CorsRules DeserializeCorsRules(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<CorsRule>> corsRules = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("corsRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CorsRule> array = new List<CorsRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CorsRule.DeserializeCorsRule(item));
                    }
                    corsRules = array;
                    continue;
                }
            }
            return new CorsRules(Optional.ToList(corsRules));
        }
    }
}
