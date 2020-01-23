// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Represents the result of an individual indexer execution. </summary>
    public partial class IndexerExecutionResult
    {
        /// <summary> Represents the status of an individual indexer execution. </summary>
        public IndexerExecutionStatus? Status { get; internal set; }
        /// <summary> The error message indicating the top-level error, if any. </summary>
        public string? ErrorMessage { get; internal set; }
        /// <summary> The start time of this indexer execution. </summary>
        public DateTimeOffset? StartTime { get; internal set; }
        /// <summary> The end time of this indexer execution, if the execution has already completed. </summary>
        public DateTimeOffset? EndTime { get; internal set; }
        /// <summary> The item-level indexing errors. </summary>
        public ICollection<ItemError>? Errors { get; internal set; }
        /// <summary> The item-level indexing warnings. </summary>
        public ICollection<ItemWarning>? Warnings { get; internal set; }
        /// <summary> The number of items that were processed during this indexer execution. This includes both successfully processed items and items where indexing was attempted but failed. </summary>
        public int? ItemCount { get; internal set; }
        /// <summary> The number of items that failed to be indexed during this indexer execution. </summary>
        public int? FailedItemCount { get; internal set; }
        /// <summary> Change tracking state with which an indexer execution started. </summary>
        public string? InitialTrackingState { get; internal set; }
        /// <summary> Change tracking state with which an indexer execution finished. </summary>
        public string? FinalTrackingState { get; internal set; }
    }
}
