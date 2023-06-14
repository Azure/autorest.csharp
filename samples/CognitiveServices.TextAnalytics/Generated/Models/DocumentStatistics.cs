// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
    public partial class DocumentStatistics
    {
        /// <summary> Initializes a new instance of DocumentStatistics. </summary>
        /// <param name="charactersCount"> Number of text elements recognized in the document. </param>
        /// <param name="transactionsCount"> Number of transactions for the document. </param>
        internal DocumentStatistics(int charactersCount, int transactionsCount)
        {
            CharactersCount = charactersCount;
            TransactionsCount = transactionsCount;
        }

        /// <summary> Number of text elements recognized in the document. </summary>
        public int CharactersCount { get; }
        /// <summary> Number of transactions for the document. </summary>
        public int TransactionsCount { get; }
    }
}
