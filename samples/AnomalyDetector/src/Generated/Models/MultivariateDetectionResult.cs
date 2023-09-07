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
    /// <summary> Detection results for the given resultId. </summary>
    public partial class MultivariateDetectionResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of MultivariateDetectionResult. </summary>
        /// <param name="summary"> Multivariate anomaly detection status. </param>
        /// <param name="results"> Detection result for each timestamp. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="summary"/> or <paramref name="results"/> is null. </exception>
        internal MultivariateDetectionResult(MultivariateBatchDetectionResultSummary summary, IEnumerable<AnomalyState> results)
        {
            Argument.AssertNotNull(summary, nameof(summary));
            Argument.AssertNotNull(results, nameof(results));

            Summary = summary;
            Results = results.ToList();
        }

        /// <summary> Initializes a new instance of MultivariateDetectionResult. </summary>
        /// <param name="resultId"> Result identifier, which is used to fetch the results of an inference call. </param>
        /// <param name="summary"> Multivariate anomaly detection status. </param>
        /// <param name="results"> Detection result for each timestamp. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MultivariateDetectionResult(Guid resultId, MultivariateBatchDetectionResultSummary summary, IReadOnlyList<AnomalyState> results, Dictionary<string, BinaryData> serializedAdditionalRawData)
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
