// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Divides text at non-letters; Applies the lowercase and stopword token filters. This analyzer is implemented using Apache Lucene. </summary>
    public partial class StopAnalyzer : Analyzer
    {
        /// <summary> Initializes a new instance of StopAnalyzer. </summary>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StopAnalyzer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Stopwords = new ChangeTrackingList<string>();
            OdataType = "#Microsoft.Azure.Search.StopAnalyzer";
        }

        /// <summary> Initializes a new instance of StopAnalyzer. </summary>
        /// <param name="odataType"> Identifies the concrete type of the analyzer. </param>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="stopwords"> A list of stopwords. </param>
        internal StopAnalyzer(string odataType, string name, IList<string> stopwords) : base(odataType, name)
        {
            Stopwords = stopwords;
            OdataType = odataType ?? "#Microsoft.Azure.Search.StopAnalyzer";
        }

        /// <summary> A list of stopwords. </summary>
        public IList<string> Stopwords { get; }
    }
}
