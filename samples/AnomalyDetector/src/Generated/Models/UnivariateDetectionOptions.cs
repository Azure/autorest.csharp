// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> The request of entire or last anomaly detection. </summary>
    public partial class UnivariateDetectionOptions
    {
        /// <summary> Initializes a new instance of UnivariateDetectionOptions. </summary>
        /// <param name="series">
        /// Time series data points. Points should be sorted by timestamp in ascending
        /// order to match the anomaly detection result. If the data is not sorted
        /// correctly or there is duplicated timestamp, the API will not work. In such
        /// case, an error message will be returned.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="series"/> is null. </exception>
        public UnivariateDetectionOptions(IEnumerable<TimeSeriesPoint> series)
        {
            Argument.AssertNotNull(series, nameof(series));

            Series = series.ToList();
        }

        /// <summary> Initializes a new instance of UnivariateDetectionOptions. </summary>
        /// <param name="series">
        /// Time series data points. Points should be sorted by timestamp in ascending
        /// order to match the anomaly detection result. If the data is not sorted
        /// correctly or there is duplicated timestamp, the API will not work. In such
        /// case, an error message will be returned.
        /// </param>
        /// <param name="granularity">
        /// Optional argument, can be one of yearly, monthly, weekly, daily, hourly,
        /// minutely, secondly, microsecond or none. If granularity is not present, it will
        /// be none by default. If granularity is none, the timestamp property in time
        /// series point can be absent.
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
        /// <param name="maxAnomalyRatio"> Optional argument, advanced model parameter, max anomaly ratio in a time series. </param>
        /// <param name="sensitivity">
        /// Optional argument, advanced model parameter, between 0-99, the lower the value
        /// is, the larger the margin value will be which means less anomalies will be
        /// accepted.
        /// </param>
        /// <param name="imputeMode">
        /// Used to specify how to deal with missing values in the input series, it's used
        /// when granularity is not "none".
        /// </param>
        /// <param name="imputeFixedValue">
        /// Used to specify the value to fill, it's used when granularity is not "none"
        /// and imputeMode is "fixed".
        /// </param>
        internal UnivariateDetectionOptions(IList<TimeSeriesPoint> series, TimeGranularity? granularity, int? customInterval, int? period, float? maxAnomalyRatio, int? sensitivity, ImputeMode? imputeMode, float? imputeFixedValue)
        {
            Series = series;
            Granularity = granularity;
            CustomInterval = customInterval;
            Period = period;
            MaxAnomalyRatio = maxAnomalyRatio;
            Sensitivity = sensitivity;
            ImputeMode = imputeMode;
            ImputeFixedValue = imputeFixedValue;
        }

        /// <summary>
        /// Time series data points. Points should be sorted by timestamp in ascending
        /// order to match the anomaly detection result. If the data is not sorted
        /// correctly or there is duplicated timestamp, the API will not work. In such
        /// case, an error message will be returned.
        /// </summary>
        public IList<TimeSeriesPoint> Series { get; }
        /// <summary>
        /// Optional argument, can be one of yearly, monthly, weekly, daily, hourly,
        /// minutely, secondly, microsecond or none. If granularity is not present, it will
        /// be none by default. If granularity is none, the timestamp property in time
        /// series point can be absent.
        /// </summary>
        public TimeGranularity? Granularity { get; set; }
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
        /// <summary> Optional argument, advanced model parameter, max anomaly ratio in a time series. </summary>
        public float? MaxAnomalyRatio { get; set; }
        /// <summary>
        /// Optional argument, advanced model parameter, between 0-99, the lower the value
        /// is, the larger the margin value will be which means less anomalies will be
        /// accepted.
        /// </summary>
        public int? Sensitivity { get; set; }
        /// <summary>
        /// Used to specify how to deal with missing values in the input series, it's used
        /// when granularity is not "none".
        /// </summary>
        public ImputeMode? ImputeMode { get; set; }
        /// <summary>
        /// Used to specify the value to fill, it's used when granularity is not "none"
        /// and imputeMode is "fixed".
        /// </summary>
        public float? ImputeFixedValue { get; set; }
    }
}
