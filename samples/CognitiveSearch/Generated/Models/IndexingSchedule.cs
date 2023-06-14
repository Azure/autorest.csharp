// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Represents a schedule for indexer execution. </summary>
    public partial class IndexingSchedule
    {
        /// <summary> Initializes a new instance of IndexingSchedule. </summary>
        /// <param name="interval"> The interval of time between indexer executions. </param>
        public IndexingSchedule(TimeSpan interval)
        {
            Interval = interval;
        }

        /// <summary> Initializes a new instance of IndexingSchedule. </summary>
        /// <param name="interval"> The interval of time between indexer executions. </param>
        /// <param name="startTime"> The time when an indexer should start running. </param>
        internal IndexingSchedule(TimeSpan interval, DateTimeOffset? startTime)
        {
            Interval = interval;
            StartTime = startTime;
        }

        /// <summary> The interval of time between indexer executions. </summary>
        public TimeSpan Interval { get; set; }
        /// <summary> The time when an indexer should start running. </summary>
        public DateTimeOffset? StartTime { get; set; }
    }
}
