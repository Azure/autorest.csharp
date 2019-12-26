// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class SentimentConfidenceScorePerLabel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("positive");
            writer.WriteNumberValue(Positive);
            writer.WritePropertyName("neutral");
            writer.WriteNumberValue(Neutral);
            writer.WritePropertyName("negative");
            writer.WriteNumberValue(Negative);
            writer.WriteEndObject();
        }
        internal static SentimentConfidenceScorePerLabel DeserializeSentimentConfidenceScorePerLabel(JsonElement element)
        {
            SentimentConfidenceScorePerLabel result = new SentimentConfidenceScorePerLabel();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("positive"))
                {
                    result.Positive = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("neutral"))
                {
                    result.Neutral = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("negative"))
                {
                    result.Negative = property.Value.GetDouble();
                    continue;
                }
            }
            return result;
        }
    }
}
