// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Defines a function that boosts scores based on distance from a geographic location. </summary>
    public partial class DistanceScoringFunction : ScoringFunction
    {
        /// <summary> Initializes a new instance of DistanceScoringFunction. </summary>
        /// <param name="fieldName"> The name of the field used as input to the scoring function. </param>
        /// <param name="boost"> A multiplier for the raw score. Must be a positive number not equal to 1.0. </param>
        /// <param name="parameters"> Parameter values for the distance scoring function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fieldName"/> or <paramref name="parameters"/> is null. </exception>
        public DistanceScoringFunction(string fieldName, double boost, DistanceScoringParameters parameters) : base(fieldName, boost)
        {
            Argument.AssertNotNull(fieldName, nameof(fieldName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Type = "distance";
        }

        /// <summary> Initializes a new instance of DistanceScoringFunction. </summary>
        /// <param name="type"> Indicates the type of function to use. Valid values include magnitude, freshness, distance, and tag. The function type must be lower case. </param>
        /// <param name="fieldName"> The name of the field used as input to the scoring function. </param>
        /// <param name="boost"> A multiplier for the raw score. Must be a positive number not equal to 1.0. </param>
        /// <param name="interpolation"> A value indicating how boosting will be interpolated across document scores; defaults to "Linear". </param>
        /// <param name="parameters"> Parameter values for the distance scoring function. </param>
        internal DistanceScoringFunction(string type, string fieldName, double boost, ScoringFunctionInterpolation? interpolation, DistanceScoringParameters parameters) : base(type, fieldName, boost, interpolation)
        {
            Parameters = parameters;
            Type = type ?? "distance";
        }

        /// <summary> Parameter values for the distance scoring function. </summary>
        public DistanceScoringParameters Parameters { get; set; }
    }
}
