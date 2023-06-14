// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace AnomalyDetector.Models
{
    /// <summary> Interpretation of the anomalous timestamp. </summary>
    public partial class AnomalyInterpretation
    {
        /// <summary> Initializes a new instance of AnomalyInterpretation. </summary>
        internal AnomalyInterpretation()
        {
        }

        /// <summary> Initializes a new instance of AnomalyInterpretation. </summary>
        /// <param name="variable"> Variable. </param>
        /// <param name="contributionScore">
        /// This score shows the percentage contributing to the anomalous timestamp. A
        /// number between 0 and 1.
        /// </param>
        /// <param name="correlationChanges"> Correlation changes among the anomalous variables. </param>
        internal AnomalyInterpretation(string variable, float? contributionScore, CorrelationChanges correlationChanges)
        {
            Variable = variable;
            ContributionScore = contributionScore;
            CorrelationChanges = correlationChanges;
        }

        /// <summary> Variable. </summary>
        public string Variable { get; }
        /// <summary>
        /// This score shows the percentage contributing to the anomalous timestamp. A
        /// number between 0 and 1.
        /// </summary>
        public float? ContributionScore { get; }
        /// <summary> Correlation changes among the anomalous variables. </summary>
        public CorrelationChanges CorrelationChanges { get; }
    }
}
