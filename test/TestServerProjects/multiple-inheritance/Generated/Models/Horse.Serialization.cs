// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace multiple_inheritance.Models
{
    public partial class Horse : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(IsAShowHorse))
            {
                writer.WritePropertyName("isAShowHorse"u8);
                writer.WriteBooleanValue(IsAShowHorse.Value);
            }
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static Horse DeserializeHorse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> isAShowHorse = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("isAShowHorse"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isAShowHorse = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new Horse(name, Optional.ToNullable(isAShowHorse));
        }
    }
}
