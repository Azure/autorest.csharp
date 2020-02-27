// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Divides text using language-specific rules and reduces words to their base forms. </summary>
    public partial class MicrosoftLanguageStemmingTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of MicrosoftLanguageStemmingTokenizer. </summary>
        public MicrosoftLanguageStemmingTokenizer()
        {
            OdataType = "#Microsoft.Azure.Search.MicrosoftLanguageStemmingTokenizer";
        }
        /// <summary> The maximum token length. Tokens longer than the maximum length are split. Maximum token length that can be used is 300 characters. Tokens longer than 300 characters are first split into tokens of length 300 and then each of those tokens is split based on the max token length set. Default is 255. </summary>
        public int? MaxTokenLength { get; set; }
        /// <summary> A value indicating how the tokenizer is used. Set to true if used as the search tokenizer, set to false if used as the indexing tokenizer. Default is false. </summary>
        public bool? IsSearchTokenizer { get; set; }
        /// <summary> The language to use. The default is English. </summary>
        public MicrosoftStemmingTokenizerLanguage? Language { get; set; }
    }
}
