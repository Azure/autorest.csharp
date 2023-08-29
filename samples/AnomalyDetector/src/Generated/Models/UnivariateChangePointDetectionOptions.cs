// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> The request of change point detection. </summary>
    public partial class UnivariateChangePointDetectionOptions
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of UnivariateChangePointDetectionOptions. </summary>
        /// <param name="series">
        /// Time series data points. Points should be sorted by timestamp in ascending
        /// order to match the change point detection result.
        /// </param>
        /// <param name="granularity">
        /// Can only be one of yearly, monthly, weekly, daily, hourly, minutely or
        /// secondly. Granularity is used for verify whether input series is valid.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="series"/> is null. </exception>
        public UnivariateChangePointDetectionOptions(IEnumerable<TimeSeriesPoint> series, TimeGranularity granularity)
        {
            Argument.AssertNotNull(series, nameof(series));

            Series = series.ToList();
            Granularity = granularity;
        }

        /// <summary> Initializes a new instance of UnivariateChangePointDetectionOptions. </summary>
        /// <param name="series">
        /// Time series data points. Points should be sorted by timestamp in ascending
        /// order to match the change point detection result.
        /// </param>
        /// <param name="granularity">
        /// Can only be one of yearly, monthly, weekly, daily, hourly, minutely or
        /// secondly. Granularity is used for verify whether input series is valid.
        /// </param>
        /// <param name="customInterval">
        /// Custom Interval is used to set non-standard time interval, for example, if the
        /// series is 5 minutes, request can be set as {"granularity":"minutely",
        /// "customInterval":5}.
        /// </param>
        /// <param name="period">
        /// Optional argument, periodic value of a time series. If the value is null or
        /// does not present, the API will determine the period automatically.
        /// </param>
        /// <param name="stableTrendWindow">
        /// Optional argument, advanced model parameter, a default stableTrendWindow will
        /// be used in detection.
        /// </param>
        /// <param name="threshold">
        /// Optional argument, advanced model parameter, between 0.0-1.0, the lower the
        /// value is, the larger the trend error will be which means less change point will
        /// be accepted.
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnivariateChangePointDetectionOptions(IList<TimeSeriesPoint> series, TimeGranularity granularity, int? customInterval, int? period, int? stableTrendWindow, float? threshold, Dictionary<string, BinaryData> rawData)
        {
            Series = series;
            Granularity = granularity;
            CustomInterval = customInterval;
            Period = period;
            StableTrendWindow = stableTrendWindow;
            Threshold = threshold;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="UnivariateChangePointDetectionOptions"/> for deserialization. </summary>
        internal UnivariateChangePointDetectionOptions()
        {
        }

        /// <summary>
        /// Time series data points. Points should be sorted by timestamp in ascending
        /// order to match the change point detection result.
        /// </summary>
        public IList<TimeSeriesPoint> Series { get; }
        /// <summary>
        /// Can only be one of yearly, monthly, weekly, daily, hourly, minutely or
        /// secondly. Granularity is used for verify whether input series is valid.
        /// </summary>
        public TimeGranularity Granularity { get; }
        /// <summary>
        /// Custom Interval is used to set non-standard time interval, for example, if the
        /// series is 5 minutes, request can be set as {"granularity":"minutely",
        /// "customInterval":5}.
        /// </summary>
        public int? CustomInterval { get; set; }
        /// <summary>
        /// Optional argument, periodic value of a time series. If the value is null or
        /// does not present, the API will determine the period automatically.
        /// </summary>
        public int? Period { get; set; }
        /// <summary>
        /// Optional argument, advanced model parameter, a default stableTrendWindow will
        /// be used in detection.
        /// </summary>
        public int? StableTrendWindow { get; set; }
        /// <summary>
        /// Optional argument, advanced model parameter, between 0.0-1.0, the lower the
        /// value is, the larger the trend error will be which means less change point will
        /// be accepted.
        /// </summary>
        public float? Threshold { get; set; }
    }
}
