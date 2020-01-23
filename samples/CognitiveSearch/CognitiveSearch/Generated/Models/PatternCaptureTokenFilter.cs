// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Uses Java regexes to emit multiple tokens - one for each capture group in one or more patterns. This token filter is implemented using Apache Lucene. </summary>
    public partial class PatternCaptureTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of PatternCaptureTokenFilter. </summary>
        public PatternCaptureTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.PatternCaptureTokenFilter";
        }
        /// <summary> A list of patterns to match against each token. </summary>
        public ICollection<string> Patterns { get; set; } = new List<string>();
        /// <summary> A value indicating whether to return the original token even if one of the patterns matches. Default is true. </summary>
        public bool? PreserveOriginal { get; set; }
    }
}
