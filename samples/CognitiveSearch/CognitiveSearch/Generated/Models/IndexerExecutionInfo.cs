// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Represents the current status and execution history of an indexer. </summary>
    public partial class IndexerExecutionInfo
    {
        /// <summary> Represents the overall indexer status. </summary>
        public IndexerStatus? Status { get; internal set; }
        /// <summary> Represents the result of an individual indexer execution. </summary>
        public IndexerExecutionResult? LastResult { get; internal set; }
        /// <summary> History of the recent indexer executions, sorted in reverse chronological order. </summary>
        public ICollection<IndexerExecutionResult>? ExecutionHistory { get; internal set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
        public IndexerLimits? Limits { get; internal set; }
    }
}
