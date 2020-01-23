// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Forms bigrams of CJK terms that are generated from StandardTokenizer. This token filter is implemented using Apache Lucene. </summary>
    public partial class CjkBigramTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of CjkBigramTokenFilter. </summary>
        public CjkBigramTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.CjkBigramTokenFilter";
        }
        /// <summary> The scripts to ignore. </summary>
        public ICollection<CjkBigramTokenFilterScripts>? IgnoreScripts { get; set; }
        /// <summary> A value indicating whether to output both unigrams and bigrams (if true), or just bigrams (if false). Default is false. </summary>
        public bool? OutputUnigrams { get; set; }
    }
}
