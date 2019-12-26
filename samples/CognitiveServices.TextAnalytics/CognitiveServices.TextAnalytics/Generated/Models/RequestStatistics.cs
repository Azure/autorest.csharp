// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class RequestStatistics
    {
        public int DocumentsCount { get; set; }
        public int ValidDocumentsCount { get; set; }
        public int ErroneousDocumentsCount { get; set; }
        public long TransactionsCount { get; set; }
    }
}
