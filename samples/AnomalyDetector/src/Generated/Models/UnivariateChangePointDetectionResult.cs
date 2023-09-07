// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> The response of change point detection. </summary>
    public partial class UnivariateChangePointDetectionResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of UnivariateChangePointDetectionResult. </summary>
        internal UnivariateChangePointDetectionResult()
        {
            IsChangePoint = new ChangeTrackingList<bool>();
            ConfidenceScores = new ChangeTrackingList<float>();
        }

        /// <summary> Initializes a new instance of UnivariateChangePointDetectionResult. </summary>
        /// <param name="period">
        /// Frequency extracted from the series, zero means no recurrent pattern has been
        /// found.
        /// </param>
        /// <param name="isChangePoint">
        /// isChangePoint contains change point properties for each input point. True means
        /// an anomaly either negative or positive has been detected. The index of the
        /// array is consistent with the input series.
        /// </param>
        /// <param name="confidenceScores"> the change point confidence of each point. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnivariateChangePointDetectionResult(int? period, IReadOnlyList<bool> isChangePoint, IReadOnlyList<float> confidenceScores, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Period = period;
            IsChangePoint = isChangePoint;
            ConfidenceScores = confidenceScores;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Frequency extracted from the series, zero means no recurrent pattern has been
        /// found.
        /// </summary>
        public int? Period { get; }
        /// <summary>
        /// isChangePoint contains change point properties for each input point. True means
        /// an anomaly either negative or positive has been detected. The index of the
        /// array is consistent with the input series.
        /// </summary>
        public IReadOnlyList<bool> IsChangePoint { get; }
        /// <summary> the change point confidence of each point. </summary>
        public IReadOnlyList<float> ConfidenceScores { get; }
    }
}
