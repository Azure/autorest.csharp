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
    public partial class UnivariateChangePointDetectionResult : IUtf8JsonSerializable, IJsonModel<UnivariateChangePointDetectionResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<UnivariateChangePointDetectionResult>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<UnivariateChangePointDetectionResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UnivariateChangePointDetectionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(UnivariateChangePointDetectionResult)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W")
            {
                if (Optional.IsDefined(Period))
                {
                    writer.WritePropertyName("period"u8);
                    writer.WriteNumberValue(Period.Value);
                }
            }
            if (Optional.IsCollectionDefined(IsChangePoint))
            {
                writer.WritePropertyName("isChangePoint"u8);
                writer.WriteStartArray();
                foreach (var item in IsChangePoint)
                {
                    writer.WriteBooleanValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ConfidenceScores))
            {
                writer.WritePropertyName("confidenceScores"u8);
                writer.WriteStartArray();
                foreach (var item in ConfidenceScores)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        UnivariateChangePointDetectionResult IJsonModel<UnivariateChangePointDetectionResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UnivariateChangePointDetectionResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(UnivariateChangePointDetectionResult)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUnivariateChangePointDetectionResult(document.RootElement, options);
        }

        internal static UnivariateChangePointDetectionResult DeserializeUnivariateChangePointDetectionResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> period = default;
            Optional<IReadOnlyList<bool>> isChangePoint = default;
            Optional<IReadOnlyList<float>> confidenceScores = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("period"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    period = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("isChangePoint"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<bool> array = new List<bool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetBoolean());
                    }
                    isChangePoint = array;
                    continue;
                }
                if (property.NameEquals("confidenceScores"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    confidenceScores = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UnivariateChangePointDetectionResult(Optional.ToNullable(period), Optional.ToList(isChangePoint), Optional.ToList(confidenceScores), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<UnivariateChangePointDetectionResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UnivariateChangePointDetectionResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(UnivariateChangePointDetectionResult)} does not support '{options.Format}' format.");
            }
        }

        UnivariateChangePointDetectionResult IPersistableModel<UnivariateChangePointDetectionResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UnivariateChangePointDetectionResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeUnivariateChangePointDetectionResult(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(UnivariateChangePointDetectionResult)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<UnivariateChangePointDetectionResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static UnivariateChangePointDetectionResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnivariateChangePointDetectionResult(document.RootElement, new ModelReaderWriterOptions("W"));
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
