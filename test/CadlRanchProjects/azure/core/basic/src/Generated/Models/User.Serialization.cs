// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Specs_.Azure.Core.Basic.Models
{
    public partial class User : IUtf8JsonSerializable, IJsonModel<User>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<User>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<User>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<User>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<User>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteNumberValue(Id);
            }
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsCollectionDefined(Orders))
            {
                writer.WritePropertyName("orders"u8);
                writer.WriteStartArray();
                foreach (var item in Orders)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(Etag);
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        User IJsonModel<User>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(User)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUser(document.RootElement, options);
        }

        internal static User DeserializeUser(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int id = default;
            string name = default;
            Optional<IList<UserOrder>> orders = default;
            string etag = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("orders"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<UserOrder> array = new List<UserOrder>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(UserOrder.DeserializeUserOrder(item));
                    }
                    orders = array;
                    continue;
                }
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new User(id, name, Optional.ToList(orders), etag, serializedAdditionalRawData);
        }

        BinaryData IModel<User>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(User)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        User IModel<User>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(User)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeUser(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<User>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static User FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUser(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
