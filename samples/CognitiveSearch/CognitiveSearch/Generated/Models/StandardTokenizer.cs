// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
