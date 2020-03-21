// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Breaks text following the Unicode Text Segmentation rules. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class StandardTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of StandardTokenizer. </summary>
        public StandardTokenizer()
        {
            OdataType = "#Microsoft.Azure.Search.StandardTokenizer";
        }

        /// <summary> Initializes a new instance of StandardTokenizer. </summary>
        /// <param name="maxTokenLength"> The maximum token length. Default is 255. Tokens longer than the maximum length are split. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal StandardTokenizer(int? maxTokenLength, string odataType, string name) : base(odataType ?? "#Microsoft.Azure.Search.StandardTokenizer", name)
        {
            MaxTokenLength = maxTokenLength;
        }

        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
