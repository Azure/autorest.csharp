// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class FieldMappingFunction : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            if (Parameters != null)
            {
                writer.WritePropertyName("parameters");
                writer.WriteStartObject();
                foreach (var item in Parameters)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
        internal static FieldMappingFunction DeserializeFieldMappingFunction(JsonElement element)
        {
            FieldMappingFunction result = new FieldMappingFunction();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("parameters"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Parameters = new Dictionary<string, object>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        result.Parameters.Add(property0.Name, property0.Value.GetObject());
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
