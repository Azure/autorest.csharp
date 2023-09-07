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

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class Entity : IUtf8JsonSerializable, IModelJsonSerializable<Entity>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Entity>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Entity>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("text"u8);
            writer.WriteStringValue(Text);
            writer.WritePropertyName("category"u8);
            writer.WriteStringValue(Category);
            if (Optional.IsDefined(Subcategory))
            {
                writer.WritePropertyName("subcategory"u8);
                writer.WriteStringValue(Subcategory);
            }
            writer.WritePropertyName("offset"u8);
            writer.WriteNumberValue(Offset);
            writer.WritePropertyName("length"u8);
            writer.WriteNumberValue(Length);
            writer.WritePropertyName("confidenceScore"u8);
            writer.WriteNumberValue(ConfidenceScore);
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

        internal static Entity DeserializeEntity(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string text = default;
            string category = default;
            Optional<string> subcategory = default;
            int offset = default;
            int length = default;
            double confidenceScore = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("category"u8))
                {
                    category = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("subcategory"u8))
                {
                    subcategory = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("offset"u8))
                {
                    offset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("length"u8))
                {
                    length = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("confidenceScore"u8))
                {
                    confidenceScore = property.Value.GetDouble();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new Entity(text, category, subcategory.Value, offset, length, confidenceScore, serializedAdditionalRawData);
        }

        Entity IModelJsonSerializable<Entity>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeEntity(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Entity>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        Entity IModelSerializable<Entity>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeEntity(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="Entity"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="Entity"/> to convert. </param>
        public static implicit operator RequestContent(Entity model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="Entity"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator Entity(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeEntity(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
