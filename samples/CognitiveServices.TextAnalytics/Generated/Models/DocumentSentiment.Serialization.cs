// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentSentiment : IUtf8JsonSerializable, IModelJsonSerializable<DocumentSentiment>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DocumentSentiment>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DocumentSentiment>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("sentiment"u8);
            writer.WriteStringValue(Sentiment.ToSerialString());
            if (Optional.IsDefined(Statistics))
            {
                writer.WritePropertyName("statistics"u8);
                writer.WriteObjectValue(Statistics);
            }
            writer.WritePropertyName("confidenceScores"u8);
            writer.WriteObjectValue(ConfidenceScores);
            writer.WritePropertyName("sentences"u8);
            writer.WriteStartArray();
            foreach (var item in Sentences)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("warnings"u8);
            writer.WriteStartArray();
            foreach (var item in Warnings)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        DocumentSentiment IModelJsonSerializable<DocumentSentiment>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDocumentSentiment(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DocumentSentiment>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        DocumentSentiment IModelSerializable<DocumentSentiment>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDocumentSentiment(document.RootElement, options);
        }

        internal static DocumentSentiment DeserializeDocumentSentiment(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            DocumentSentimentValue sentiment = default;
            Optional<DocumentStatistics> statistics = default;
            SentimentConfidenceScorePerLabel confidenceScores = default;
            IReadOnlyList<SentenceSentiment> sentences = default;
            IReadOnlyList<TextAnalyticsWarning> warnings = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sentiment"u8))
                {
                    sentiment = property.Value.GetString().ToDocumentSentimentValue();
                    continue;
                }
                if (property.NameEquals("statistics"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    statistics = DocumentStatistics.DeserializeDocumentStatistics(property.Value);
                    continue;
                }
                if (property.NameEquals("confidenceScores"u8))
                {
                    confidenceScores = SentimentConfidenceScorePerLabel.DeserializeSentimentConfidenceScorePerLabel(property.Value);
                    continue;
                }
                if (property.NameEquals("sentences"u8))
                {
                    List<SentenceSentiment> array = new List<SentenceSentiment>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SentenceSentiment.DeserializeSentenceSentiment(item));
                    }
                    sentences = array;
                    continue;
                }
                if (property.NameEquals("warnings"u8))
                {
                    List<TextAnalyticsWarning> array = new List<TextAnalyticsWarning>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TextAnalyticsWarning.DeserializeTextAnalyticsWarning(item));
                    }
                    warnings = array;
                    continue;
                }
            }
            return new DocumentSentiment(id, sentiment, statistics.Value, confidenceScores, sentences, warnings);
        }
    }
}
