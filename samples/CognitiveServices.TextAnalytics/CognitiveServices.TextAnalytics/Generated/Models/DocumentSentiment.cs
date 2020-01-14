// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class DocumentSentiment
    {
        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; set; }
        /// <summary> Predicted sentiment for document (Negative, Neutral, Positive, or Mixed). </summary>
        public DocumentSentimentSentiment Sentiment { get; set; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public DocumentStatistics? Statistics { get; set; }
        /// <summary> &lt;Any object&gt;. </summary>
        public object DocumentScores { get; set; }
        /// <summary> Sentence level sentiment analysis. </summary>
        public ICollection<SentenceSentiment> Sentences { get; set; } = new List<SentenceSentiment>();
    }
}
