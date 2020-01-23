// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Truncates the terms to a specific length. This token filter is implemented using Apache Lucene. </summary>
    public partial class TruncateTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of TruncateTokenFilter. </summary>
        public TruncateTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.TruncateTokenFilter";
        }
        /// <summary> The length at which terms will be truncated. Default and maximum is 300. </summary>
        public int? Length { get; set; }
    }
}
