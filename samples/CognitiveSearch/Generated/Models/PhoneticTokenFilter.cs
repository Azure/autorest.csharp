// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Create tokens for phonetic matches. This token filter is implemented using Apache Lucene. </summary>
    public partial class PhoneticTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of <see cref="PhoneticTokenFilter"/>. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public PhoneticTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.PhoneticTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="PhoneticTokenFilter"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="encoder"> The phonetic encoder to use. Default is "metaphone". </param>
        /// <param name="replaceOriginalTokens"> A value indicating whether encoded tokens should replace original tokens. If false, encoded tokens are added as synonyms. Default is true. </param>
        internal PhoneticTokenFilter(string odataType, string name, PhoneticEncoder? encoder, bool? replaceOriginalTokens) : base(odataType, name)
        {
            Encoder = encoder;
            ReplaceOriginalTokens = replaceOriginalTokens;
            OdataType = odataType ?? "#Microsoft.Azure.Search.PhoneticTokenFilter";
        }

        /// <summary> The phonetic encoder to use. Default is "metaphone". </summary>
        public PhoneticEncoder? Encoder { get; set; }
        /// <summary> A value indicating whether encoded tokens should replace original tokens. If false, encoded tokens are added as synonyms. Default is true. </summary>
        public bool? ReplaceOriginalTokens { get; set; }
    }
}
