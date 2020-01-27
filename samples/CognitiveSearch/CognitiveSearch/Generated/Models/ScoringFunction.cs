// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Abstract base class for functions that can modify document scores during ranking. </summary>
    public partial class ScoringFunction
    {
        /// <summary> Initializes a new instance of ScoringFunction. </summary>
        public ScoringFunction()
        {
            Type = null;
        }
        public string Type { get; internal set; }
        /// <summary> The name of the field used as input to the scoring function. </summary>
        public string FieldName { get; set; }
        /// <summary> A multiplier for the raw score. Must be a positive number not equal to 1.0. </summary>
        public double Boost { get; set; }
        /// <summary> Defines the function used to interpolate score boosting across a range of documents. </summary>
        public ScoringFunctionInterpolation? Interpolation { get; set; }
    }
}
