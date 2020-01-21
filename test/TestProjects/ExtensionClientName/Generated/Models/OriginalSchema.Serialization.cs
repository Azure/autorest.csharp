// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace ExtensionClientName.Models
{
    public partial class OriginalSchema : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (RenamedProperty != null)
            {
                writer.WritePropertyName("originalProperty");
                writer.WriteStartObject();
                foreach (var item in RenamedProperty)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (RenamedPropertyString != null)
            {
                writer.WritePropertyName("originalPropertyString");
                writer.WriteStringValue(RenamedPropertyString);
            }
            writer.WriteEndObject();
        }
        internal static OriginalSchema DeserializeOriginalSchema(JsonElement element)
        {
            OriginalSchema result = new OriginalSchema();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("originalProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.RenamedProperty = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        result.RenamedProperty.Add(property0.Name, property0.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("originalPropertyString"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.RenamedPropertyString = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
