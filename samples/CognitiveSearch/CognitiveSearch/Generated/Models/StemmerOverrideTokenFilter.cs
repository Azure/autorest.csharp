// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Provides the ability to override other stemming filters with custom dictionary-based stemming. Any dictionary-stemmed terms will be marked as keywords so that they will not be stemmed with stemmers down the chain. Must be placed before any stemming filters. This token filter is implemented using Apache Lucene. </summary>
    public partial class StemmerOverrideTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of StemmerOverrideTokenFilter. </summary>
        public StemmerOverrideTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.StemmerOverrideTokenFilter";
        }
        /// <summary> A list of stemming rules in the following format: &quot;word =&gt; stem&quot;, for example: &quot;ran =&gt; run&quot;. </summary>
        public ICollection<string> Rules { get; set; } = new List<string>();
    }
}
