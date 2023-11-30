// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Generates n-grams of the given size(s) starting from the front or the back of an input token. This token filter is implemented using Apache Lucene. </summary>
    public partial class EdgeNGramTokenFilterV2 : TokenFilter
    {
        /// <summary> Initializes a new instance of <see cref="EdgeNGramTokenFilterV2"/>. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public EdgeNGramTokenFilterV2(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.EdgeNGramTokenFilterV2";
        }

        /// <summary> Initializes a new instance of <see cref="EdgeNGramTokenFilterV2"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="minGram"> The minimum n-gram length. Default is 1. Maximum is 300. Must be less than the value of maxGram. </param>
        /// <param name="maxGram"> The maximum n-gram length. Default is 2. Maximum is 300. </param>
        /// <param name="side"> Specifies which side of the input the n-gram should be generated from. Default is "front". </param>
        internal EdgeNGramTokenFilterV2(string odataType, string name, int? minGram, int? maxGram, EdgeNGramTokenFilterSide? side) : base(odataType, name)
        {
            MinGram = minGram;
            MaxGram = maxGram;
            Side = side;
            OdataType = odataType ?? "#Microsoft.Azure.Search.EdgeNGramTokenFilterV2";
        }

        /// <summary> The minimum n-gram length. Default is 1. Maximum is 300. Must be less than the value of maxGram. </summary>
        public int? MinGram { get; set; }
        /// <summary> The maximum n-gram length. Default is 2. Maximum is 300. </summary>
        public int? MaxGram { get; set; }
        /// <summary> Specifies which side of the input the n-gram should be generated from. Default is "front". </summary>
        public EdgeNGramTokenFilterSide? Side { get; set; }
    }
}
