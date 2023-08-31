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

namespace multiple_inheritance.Models
{
    public partial class Cat : IUtf8JsonSerializable, IModelJsonSerializable<Cat>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Cat>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Cat>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Cat>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(LikesMilk))
            {
                writer.WritePropertyName("likesMilk"u8);
                writer.WriteBooleanValue(LikesMilk.Value);
            }
            if (Optional.IsDefined(Meows))
            {
                writer.WritePropertyName("meows"u8);
                writer.WriteBooleanValue(Meows.Value);
            }
            if (Optional.IsDefined(Hisses))
            {
                writer.WritePropertyName("hisses"u8);
                writer.WriteBooleanValue(Hisses.Value);
            }
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
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

        internal static Cat DeserializeCat(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> likesMilk = default;
            Optional<bool> meows = default;
            Optional<bool> hisses = default;
            string name = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("likesMilk"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    likesMilk = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("meows"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    meows = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("hisses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hisses = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new Cat(name, Optional.ToNullable(likesMilk), Optional.ToNullable(meows), Optional.ToNullable(hisses), rawData);
        }

        Cat IModelJsonSerializable<Cat>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Cat>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeCat(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Cat>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Cat>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        Cat IModelSerializable<Cat>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Cat>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeCat(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="Cat"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="Cat"/> to convert. </param>
        public static implicit operator RequestContent(Cat model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="Cat"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator Cat(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeCat(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
