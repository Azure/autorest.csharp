// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Marks terms as keywords. This token filter is implemented using Apache Lucene. </summary>
    public partial class KeywordMarkerTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of KeywordMarkerTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="keywords"> A list of words to mark as keywords. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="keywords"/> is null. </exception>
        public KeywordMarkerTokenFilter(string name, IEnumerable<string> keywords) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(keywords, nameof(keywords));

            Keywords = keywords.ToList();
            OdataType = "#Microsoft.Azure.Search.KeywordMarkerTokenFilter";
        }

        /// <summary> Initializes a new instance of KeywordMarkerTokenFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="keywords"> A list of words to mark as keywords. </param>
        /// <param name="ignoreCase"> A value indicating whether to ignore case. If true, all words are converted to lower case first. Default is false. </param>
        internal KeywordMarkerTokenFilter(string odataType, string name, IList<string> keywords, bool? ignoreCase) : base(odataType, name)
        {
            Keywords = keywords;
            IgnoreCase = ignoreCase;
            OdataType = odataType ?? "#Microsoft.Azure.Search.KeywordMarkerTokenFilter";
        }

        /// <summary> A list of words to mark as keywords. </summary>
        public IList<string> Keywords { get; }
        /// <summary> A value indicating whether to ignore case. If true, all words are converted to lower case first. Default is false. </summary>
        public bool? IgnoreCase { get; set; }
    }
}
