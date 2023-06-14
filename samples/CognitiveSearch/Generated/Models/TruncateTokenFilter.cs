// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Truncates the terms to a specific length. This token filter is implemented using Apache Lucene. </summary>
    public partial class TruncateTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of TruncateTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public TruncateTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.TruncateTokenFilter";
        }

        /// <summary> Initializes a new instance of TruncateTokenFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="length"> The length at which terms will be truncated. Default and maximum is 300. </param>
        internal TruncateTokenFilter(string odataType, string name, int? length) : base(odataType, name)
        {
            Length = length;
            OdataType = odataType ?? "#Microsoft.Azure.Search.TruncateTokenFilter";
        }

        /// <summary> The length at which terms will be truncated. Default and maximum is 300. </summary>
        public int? Length { get; set; }
    }
}
