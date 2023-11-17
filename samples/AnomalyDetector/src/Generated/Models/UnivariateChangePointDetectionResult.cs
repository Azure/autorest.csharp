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
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="UnivariateChangePointDetectionResult"/>. </summary>
        internal UnivariateChangePointDetectionResult()
        {
            IsChangePoint = new ChangeTrackingList<bool>();
            ConfidenceScores = new ChangeTrackingList<float>();
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="UnivariateChangePointDetectionResult"/>. </summary>
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
        internal UnivariateChangePointDetectionResult(int? period, IReadOnlyList<bool> isChangePoint, IReadOnlyList<float> confidenceScores, IDictionary<string, BinaryData> serializedAdditionalRawData)
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
