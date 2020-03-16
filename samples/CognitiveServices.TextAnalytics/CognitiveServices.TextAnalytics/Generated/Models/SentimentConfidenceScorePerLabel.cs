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
        internal SentimentConfidenceScorePerLabel()
        {
        }

        /// <summary> Initializes a new instance of SentimentConfidenceScorePerLabel. </summary>
        /// <param name="positive"> . </param>
        /// <param name="neutral"> . </param>
        /// <param name="negative"> . </param>
        internal SentimentConfidenceScorePerLabel(double positive, double neutral, double negative)
        {
            Positive = positive;
            Neutral = neutral;
            Negative = negative;
        }

        public double Positive { get; set; }
        public double Neutral { get; set; }
        public double Negative { get; set; }
    }
}
