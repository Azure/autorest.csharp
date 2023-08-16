// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> A character filter that replaces characters in the input string. It uses a regular expression to identify character sequences to preserve and a replacement pattern to identify characters to replace. For example, given the input text "aa bb aa bb", pattern "(aa)\s+(bb)", and replacement "$1#$2", the result would be "aa#bb aa#bb". This character filter is implemented using Apache Lucene. </summary>
    public partial class PatternReplaceCharFilter : CharFilter
    {
        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.PatternReplaceCharFilter
        ///
        /// </summary>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="pattern"> A regular expression pattern. </param>
        /// <param name="replacement"> The replacement text. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="pattern"/> or <paramref name="replacement"/> is null. </exception>
        public PatternReplaceCharFilter(string name, string pattern, string replacement) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(pattern, nameof(pattern));
            Argument.AssertNotNull(replacement, nameof(replacement));

            Pattern = pattern;
            Replacement = replacement;
            OdataType = "#Microsoft.Azure.Search.PatternReplaceCharFilter";
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.PatternReplaceCharFilter
        ///
        /// </summary>
        /// <param name="odataType"> Identifies the concrete type of the char filter. </param>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="pattern"> A regular expression pattern. </param>
        /// <param name="replacement"> The replacement text. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PatternReplaceCharFilter(string odataType, string name, string pattern, string replacement, Dictionary<string, BinaryData> rawData) : base(odataType, name, rawData)
        {
            Pattern = pattern;
            Replacement = replacement;
            OdataType = odataType ?? "#Microsoft.Azure.Search.PatternReplaceCharFilter";
        }

        /// <summary> A regular expression pattern. </summary>
        public string Pattern { get; set; }
        /// <summary> The replacement text. </summary>
        public string Replacement { get; set; }
    }
}
