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
    [JsonConverter(typeof(BaseClassWithExtensibleEnumDiscriminatorConverter))]
    public partial class BaseClassWithExtensibleEnumDiscriminator : IUtf8JsonSerializable, IModelJsonSerializable<BaseClassWithExtensibleEnumDiscriminator>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<BaseClassWithExtensibleEnumDiscriminator>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BaseClassWithExtensibleEnumDiscriminator>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty.ToString());
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
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

        internal static BaseClassWithExtensibleEnumDiscriminator DeserializeBaseClassWithExtensibleEnumDiscriminator(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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

            // Unknown type found so we will deserialize the base properties only
            BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("DiscriminatorProperty"u8))
                {
                    discriminatorProperty = new BaseClassWithEntensibleEnumDiscriminatorEnum(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new UnknownBaseClassWithExtensibleEnumDiscriminator(discriminatorProperty, rawData);
        }

        BaseClassWithExtensibleEnumDiscriminator IModelJsonSerializable<BaseClassWithExtensibleEnumDiscriminator>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeBaseClassWithExtensibleEnumDiscriminator(doc.RootElement, options);
        }

        BinaryData IModelSerializable<BaseClassWithExtensibleEnumDiscriminator>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        BaseClassWithExtensibleEnumDiscriminator IModelSerializable<BaseClassWithExtensibleEnumDiscriminator>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeBaseClassWithExtensibleEnumDiscriminator(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="BaseClassWithExtensibleEnumDiscriminator"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="BaseClassWithExtensibleEnumDiscriminator"/> to convert. </param>
        public static implicit operator RequestContent(BaseClassWithExtensibleEnumDiscriminator model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="BaseClassWithExtensibleEnumDiscriminator"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator BaseClassWithExtensibleEnumDiscriminator(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeBaseClassWithExtensibleEnumDiscriminator(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
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
