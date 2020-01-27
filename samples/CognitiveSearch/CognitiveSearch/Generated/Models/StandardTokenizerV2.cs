// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Breaks text following the Unicode Text Segmentation rules. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class StandardTokenizerV2 : Tokenizer
    {
        /// <summary> Initializes a new instance of StandardTokenizerV2. </summary>
        public StandardTokenizerV2()
        {
            OdataType = "#Microsoft.Azure.Search.StandardTokenizerV2";
        }
        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
