// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace AnomalyDetector.Models
{
    /// <summary> The definition of input timeseries points. </summary>
    public partial class TimeSeriesPoint
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of TimeSeriesPoint. </summary>
        /// <param name="value"> The measurement of that point, should be float. </param>
        public TimeSeriesPoint(float value)
        {
            Value = value;
        }

        /// <summary> Initializes a new instance of TimeSeriesPoint. </summary>
        /// <param name="timestamp"> Optional argument, timestamp of a data point (ISO8601 format). </param>
        /// <param name="value"> The measurement of that point, should be float. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TimeSeriesPoint(DateTimeOffset? timestamp, float value, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Timestamp = timestamp;
            Value = value;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="TimeSeriesPoint"/> for deserialization. </summary>
        internal TimeSeriesPoint()
        {
        }

        /// <summary> Optional argument, timestamp of a data point (ISO8601 format). </summary>
        public DateTimeOffset? Timestamp { get; set; }
        /// <summary> The measurement of that point, should be float. </summary>
        public float Value { get; }
    }
}
