// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Multiple_Inheritance.Models
{
    public partial class Horse : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(IsAShowHorse))
            {
                writer.WritePropertyName("isAShowHorse");
                writer.WriteBooleanValue(IsAShowHorse.Value);
            }
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static Horse DeserializeHorse(JsonElement element)
        {
            Optional<bool> isAShowHorse = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("isAShowHorse"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isAShowHorse = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new Horse(name, Optional.ToNullable(isAShowHorse));
        }
    }
}
