// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Correlation changes among the anomalous variables. </summary>
    public partial class CorrelationChanges
    {
        /// <summary> Initializes a new instance of CorrelationChanges. </summary>
        internal CorrelationChanges()
        {
            ChangedVariables = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of CorrelationChanges. </summary>
        /// <param name="changedVariables"> The correlated variables that have correlation changes under an anomaly. </param>
        internal CorrelationChanges(IReadOnlyList<string> changedVariables)
        {
            ChangedVariables = changedVariables;
        }

        /// <summary> The correlated variables that have correlation changes under an anomaly. </summary>
        public IReadOnlyList<string> ChangedVariables { get; }
    }
}
