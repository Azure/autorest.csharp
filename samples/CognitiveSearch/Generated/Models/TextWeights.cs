// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Defines weights on index fields for which matches should boost scoring in search queries. </summary>
    public partial class TextWeights
    {
        /// <summary> Initializes a new instance of TextWeights. </summary>
        /// <param name="weights"> The dictionary of per-field weights to boost document scoring. The keys are field names and the values are the weights for each field. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="weights"/> is null. </exception>
        public TextWeights(IDictionary<string, double> weights)
        {
            Argument.AssertNotNull(weights, nameof(weights));

            Weights = weights;
        }

        /// <summary> The dictionary of per-field weights to boost document scoring. The keys are field names and the values are the weights for each field. </summary>
        public IDictionary<string, double> Weights { get; }
    }
}
