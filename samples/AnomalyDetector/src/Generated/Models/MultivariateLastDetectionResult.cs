// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Results of last detection. </summary>
    public partial class MultivariateLastDetectionResult
    {
        /// <summary> Initializes a new instance of MultivariateLastDetectionResult. </summary>
        internal MultivariateLastDetectionResult()
        {
            VariableStates = new ChangeTrackingList<VariableState>();
            Results = new ChangeTrackingList<AnomalyState>();
        }

        /// <summary> Initializes a new instance of MultivariateLastDetectionResult. </summary>
        /// <param name="variableStates"> Variable Status. </param>
        /// <param name="results"> Anomaly status and information. </param>
        internal MultivariateLastDetectionResult(IReadOnlyList<VariableState> variableStates, IReadOnlyList<AnomalyState> results)
        {
            VariableStates = variableStates;
            Results = results;
        }

        /// <summary> Variable Status. </summary>
        public IReadOnlyList<VariableState> VariableStates { get; }
        /// <summary> Anomaly status and information. </summary>
        public IReadOnlyList<AnomalyState> Results { get; }
    }
}
