// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Grammar-based tokenizer that is suitable for processing most European-language documents. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class ClassicTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of ClassicTokenizer. </summary>
        public ClassicTokenizer()
        {
            OdataType = "#Microsoft.Azure.Search.ClassicTokenizer";
        }
        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
