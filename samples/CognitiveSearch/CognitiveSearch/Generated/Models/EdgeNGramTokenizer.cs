// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizes the input from an edge into n-grams of the given size(s). This tokenizer is implemented using Apache Lucene. </summary>
    public partial class EdgeNGramTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of EdgeNGramTokenizer. </summary>
        public EdgeNGramTokenizer()
        {
            OdataType = "#Microsoft.Azure.Search.EdgeNGramTokenizer";
        }
        /// <summary> The minimum n-gram length. Default is 1. Maximum is 300. Must be less than the value of maxGram. </summary>
        public int? MinGram { get; set; }
        /// <summary> The maximum n-gram length. Default is 2. Maximum is 300. </summary>
        public int? MaxGram { get; set; }
        /// <summary> Character classes to keep in the tokens. </summary>
        public ICollection<TokenCharacterKind>? TokenChars { get; set; }
    }
}
