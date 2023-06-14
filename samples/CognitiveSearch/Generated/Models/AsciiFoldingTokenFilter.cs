// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Converts alphabetic, numeric, and symbolic Unicode characters which are not in the first 127 ASCII characters (the "Basic Latin" Unicode block) into their ASCII equivalents, if such equivalents exist. This token filter is implemented using Apache Lucene. </summary>
    public partial class AsciiFoldingTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of AsciiFoldingTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public AsciiFoldingTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.AsciiFoldingTokenFilter";
        }

        /// <summary> Initializes a new instance of AsciiFoldingTokenFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="preserveOriginal"> A value indicating whether the original token will be kept. Default is false. </param>
        internal AsciiFoldingTokenFilter(string odataType, string name, bool? preserveOriginal) : base(odataType, name)
        {
            PreserveOriginal = preserveOriginal;
            OdataType = odataType ?? "#Microsoft.Azure.Search.AsciiFoldingTokenFilter";
        }

        /// <summary> A value indicating whether the original token will be kept. Default is false. </summary>
        public bool? PreserveOriginal { get; set; }
    }
}
