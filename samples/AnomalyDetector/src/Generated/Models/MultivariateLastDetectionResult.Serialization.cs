// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class MultivariateLastDetectionResult : IUtf8JsonSerializable, IJsonModel<MultivariateLastDetectionResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MultivariateLastDetectionResult>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<MultivariateLastDetectionResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultivariateLastDetectionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(MultivariateLastDetectionResult)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(VariableStates))
            {
                writer.WritePropertyName("variableStates"u8);
                writer.WriteStartArray();
                foreach (var item in VariableStates)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Results))
            {
                writer.WritePropertyName("results"u8);
                writer.WriteStartArray();
                foreach (var item in Results)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
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

        MultivariateLastDetectionResult IJsonModel<MultivariateLastDetectionResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultivariateLastDetectionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(MultivariateLastDetectionResult)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMultivariateLastDetectionResult(document.RootElement, options);
        }

        internal static MultivariateLastDetectionResult DeserializeMultivariateLastDetectionResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<VariableState>> variableStates = default;
            Optional<IReadOnlyList<AnomalyState>> results = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("variableStates"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VariableState> array = new List<VariableState>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VariableState.DeserializeVariableState(item));
                    }
                    variableStates = array;
                    continue;
                }
                if (property.NameEquals("results"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AnomalyState> array = new List<AnomalyState>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AnomalyState.DeserializeAnomalyState(item));
                    }
                    results = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new MultivariateLastDetectionResult(Optional.ToList(variableStates), Optional.ToList(results), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MultivariateLastDetectionResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultivariateLastDetectionResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(MultivariateLastDetectionResult)} does not support '{options.Format}' format.");
            }
        }

        MultivariateLastDetectionResult IPersistableModel<MultivariateLastDetectionResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MultivariateLastDetectionResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMultivariateLastDetectionResult(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(MultivariateLastDetectionResult)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<MultivariateLastDetectionResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MultivariateLastDetectionResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMultivariateLastDetectionResult(document.RootElement);
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
