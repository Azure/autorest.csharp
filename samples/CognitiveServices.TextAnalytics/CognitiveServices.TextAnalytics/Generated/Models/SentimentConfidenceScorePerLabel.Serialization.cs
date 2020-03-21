// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class SentimentConfidenceScorePerLabel
    {
        internal static SentimentConfidenceScorePerLabel DeserializeSentimentConfidenceScorePerLabel(JsonElement element)
        {
            SentimentConfidenceScorePerLabel result;
            double positive = default;
            double neutral = default;
            double negative = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("positive"))
                {
                    positive = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("neutral"))
                {
                    neutral = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("negative"))
                {
                    negative = property.Value.GetDouble();
                    continue;
                }
            }
            result = new SentimentConfidenceScorePerLabel(positive, neutral, negative);
            return result;
        }
    }
}
