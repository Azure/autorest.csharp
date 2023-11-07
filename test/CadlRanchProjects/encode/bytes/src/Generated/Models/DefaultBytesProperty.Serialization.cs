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

namespace Encode.Bytes.Models
{
    public partial class DefaultBytesProperty : IUtf8JsonSerializable, IJsonModel<DefaultBytesProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DefaultBytesProperty>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<DefaultBytesProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value"u8);
            writer.WriteBase64StringValue(Value.ToArray(), "D");
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

        DefaultBytesProperty IJsonModel<DefaultBytesProperty>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DefaultBytesProperty)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDefaultBytesProperty(document.RootElement, options);
        }

        internal static DefaultBytesProperty DeserializeDefaultBytesProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData value = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    value = BinaryData.FromBytes(property.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DefaultBytesProperty(value, serializedAdditionalRawData);
        }

        BinaryData IModel<DefaultBytesProperty>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DefaultBytesProperty)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DefaultBytesProperty IModel<DefaultBytesProperty>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DefaultBytesProperty)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDefaultBytesProperty(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<DefaultBytesProperty>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static DefaultBytesProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDefaultBytesProperty(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
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
