// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Inheritance.Models
{
    internal partial class UnknownBaseClassWithExtensibleEnumDiscriminator : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty.ToString());
            writer.WriteEndObject();
        }

        internal static UnknownBaseClassWithExtensibleEnumDiscriminator DeserializeUnknownBaseClassWithExtensibleEnumDiscriminator(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("DiscriminatorProperty"u8))
                {
                    discriminatorProperty = new BaseClassWithEntensibleEnumDiscriminatorEnum(property.Value.GetString());
                    continue;
                }
            }
            return new UnknownBaseClassWithExtensibleEnumDiscriminator(discriminatorProperty);
        }
    }
}
