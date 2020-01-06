// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
    public partial class DocumentStatistics
    {
        /// <summary> Number of text elements recognized in the document. </summary>
        public int CharactersCount { get; set; }
        /// <summary> Number of transactions for the document. </summary>
        public int TransactionsCount { get; set; }
    }
}
