// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> A filter that stems words using a Snowball-generated stemmer. This token filter is implemented using Apache Lucene. </summary>
    public partial class SnowballTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of SnowballTokenFilter. </summary>
        public SnowballTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.SnowballTokenFilter";
        }
        /// <summary> The language to use for a Snowball token filter. </summary>
        public SnowballTokenFilterLanguage Language { get; set; }
    }
}
