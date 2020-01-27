// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class SentenceSentiment
    {
        /// <summary> The predicted Sentiment for the sentence. </summary>
        public SentenceSentimentSentiment Sentiment { get; set; }
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
