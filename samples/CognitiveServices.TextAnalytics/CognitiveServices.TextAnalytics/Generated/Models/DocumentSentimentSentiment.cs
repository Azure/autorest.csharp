// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public readonly partial struct DocumentSentimentSentiment : IEquatable<DocumentSentimentSentiment>
    {
        private readonly string? _value;

        public DocumentSentimentSentiment(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PositiveValue = "positive";
        private const string NeutralValue = "neutral";
        private const string NegativeValue = "negative";
        private const string MixedValue = "mixed";

        public static DocumentSentimentSentiment Positive { get; } = new DocumentSentimentSentiment(PositiveValue);
        public static DocumentSentimentSentiment Neutral { get; } = new DocumentSentimentSentiment(NeutralValue);
        public static DocumentSentimentSentiment Negative { get; } = new DocumentSentimentSentiment(NegativeValue);
        public static DocumentSentimentSentiment Mixed { get; } = new DocumentSentimentSentiment(MixedValue);
        public static bool operator ==(DocumentSentimentSentiment left, DocumentSentimentSentiment right) => left.Equals(right);
        public static bool operator !=(DocumentSentimentSentiment left, DocumentSentimentSentiment right) => !left.Equals(right);
        public static implicit operator DocumentSentimentSentiment(string value) => new DocumentSentimentSentiment(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is DocumentSentimentSentiment other && Equals(other);
        public bool Equals(DocumentSentimentSentiment other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
