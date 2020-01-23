// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Represents a schedule for indexer execution. </summary>
    public partial class IndexingSchedule
    {
        /// <summary> The interval of time between indexer executions. </summary>
        public TimeSpan Interval { get; set; }
        /// <summary> The time when an indexer should start running. </summary>
        public DateTimeOffset? StartTime { get; set; }
    }
}
