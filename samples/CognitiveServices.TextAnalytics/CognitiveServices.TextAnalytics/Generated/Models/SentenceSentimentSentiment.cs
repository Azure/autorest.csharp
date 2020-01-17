// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The predicted Sentiment for the sentence. </summary>
    public readonly partial struct SentenceSentimentSentiment : IEquatable<SentenceSentimentSentiment>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="SentenceSentimentSentiment"/> values are the same. </summary>
        public SentenceSentimentSentiment(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PositiveValue = "positive";
        private const string NeutralValue = "neutral";
        private const string NegativeValue = "negative";

        /// <summary> positive. </summary>
        public static SentenceSentimentSentiment Positive { get; } = new SentenceSentimentSentiment(PositiveValue);
        /// <summary> neutral. </summary>
        public static SentenceSentimentSentiment Neutral { get; } = new SentenceSentimentSentiment(NeutralValue);
        /// <summary> negative. </summary>
        public static SentenceSentimentSentiment Negative { get; } = new SentenceSentimentSentiment(NegativeValue);
        /// <summary> Determines if two <see cref="SentenceSentimentSentiment"/> values are the same. </summary>
        public static bool operator ==(SentenceSentimentSentiment left, SentenceSentimentSentiment right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SentenceSentimentSentiment"/> values are not the same. </summary>
        public static bool operator !=(SentenceSentimentSentiment left, SentenceSentimentSentiment right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SentenceSentimentSentiment"/>. </summary>
        public static implicit operator SentenceSentimentSentiment(string value) => new SentenceSentimentSentiment(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is SentenceSentimentSentiment other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SentenceSentimentSentiment other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
