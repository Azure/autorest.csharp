// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> Contains an input document to be analyzed by the service. </summary>
    public partial class MultiLanguageInput
    {
        /// <summary> A unique, non-empty document identifier. </summary>
        public string Id { get; set; }
        /// <summary> The input text to process. </summary>
        public string Text { get; set; }
        /// <summary> (Optional) This is the 2 letter ISO 639-1 representation of a language. For example, use &quot;en&quot; for English; &quot;es&quot; for Spanish etc. If not set, use &quot;en&quot; for English as default. </summary>
        public string? Language { get; set; }
    }
}
