// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class SentimentConfidenceScorePerLabel
    {
        internal static SentimentConfidenceScorePerLabel DeserializeSentimentConfidenceScorePerLabel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            double positive = default;
            double neutral = default;
            double negative = default;
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
            }
            return new SentimentConfidenceScorePerLabel(positive, neutral, negative);
        }
    }
}
