// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Create tokens for phonetic matches. This token filter is implemented using Apache Lucene. </summary>
    public partial class PhoneticTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of PhoneticTokenFilter. </summary>
        public PhoneticTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.PhoneticTokenFilter";
        }
        /// <summary> Identifies the type of phonetic encoder to use with a PhoneticTokenFilter. </summary>
        public PhoneticEncoder? Encoder { get; set; }
        /// <summary> A value indicating whether encoded tokens should replace original tokens. If false, encoded tokens are added as synonyms. Default is true. </summary>
        public bool? ReplaceOriginalTokens { get; set; }
    }
}
