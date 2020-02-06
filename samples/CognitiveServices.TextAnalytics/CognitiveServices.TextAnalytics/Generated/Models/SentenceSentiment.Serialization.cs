// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class SentenceSentiment : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("sentiment");
            writer.WriteStringValue(Sentiment.ToString());
            writer.WritePropertyName("sentenceScores");
            writer.WriteObjectValue(SentenceScores);
            writer.WritePropertyName("offset");
            writer.WriteNumberValue(Offset);
            writer.WritePropertyName("length");
            writer.WriteNumberValue(Length);
            writer.WritePropertyName("warnings");
            writer.WriteStartArray();
            foreach (var item in Warnings)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static Models.SentenceSentiment DeserializeSentenceSentiment(JsonElement element)
        {
            Models.SentenceSentiment result = new Models.SentenceSentiment();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sentiment"))
                {
                    result.Sentiment = new Models.SentenceSentiment(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sentenceScores"))
                {
                    result.SentenceScores = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("offset"))
                {
                    result.Offset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    result.Length = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("warnings"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Warnings.Add(item.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
