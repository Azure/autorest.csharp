// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace additionalProperties.Models.V100
{
    public partial class PetAPInPropertiesWithAPStringSerializer
    {
        internal static void Serialize(PetAPInPropertiesWithAPString model, Utf8JsonWriter writer)
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
            writer.WritePropertyName("@odata.location");
            writer.WriteStringValue(model.OdataLocation);
            if (model.AdditionalProperties != null)
            {
                writer.WritePropertyName("additionalProperties");
                writer.WriteStartObject();
                foreach (var item in model.AdditionalProperties)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteNumberValue(item.Value);
                }
                writer.WriteEndObject();
            }

            foreach (var item in model)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
        }
        internal static PetAPInPropertiesWithAPString Deserialize(JsonElement element)
        {
            var result = new PetAPInPropertiesWithAPString();
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
                if (property.NameEquals("@odata.location"))
                {
                    result.OdataLocation = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("additionalProperties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.AdditionalProperties = new Dictionary<string, float>();
                    foreach (var item in property.Value.EnumerateObject())
                    {
                        result.AdditionalProperties.Add(item.Name, item.Value.GetSingle());
                    }
                    continue;
                }

                result.Add(property.Name, property.Value.GetString());
            }
            return result;
        }
    }
}
