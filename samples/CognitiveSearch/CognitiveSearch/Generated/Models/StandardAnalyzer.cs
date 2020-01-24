// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Standard Apache Lucene analyzer; Composed of the standard tokenizer, lowercase filter and stop filter. </summary>
    public partial class StandardAnalyzer : Analyzer
    {
        /// <summary> Initializes a new instance of StandardAnalyzer. </summary>
        public StandardAnalyzer()
        {
            OdataType = "#Microsoft.Azure.Search.StandardAnalyzer";
        }
        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </summary>
        public int? MaxTokenLength { get; set; }
        /// <summary> A list of stopwords. </summary>
        public ICollection<string>? Stopwords { get; set; }
    }
}
