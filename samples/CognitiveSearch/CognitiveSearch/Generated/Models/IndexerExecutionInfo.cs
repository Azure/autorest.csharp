// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Represents the current status and execution history of an indexer. </summary>
    public partial class IndexerExecutionInfo
    {
        /// <summary> Overall indexer status. </summary>
        public IndexerStatus? Status { get; internal set; }
        /// <summary> The result of the most recent or an in-progress indexer execution. </summary>
        public IndexerExecutionResult LastResult { get; internal set; }
        /// <summary> History of the recent indexer executions, sorted in reverse chronological order. </summary>
        public ICollection<IndexerExecutionResult> ExecutionHistory { get; internal set; }
        /// <summary> The execution limits for the indexer. </summary>
        public IndexerLimits Limits { get; internal set; }
    }
}
