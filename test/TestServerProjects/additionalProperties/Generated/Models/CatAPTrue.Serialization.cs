// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace additionalProperties.Models.V100
{
    public partial class CatAPTrueSerializer
    {
        internal static void Serialize(CatAPTrue model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Friendly != null)
            {
                writer.WritePropertyName("friendly");
                writer.WriteBooleanValue(model.Friendly.Value);
            }

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

            writer.WriteEndObject();
        }
        internal static CatAPTrue Deserialize(JsonElement element)
        {
            var result = new CatAPTrue();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("friendly"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Friendly = property.Value.GetBoolean();
                    continue;
                }

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

            }
            return result;
        }
    }
}
