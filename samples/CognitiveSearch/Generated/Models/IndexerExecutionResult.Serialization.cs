// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class IndexerExecutionResult : IUtf8JsonSerializable, IJsonModel<IndexerExecutionResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<IndexerExecutionResult>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<IndexerExecutionResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<IndexerExecutionResult>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<IndexerExecutionResult>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.ToSerialString());
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ErrorMessage))
                {
                    writer.WritePropertyName("errorMessage"u8);
                    writer.WriteStringValue(ErrorMessage);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(StartTime))
                {
                    writer.WritePropertyName("startTime"u8);
                    writer.WriteStringValue(StartTime.Value, "O");
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(EndTime))
                {
                    writer.WritePropertyName("endTime"u8);
                    writer.WriteStringValue(EndTime.Value, "O");
                }
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("errors"u8);
                writer.WriteStartArray();
                foreach (var item in Errors)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("warnings"u8);
                writer.WriteStartArray();
                foreach (var item in Warnings)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("itemsProcessed"u8);
                writer.WriteNumberValue(ItemCount);
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("itemsFailed"u8);
                writer.WriteNumberValue(FailedItemCount);
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(InitialTrackingState))
                {
                    writer.WritePropertyName("initialTrackingState"u8);
                    writer.WriteStringValue(InitialTrackingState);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(FinalTrackingState))
                {
                    writer.WritePropertyName("finalTrackingState"u8);
                    writer.WriteStringValue(FinalTrackingState);
                }
            }
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

        IndexerExecutionResult IJsonModel<IndexerExecutionResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(IndexerExecutionResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIndexerExecutionResult(document.RootElement, options);
        }

        internal static IndexerExecutionResult DeserializeIndexerExecutionResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IndexerExecutionStatus status = default;
            Optional<string> errorMessage = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> endTime = default;
            IReadOnlyList<ItemError> errors = default;
            IReadOnlyList<ItemWarning> warnings = default;
            int itemsProcessed = default;
            int itemsFailed = default;
            Optional<string> initialTrackingState = default;
            Optional<string> finalTrackingState = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToIndexerExecutionStatus();
                    continue;
                }
                if (property.NameEquals("errorMessage"u8))
                {
                    errorMessage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("startTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("endTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    endTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    List<ItemError> array = new List<ItemError>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ItemError.DeserializeItemError(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("warnings"u8))
                {
                    List<ItemWarning> array = new List<ItemWarning>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ItemWarning.DeserializeItemWarning(item));
                    }
                    warnings = array;
                    continue;
                }
                if (property.NameEquals("itemsProcessed"u8))
                {
                    itemsProcessed = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("itemsFailed"u8))
                {
                    itemsFailed = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("initialTrackingState"u8))
                {
                    initialTrackingState = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("finalTrackingState"u8))
                {
                    finalTrackingState = property.Value.GetString();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new IndexerExecutionResult(status, errorMessage.Value, Optional.ToNullable(startTime), Optional.ToNullable(endTime), errors, warnings, itemsProcessed, itemsFailed, initialTrackingState.Value, finalTrackingState.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<IndexerExecutionResult>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(IndexerExecutionResult)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        IndexerExecutionResult IPersistableModel<IndexerExecutionResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(IndexerExecutionResult)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeIndexerExecutionResult(document.RootElement, options);
        }

        string IPersistableModel<IndexerExecutionResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
