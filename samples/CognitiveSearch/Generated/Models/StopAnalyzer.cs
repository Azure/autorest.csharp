// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Divides text at non-letters; Applies the lowercase and stopword token filters. This analyzer is implemented using Apache Lucene. </summary>
    public partial class StopAnalyzer : Analyzer
    {
        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.StopAnalyzer
        ///
        /// </summary>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StopAnalyzer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Stopwords = new ChangeTrackingList<string>();
            OdataType = "#Microsoft.Azure.Search.StopAnalyzer";
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.StopAnalyzer
        ///
        /// </summary>
        /// <param name="odataType"> Identifies the concrete type of the analyzer. </param>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="stopwords"> A list of stopwords. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StopAnalyzer(string odataType, string name, IList<string> stopwords, Dictionary<string, BinaryData> rawData) : base(odataType, name, rawData)
        {
            Stopwords = stopwords;
            OdataType = odataType ?? "#Microsoft.Azure.Search.StopAnalyzer";
        }

        /// <summary> A list of stopwords. </summary>
        public IList<string> Stopwords { get; }
    }
}
