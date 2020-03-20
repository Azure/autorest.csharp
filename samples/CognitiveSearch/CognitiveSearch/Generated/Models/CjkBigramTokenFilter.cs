// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

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

        /// <summary> Initializes a new instance of CjkBigramTokenFilter. </summary>
        /// <param name="ignoreScripts"> The scripts to ignore. </param>
        /// <param name="outputUnigrams"> A value indicating whether to output both unigrams and bigrams (if true), or just bigrams (if false). Default is false. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal CjkBigramTokenFilter(IList<CjkBigramTokenFilterScripts> ignoreScripts, bool? outputUnigrams, string odataType, string name) : base(odataType, name)
        {
            IgnoreScripts = ignoreScripts;
            OutputUnigrams = outputUnigrams;
            OdataType = "#Microsoft.Azure.Search.CjkBigramTokenFilter";
        }

        /// <summary> The scripts to ignore. </summary>
        public IList<CjkBigramTokenFilterScripts> IgnoreScripts { get; set; }
        /// <summary> A value indicating whether to output both unigrams and bigrams (if true), or just bigrams (if false). Default is false. </summary>
        public bool? OutputUnigrams { get; set; }
    }
}
