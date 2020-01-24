// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Defines the aggregation function used to combine the results of all the scoring functions in a scoring profile. </summary>
    public enum ScoringFunctionAggregation
    {
        /// <summary> The value &apos;undefined&apos;. </summary>
        Sum,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Average,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Minimum,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Maximum,
        /// <summary> The value &apos;undefined&apos;. </summary>
        FirstMatching
    }
}
