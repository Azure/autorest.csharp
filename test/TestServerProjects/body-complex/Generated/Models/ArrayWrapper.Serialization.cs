// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class ArrayWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Array != null)
            {
                writer.WritePropertyName("array");
                writer.WriteStartArray();
                foreach (var item in Array)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static ArrayWrapper DeserializeArrayWrapper(JsonElement element)
        {
            ArrayWrapper result = new ArrayWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("array"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Array.Add(item.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
