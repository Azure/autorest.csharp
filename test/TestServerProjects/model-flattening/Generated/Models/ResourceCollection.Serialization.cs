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

namespace model_flattening.Models
{
    public partial class ResourceCollection : IUtf8JsonSerializable, IModelJsonSerializable<ResourceCollection>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ResourceCollection>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ResourceCollection>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Productresource))
            {
                writer.WritePropertyName("productresource"u8);
                if (Productresource is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<FlattenedProduct>)Productresource).Serialize(writer, options);
                }
            }
            if (Optional.IsCollectionDefined(Arrayofresources))
            {
                writer.WritePropertyName("arrayofresources"u8);
                writer.WriteStartArray();
                foreach (var item in Arrayofresources)
                {
                    if (item is null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        ((IModelJsonSerializable<FlattenedProduct>)item).Serialize(writer, options);
                    }
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Dictionaryofresources))
            {
                writer.WritePropertyName("dictionaryofresources"u8);
                writer.WriteStartObject();
                foreach (var item in Dictionaryofresources)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value is null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        ((IModelJsonSerializable<FlattenedProduct>)item.Value).Serialize(writer, options);
                    }
                }
                writer.WriteEndObject();
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

        internal static ResourceCollection DeserializeResourceCollection(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<FlattenedProduct> productresource = default;
            Optional<IList<FlattenedProduct>> arrayofresources = default;
            Optional<IDictionary<string, FlattenedProduct>> dictionaryofresources = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("productresource"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    productresource = FlattenedProduct.DeserializeFlattenedProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("arrayofresources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FlattenedProduct> array = new List<FlattenedProduct>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FlattenedProduct.DeserializeFlattenedProduct(item));
                    }
                    arrayofresources = array;
                    continue;
                }
                if (property.NameEquals("dictionaryofresources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, FlattenedProduct> dictionary = new Dictionary<string, FlattenedProduct>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, FlattenedProduct.DeserializeFlattenedProduct(property0.Value));
                    }
                    dictionaryofresources = dictionary;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ResourceCollection(productresource.Value, Optional.ToList(arrayofresources), Optional.ToDictionary(dictionaryofresources), serializedAdditionalRawData);
        }

        ResourceCollection IModelJsonSerializable<ResourceCollection>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeResourceCollection(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ResourceCollection>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ResourceCollection IModelSerializable<ResourceCollection>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeResourceCollection(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ResourceCollection"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ResourceCollection"/> to convert. </param>
        public static implicit operator RequestContent(ResourceCollection model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ResourceCollection"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ResourceCollection(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeResourceCollection(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
