// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class DocumentSentiment
    {
        public string Id { get; set; }
        public DocumentSentimentSentiment Sentiment { get; set; }
        public DocumentStatistics? Statistics { get; set; }
        public object DocumentScores { get; set; }
        public ICollection<SentenceSentiment> Sentences { get; set; } = new List<SentenceSentiment>();
    }
}
