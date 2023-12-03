// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Filters out tokens with same text as the previous token. This token filter is implemented using Apache Lucene. </summary>
    public partial class UniqueTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of <see cref="UniqueTokenFilter"/>. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public UniqueTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.UniqueTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="UniqueTokenFilter"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="onlyOnSamePosition"> A value indicating whether to remove duplicates only at the same position. Default is false. </param>
        internal UniqueTokenFilter(string odataType, string name, bool? onlyOnSamePosition) : base(odataType, name)
        {
            OnlyOnSamePosition = onlyOnSamePosition;
            OdataType = odataType ?? "#Microsoft.Azure.Search.UniqueTokenFilter";
        }

        /// <summary> A value indicating whether to remove duplicates only at the same position. Default is false. </summary>
        public bool? OnlyOnSamePosition { get; set; }
    }
}
