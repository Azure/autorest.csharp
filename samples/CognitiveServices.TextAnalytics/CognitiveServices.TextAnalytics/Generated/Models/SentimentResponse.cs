// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The SentimentResponse. </summary>
    public partial class SentimentResponse
    {
        /// <summary> Sentiment analysis per document. </summary>
        public ICollection<DocumentSentiment> Documents { get; set; } = new System.Collections.Generic.List<CognitiveServices.TextAnalytics.Models.DocumentSentiment>();
        /// <summary> Errors by document id. </summary>
        public ICollection<DocumentError> Errors { get; set; } = new System.Collections.Generic.List<CognitiveServices.TextAnalytics.Models.DocumentError>();
        /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
        public RequestStatistics Statistics { get; set; }
        /// <summary> This field indicates which model is used for scoring. </summary>
        public string ModelVersion { get; set; }
    }
}
