// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace AnomalyDetector.Models
{
    public enum MultivariateBatchDetectionStatus
    {
        /// <summary> CREATED. </summary>
        Created,
        /// <summary> RUNNING. </summary>
        Running,
        /// <summary> READY. </summary>
        Ready,
        /// <summary> FAILED. </summary>
        Failed
    }
}
