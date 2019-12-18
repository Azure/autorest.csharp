// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace additionalProperties.Models.V100
{
    public partial class PetAPStringSerializer
    {
        internal static void Serialize(PetAPString model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteNumberValue(model.Id);
            if (model.Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(model.Name);
            }
            if (model.Status != null)
            {
                writer.WritePropertyName("status");
                writer.WriteBooleanValue(model.Status.Value);
            }
            foreach (var item in model)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
        }
        internal static PetAPString Deserialize(JsonElement element)
        {
            var result = new PetAPString();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
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
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Status = property.Value.GetBoolean();
                    continue;
                }
                result.Add(property.Name, property.Value.GetString());
            }
            return result;
        }
    }
}
