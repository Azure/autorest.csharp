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

namespace MgmtAcronymMapping.Models
{
    public partial class ImageReference : IUtf8JsonSerializable, IModelJsonSerializable<ImageReference>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ImageReference>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ImageReference>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ImageReference>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Publisher))
            {
                writer.WritePropertyName("publisher"u8);
                writer.WriteStringValue(Publisher);
            }
            if (Optional.IsDefined(Offer))
            {
                writer.WritePropertyName("offer"u8);
                writer.WriteStringValue(Offer);
            }
            if (Optional.IsDefined(Sku))
            {
                writer.WritePropertyName("sku"u8);
                writer.WriteStringValue(Sku);
            }
            if (Optional.IsDefined(Version))
            {
                writer.WritePropertyName("version"u8);
                writer.WriteStringValue(Version);
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
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

        internal static ImageReference DeserializeImageReference(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> publisher = default;
            Optional<string> offer = default;
            Optional<string> sku = default;
            Optional<string> version = default;
            Optional<string> exactVersion = default;
            Optional<string> id = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("publisher"u8))
                {
                    publisher = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("offer"u8))
                {
                    offer = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sku"u8))
                {
                    sku = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("version"u8))
                {
                    version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("exactVersion"u8))
                {
                    exactVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ImageReference(id.Value, publisher.Value, offer.Value, sku.Value, version.Value, exactVersion.Value, serializedAdditionalRawData);
        }

        ImageReference IModelJsonSerializable<ImageReference>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ImageReference>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeImageReference(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ImageReference>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ImageReference>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ImageReference IModelSerializable<ImageReference>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<ImageReference>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeImageReference(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ImageReference"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ImageReference"/> to convert. </param>
        public static implicit operator RequestContent(ImageReference model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ImageReference"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ImageReference(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeImageReference(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
