// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtCustomizations.Models
{
    public partial class Pet : IUtf8JsonSerializable
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

        internal static Pet DeserializePet(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Cat": return Cat.DeserializeCat(element);
                    case "Dog": return Dog.DeserializeDog(element);
                }
            }
            return UnknownPet.DeserializeUnknownPet(element);
        }
    }
}
