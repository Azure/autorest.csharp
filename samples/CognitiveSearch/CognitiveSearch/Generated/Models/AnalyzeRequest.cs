// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Specifies some text and analysis components used to break that text into tokens. </summary>
    public partial class AnalyzeRequest
    {
        /// <summary> The text to break into tokens. </summary>
        public string Text { get; set; }
        /// <summary> Defines the names of all text analyzers supported by Azure Cognitive Search. </summary>
        public AnalyzerName? Analyzer { get; set; }
        /// <summary> Defines the names of all tokenizers supported by Azure Cognitive Search. </summary>
        public TokenizerName? Tokenizer { get; set; }
        /// <summary> An optional list of token filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        public ICollection<TokenFilterName> TokenFilters { get; set; }
        /// <summary> An optional list of character filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        public ICollection<string> CharFilters { get; set; }
    }
}
