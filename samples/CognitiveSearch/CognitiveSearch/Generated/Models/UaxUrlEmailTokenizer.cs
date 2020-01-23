// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizes urls and emails as one token. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class UaxUrlEmailTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of UaxUrlEmailTokenizer. </summary>
        public UaxUrlEmailTokenizer()
        {
            OdataType = "#Microsoft.Azure.Search.UaxUrlEmailTokenizer";
        }
        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
