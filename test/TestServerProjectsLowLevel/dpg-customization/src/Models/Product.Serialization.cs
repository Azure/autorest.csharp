// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace dpg_customization_LowLevel.Models
{
    public partial class Product : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        internal static Product DeserializeProduct(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            ProductReceived received = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("received"))
                {
                    received = new ProductReceived(property.Value.GetString());
                    continue;
                }
            }
            return new Product(received);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static Product FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeProduct(document.RootElement);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeProduct(doc.RootElement, options);
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeProduct(doc.RootElement, options);
        }

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("received");
            writer.WriteStringValue(Received.ToString());
            writer.WriteEndObject();
        }
    }
}
