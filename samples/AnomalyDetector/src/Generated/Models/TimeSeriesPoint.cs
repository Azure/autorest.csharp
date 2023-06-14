// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace AnomalyDetector.Models
{
    /// <summary> The definition of input timeseries points. </summary>
    public partial class TimeSeriesPoint
    {
        /// <summary> Initializes a new instance of TimeSeriesPoint. </summary>
        /// <param name="value"> The measurement of that point, should be float. </param>
        public TimeSeriesPoint(float value)
        {
            Value = value;
        }

        /// <summary> Initializes a new instance of TimeSeriesPoint. </summary>
        /// <param name="timestamp"> Optional argument, timestamp of a data point (ISO8601 format). </param>
        /// <param name="value"> The measurement of that point, should be float. </param>
        internal TimeSeriesPoint(DateTimeOffset? timestamp, float value)
        {
            Timestamp = timestamp;
            Value = value;
        }

        /// <summary> Optional argument, timestamp of a data point (ISO8601 format). </summary>
        public DateTimeOffset? Timestamp { get; set; }
        /// <summary> The measurement of that point, should be float. </summary>
        public float Value { get; }
    }
}
