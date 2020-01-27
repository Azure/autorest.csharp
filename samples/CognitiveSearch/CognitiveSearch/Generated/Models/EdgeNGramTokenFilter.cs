// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Generates n-grams of the given size(s) starting from the front or the back of an input token. This token filter is implemented using Apache Lucene. </summary>
    public partial class EdgeNGramTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of EdgeNGramTokenFilter. </summary>
        public EdgeNGramTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.EdgeNGramTokenFilter";
        }
        /// <summary> The minimum n-gram length. Default is 1. Must be less than the value of maxGram. </summary>
        public int? MinGram { get; set; }
        /// <summary> The maximum n-gram length. Default is 2. </summary>
        public int? MaxGram { get; set; }
        /// <summary> Specifies which side of the input an n-gram should be generated from. </summary>
        public EdgeNGramTokenFilterSide? Side { get; set; }
    }
}
