// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Anomaly status and information. </summary>
    public partial class AnomalyState
    {
        /// <summary> Initializes a new instance of AnomalyState. </summary>
        /// <param name="timestamp"> The timestamp for this anomaly. </param>
        internal AnomalyState(DateTimeOffset timestamp)
        {
            Timestamp = timestamp;
            Errors = new ChangeTrackingList<ErrorResponse>();
        }

        /// <summary> Initializes a new instance of AnomalyState. </summary>
        /// <param name="timestamp"> The timestamp for this anomaly. </param>
        /// <param name="value"> The detailed value of this anomalous timestamp. </param>
        /// <param name="errors"> Error message for the current timestamp. </param>
        internal AnomalyState(DateTimeOffset timestamp, AnomalyValue value, IReadOnlyList<ErrorResponse> errors)
        {
            Timestamp = timestamp;
            Value = value;
            Errors = errors;
        }

        /// <summary> The timestamp for this anomaly. </summary>
        public DateTimeOffset Timestamp { get; }
        /// <summary> The detailed value of this anomalous timestamp. </summary>
        public AnomalyValue Value { get; }
        /// <summary> Error message for the current timestamp. </summary>
        public IReadOnlyList<ErrorResponse> Errors { get; }
    }
}
