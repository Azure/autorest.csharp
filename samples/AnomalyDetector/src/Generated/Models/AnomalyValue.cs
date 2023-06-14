// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Detailed information of the anomalous timestamp. </summary>
    public partial class AnomalyValue
    {
        /// <summary> Initializes a new instance of AnomalyValue. </summary>
        /// <param name="isAnomaly"> True if an anomaly is detected at the current timestamp. </param>
        /// <param name="severity">
        /// Indicates the significance of the anomaly. The higher the severity, the more
        /// significant the anomaly is.
        /// </param>
        /// <param name="score">
        /// Raw anomaly score of severity, will help indicate the degree of abnormality as
        /// well.
        /// </param>
        internal AnomalyValue(bool isAnomaly, float severity, float score)
        {
            IsAnomaly = isAnomaly;
            Severity = severity;
            Score = score;
            Interpretation = new ChangeTrackingList<AnomalyInterpretation>();
        }

        /// <summary> Initializes a new instance of AnomalyValue. </summary>
        /// <param name="isAnomaly"> True if an anomaly is detected at the current timestamp. </param>
        /// <param name="severity">
        /// Indicates the significance of the anomaly. The higher the severity, the more
        /// significant the anomaly is.
        /// </param>
        /// <param name="score">
        /// Raw anomaly score of severity, will help indicate the degree of abnormality as
        /// well.
        /// </param>
        /// <param name="interpretation"> Interpretation of this anomalous timestamp. </param>
        internal AnomalyValue(bool isAnomaly, float severity, float score, IReadOnlyList<AnomalyInterpretation> interpretation)
        {
            IsAnomaly = isAnomaly;
            Severity = severity;
            Score = score;
            Interpretation = interpretation;
        }

        /// <summary> True if an anomaly is detected at the current timestamp. </summary>
        public bool IsAnomaly { get; }
        /// <summary>
        /// Indicates the significance of the anomaly. The higher the severity, the more
        /// significant the anomaly is.
        /// </summary>
        public float Severity { get; }
        /// <summary>
        /// Raw anomaly score of severity, will help indicate the degree of abnormality as
        /// well.
        /// </summary>
        public float Score { get; }
        /// <summary> Interpretation of this anomalous timestamp. </summary>
        public IReadOnlyList<AnomalyInterpretation> Interpretation { get; }
    }
}
