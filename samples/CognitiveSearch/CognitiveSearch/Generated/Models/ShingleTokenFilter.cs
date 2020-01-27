// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Creates combinations of tokens as a single token. This token filter is implemented using Apache Lucene. </summary>
    public partial class ShingleTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of ShingleTokenFilter. </summary>
        public ShingleTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.ShingleTokenFilter";
        }
        /// <summary> The maximum shingle size. Default and minimum value is 2. </summary>
        public int? MaxShingleSize { get; set; }
        /// <summary> The minimum shingle size. Default and minimum value is 2. Must be less than the value of maxShingleSize. </summary>
        public int? MinShingleSize { get; set; }
        /// <summary> A value indicating whether the output stream will contain the input tokens (unigrams) as well as shingles. Default is true. </summary>
        public bool? OutputUnigrams { get; set; }
        /// <summary> A value indicating whether to output unigrams for those times when no shingles are available. This property takes precedence when outputUnigrams is set to false. Default is false. </summary>
        public bool? OutputUnigramsIfNoShingles { get; set; }
        /// <summary> The string to use when joining adjacent tokens to form a shingle. Default is a single space (&quot; &quot;). </summary>
        public string TokenSeparator { get; set; }
        /// <summary> The string to insert for each position at which there is no token. Default is an underscore (&quot;_&quot;). </summary>
        public string FilterToken { get; set; }
    }
}
