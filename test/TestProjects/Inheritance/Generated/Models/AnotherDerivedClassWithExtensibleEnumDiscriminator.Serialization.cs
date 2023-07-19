// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Serialization;

namespace Inheritance.Models
{
    [JsonConverter(typeof(AnotherDerivedClassWithExtensibleEnumDiscriminatorConverter))]
    public partial class AnotherDerivedClassWithExtensibleEnumDiscriminator : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty.ToString());
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(doc.RootElement, options);
        }

        internal static AnotherDerivedClassWithExtensibleEnumDiscriminator DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("DiscriminatorProperty"u8))
                {
                    discriminatorProperty = new BaseClassWithEntensibleEnumDiscriminatorEnum(property.Value.GetString());
                    continue;
                }
            }
            return new AnotherDerivedClassWithExtensibleEnumDiscriminator(discriminatorProperty);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(doc.RootElement, options);
        }

        internal partial class AnotherDerivedClassWithExtensibleEnumDiscriminatorConverter : JsonConverter<AnotherDerivedClassWithExtensibleEnumDiscriminator>
        {
            public override void Write(Utf8JsonWriter writer, AnotherDerivedClassWithExtensibleEnumDiscriminator model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override AnotherDerivedClassWithExtensibleEnumDiscriminator Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(document.RootElement);
            }
        }
    }
}
