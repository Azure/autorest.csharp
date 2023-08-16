// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Represents the current status and execution history of an indexer. </summary>
    public partial class IndexerExecutionInfo
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.IndexerExecutionInfo
        ///
        /// </summary>
        /// <param name="status"> Overall indexer status. </param>
        /// <param name="executionHistory"> History of the recent indexer executions, sorted in reverse chronological order. </param>
        /// <param name="limits"> The execution limits for the indexer. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="executionHistory"/> or <paramref name="limits"/> is null. </exception>
        internal IndexerExecutionInfo(IndexerStatus status, IEnumerable<IndexerExecutionResult> executionHistory, IndexerLimits limits)
        {
            Argument.AssertNotNull(executionHistory, nameof(executionHistory));
            Argument.AssertNotNull(limits, nameof(limits));

            Status = status;
            ExecutionHistory = executionHistory.ToList();
            Limits = limits;
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.IndexerExecutionInfo
        ///
        /// </summary>
        /// <param name="status"> Overall indexer status. </param>
        /// <param name="lastResult"> The result of the most recent or an in-progress indexer execution. </param>
        /// <param name="executionHistory"> History of the recent indexer executions, sorted in reverse chronological order. </param>
        /// <param name="limits"> The execution limits for the indexer. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal IndexerExecutionInfo(IndexerStatus status, IndexerExecutionResult lastResult, IReadOnlyList<IndexerExecutionResult> executionHistory, IndexerLimits limits, Dictionary<string, BinaryData> rawData)
        {
            Status = status;
            LastResult = lastResult;
            ExecutionHistory = executionHistory;
            Limits = limits;
            _rawData = rawData;
        }

        /// <summary> Overall indexer status. </summary>
        public IndexerStatus Status { get; }
        /// <summary> The result of the most recent or an in-progress indexer execution. </summary>
        public IndexerExecutionResult LastResult { get; }
        /// <summary> History of the recent indexer executions, sorted in reverse chronological order. </summary>
        public IReadOnlyList<IndexerExecutionResult> ExecutionHistory { get; }
        /// <summary> The execution limits for the indexer. </summary>
        public IndexerLimits Limits { get; }
    }
}
