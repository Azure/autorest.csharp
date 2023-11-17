// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class DataChangeDetectionPolicy : IUtf8JsonSerializable, IJsonModel<DataChangeDetectionPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DataChangeDetectionPolicy>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DataChangeDetectionPolicy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<DataChangeDetectionPolicy>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<DataChangeDetectionPolicy>)} interface");
            }

            writer.WriteStartObject();
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

        DataChangeDetectionPolicy IJsonModel<DataChangeDetectionPolicy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DataChangeDetectionPolicy)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataChangeDetectionPolicy(document.RootElement, options);
        }

        internal static DataChangeDetectionPolicy DeserializeDataChangeDetectionPolicy(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.HighWaterMarkChangeDetectionPolicy": return HighWaterMarkChangeDetectionPolicy.DeserializeHighWaterMarkChangeDetectionPolicy(element);
                    case "#Microsoft.Azure.Search.SqlIntegratedChangeTrackingPolicy": return SqlIntegratedChangeTrackingPolicy.DeserializeSqlIntegratedChangeTrackingPolicy(element);
                }
            }
            return UnknownDataChangeDetectionPolicy.DeserializeUnknownDataChangeDetectionPolicy(element);
        }

        BinaryData IPersistableModel<DataChangeDetectionPolicy>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DataChangeDetectionPolicy)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DataChangeDetectionPolicy IPersistableModel<DataChangeDetectionPolicy>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DataChangeDetectionPolicy)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDataChangeDetectionPolicy(document.RootElement, options);
        }

        string IPersistableModel<DataChangeDetectionPolicy>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
