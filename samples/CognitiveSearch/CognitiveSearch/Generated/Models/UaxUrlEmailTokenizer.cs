// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizes urls and emails as one token. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class UaxUrlEmailTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of UaxUrlEmailTokenizer. </summary>
        internal UaxUrlEmailTokenizer()
        {
            OdataType = "#Microsoft.Azure.Search.UaxUrlEmailTokenizer";
        }

        /// <summary> Initializes a new instance of UaxUrlEmailTokenizer. </summary>
        /// <param name="maxTokenLength"> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal UaxUrlEmailTokenizer(int? maxTokenLength, string odataType, string name) : base(odataType, name)
        {
            MaxTokenLength = maxTokenLength;
            OdataType = "#Microsoft.Azure.Search.UaxUrlEmailTokenizer";
        }

        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
