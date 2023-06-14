// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class FieldMapping : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("sourceFieldName"u8);
            writer.WriteStringValue(SourceFieldName);
            if (Optional.IsDefined(TargetFieldName))
            {
                writer.WritePropertyName("targetFieldName"u8);
                writer.WriteStringValue(TargetFieldName);
            }
            if (Optional.IsDefined(MappingFunction))
            {
                writer.WritePropertyName("mappingFunction"u8);
                writer.WriteObjectValue(MappingFunction);
            }
            writer.WriteEndObject();
        }

        internal static FieldMapping DeserializeFieldMapping(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string sourceFieldName = default;
            Optional<string> targetFieldName = default;
            Optional<FieldMappingFunction> mappingFunction = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sourceFieldName"u8))
                {
                    sourceFieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetFieldName"u8))
                {
                    targetFieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("mappingFunction"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mappingFunction = FieldMappingFunction.DeserializeFieldMappingFunction(property.Value);
                    continue;
                }
            }
            return new FieldMapping(sourceFieldName, targetFieldName.Value, mappingFunction.Value);
        }
    }
}
