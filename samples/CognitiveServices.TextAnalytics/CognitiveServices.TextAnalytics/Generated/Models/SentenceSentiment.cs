// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class SentenceSentiment
    {
        public SentenceSentimentSentiment Sentiment { get; set; }
        public object SentenceScores { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
        public ICollection<string> Warnings { get; set; } = new List<string>();
    }
}
