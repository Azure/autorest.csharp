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

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class SentimentConfidenceScorePerLabel : IUtf8JsonSerializable, IJsonModel<SentimentConfidenceScorePerLabel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SentimentConfidenceScorePerLabel>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<SentimentConfidenceScorePerLabel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("positive"u8);
            writer.WriteNumberValue(Positive);
            writer.WritePropertyName("neutral"u8);
            writer.WriteNumberValue(Neutral);
            writer.WritePropertyName("negative"u8);
            writer.WriteNumberValue(Negative);
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

        SentimentConfidenceScorePerLabel IJsonModel<SentimentConfidenceScorePerLabel>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSentimentConfidenceScorePerLabel(document.RootElement, options);
        }

        internal static SentimentConfidenceScorePerLabel DeserializeSentimentConfidenceScorePerLabel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            double positive = default;
            double neutral = default;
            double negative = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("positive"u8))
                {
                    positive = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("neutral"u8))
                {
                    neutral = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("negative"u8))
                {
                    negative = property.Value.GetDouble();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new SentimentConfidenceScorePerLabel(positive, neutral, negative, serializedAdditionalRawData);
        }

        BinaryData IModel<SentimentConfidenceScorePerLabel>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.WriteCore(this, options);
        }

        SentimentConfidenceScorePerLabel IModel<SentimentConfidenceScorePerLabel>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSentimentConfidenceScorePerLabel(document.RootElement, options);
        }
    }
}
