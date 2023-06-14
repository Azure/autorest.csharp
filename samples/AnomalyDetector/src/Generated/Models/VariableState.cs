// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace AnomalyDetector.Models
{
    /// <summary> Variable Status. </summary>
    public partial class VariableState
    {
        /// <summary> Initializes a new instance of VariableState. </summary>
        public VariableState()
        {
        }

        /// <summary> Initializes a new instance of VariableState. </summary>
        /// <param name="variable"> Variable name in variable states. </param>
        /// <param name="filledNARatio"> Proportion of missing values that need to be filled by fillNAMethod. </param>
        /// <param name="effectiveCount"> Number of effective data points before applying fillNAMethod. </param>
        /// <param name="firstTimestamp"> First valid timestamp with value of input data. </param>
        /// <param name="lastTimestamp"> Last valid timestamp with value of input data. </param>
        internal VariableState(string variable, float? filledNARatio, int? effectiveCount, DateTimeOffset? firstTimestamp, DateTimeOffset? lastTimestamp)
        {
            Variable = variable;
            FilledNARatio = filledNARatio;
            EffectiveCount = effectiveCount;
            FirstTimestamp = firstTimestamp;
            LastTimestamp = lastTimestamp;
        }

        /// <summary> Variable name in variable states. </summary>
        public string Variable { get; set; }
        /// <summary> Proportion of missing values that need to be filled by fillNAMethod. </summary>
        public float? FilledNARatio { get; set; }
        /// <summary> Number of effective data points before applying fillNAMethod. </summary>
        public int? EffectiveCount { get; set; }
        /// <summary> First valid timestamp with value of input data. </summary>
        public DateTimeOffset? FirstTimestamp { get; set; }
        /// <summary> Last valid timestamp with value of input data. </summary>
        public DateTimeOffset? LastTimestamp { get; set; }
    }
}
