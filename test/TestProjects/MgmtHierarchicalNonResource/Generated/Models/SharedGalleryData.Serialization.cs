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

namespace MgmtHierarchicalNonResource
{
    public partial class SharedGalleryData : IUtf8JsonSerializable, IModelJsonSerializable<SharedGalleryData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SharedGalleryData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<SharedGalleryData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<SharedGalleryData>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("identifier"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(UniqueId))
            {
                writer.WritePropertyName("uniqueId"u8);
                writer.WriteStringValue(UniqueId);
            }
            writer.WriteEndObject();
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

        internal static SharedGalleryData DeserializeSharedGalleryData(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> location = default;
            Optional<string> uniqueId = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("identifier"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("uniqueId"u8))
                        {
                            uniqueId = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new SharedGalleryData(name.Value, location.Value, uniqueId.Value, rawData);
        }

        SharedGalleryData IModelJsonSerializable<SharedGalleryData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<SharedGalleryData>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeSharedGalleryData(doc.RootElement, options);
        }

        BinaryData IModelSerializable<SharedGalleryData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<SharedGalleryData>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        SharedGalleryData IModelSerializable<SharedGalleryData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<SharedGalleryData>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeSharedGalleryData(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="SharedGalleryData"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="SharedGalleryData"/> to convert. </param>
        public static implicit operator RequestContent(SharedGalleryData model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="SharedGalleryData"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator SharedGalleryData(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeSharedGalleryData(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
