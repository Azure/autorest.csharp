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

namespace AnomalyDetector.Models
{
    public partial class MultivariateBatchDetectionResultSummary : IUtf8JsonSerializable, IJsonModel<MultivariateBatchDetectionResultSummary>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MultivariateBatchDetectionResultSummary>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MultivariateBatchDetectionResultSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultivariateBatchDetectionResultSummary>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MultivariateBatchDetectionResultSummary)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status.ToSerialString());
            if (Optional.IsCollectionDefined(Errors))
            {
                writer.WritePropertyName("errors"u8);
                writer.WriteStartArray();
                foreach (var item in Errors)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(VariableStates))
            {
                writer.WritePropertyName("variableStates"u8);
                writer.WriteStartArray();
                foreach (var item in VariableStates)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("setupInfo"u8);
            writer.WriteObjectValue(SetupInfo, options);
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, new JsonDocumentOptions { MaxDepth = 256 }))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        MultivariateBatchDetectionResultSummary IJsonModel<MultivariateBatchDetectionResultSummary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultivariateBatchDetectionResultSummary>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MultivariateBatchDetectionResultSummary)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMultivariateBatchDetectionResultSummary(document.RootElement, options);
        }

        internal static MultivariateBatchDetectionResultSummary DeserializeMultivariateBatchDetectionResultSummary(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MultivariateBatchDetectionStatus status = default;
            IReadOnlyList<ErrorResponse> errors = default;
            IReadOnlyList<VariableState> variableStates = default;
            MultivariateBatchDetectionOptions setupInfo = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToMultivariateBatchDetectionStatus();
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ErrorResponse> array = new List<ErrorResponse>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ErrorResponse.DeserializeErrorResponse(item, options));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("variableStates"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VariableState> array = new List<VariableState>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VariableState.DeserializeVariableState(item, options));
                    }
                    variableStates = array;
                    continue;
                }
                if (property.NameEquals("setupInfo"u8))
                {
                    setupInfo = MultivariateBatchDetectionOptions.DeserializeMultivariateBatchDetectionOptions(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MultivariateBatchDetectionResultSummary(status, errors ?? new ChangeTrackingList<ErrorResponse>(), variableStates ?? new ChangeTrackingList<VariableState>(), setupInfo, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MultivariateBatchDetectionResultSummary>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultivariateBatchDetectionResultSummary>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MultivariateBatchDetectionResultSummary)} does not support writing '{options.Format}' format.");
            }
        }

        MultivariateBatchDetectionResultSummary IPersistableModel<MultivariateBatchDetectionResultSummary>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultivariateBatchDetectionResultSummary>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, new JsonDocumentOptions { MaxDepth = 256 });
                        return DeserializeMultivariateBatchDetectionResultSummary(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MultivariateBatchDetectionResultSummary)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MultivariateBatchDetectionResultSummary>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MultivariateBatchDetectionResultSummary FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, new JsonDocumentOptions { MaxDepth = 256 });
            return DeserializeMultivariateBatchDetectionResultSummary(document.RootElement);
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
