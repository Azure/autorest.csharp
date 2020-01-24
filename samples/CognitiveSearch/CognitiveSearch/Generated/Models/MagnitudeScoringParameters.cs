// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Provides parameter values to a magnitude scoring function. </summary>
    public partial class MagnitudeScoringParameters
    {
        /// <summary> The field value at which boosting starts. </summary>
        public double BoostingRangeStart { get; set; }
        /// <summary> The field value at which boosting ends. </summary>
        public double BoostingRangeEnd { get; set; }
        /// <summary> A value indicating whether to apply a constant boost for field values beyond the range end value; default is false. </summary>
        public bool? ShouldBoostBeyondRangeByConstant { get; set; }
    }
}
