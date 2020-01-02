// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace extension_client_name.Models.V100
{
    public partial class OriginalSchema : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (OriginalProperty != null)
            {
                writer.WritePropertyName("originalProperty");
                writer.WriteStartObject();
                foreach (var item in OriginalProperty)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
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
                    result.OriginalProperty = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        result.OriginalProperty.Add(property0.Name, property0.Value.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
