// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    /// <summary> Represents the confidence scores between 0 and 1 across all sentiment classes: positive, neutral, negative. </summary>
    public partial class SentimentConfidenceScorePerLabel
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-NUMBER. </summary>
        public double Positive { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-NUMBER. </summary>
        public double Neutral { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-NUMBER. </summary>
        public double Negative { get; set; }
    }
}
