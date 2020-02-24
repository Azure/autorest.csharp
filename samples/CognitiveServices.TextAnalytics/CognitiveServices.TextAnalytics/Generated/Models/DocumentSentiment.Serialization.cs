// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentSentiment : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("sentiment");
            writer.WriteStringValue(Sentiment.ToSerialString());
            if (Statistics != null)
            {
                writer.WritePropertyName("statistics");
                writer.WriteObjectValue(Statistics);
            }
            writer.WritePropertyName("documentScores");
            writer.WriteObjectValue(DocumentScores);
            writer.WritePropertyName("sentences");
            writer.WriteStartArray();
            foreach (var item in Sentences)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static DocumentSentiment DeserializeDocumentSentiment(JsonElement element)
        {
            DocumentSentiment result = new DocumentSentiment();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sentiment"))
                {
                    result.Sentiment = property.Value.GetString().ToDocumentSentimentValue();
                    continue;
                }
                if (property.NameEquals("statistics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Statistics = DocumentStatistics.DeserializeDocumentStatistics(property.Value);
                    continue;
                }
                if (property.NameEquals("documentScores"))
                {
                    result.DocumentScores = SentimentConfidenceScorePerLabel.DeserializeSentimentConfidenceScorePerLabel(property.Value);
                    continue;
                }
                if (property.NameEquals("sentences"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Sentences.Add(SentenceSentiment.DeserializeSentenceSentiment(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
