// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary>
    /// Detection request for batch inference. This is an asynchronous inference which
    /// will need another API to get detection results.
    /// </summary>
    public partial class MultivariateBatchDetectionOptions
    {
        /// <summary> Initializes a new instance of MultivariateBatchDetectionOptions. </summary>
        /// <param name="dataSource"></param>
        /// <param name="topContributorCount"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="dataSource"/> is null. </exception>
        public MultivariateBatchDetectionOptions(string dataSource, int topContributorCount, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Argument.AssertNotNull(dataSource, nameof(dataSource));

            DataSource = dataSource;
            TopContributorCount = topContributorCount;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary> Gets or sets the data source. </summary>
        public string DataSource { get; set; }
        /// <summary> Gets or sets the top contributor count. </summary>
        public int TopContributorCount { get; set; }
        /// <summary> Gets or sets the start time. </summary>
        public DateTimeOffset StartTime { get; set; }
        /// <summary> Gets or sets the end time. </summary>
        public DateTimeOffset EndTime { get; set; }
    }
}
