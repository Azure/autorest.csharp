// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Defines weights on index fields for which matches should boost scoring in search queries. </summary>
    public partial class TextWeights
    {
        /// <summary> Initializes a new instance of TextWeights. </summary>
        /// <param name="weights"> The dictionary of per-field weights to boost document scoring. The keys are field names and the values are the weights for each field. </param>
        public TextWeights(IDictionary<string, double> weights)
        {
            Weights = weights;
        }

        /// <summary> The dictionary of per-field weights to boost document scoring. The keys are field names and the values are the weights for each field. </summary>
        public IDictionary<string, double> Weights { get; }
    }
}
