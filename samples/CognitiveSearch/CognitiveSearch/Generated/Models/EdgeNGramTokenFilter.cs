// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Generates n-grams of the given size(s) starting from the front or the back of an input token. This token filter is implemented using Apache Lucene. </summary>
    public partial class EdgeNGramTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of EdgeNGramTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public EdgeNGramTokenFilter(string name) : base(name)
        {
            OdataType = "#Microsoft.Azure.Search.EdgeNGramTokenFilter";
        }

        /// <summary> Initializes a new instance of EdgeNGramTokenFilter. </summary>
        /// <param name="minGram"> The minimum n-gram length. Default is 1. Must be less than the value of maxGram. </param>
        /// <param name="maxGram"> The maximum n-gram length. Default is 2. </param>
        /// <param name="side"> Specifies which side of the input the n-gram should be generated from. Default is &quot;front&quot;. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal EdgeNGramTokenFilter(int? minGram, int? maxGram, EdgeNGramTokenFilterSide? side, string odataType, string name) : base(odataType ?? "#Microsoft.Azure.Search.EdgeNGramTokenFilter", name)
        {
            MinGram = minGram;
            MaxGram = maxGram;
            Side = side;
        }

        /// <summary> The minimum n-gram length. Default is 1. Must be less than the value of maxGram. </summary>
        public int? MinGram { get; set; }
        /// <summary> The maximum n-gram length. Default is 2. </summary>
        public int? MaxGram { get; set; }
        /// <summary> Specifies which side of the input the n-gram should be generated from. Default is &quot;front&quot;. </summary>
        public EdgeNGramTokenFilterSide? Side { get; set; }
    }
}
