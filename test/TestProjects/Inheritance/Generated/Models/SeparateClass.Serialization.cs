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
    [JsonConverter(typeof(SeparateClassConverter))]
    public partial class SeparateClass : IUtf8JsonSerializable, IModelJsonSerializable<SeparateClass>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SeparateClass>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<SeparateClass>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(StringProperty))
            {
                writer.WritePropertyName("StringProperty"u8);
                writer.WriteStringValue(StringProperty);
            }
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                ((IModelJsonSerializable<BaseClassWithExtensibleEnumDiscriminator>)ModelProperty).Serialize(writer, options);
            }
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

        internal static SeparateClass DeserializeSeparateClass(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> stringProperty = default;
            Optional<BaseClassWithExtensibleEnumDiscriminator> modelProperty = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("StringProperty"u8))
                {
                    stringProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ModelProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    modelProperty = BaseClassWithExtensibleEnumDiscriminator.DeserializeBaseClassWithExtensibleEnumDiscriminator(property.Value);
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new SeparateClass(stringProperty.Value, modelProperty.Value, rawData);
        }

        SeparateClass IModelJsonSerializable<SeparateClass>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeSeparateClass(doc.RootElement, options);
        }

        BinaryData IModelSerializable<SeparateClass>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        SeparateClass IModelSerializable<SeparateClass>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeSeparateClass(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="SeparateClass"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="SeparateClass"/> to convert. </param>
        public static implicit operator RequestContent(SeparateClass model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="SeparateClass"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator SeparateClass(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeSeparateClass(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        internal partial class SeparateClassConverter : JsonConverter<SeparateClass>
        {
            public override void Write(Utf8JsonWriter writer, SeparateClass model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override SeparateClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeSeparateClass(document.RootElement);
            }
        }
    }
}
