// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    public partial class Cat : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Meow))
            {
                writer.WritePropertyName("meow"u8);
                writer.WriteStringValue(Meow);
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToSerialString());
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeCat(doc.RootElement, options);
        }

        internal static Cat DeserializeCat(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> meow = default;
            PetKind kind = default;
            Optional<string> id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("meow"u8))
                {
                    meow = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString().ToPetKind();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new Cat(kind, id.Value, meow.Value);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeCat(doc.RootElement, options);
        }
    }
}
