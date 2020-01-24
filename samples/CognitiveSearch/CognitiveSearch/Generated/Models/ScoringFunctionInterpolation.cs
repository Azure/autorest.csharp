// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Defines the function used to interpolate score boosting across a range of documents. </summary>
    public enum ScoringFunctionInterpolation
    {
        /// <summary> The value &apos;undefined&apos;. </summary>
        Linear,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Constant,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Quadratic,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Logarithmic
    }
}
