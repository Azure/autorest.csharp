// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveServices.TextAnalytics.Models
{
    internal static partial class DocumentSentimentValueExtensions
    {
        public static string ToSerialString(this DocumentSentimentValue value) => value switch
        {
            DocumentSentimentValue.Positive => "positive",
            DocumentSentimentValue.Neutral => "neutral",
            DocumentSentimentValue.Negative => "negative",
            DocumentSentimentValue.Mixed => "mixed",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DocumentSentimentValue value.")
        };

        public static DocumentSentimentValue ToDocumentSentimentValue(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "positive")) return DocumentSentimentValue.Positive;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "neutral")) return DocumentSentimentValue.Neutral;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "negative")) return DocumentSentimentValue.Negative;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "mixed")) return DocumentSentimentValue.Mixed;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DocumentSentimentValue value.");
        }
    }
}
