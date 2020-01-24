// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Removes stop words from a token stream. This token filter is implemented using Apache Lucene. </summary>
    public partial class StopwordsTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of StopwordsTokenFilter. </summary>
        public StopwordsTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.StopwordsTokenFilter";
        }
        /// <summary> The list of stopwords. This property and the stopwords list property cannot both be set. </summary>
        public ICollection<string>? Stopwords { get; set; }
        /// <summary> Identifies a predefined list of language-specific stopwords. </summary>
        public StopwordsList? StopwordsList { get; set; }
        /// <summary> A value indicating whether to ignore case. If true, all words are converted to lower case first. Default is false. </summary>
        public bool? IgnoreCase { get; set; }
        /// <summary> A value indicating whether to ignore the last search term if it&apos;s a stop word. Default is true. </summary>
        public bool? RemoveTrailingStopWords { get; set; }
    }
}
