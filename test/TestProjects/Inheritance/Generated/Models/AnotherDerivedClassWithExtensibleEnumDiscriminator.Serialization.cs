// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace Inheritance.Models
{
    [JsonConverter(typeof(AnotherDerivedClassWithExtensibleEnumDiscriminatorConverter))]
    public partial class AnotherDerivedClassWithExtensibleEnumDiscriminator : IUtf8JsonSerializable, IModelJsonSerializable<AnotherDerivedClassWithExtensibleEnumDiscriminator>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AnotherDerivedClassWithExtensibleEnumDiscriminator>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AnotherDerivedClassWithExtensibleEnumDiscriminator>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<AnotherDerivedClassWithExtensibleEnumDiscriminator>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty.ToString());
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static AnotherDerivedClassWithExtensibleEnumDiscriminator DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("DiscriminatorProperty"u8))
                {
                    discriminatorProperty = new BaseClassWithEntensibleEnumDiscriminatorEnum(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new AnotherDerivedClassWithExtensibleEnumDiscriminator(discriminatorProperty, serializedAdditionalRawData);
        }

        AnotherDerivedClassWithExtensibleEnumDiscriminator IModelJsonSerializable<AnotherDerivedClassWithExtensibleEnumDiscriminator>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<AnotherDerivedClassWithExtensibleEnumDiscriminator>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(doc.RootElement, options);
        }

        BinaryData IModelSerializable<AnotherDerivedClassWithExtensibleEnumDiscriminator>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<AnotherDerivedClassWithExtensibleEnumDiscriminator>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        AnotherDerivedClassWithExtensibleEnumDiscriminator IModelSerializable<AnotherDerivedClassWithExtensibleEnumDiscriminator>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<AnotherDerivedClassWithExtensibleEnumDiscriminator>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="AnotherDerivedClassWithExtensibleEnumDiscriminator"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="AnotherDerivedClassWithExtensibleEnumDiscriminator"/> to convert. </param>
        public static implicit operator RequestContent(AnotherDerivedClassWithExtensibleEnumDiscriminator model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="AnotherDerivedClassWithExtensibleEnumDiscriminator"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator AnotherDerivedClassWithExtensibleEnumDiscriminator(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
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
