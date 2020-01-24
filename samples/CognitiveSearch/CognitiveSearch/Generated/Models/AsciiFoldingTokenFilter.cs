// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Converts alphabetic, numeric, and symbolic Unicode characters which are not in the first 127 ASCII characters (the &quot;Basic Latin&quot; Unicode block) into their ASCII equivalents, if such equivalents exist. This token filter is implemented using Apache Lucene. </summary>
    public partial class AsciiFoldingTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of AsciiFoldingTokenFilter. </summary>
        public AsciiFoldingTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.AsciiFoldingTokenFilter";
        }
        /// <summary> A value indicating whether the original token will be kept. Default is false. </summary>
        public bool? PreserveOriginal { get; set; }
    }
}
