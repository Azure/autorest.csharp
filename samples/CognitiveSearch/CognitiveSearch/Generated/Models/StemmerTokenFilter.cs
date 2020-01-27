// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Language specific stemming filter. This token filter is implemented using Apache Lucene. </summary>
    public partial class StemmerTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of StemmerTokenFilter. </summary>
        public StemmerTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.StemmerTokenFilter";
        }
        /// <summary> The language to use for a stemmer token filter. </summary>
        public StemmerTokenFilterLanguage Language { get; set; }
    }
}
