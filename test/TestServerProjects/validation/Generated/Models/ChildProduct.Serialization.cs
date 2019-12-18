// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace validation.Models.V100
{
    public partial class ChildProductSerializer
    {
        internal static void Serialize(ChildProduct model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("constProperty");
            writer.WriteStringValue(model.ConstProperty);
            if (model.Count != null)
            {
                writer.WritePropertyName("count");
                writer.WriteNumberValue(model.Count.Value);
            }
            writer.WriteEndObject();
        }
        internal static ChildProduct Deserialize(JsonElement element)
        {
            var result = new ChildProduct();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("constProperty"))
                {
                    result.ConstProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("count"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Count = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
