// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Language specific stemming filter. This token filter is implemented using Apache Lucene. </summary>
    public partial class StemmerTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of StemmerTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="language"> The language to use. </param>
        public StemmerTokenFilter(string name, StemmerTokenFilterLanguage language) : base(name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

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
        }

        /// <summary> The language to use. </summary>
        public StemmerTokenFilterLanguage Language { get; }
    }
}
