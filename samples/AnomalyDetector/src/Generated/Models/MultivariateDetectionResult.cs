// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace AnomalyDetector.Models
{
    /// <summary> Detection results for the given resultId. </summary>
    public partial class MultivariateDetectionResult
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

        /// <summary> Initializes a new instance of <see cref="MultivariateDetectionResult"/>. </summary>
        /// <param name="summary"> Multivariate anomaly detection status. </param>
        /// <param name="results"> Detection result for each timestamp. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="summary"/> or <paramref name="results"/> is null. </exception>
        internal MultivariateDetectionResult(MultivariateBatchDetectionResultSummary summary, IEnumerable<AnomalyState> results)
        {
            if (summary == null)
            {
                throw new ArgumentNullException(nameof(summary));
            }
            if (results == null)
            {
                throw new ArgumentNullException(nameof(results));
            }

            Summary = summary;
            Results = results.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="MultivariateDetectionResult"/>. </summary>
        /// <param name="resultId"> Result identifier, which is used to fetch the results of an inference call. </param>
        /// <param name="summary"> Multivariate anomaly detection status. </param>
        /// <param name="results"> Detection result for each timestamp. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MultivariateDetectionResult(Guid resultId, MultivariateBatchDetectionResultSummary summary, IReadOnlyList<AnomalyState> results, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ResultId = resultId;
            Summary = summary;
            Results = results;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MultivariateDetectionResult"/> for deserialization. </summary>
        internal MultivariateDetectionResult()
        {
        }

        /// <summary> Result identifier, which is used to fetch the results of an inference call. </summary>
        public Guid ResultId { get; }
        /// <summary> Multivariate anomaly detection status. </summary>
        public MultivariateBatchDetectionResultSummary Summary { get; }
        /// <summary> Detection result for each timestamp. </summary>
        public IReadOnlyList<AnomalyState> Results { get; }
    }
}
