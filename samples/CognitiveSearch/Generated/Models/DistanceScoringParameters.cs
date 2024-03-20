// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Provides parameter values to a distance scoring function. </summary>
    public partial class DistanceScoringParameters
    {
        /// <summary> Initializes a new instance of <see cref="DistanceScoringParameters"/>. </summary>
        /// <param name="referencePointParameter"> The name of the parameter passed in search queries to specify the reference location. </param>
        /// <param name="boostingDistance"> The distance in kilometers from the reference location where the boosting range ends. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="referencePointParameter"/> is null. </exception>
        public DistanceScoringParameters(string referencePointParameter, double boostingDistance)
        {
            Argument.AssertNotNull(referencePointParameter, nameof(referencePointParameter));

            ReferencePointParameter = referencePointParameter;
            BoostingDistance = boostingDistance;
        }

        /// <summary> The name of the parameter passed in search queries to specify the reference location. </summary>
        public string ReferencePointParameter { get; set; }
        /// <summary> The distance in kilometers from the reference location where the boosting range ends. </summary>
        public double BoostingDistance { get; set; }
    }
}
