// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary>
    /// Detection request for batch inference. This is an asynchronous inference which
    /// will need another API to get detection results.
    /// </summary>
    public partial class MultivariateBatchDetectionOptions
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of MultivariateBatchDetectionOptions. </summary>
        /// <param name="dataSource">
        /// Source link to the input data to indicate an accessible Azure storage Uri,
        /// either pointed to an Azure blob storage folder, or pointed to a CSV file in
        /// Azure blob storage based on you data schema selection. The data schema should
        /// be exactly the same with those used in the training phase.
        /// </param>
        /// <param name="topContributorCount">
        /// An optional field, which is used to specify the number of top contributed
        /// variables for one anomalous timestamp in the response. The default number is
        /// 10.
        /// </param>
        /// <param name="startTime">
        /// A required field, indicating the start time of data for detection, which should
        /// be date-time of ISO 8601 format.
        /// </param>
        /// <param name="endTime">
        /// A required field, indicating the end time of data for detection, which should
        /// be date-time of ISO 8601 format.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dataSource"/> is null. </exception>
        public MultivariateBatchDetectionOptions(Uri dataSource, int topContributorCount, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Argument.AssertNotNull(dataSource, nameof(dataSource));

            DataSource = dataSource;
            TopContributorCount = topContributorCount;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary> Initializes a new instance of MultivariateBatchDetectionOptions. </summary>
        /// <param name="dataSource">
        /// Source link to the input data to indicate an accessible Azure storage Uri,
        /// either pointed to an Azure blob storage folder, or pointed to a CSV file in
        /// Azure blob storage based on you data schema selection. The data schema should
        /// be exactly the same with those used in the training phase.
        /// </param>
        /// <param name="topContributorCount">
        /// An optional field, which is used to specify the number of top contributed
        /// variables for one anomalous timestamp in the response. The default number is
        /// 10.
        /// </param>
        /// <param name="startTime">
        /// A required field, indicating the start time of data for detection, which should
        /// be date-time of ISO 8601 format.
        /// </param>
        /// <param name="endTime">
        /// A required field, indicating the end time of data for detection, which should
        /// be date-time of ISO 8601 format.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MultivariateBatchDetectionOptions(Uri dataSource, int topContributorCount, DateTimeOffset startTime, DateTimeOffset endTime, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            DataSource = dataSource;
            TopContributorCount = topContributorCount;
            StartTime = startTime;
            EndTime = endTime;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MultivariateBatchDetectionOptions"/> for deserialization. </summary>
        internal MultivariateBatchDetectionOptions()
        {
        }

        /// <summary>
        /// Source link to the input data to indicate an accessible Azure storage Uri,
        /// either pointed to an Azure blob storage folder, or pointed to a CSV file in
        /// Azure blob storage based on you data schema selection. The data schema should
        /// be exactly the same with those used in the training phase.
        /// </summary>
        public Uri DataSource { get; set; }
        /// <summary>
        /// An optional field, which is used to specify the number of top contributed
        /// variables for one anomalous timestamp in the response. The default number is
        /// 10.
        /// </summary>
        public int TopContributorCount { get; set; }
        /// <summary>
        /// A required field, indicating the start time of data for detection, which should
        /// be date-time of ISO 8601 format.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }
        /// <summary>
        /// A required field, indicating the end time of data for detection, which should
        /// be date-time of ISO 8601 format.
        /// </summary>
        public DateTimeOffset EndTime { get; set; }
    }
}
