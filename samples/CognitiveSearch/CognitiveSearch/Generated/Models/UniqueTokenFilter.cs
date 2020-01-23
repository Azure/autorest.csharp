// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Filters out tokens with same text as the previous token. This token filter is implemented using Apache Lucene. </summary>
    public partial class UniqueTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of UniqueTokenFilter. </summary>
        public UniqueTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.UniqueTokenFilter";
        }
        /// <summary> A value indicating whether to remove duplicates only at the same position. Default is false. </summary>
        public bool? OnlyOnSamePosition { get; set; }
    }
}
