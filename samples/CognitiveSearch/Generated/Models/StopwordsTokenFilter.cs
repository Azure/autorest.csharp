// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Removes stop words from a token stream. This token filter is implemented using Apache Lucene. </summary>
    public partial class StopwordsTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of <see cref="StopwordsTokenFilter"/>. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StopwordsTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Stopwords = new ChangeTrackingList<string>();
            OdataType = "#Microsoft.Azure.Search.StopwordsTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="StopwordsTokenFilter"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="stopwords"> The list of stopwords. This property and the stopwords list property cannot both be set. </param>
        /// <param name="stopwordsList"> A predefined list of stopwords to use. This property and the stopwords property cannot both be set. Default is English. </param>
        /// <param name="ignoreCase"> A value indicating whether to ignore case. If true, all words are converted to lower case first. Default is false. </param>
        /// <param name="removeTrailingStopWords"> A value indicating whether to ignore the last search term if it's a stop word. Default is true. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal StopwordsTokenFilter(string odataType, string name, IList<string> stopwords, StopwordsList? stopwordsList, bool? ignoreCase, bool? removeTrailingStopWords, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(odataType, name, serializedAdditionalRawData)
        {
            Stopwords = stopwords;
            StopwordsList = stopwordsList;
            IgnoreCase = ignoreCase;
            RemoveTrailingStopWords = removeTrailingStopWords;
            OdataType = odataType ?? "#Microsoft.Azure.Search.StopwordsTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="StopwordsTokenFilter"/> for deserialization. </summary>
        internal StopwordsTokenFilter()
        {
        }

        /// <summary> The list of stopwords. This property and the stopwords list property cannot both be set. </summary>
        public IList<string> Stopwords { get; }
        /// <summary> A predefined list of stopwords to use. This property and the stopwords property cannot both be set. Default is English. </summary>
        public StopwordsList? StopwordsList { get; set; }
        /// <summary> A value indicating whether to ignore case. If true, all words are converted to lower case first. Default is false. </summary>
        public bool? IgnoreCase { get; set; }
        /// <summary> A value indicating whether to ignore the last search term if it's a stop word. Default is true. </summary>
        public bool? RemoveTrailingStopWords { get; set; }
    }
}
