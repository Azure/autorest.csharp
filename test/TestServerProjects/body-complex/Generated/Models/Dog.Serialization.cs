// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class DogSerializer
    {
        internal static void Serialize(Dog model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Food != null)
            {
                writer.WritePropertyName("food");
                writer.WriteStringValue(model.Food);
            }
            if (model.Id != null)
            {
                writer.WritePropertyName("id");
                writer.WriteNumberValue(model.Id.Value);
            }
            if (model.Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(model.Name);
            }
            writer.WriteEndObject();
        }
        internal static Dog Deserialize(JsonElement element)
        {
            var result = new Dog();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("food"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Food = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
