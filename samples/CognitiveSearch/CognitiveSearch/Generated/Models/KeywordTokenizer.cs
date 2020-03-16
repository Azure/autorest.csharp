// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

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

        /// <summary> Initializes a new instance of KeywordTokenizer. </summary>
        /// <param name="bufferSize"> The read buffer size in bytes. Default is 256. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal KeywordTokenizer(int? bufferSize, string odataType, string name) : base(odataType, name)
        {
            BufferSize = bufferSize;
            OdataType = "#Microsoft.Azure.Search.KeywordTokenizer";
        }

        /// <summary> The read buffer size in bytes. Default is 256. </summary>
        public int? BufferSize { get; set; }
    }
}
