// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Flexibly separates text into terms via a regular expression pattern. This analyzer is implemented using Apache Lucene. </summary>
    public partial class PatternAnalyzer : Analyzer
    {
        /// <summary> Initializes a new instance of PatternAnalyzer. </summary>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public PatternAnalyzer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Stopwords = new ChangeTrackingList<string>();
            OdataType = "#Microsoft.Azure.Search.PatternAnalyzer";
        }

        /// <summary> Initializes a new instance of PatternAnalyzer. </summary>
        /// <param name="odataType"> Identifies the concrete type of the analyzer. </param>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="lowerCaseTerms"> A value indicating whether terms should be lower-cased. Default is true. </param>
        /// <param name="pattern"> A regular expression pattern to match token separators. Default is an expression that matches one or more whitespace characters. </param>
        /// <param name="flags"> Regular expression flags. </param>
        /// <param name="stopwords"> A list of stopwords. </param>
        internal PatternAnalyzer(string odataType, string name, bool? lowerCaseTerms, string pattern, RegexFlags? flags, IList<string> stopwords) : base(odataType, name)
        {
            LowerCaseTerms = lowerCaseTerms;
            Pattern = pattern;
            Flags = flags;
            Stopwords = stopwords;
            OdataType = odataType ?? "#Microsoft.Azure.Search.PatternAnalyzer";
        }

        /// <summary> A value indicating whether terms should be lower-cased. Default is true. </summary>
        public bool? LowerCaseTerms { get; set; }
        /// <summary> A regular expression pattern to match token separators. Default is an expression that matches one or more whitespace characters. </summary>
        public string Pattern { get; set; }
        /// <summary> Regular expression flags. </summary>
        public RegexFlags? Flags { get; set; }
        /// <summary> A list of stopwords. </summary>
        public IList<string> Stopwords { get; }
    }
}
