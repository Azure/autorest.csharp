// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace additionalProperties.Models
{
    public partial class PetAPString : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteNumberValue(Id);
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Status != null)
            {
                writer.WritePropertyName("status");
                writer.WriteBooleanValue(Status.Value);
            }
            foreach (var item in this)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
        }
        internal static PetAPString DeserializePetAPString(JsonElement element)
        {
            PetAPString result = new PetAPString();
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
