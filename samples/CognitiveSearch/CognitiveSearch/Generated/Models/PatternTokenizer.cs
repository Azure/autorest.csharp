// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizer that uses regex pattern matching to construct distinct tokens. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class PatternTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of PatternTokenizer. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public PatternTokenizer(string name) : base(name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            OdataType = "#Microsoft.Azure.Search.PatternTokenizer";
        }

        /// <summary> Initializes a new instance of PatternTokenizer. </summary>
        /// <param name="pattern"> A regular expression pattern to match token separators. Default is an expression that matches one or more whitespace characters. </param>
        /// <param name="flags"> Regular expression flags. </param>
        /// <param name="group"> The zero-based ordinal of the matching group in the regular expression pattern to extract into tokens. Use -1 if you want to use the entire pattern to split the input into tokens, irrespective of matching groups. Default is -1. </param>
        /// <param name="odataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal PatternTokenizer(string pattern, RegexFlags? flags, int? group, string odataType, string name) : base(odataType, name)
        {
            Pattern = pattern;
            Flags = flags;
            Group = group;
            OdataType = odataType ?? "#Microsoft.Azure.Search.PatternTokenizer";
        }

        /// <summary> A regular expression pattern to match token separators. Default is an expression that matches one or more whitespace characters. </summary>
        public string Pattern { get; set; }
        /// <summary> Regular expression flags. </summary>
        public RegexFlags? Flags { get; set; }
        /// <summary> The zero-based ordinal of the matching group in the regular expression pattern to extract into tokens. Use -1 if you want to use the entire pattern to split the input into tokens, irrespective of matching groups. Default is -1. </summary>
        public int? Group { get; set; }
    }
}
