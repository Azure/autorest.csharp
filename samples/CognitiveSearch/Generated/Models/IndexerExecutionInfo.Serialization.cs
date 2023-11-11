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
    public partial class IndexerExecutionInfo : IUtf8JsonSerializable, IJsonModel<IndexerExecutionInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<IndexerExecutionInfo>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<IndexerExecutionInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<IndexerExecutionInfo>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<IndexerExecutionInfo>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.ToSerialString());
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(LastResult))
                {
                    writer.WritePropertyName("lastResult"u8);
                    writer.WriteObjectValue(LastResult);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("executionHistory"u8);
                writer.WriteStartArray();
                foreach (var item in ExecutionHistory)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("limits"u8);
                writer.WriteObjectValue(Limits);
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

        IndexerExecutionInfo IJsonModel<IndexerExecutionInfo>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(IndexerExecutionInfo)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIndexerExecutionInfo(document.RootElement, options);
        }

        internal static IndexerExecutionInfo DeserializeIndexerExecutionInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IndexerStatus status = default;
            Optional<IndexerExecutionResult> lastResult = default;
            IReadOnlyList<IndexerExecutionResult> executionHistory = default;
            IndexerLimits limits = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToIndexerStatus();
                    continue;
                }
                if (property.NameEquals("lastResult"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastResult = IndexerExecutionResult.DeserializeIndexerExecutionResult(property.Value);
                    continue;
                }
                if (property.NameEquals("executionHistory"u8))
                {
                    List<IndexerExecutionResult> array = new List<IndexerExecutionResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(IndexerExecutionResult.DeserializeIndexerExecutionResult(item));
                    }
                    executionHistory = array;
                    continue;
                }
                if (property.NameEquals("limits"u8))
                {
                    limits = IndexerLimits.DeserializeIndexerLimits(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new IndexerExecutionInfo(status, lastResult.Value, executionHistory, limits, serializedAdditionalRawData);
        }

        BinaryData IModel<IndexerExecutionInfo>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(IndexerExecutionInfo)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        IndexerExecutionInfo IModel<IndexerExecutionInfo>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(IndexerExecutionInfo)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeIndexerExecutionInfo(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<IndexerExecutionInfo>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
