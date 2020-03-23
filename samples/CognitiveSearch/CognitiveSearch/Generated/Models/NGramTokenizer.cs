// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizes the input into n-grams of the given size(s). This tokenizer is implemented using Apache Lucene. </summary>
    public partial class NGramTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of NGramTokenizer. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public NGramTokenizer(string name) : base(name)
        {
            OdataType = "#Microsoft.Azure.Search.NGramTokenizer";
        }

        /// <summary> Initializes a new instance of NGramTokenizer. </summary>
        /// <param name="minGram"> The minimum n-gram length. Default is 1. Maximum is 300. Must be less than the value of maxGram. </param>
        /// <param name="maxGram"> The maximum n-gram length. Default is 2. Maximum is 300. </param>
        /// <param name="tokenChars"> Character classes to keep in the tokens. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal NGramTokenizer(int? minGram, int? maxGram, IList<TokenCharacterKind> tokenChars, string odataType, string name) : base(odataType ?? "#Microsoft.Azure.Search.NGramTokenizer", name)
        {
            MinGram = minGram;
            MaxGram = maxGram;
            TokenChars = tokenChars;
        }

        /// <summary> The minimum n-gram length. Default is 1. Maximum is 300. Must be less than the value of maxGram. </summary>
        public int? MinGram { get; set; }
        /// <summary> The maximum n-gram length. Default is 2. Maximum is 300. </summary>
        public int? MaxGram { get; set; }
        /// <summary> Character classes to keep in the tokens. </summary>
        public IList<TokenCharacterKind> TokenChars { get; set; }
    }
}
