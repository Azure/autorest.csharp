// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizer for path-like hierarchies. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class PathHierarchyTokenizerV2 : Tokenizer
    {
        /// <summary> Initializes a new instance of PathHierarchyTokenizerV2. </summary>
        public PathHierarchyTokenizerV2()
        {
            OdataType = "#Microsoft.Azure.Search.PathHierarchyTokenizerV2";
        }
        /// <summary> The delimiter character to use. Default is &quot;/&quot;. </summary>
        public char? Delimiter { get; set; }
        /// <summary> A value that, if set, replaces the delimiter character. Default is &quot;/&quot;. </summary>
        public char? Replacement { get; set; }
        /// <summary> The maximum token length. Default and maximum is 300. </summary>
        public int? MaxTokenLength { get; set; }
        /// <summary> A value indicating whether to generate tokens in reverse order. Default is false. </summary>
        public bool? ReverseTokenOrder { get; set; }
        /// <summary> The number of initial tokens to skip. Default is 0. </summary>
        public int? NumberOfTokensToSkip { get; set; }
    }
}
