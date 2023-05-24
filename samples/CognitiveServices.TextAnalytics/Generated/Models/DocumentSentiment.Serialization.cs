// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentSentiment
    {
        internal static DocumentSentiment DeserializeDocumentSentiment(JsonElement element, SerializableOptions options = default)
        {
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
