// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary>
    /// Base type for token filters.
    /// Please note <see cref="TokenFilter"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AsciiFoldingTokenFilter"/>, <see cref="CjkBigramTokenFilter"/>, <see cref="CommonGramTokenFilter"/>, <see cref="DictionaryDecompounderTokenFilter"/>, <see cref="EdgeNGramTokenFilter"/>, <see cref="EdgeNGramTokenFilterV2"/>, <see cref="ElisionTokenFilter"/>, <see cref="KeepTokenFilter"/>, <see cref="KeywordMarkerTokenFilter"/>, <see cref="LengthTokenFilter"/>, <see cref="LimitTokenFilter"/>, <see cref="NGramTokenFilter"/>, <see cref="NGramTokenFilterV2"/>, <see cref="PatternCaptureTokenFilter"/>, <see cref="PatternReplaceTokenFilter"/>, <see cref="PhoneticTokenFilter"/>, <see cref="ShingleTokenFilter"/>, <see cref="SnowballTokenFilter"/>, <see cref="StemmerOverrideTokenFilter"/>, <see cref="StemmerTokenFilter"/>, <see cref="StopwordsTokenFilter"/>, <see cref="SynonymTokenFilter"/>, <see cref="TruncateTokenFilter"/>, <see cref="UniqueTokenFilter"/> and <see cref="WordDelimiterTokenFilter"/>.
    /// </summary>
    public partial class TokenFilter
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="TokenFilter"/>. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public TokenFilter(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="TokenFilter"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal TokenFilter(string odataType, string name, Dictionary<string, BinaryData> rawData)
        {
            OdataType = odataType;
            Name = name;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="TokenFilter"/> for deserialization. </summary>
        internal TokenFilter()
        {
        }

        /// <summary> Identifies the concrete type of the token filter. </summary>
        internal string OdataType { get; set; }
        /// <summary> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </summary>
        public string Name { get; set; }
    }
}
