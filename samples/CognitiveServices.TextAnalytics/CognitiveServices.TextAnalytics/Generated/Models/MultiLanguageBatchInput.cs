// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    /// <summary> Contains a set of input documents to be analyzed by the service. </summary>
    public partial class MultiLanguageBatchInput
    {
        /// <summary> The set of documents to process as part of this batch. </summary>
        public ICollection<MultiLanguageInput> Documents { get; set; } = new List<MultiLanguageInput>();
    }
}
