// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Inheritance.Models
{
    [JsonConverter(typeof(BaseClassWithExtensibleEnumDiscriminatorConverter))]
    public partial class BaseClassWithExtensibleEnumDiscriminator : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty.ToString());
            writer.WriteEndObject();
        }

        internal static BaseClassWithExtensibleEnumDiscriminator DeserializeBaseClassWithExtensibleEnumDiscriminator(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("DiscriminatorProperty", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "derived": return DerivedClassWithExtensibleEnumDiscriminator.DeserializeDerivedClassWithExtensibleEnumDiscriminator(element);
                    case "random value": return AnotherDerivedClassWithExtensibleEnumDiscriminator.DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(element);
                }
            }
            return UnknownBaseClassWithExtensibleEnumDiscriminator.DeserializeUnknownBaseClassWithExtensibleEnumDiscriminator(element);
        }

        internal partial class BaseClassWithExtensibleEnumDiscriminatorConverter : JsonConverter<BaseClassWithExtensibleEnumDiscriminator>
        {
            public override void Write(Utf8JsonWriter writer, BaseClassWithExtensibleEnumDiscriminator model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override BaseClassWithExtensibleEnumDiscriminator Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeBaseClassWithExtensibleEnumDiscriminator(document.RootElement);
            }
        }
    }
}
