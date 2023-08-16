// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace dpg_customization_LowLevel.Models
{
    internal partial class ProductResult : IUtf8JsonSerializable, IModelJsonSerializable<ProductResult>
    {
        public static implicit operator RequestContent(ProductResult productResult)
        {
            if (productResult == null)
            {
                return null;
            }

            return RequestContent.Create(productResult, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ProductResult(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
            return DeserializeProductResult(jsonDocument.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ProductResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        internal static ProductResult DeserializeProductResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
            Optional<IReadOnlyList<Product>> values = default;
            Optional<string> nextLink = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("values"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<Product> array = new List<Product>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Product.DeserializeProduct(item));
                    }
                    values = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new ProductResult(Optional.ToList(values), nextLink.Value, rawData);
        }

        void IModelJsonSerializable<ProductResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("nextLink");
            writer.WriteStringValue(NextLink);
            writer.WritePropertyName("values");
            writer.WriteStartArray();
            foreach (var item in Values)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (options.Format == ModelSerializerFormat.Json)
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

        ProductResult IModelJsonSerializable<ProductResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeProductResult(doc.RootElement, options);
        }

        ProductResult IModelSerializable<ProductResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeProductResult(doc.RootElement, options);
        }
        BinaryData IModelSerializable<ProductResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }
    }
}
