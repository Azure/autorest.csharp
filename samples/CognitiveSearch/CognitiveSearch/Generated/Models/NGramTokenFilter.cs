// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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

        /// <summary> Initializes a new instance of NGramTokenFilter. </summary>
        /// <param name="minGram"> The minimum n-gram length. Default is 1. Must be less than the value of maxGram. </param>
        /// <param name="maxGram"> The maximum n-gram length. Default is 2. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal NGramTokenFilter(int? minGram, int? maxGram, string odataType, string name) : base(odataType ?? "#Microsoft.Azure.Search.NGramTokenFilter", name)
        {
            MinGram = minGram;
            MaxGram = maxGram;
        }

        /// <summary> The minimum n-gram length. Default is 1. Must be less than the value of maxGram. </summary>
        public int? MinGram { get; set; }
        /// <summary> The maximum n-gram length. Default is 2. </summary>
        public int? MaxGram { get; set; }
    }
}
