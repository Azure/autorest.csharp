// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Construct bigrams for frequently occurring terms while indexing. Single terms are still indexed too, with bigrams overlaid. This token filter is implemented using Apache Lucene. </summary>
    public partial class CommonGramTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of <see cref="CommonGramTokenFilter"/>. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="commonWords"> The set of common words. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="commonWords"/> is null. </exception>
        public CommonGramTokenFilter(string name, IEnumerable<string> commonWords) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(commonWords, nameof(commonWords));

            CommonWords = commonWords.ToList();
            OdataType = "#Microsoft.Azure.Search.CommonGramTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="CommonGramTokenFilter"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="commonWords"> The set of common words. </param>
        /// <param name="ignoreCase"> A value indicating whether common words matching will be case insensitive. Default is false. </param>
        /// <param name="useQueryMode"> A value that indicates whether the token filter is in query mode. When in query mode, the token filter generates bigrams and then removes common words and single terms followed by a common word. Default is false. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CommonGramTokenFilter(string odataType, string name, IList<string> commonWords, bool? ignoreCase, bool? useQueryMode, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(odataType, name, serializedAdditionalRawData)
        {
            CommonWords = commonWords;
            IgnoreCase = ignoreCase;
            UseQueryMode = useQueryMode;
            OdataType = odataType ?? "#Microsoft.Azure.Search.CommonGramTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="CommonGramTokenFilter"/> for deserialization. </summary>
        internal CommonGramTokenFilter()
        {
        }

        /// <summary> The set of common words. </summary>
        public IList<string> CommonWords { get; }
        /// <summary> A value indicating whether common words matching will be case insensitive. Default is false. </summary>
        public bool? IgnoreCase { get; set; }
        /// <summary> A value that indicates whether the token filter is in query mode. When in query mode, the token filter generates bigrams and then removes common words and single terms followed by a common word. Default is false. </summary>
        public bool? UseQueryMode { get; set; }
    }
}
