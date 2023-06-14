// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Multivariate anomaly detection status. </summary>
    public partial class MultivariateBatchDetectionResultSummary
    {
        /// <summary> Initializes a new instance of MultivariateBatchDetectionResultSummary. </summary>
        /// <param name="status"> Status of detection results. One of CREATED, RUNNING, READY, and FAILED. </param>
        /// <param name="setupInfo">
        /// Detection request for batch inference. This is an asynchronous inference which
        /// will need another API to get detection results.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="setupInfo"/> is null. </exception>
        internal MultivariateBatchDetectionResultSummary(MultivariateBatchDetectionStatus status, MultivariateBatchDetectionOptions setupInfo)
        {
            Argument.AssertNotNull(setupInfo, nameof(setupInfo));

            Status = status;
            Errors = new ChangeTrackingList<ErrorResponse>();
            VariableStates = new ChangeTrackingList<VariableState>();
            SetupInfo = setupInfo;
        }

        /// <summary> Initializes a new instance of MultivariateBatchDetectionResultSummary. </summary>
        /// <param name="status"> Status of detection results. One of CREATED, RUNNING, READY, and FAILED. </param>
        /// <param name="errors"> Error message when detection is failed. </param>
        /// <param name="variableStates"> Variable Status. </param>
        /// <param name="setupInfo">
        /// Detection request for batch inference. This is an asynchronous inference which
        /// will need another API to get detection results.
        /// </param>
        internal MultivariateBatchDetectionResultSummary(MultivariateBatchDetectionStatus status, IReadOnlyList<ErrorResponse> errors, IReadOnlyList<VariableState> variableStates, MultivariateBatchDetectionOptions setupInfo)
        {
            Status = status;
            Errors = errors;
            VariableStates = variableStates;
            SetupInfo = setupInfo;
        }

        /// <summary> Status of detection results. One of CREATED, RUNNING, READY, and FAILED. </summary>
        public MultivariateBatchDetectionStatus Status { get; }
        /// <summary> Error message when detection is failed. </summary>
        public IReadOnlyList<ErrorResponse> Errors { get; }
        /// <summary> Variable Status. </summary>
        public IReadOnlyList<VariableState> VariableStates { get; }
        /// <summary>
        /// Detection request for batch inference. This is an asynchronous inference which
        /// will need another API to get detection results.
        /// </summary>
        public MultivariateBatchDetectionOptions SetupInfo { get; }
    }
}
