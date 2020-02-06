// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The DocumentSentiment. </summary>
    public partial class DocumentSentiment
    {
        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; set; }
        /// <summary> Predicted sentiment for document (Negative, Neutral, Positive, or Mixed). </summary>
        public Models.DocumentSentiment Sentiment { get; set; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public DocumentStatistics Statistics { get; set; }
        /// <summary> &lt;Any object&gt;. </summary>
        public object DocumentScores { get; set; }
        /// <summary> Sentence level sentiment analysis. </summary>
        public ICollection<Models.SentenceSentiment> Sentences { get; set; } = new System.Collections.Generic.List<CognitiveServices.TextAnalytics.Models.SentenceSentiment>();
    }
}
tic Models.DocumentSentiment Neutral { get; } = new Models.DocumentSentiment(NeutralValue);
        /// <summary> negative. </summary>
        public static Models.DocumentSentiment Negative { get; } = new Models.DocumentSentiment(NegativeValue);
        /// <summary> mixed. </summary>
        public static Models.DocumentSentiment Mixed { get; } = new Models.DocumentSentiment(MixedValue);
        /// <summary> Determines if two <see cref="DocumentSentiment"/> values are the same. </summary>
        public static bool operator ==(Models.DocumentSentiment left, Models.DocumentSentiment right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DocumentSentiment"/> values are not the same. </summary>
        public static bool operator !=(Models.DocumentSentiment left, Models.DocumentSentiment right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DocumentSentiment"/>. </summary>
        public static implicit operator Models.DocumentSentiment(string value) => new Models.DocumentSentiment(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Models.DocumentSentiment other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Models.DocumentSentiment other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
