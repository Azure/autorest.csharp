// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

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

        /// <summary> Initializes a new instance of PatternCaptureTokenFilter. </summary>
        /// <param name="patterns"> A list of patterns to match against each token. </param>
        /// <param name="preserveOriginal"> A value indicating whether to return the original token even if one of the patterns matches. Default is true. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal PatternCaptureTokenFilter(IList<string> patterns, bool? preserveOriginal, string odataType, string name) : base(odataType ?? "#Microsoft.Azure.Search.PatternCaptureTokenFilter", name)
        {
            Patterns = patterns;
            PreserveOriginal = preserveOriginal;
        }

        /// <summary> A list of patterns to match against each token. </summary>
        public IList<string> Patterns { get; set; } = new List<string>();
        /// <summary> A value indicating whether to return the original token even if one of the patterns matches. Default is true. </summary>
        public bool? PreserveOriginal { get; set; }
    }
}
