// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Defines a function that boosts scores based on the value of a date-time field. </summary>
    public partial class FreshnessScoringFunction : ScoringFunction
    {
        /// <summary> Initializes a new instance of FreshnessScoringFunction. </summary>
        public FreshnessScoringFunction()
        {
            Type = "freshness";
        }
        /// <summary> Provides parameter values to a freshness scoring function. </summary>
        public FreshnessScoringParameters Parameters { get; set; } = new FreshnessScoringParameters();
    }
}
