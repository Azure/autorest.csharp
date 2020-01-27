// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizes the input into n-grams of the given size(s). This tokenizer is implemented using Apache Lucene. </summary>
    public partial class NGramTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of NGramTokenizer. </summary>
        public NGramTokenizer()
        {
            OdataType = "#Microsoft.Azure.Search.NGramTokenizer";
        }
        /// <summary> The minimum n-gram length. Default is 1. Maximum is 300. Must be less than the value of maxGram. </summary>
        public int? MinGram { get; set; }
        /// <summary> The maximum n-gram length. Default is 2. Maximum is 300. </summary>
        public int? MaxGram { get; set; }
        /// <summary> Character classes to keep in the tokens. </summary>
        public ICollection<TokenCharacterKind> TokenChars { get; set; }
    }
}
