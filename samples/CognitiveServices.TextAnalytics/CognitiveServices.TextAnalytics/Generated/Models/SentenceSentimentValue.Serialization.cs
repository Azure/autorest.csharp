// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveServices.TextAnalytics.Models
{
    internal static class SentenceSentimentValueExtensions
    {
        public static string ToSerialString(this SentenceSentimentValue value) => value switch
        {
            SentenceSentimentValue.Positive => "positive",
            SentenceSentimentValue.Neutral => "neutral",
            SentenceSentimentValue.Negative => "negative",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SentenceSentimentValue value.")
        };

        public static SentenceSentimentValue ToSentenceSentimentValue(this string value) => value switch
        {
            "positive" => SentenceSentimentValue.Positive,
            "neutral" => SentenceSentimentValue.Neutral,
            "negative" => SentenceSentimentValue.Negative,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SentenceSentimentValue value.")
        };
    }
}
