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
    public partial class Product : IUtf8JsonSerializable, IModelJsonSerializable<Product>
    {
        /// <summary>
        /// Converts a <see cref="Product"/> into a <see cref="RequestContent"/> using the default serialization options.
        /// </summary>
        /// <param name="product">The product to convert.</param>
        public static implicit operator RequestContent(Product product)
        {
            if (product == null)
            {
                return null;
            }

            return RequestContent.Create(product, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary>
        /// Converts a <see cref="Response"/> to a <see cref="Product"/>.
        /// </summary>
        /// <param name="response">The response to convert.</param>
        public static explicit operator Product(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            using JsonDocument jsonDocument = JsonDocument.Parse(response.ContentStream);
            return DeserializeProduct(jsonDocument.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Product>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        internal static Product DeserializeProduct(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
            ProductReceived received = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("received"))
                {
                    received = new ProductReceived(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new Product(received, rawData);
        }

        Product IModelJsonSerializable<Product>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeProduct(doc.RootElement, options);
        }

        Product IModelSerializable<Product>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeProduct(doc.RootElement, options);
        }

        void IModelJsonSerializable<Product>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("received");
            writer.WriteStringValue(Received.ToString());
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

        BinaryData IModelSerializable<Product>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }
    }
}
