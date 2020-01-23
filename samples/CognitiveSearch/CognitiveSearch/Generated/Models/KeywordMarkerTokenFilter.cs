// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Marks terms as keywords. This token filter is implemented using Apache Lucene. </summary>
    public partial class KeywordMarkerTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of KeywordMarkerTokenFilter. </summary>
        public KeywordMarkerTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.KeywordMarkerTokenFilter";
        }
        /// <summary> A list of words to mark as keywords. </summary>
        public ICollection<string> Keywords { get; set; } = new List<string>();
        /// <summary> A value indicating whether to ignore case. If true, all words are converted to lower case first. Default is false. </summary>
        public bool? IgnoreCase { get; set; }
    }
}
