// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtCustomizations.Models
{
    internal partial class UnknownPet : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToSerialString());
            if (Optional.IsDefined(Size))
            {
                writer.WritePropertyName("size"u8);
                SerializeSizeProperty(writer);
            }
            writer.WriteEndObject();
        }

        internal static UnknownPet DeserializeUnknownPet(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            PetKind kind = default;
            Optional<string> name = default;
            Optional<int> size = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString().ToPetKind();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("size"u8))
                {
                    DeserializeSizeProperty(property, ref size);
                    continue;
                }
            }
            return new UnknownPet(kind, name.Value, size);
        }
    }
}
