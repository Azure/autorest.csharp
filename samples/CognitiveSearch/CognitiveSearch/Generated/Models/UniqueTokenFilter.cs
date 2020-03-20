// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

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

        /// <summary> Initializes a new instance of UniqueTokenFilter. </summary>
        /// <param name="onlyOnSamePosition"> A value indicating whether to remove duplicates only at the same position. Default is false. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal UniqueTokenFilter(bool? onlyOnSamePosition, string odataType, string name) : base(odataType, name)
        {
            OnlyOnSamePosition = onlyOnSamePosition;
            OdataType = "#Microsoft.Azure.Search.UniqueTokenFilter";
        }

        /// <summary> A value indicating whether to remove duplicates only at the same position. Default is false. </summary>
        public bool? OnlyOnSamePosition { get; set; }
    }
}
