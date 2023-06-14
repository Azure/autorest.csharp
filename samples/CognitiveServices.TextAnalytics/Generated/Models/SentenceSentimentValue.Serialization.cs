// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveServices.TextAnalytics.Models
{
    internal static partial class SentenceSentimentValueExtensions
    {
        public static string ToSerialString(this SentenceSentimentValue value) => value switch
        {
            SentenceSentimentValue.Positive => "positive",
            SentenceSentimentValue.Neutral => "neutral",
            SentenceSentimentValue.Negative => "negative",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SentenceSentimentValue value.")
        };

        public static SentenceSentimentValue ToSentenceSentimentValue(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "positive")) return SentenceSentimentValue.Positive;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "neutral")) return SentenceSentimentValue.Neutral;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "negative")) return SentenceSentimentValue.Negative;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SentenceSentimentValue value.");
        }
    }
}
