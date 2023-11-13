// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class HighWaterMarkChangeDetectionPolicy : IUtf8JsonSerializable, IJsonModel<HighWaterMarkChangeDetectionPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<HighWaterMarkChangeDetectionPolicy>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<HighWaterMarkChangeDetectionPolicy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<HighWaterMarkChangeDetectionPolicy>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<HighWaterMarkChangeDetectionPolicy>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("highWaterMarkColumnName"u8);
            writer.WriteStringValue(HighWaterMarkColumnName);
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        HighWaterMarkChangeDetectionPolicy IJsonModel<HighWaterMarkChangeDetectionPolicy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(HighWaterMarkChangeDetectionPolicy)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeHighWaterMarkChangeDetectionPolicy(document.RootElement, options);
        }

        internal static HighWaterMarkChangeDetectionPolicy DeserializeHighWaterMarkChangeDetectionPolicy(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string highWaterMarkColumnName = default;
            string odataType = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("highWaterMarkColumnName"u8))
                {
                    highWaterMarkColumnName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new HighWaterMarkChangeDetectionPolicy(odataType, serializedAdditionalRawData, highWaterMarkColumnName);
        }

        BinaryData IPersistableModel<HighWaterMarkChangeDetectionPolicy>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(HighWaterMarkChangeDetectionPolicy)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        HighWaterMarkChangeDetectionPolicy IPersistableModel<HighWaterMarkChangeDetectionPolicy>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(HighWaterMarkChangeDetectionPolicy)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeHighWaterMarkChangeDetectionPolicy(document.RootElement, options);
        }

        string IPersistableModel<HighWaterMarkChangeDetectionPolicy>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
