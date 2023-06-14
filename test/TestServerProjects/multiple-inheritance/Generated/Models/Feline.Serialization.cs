// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace multiple_inheritance.Models
{
    public partial class Feline : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Meows))
            {
                writer.WritePropertyName("meows"u8);
                writer.WriteBooleanValue(Meows.Value);
            }
            if (Optional.IsDefined(Hisses))
            {
                writer.WritePropertyName("hisses"u8);
                writer.WriteBooleanValue(Hisses.Value);
            }
            writer.WriteEndObject();
        }

        internal static Feline DeserializeFeline(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> meows = default;
            Optional<bool> hisses = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("meows"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    meows = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("hisses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hisses = property.Value.GetBoolean();
                    continue;
                }
            }
            return new Feline(Optional.ToNullable(meows), Optional.ToNullable(hisses));
        }
    }
}
