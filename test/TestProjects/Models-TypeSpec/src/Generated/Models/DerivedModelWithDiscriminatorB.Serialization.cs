// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace ModelsTypeSpec.Models
{
    public partial class DerivedModelWithDiscriminatorB : IUtf8JsonSerializable, IModelJsonSerializable<DerivedModelWithDiscriminatorB>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DerivedModelWithDiscriminatorB>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DerivedModelWithDiscriminatorB>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DerivedModelWithDiscriminatorB>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("discriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty);
            if (Optional.IsDefined(OptionalPropertyOnBase))
            {
                writer.WritePropertyName("optionalPropertyOnBase"u8);
                writer.WriteStringValue(OptionalPropertyOnBase);
            }
            writer.WritePropertyName("requiredPropertyOnBase"u8);
            writer.WriteNumberValue(RequiredPropertyOnBase);
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

        internal static DerivedModelWithDiscriminatorB DeserializeDerivedModelWithDiscriminatorB(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int requiredInt = default;
            string discriminatorProperty = default;
            Optional<string> optionalPropertyOnBase = default;
            int requiredPropertyOnBase = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredInt"u8))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("discriminatorProperty"u8))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("optionalPropertyOnBase"u8))
                {
                    optionalPropertyOnBase = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredPropertyOnBase"u8))
                {
                    requiredPropertyOnBase = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DerivedModelWithDiscriminatorB(discriminatorProperty, optionalPropertyOnBase.Value, requiredPropertyOnBase, requiredInt, rawData);
        }

        DerivedModelWithDiscriminatorB IModelJsonSerializable<DerivedModelWithDiscriminatorB>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DerivedModelWithDiscriminatorB>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDerivedModelWithDiscriminatorB(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DerivedModelWithDiscriminatorB>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DerivedModelWithDiscriminatorB>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DerivedModelWithDiscriminatorB IModelSerializable<DerivedModelWithDiscriminatorB>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DerivedModelWithDiscriminatorB>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDerivedModelWithDiscriminatorB(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="DerivedModelWithDiscriminatorB"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="DerivedModelWithDiscriminatorB"/> to convert. </param>
        public static implicit operator RequestContent(DerivedModelWithDiscriminatorB model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="DerivedModelWithDiscriminatorB"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator DerivedModelWithDiscriminatorB(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDerivedModelWithDiscriminatorB(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
