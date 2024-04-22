// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Client.Naming.Models
{
    public partial class ClientNameAndJsonEncodedNameModel : IUtf8JsonSerializable, IJsonModel<ClientNameAndJsonEncodedNameModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ClientNameAndJsonEncodedNameModel>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ClientNameAndJsonEncodedNameModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ClientNameAndJsonEncodedNameModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ClientNameAndJsonEncodedNameModel)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("wireName"u8);
            writer.WriteBooleanValue(ClientName);
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        ClientNameAndJsonEncodedNameModel IJsonModel<ClientNameAndJsonEncodedNameModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ClientNameAndJsonEncodedNameModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ClientNameAndJsonEncodedNameModel)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeClientNameAndJsonEncodedNameModel(document.RootElement, options);
        }

        internal static ClientNameAndJsonEncodedNameModel DeserializeClientNameAndJsonEncodedNameModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool wireName = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("wireName"u8))
                {
                    wireName = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ClientNameAndJsonEncodedNameModel(wireName, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ClientNameAndJsonEncodedNameModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ClientNameAndJsonEncodedNameModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ClientNameAndJsonEncodedNameModel)} does not support writing '{options.Format}' format.");
            }
        }

        ClientNameAndJsonEncodedNameModel IPersistableModel<ClientNameAndJsonEncodedNameModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ClientNameAndJsonEncodedNameModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeClientNameAndJsonEncodedNameModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ClientNameAndJsonEncodedNameModel)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ClientNameAndJsonEncodedNameModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ClientNameAndJsonEncodedNameModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeClientNameAndJsonEncodedNameModel(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
