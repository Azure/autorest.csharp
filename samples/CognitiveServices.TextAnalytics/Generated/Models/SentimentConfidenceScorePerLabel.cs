// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> Represents the confidence scores between 0 and 1 across all sentiment classes: positive, neutral, negative. </summary>
    public partial class SentimentConfidenceScorePerLabel
    {
        /// <summary> Initializes a new instance of SentimentConfidenceScorePerLabel. </summary>
        /// <param name="positive"> The Positive. </param>
        /// <param name="neutral"> The Neutral. </param>
        /// <param name="negative"> The Negative. </param>
        internal SentimentConfidenceScorePerLabel(double positive, double neutral, double negative)
        {
            Positive = positive;
            Neutral = neutral;
            Negative = negative;
        }

        /// <summary> The Positive. </summary>
        public double Positive { get; }
        /// <summary> The Neutral. </summary>
        public double Neutral { get; }
        /// <summary> The Negative. </summary>
        public double Negative { get; }
    }
}
