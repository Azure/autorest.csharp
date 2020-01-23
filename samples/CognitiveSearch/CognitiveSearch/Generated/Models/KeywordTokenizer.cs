// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Emits the entire input as a single token. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class KeywordTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of KeywordTokenizer. </summary>
        public KeywordTokenizer()
        {
            OdataType = "#Microsoft.Azure.Search.KeywordTokenizer";
        }
        /// <summary> The read buffer size in bytes. Default is 256. </summary>
        public int? BufferSize { get; set; }
    }
}
