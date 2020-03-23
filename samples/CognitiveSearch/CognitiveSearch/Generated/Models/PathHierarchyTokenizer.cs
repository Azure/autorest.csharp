// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizer for path-like hierarchies. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class PathHierarchyTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of PathHierarchyTokenizer. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public PathHierarchyTokenizer(string name) : base(name)
        {
            OdataType = "#Microsoft.Azure.Search.PathHierarchyTokenizer";
        }

        /// <summary> Initializes a new instance of PathHierarchyTokenizer. </summary>
        /// <param name="delimiter"> The delimiter character to use. Default is &quot;/&quot;. </param>
        /// <param name="replacement"> A value that, if set, replaces the delimiter character. Default is &quot;/&quot;. </param>
        /// <param name="bufferSize"> The buffer size. Default is 1024. </param>
        /// <param name="reverseTokenOrder"> A value indicating whether to generate tokens in reverse order. Default is false. </param>
        /// <param name="numberOfTokensToSkip"> The number of initial tokens to skip. Default is 0. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal PathHierarchyTokenizer(char? delimiter, char? replacement, int? bufferSize, bool? reverseTokenOrder, int? numberOfTokensToSkip, string odataType, string name) : base(odataType, name)
        {
            Delimiter = delimiter;
            Replacement = replacement;
            BufferSize = bufferSize;
            ReverseTokenOrder = reverseTokenOrder;
            NumberOfTokensToSkip = numberOfTokensToSkip;
            OdataType = odataType ?? "#Microsoft.Azure.Search.PathHierarchyTokenizer";
        }

        /// <summary> The delimiter character to use. Default is &quot;/&quot;. </summary>
        public char? Delimiter { get; set; }
        /// <summary> A value that, if set, replaces the delimiter character. Default is &quot;/&quot;. </summary>
        public char? Replacement { get; set; }
        /// <summary> The buffer size. Default is 1024. </summary>
        public int? BufferSize { get; set; }
        /// <summary> A value indicating whether to generate tokens in reverse order. Default is false. </summary>
        public bool? ReverseTokenOrder { get; set; }
        /// <summary> The number of initial tokens to skip. Default is 0. </summary>
        public int? NumberOfTokensToSkip { get; set; }
    }
}
