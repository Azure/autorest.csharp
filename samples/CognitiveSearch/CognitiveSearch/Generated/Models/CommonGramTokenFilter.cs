// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Construct bigrams for frequently occurring terms while indexing. Single terms are still indexed too, with bigrams overlaid. This token filter is implemented using Apache Lucene. </summary>
    public partial class CommonGramTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of CommonGramTokenFilter. </summary>
        public CommonGramTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.CommonGramTokenFilter";
        }
        /// <summary> The set of common words. </summary>
        public ICollection<string> CommonWords { get; set; } = new System.Collections.Generic.List<string>();
        /// <summary> A value indicating whether common words matching will be case insensitive. Default is false. </summary>
        public bool? IgnoreCase { get; set; }
        /// <summary> A value that indicates whether the token filter is in query mode. When in query mode, the token filter generates bigrams and then removes common words and single terms followed by a common word. Default is false. </summary>
        public bool? UseQueryMode { get; set; }
    }
}
