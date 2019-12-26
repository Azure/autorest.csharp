// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public readonly partial struct SentenceSentimentSentiment : IEquatable<SentenceSentimentSentiment>
    {
        private readonly string? _value;

        public SentenceSentimentSentiment(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PositiveValue = "positive";
        private const string NeutralValue = "neutral";
        private const string NegativeValue = "negative";

        public static SentenceSentimentSentiment Positive { get; } = new SentenceSentimentSentiment(PositiveValue);
        public static SentenceSentimentSentiment Neutral { get; } = new SentenceSentimentSentiment(NeutralValue);
        public static SentenceSentimentSentiment Negative { get; } = new SentenceSentimentSentiment(NegativeValue);
        public static bool operator ==(SentenceSentimentSentiment left, SentenceSentimentSentiment right) => left.Equals(right);
        public static bool operator !=(SentenceSentimentSentiment left, SentenceSentimentSentiment right) => !left.Equals(right);
        public static implicit operator SentenceSentimentSentiment(string value) => new SentenceSentimentSentiment(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is SentenceSentimentSentiment other && Equals(other);
        public bool Equals(SentenceSentimentSentiment other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string? ToString() => _value;
    }
}
