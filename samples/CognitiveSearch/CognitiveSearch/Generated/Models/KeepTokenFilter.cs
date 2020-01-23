// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> A token filter that only keeps tokens with text contained in a specified list of words. This token filter is implemented using Apache Lucene. </summary>
    public partial class KeepTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of KeepTokenFilter. </summary>
        public KeepTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.KeepTokenFilter";
        }
        /// <summary> The list of words to keep. </summary>
        public ICollection<string> KeepWords { get; set; } = new List<string>();
        /// <summary> A value indicating whether to lower case all words first. Default is false. </summary>
        public bool? LowerCaseKeepWords { get; set; }
    }
}
