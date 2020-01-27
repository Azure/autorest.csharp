// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Generates n-grams of the given size(s). This token filter is implemented using Apache Lucene. </summary>
    public partial class NGramTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of NGramTokenFilter. </summary>
        public NGramTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.NGramTokenFilter";
        }
        /// <summary> The minimum n-gram length. Default is 1. Must be less than the value of maxGram. </summary>
        public int? MinGram { get; set; }
        /// <summary> The maximum n-gram length. Default is 2. </summary>
        public int? MaxGram { get; set; }
    }
}
