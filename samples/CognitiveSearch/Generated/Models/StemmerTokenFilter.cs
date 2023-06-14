// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Language specific stemming filter. This token filter is implemented using Apache Lucene. </summary>
    public partial class StemmerTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of StemmerTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="language"> The language to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StemmerTokenFilter(string name, StemmerTokenFilterLanguage language) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Language = language;
            OdataType = "#Microsoft.Azure.Search.StemmerTokenFilter";
        }

        /// <summary> Initializes a new instance of StemmerTokenFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="language"> The language to use. </param>
        internal StemmerTokenFilter(string odataType, string name, StemmerTokenFilterLanguage language) : base(odataType, name)
        {
            Language = language;
            OdataType = odataType ?? "#Microsoft.Azure.Search.StemmerTokenFilter";
        }

        /// <summary> The language to use. </summary>
        public StemmerTokenFilterLanguage Language { get; set; }
    }
}
