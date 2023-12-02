// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class OutputFieldMappingEntry : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(TargetName))
            {
                writer.WritePropertyName("targetName"u8);
                writer.WriteStringValue(TargetName);
            }
            writer.WriteEndObject();
        }

        internal static OutputFieldMappingEntry DeserializeOutputFieldMappingEntry(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> targetName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetName"u8))
                {
                    targetName = property.Value.GetString();
                    continue;
                }
            }
            return new OutputFieldMappingEntry(name, targetName.Value);
        }
    }
}
