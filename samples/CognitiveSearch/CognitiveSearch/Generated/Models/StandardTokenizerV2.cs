// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Breaks text following the Unicode Text Segmentation rules. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class StandardTokenizerV2 : Tokenizer
    {
        /// <summary> Initializes a new instance of StandardTokenizerV2. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public StandardTokenizerV2(string name) : base(name)
        {
            OdataType = "#Microsoft.Azure.Search.StandardTokenizerV2";
        }

        /// <summary> Initializes a new instance of StandardTokenizerV2. </summary>
        /// <param name="maxTokenLength"> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal StandardTokenizerV2(int? maxTokenLength, string odataType, string name) : base(odataType ?? "#Microsoft.Azure.Search.StandardTokenizerV2", name)
        {
            MaxTokenLength = maxTokenLength;
        }

        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
