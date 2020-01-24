// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Defines parameters for a search index that influence scoring in search queries. </summary>
    public partial class ScoringProfile
    {
        /// <summary> The name of the scoring profile. </summary>
        public string Name { get; set; }
        /// <summary> Defines weights on index fields for which matches should boost scoring in search queries. </summary>
        public TextWeights TextWeights { get; set; }
        /// <summary> The collection of functions that influence the scoring of documents. </summary>
        public ICollection<ScoringFunction> Functions { get; set; }
        /// <summary> Defines the aggregation function used to combine the results of all the scoring functions in a scoring profile. </summary>
        public ScoringFunctionAggregation? FunctionAggregation { get; set; }
    }
}
