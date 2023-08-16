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

namespace validation.Models
{
    public partial class Product : IUtf8JsonSerializable, IModelJsonSerializable<Product>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Product>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Product>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(DisplayNames))
            {
                writer.WritePropertyName("display_names"u8);
                writer.WriteStartArray();
                foreach (var item in DisplayNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("capacity"u8);
                writer.WriteNumberValue(Capacity.Value);
            }
            if (Optional.IsDefined(Image))
            {
                writer.WritePropertyName("image"u8);
                writer.WriteStringValue(Image);
            }
            writer.WritePropertyName("child"u8);
            writer.WriteObjectValue(Child);
            writer.WritePropertyName("constChild"u8);
            writer.WriteObjectValue(ConstChild);
            writer.WritePropertyName("constInt"u8);
            writer.WriteNumberValue(ConstInt.ToSerialInt32());
            writer.WritePropertyName("constString"u8);
            writer.WriteStringValue(ConstString.ToString());
            if (Optional.IsDefined(ConstStringAsEnum))
            {
                writer.WritePropertyName("constStringAsEnum"u8);
                writer.WriteStringValue(ConstStringAsEnum.Value.ToString());
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

        internal static Product DeserializeProduct(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> displayNames = default;
            Optional<int> capacity = default;
            Optional<string> image = default;
            ChildProduct child = default;
            ConstantProduct constChild = default;
            ProductConstInt constInt = default;
            ProductConstString constString = default;
            Optional<EnumConst> constStringAsEnum = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("display_names"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    displayNames = array;
                    continue;
                }
                if (property.NameEquals("capacity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    capacity = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("image"u8))
                {
                    image = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("child"u8))
                {
                    child = ChildProduct.DeserializeChildProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("constChild"u8))
                {
                    constChild = ConstantProduct.DeserializeConstantProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("constInt"u8))
                {
                    constInt = new ProductConstInt(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("constString"u8))
                {
                    constString = new ProductConstString(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("constStringAsEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    constStringAsEnum = new EnumConst(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new Product(Optional.ToList(displayNames), Optional.ToNullable(capacity), image.Value, child, constChild, constInt, constString, Optional.ToNullable(constStringAsEnum), rawData);
        }

        Product IModelJsonSerializable<Product>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeProduct(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Product>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        Product IModelSerializable<Product>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeProduct(doc.RootElement, options);
        }

        public static implicit operator RequestContent(Product model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator Product(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeProduct(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
