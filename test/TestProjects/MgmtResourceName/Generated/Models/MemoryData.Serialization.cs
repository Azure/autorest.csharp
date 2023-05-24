// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Models;

namespace MgmtResourceName
{
    public partial class MemoryData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(New))
            {
                writer.WritePropertyName("new"u8);
                writer.WriteStringValue(New);
            }
            writer.WriteEndObject();
        }

        internal static MemoryData DeserializeMemoryData(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> @new = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("new"u8))
                {
                    @new = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
            }
            return new MemoryData(id, name, type, systemData.Value, @new.Value);
        }
    }
}
