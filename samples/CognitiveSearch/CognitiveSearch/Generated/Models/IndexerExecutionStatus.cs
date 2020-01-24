// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Represents the status of an individual indexer execution. </summary>
    public enum IndexerExecutionStatus
    {
        /// <summary> The value &apos;undefined&apos;. </summary>
        TransientFailure,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Success,
        /// <summary> The value &apos;undefined&apos;. </summary>
        InProgress,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Reset
    }
}
