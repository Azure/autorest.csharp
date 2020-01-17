// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> Predicted sentiment for document (Negative, Neutral, Positive, or Mixed). </summary>
    public readonly partial struct DocumentSentimentSentiment : IEquatable<DocumentSentimentSentiment>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="DocumentSentimentSentiment"/> values are the same. </summary>
        public DocumentSentimentSentiment(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PositiveValue = "positive";
        private const string NeutralValue = "neutral";
        private const string NegativeValue = "negative";
        private const string MixedValue = "mixed";

        /// <summary> positive. </summary>
        public static DocumentSentimentSentiment Positive { get; } = new DocumentSentimentSentiment(PositiveValue);
        /// <summary> neutral. </summary>
        public static DocumentSentimentSentiment Neutral { get; } = new DocumentSentimentSentiment(NeutralValue);
        /// <summary> negative. </summary>
        public static DocumentSentimentSentiment Negative { get; } = new DocumentSentimentSentiment(NegativeValue);
        /// <summary> mixed. </summary>
        public static DocumentSentimentSentiment Mixed { get; } = new DocumentSentimentSentiment(MixedValue);
        /// <summary> Determines if two <see cref="DocumentSentimentSentiment"/> values are the same. </summary>
        public static bool operator ==(DocumentSentimentSentiment left, DocumentSentimentSentiment right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DocumentSentimentSentiment"/> values are not the same. </summary>
        public static bool operator !=(DocumentSentimentSentiment left, DocumentSentimentSentiment right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DocumentSentimentSentiment"/>. </summary>
        public static implicit operator DocumentSentimentSentiment(string value) => new DocumentSentimentSentiment(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is DocumentSentimentSentiment other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DocumentSentimentSentiment other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
