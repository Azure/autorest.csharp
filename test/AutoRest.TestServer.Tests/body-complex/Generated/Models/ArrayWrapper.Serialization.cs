// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class ArrayWrapper
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteStartArray("array");
            foreach (var item in Array)
            {
                writer.WritePropertyName("array");
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        public static ArrayWrapper Deserialize(JsonElement element)
        {
            var result = new ArrayWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("array"))
                {
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
