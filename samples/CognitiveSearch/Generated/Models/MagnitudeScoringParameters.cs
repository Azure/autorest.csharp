// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Provides parameter values to a magnitude scoring function. </summary>
    public partial class MagnitudeScoringParameters
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="MagnitudeScoringParameters"/>. </summary>
        /// <param name="boostingRangeStart"> The field value at which boosting starts. </param>
        /// <param name="boostingRangeEnd"> The field value at which boosting ends. </param>
        public MagnitudeScoringParameters(double boostingRangeStart, double boostingRangeEnd)
        {
            BoostingRangeStart = boostingRangeStart;
            BoostingRangeEnd = boostingRangeEnd;
        }

        /// <summary> Initializes a new instance of <see cref="MagnitudeScoringParameters"/>. </summary>
        /// <param name="boostingRangeStart"> The field value at which boosting starts. </param>
        /// <param name="boostingRangeEnd"> The field value at which boosting ends. </param>
        /// <param name="shouldBoostBeyondRangeByConstant"> A value indicating whether to apply a constant boost for field values beyond the range end value; default is false. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal MagnitudeScoringParameters(double boostingRangeStart, double boostingRangeEnd, bool? shouldBoostBeyondRangeByConstant, Dictionary<string, BinaryData> rawData)
        {
            BoostingRangeStart = boostingRangeStart;
            BoostingRangeEnd = boostingRangeEnd;
            ShouldBoostBeyondRangeByConstant = shouldBoostBeyondRangeByConstant;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="MagnitudeScoringParameters"/> for deserialization. </summary>
        internal MagnitudeScoringParameters()
        {
        }

        /// <summary> The field value at which boosting starts. </summary>
        public double BoostingRangeStart { get; set; }
        /// <summary> The field value at which boosting ends. </summary>
        public double BoostingRangeEnd { get; set; }
        /// <summary> A value indicating whether to apply a constant boost for field values beyond the range end value; default is false. </summary>
        public bool? ShouldBoostBeyondRangeByConstant { get; set; }
    }
}
