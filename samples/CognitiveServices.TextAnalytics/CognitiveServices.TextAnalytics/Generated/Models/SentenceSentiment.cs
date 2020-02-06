// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The SentenceSentiment. </summary>
    public partial class SentenceSentiment
    {
        /// <summary> The predicted Sentiment for the sentence. </summary>
        public Models.SentenceSentiment Sentiment { get; set; }
        /// <summary> &lt;Any object&gt;. </summary>
        public object SentenceScores { get; set; }
        /// <summary> The sentence offset from the start of the document. </summary>
        public int Offset { get; set; }
        /// <summary> The length of the sentence by Unicode standard. </summary>
        public int Length { get; set; }
        /// <summary> The warnings generated for the sentence. </summary>
        public ICollection<string> Warnings { get; set; } = new System.Collections.Generic.List<string>();
    }
}
(PositiveValue);
        /// <summary> neutral. </summary>
        public static Models.SentenceSentiment Neutral { get; } = new Models.SentenceSentiment(NeutralValue);
        /// <summary> negative. </summary>
        public static Models.SentenceSentiment Negative { get; } = new Models.SentenceSentiment(NegativeValue);
        /// <summary> Determines if two <see cref="SentenceSentiment"/> values are the same. </summary>
        public static bool operator ==(Models.SentenceSentiment left, Models.SentenceSentiment right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SentenceSentiment"/> values are not the same. </summary>
        public static bool operator !=(Models.SentenceSentiment left, Models.SentenceSentiment right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SentenceSentiment"/>. </summary>
        public static implicit operator Models.SentenceSentiment(string value) => new Models.SentenceSentiment(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Models.SentenceSentiment other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Models.SentenceSentiment other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
