// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary>
    /// Training result of a model including its status, errors and diagnostics
    /// information.
    /// </summary>
    public partial class ModelInfo
    {
        /// <summary> Initializes a new instance of ModelInfo. </summary>
        /// <param name="dataSource">
        /// Source link to the input data to indicate an accessible Azure storage Uri,
        /// either pointed to an Azure blob storage folder, or pointed to a CSV file in
        /// Azure blob storage based on you data schema selection.
        /// </param>
        /// <param name="startTime">
        /// A required field, indicating the start time of training data, which should be
        /// date-time of ISO 8601 format.
        /// </param>
        /// <param name="endTime">
        /// A required field, indicating the end time of training data, which should be
        /// date-time of ISO 8601 format.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dataSource"/> is null. </exception>
        public ModelInfo(string dataSource, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Argument.AssertNotNull(dataSource, nameof(dataSource));

            DataSource = dataSource;
            StartTime = startTime;
            EndTime = endTime;
            Errors = new ChangeTrackingList<ErrorResponse>();
        }

        /// <summary> Initializes a new instance of ModelInfo. </summary>
        /// <param name="dataSource">
        /// Source link to the input data to indicate an accessible Azure storage Uri,
        /// either pointed to an Azure blob storage folder, or pointed to a CSV file in
        /// Azure blob storage based on you data schema selection.
        /// </param>
        /// <param name="dataSchema">
        /// Data schema of input data source: OneTable or MultiTable. The default
        /// DataSchema is OneTable.
        /// </param>
        /// <param name="startTime">
        /// A required field, indicating the start time of training data, which should be
        /// date-time of ISO 8601 format.
        /// </param>
        /// <param name="endTime">
        /// A required field, indicating the end time of training data, which should be
        /// date-time of ISO 8601 format.
        /// </param>
        /// <param name="displayName">
        /// An optional field. The display name of the model whose maximum length is 24
        /// characters.
        /// </param>
        /// <param name="slidingWindow">
        /// An optional field, indicating how many previous timestamps will be used to
        /// detect whether the timestamp is anomaly or not.
        /// </param>
        /// <param name="alignPolicy"> An optional field, indicating the manner to align multiple variables. </param>
        /// <param name="status"> Model status. One of CREATED, RUNNING, READY, and FAILED. </param>
        /// <param name="errors"> Error messages when failed to create a model. </param>
        /// <param name="diagnosticsInfo"> Diagnostics information to help inspect the states of model or variable. </param>
        internal ModelInfo(string dataSource, DataSchema? dataSchema, DateTimeOffset startTime, DateTimeOffset endTime, string displayName, int? slidingWindow, AlignPolicy alignPolicy, ModelStatus? status, IReadOnlyList<ErrorResponse> errors, DiagnosticsInfo diagnosticsInfo)
        {
            DataSource = dataSource;
            DataSchema = dataSchema;
            StartTime = startTime;
            EndTime = endTime;
            DisplayName = displayName;
            SlidingWindow = slidingWindow;
            AlignPolicy = alignPolicy;
            Status = status;
            Errors = errors;
            DiagnosticsInfo = diagnosticsInfo;
        }

        /// <summary>
        /// Source link to the input data to indicate an accessible Azure storage Uri,
        /// either pointed to an Azure blob storage folder, or pointed to a CSV file in
        /// Azure blob storage based on you data schema selection.
        /// </summary>
        public string DataSource { get; set; }
        /// <summary>
        /// Data schema of input data source: OneTable or MultiTable. The default
        /// DataSchema is OneTable.
        /// </summary>
        public DataSchema? DataSchema { get; set; }
        /// <summary>
        /// A required field, indicating the start time of training data, which should be
        /// date-time of ISO 8601 format.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }
        /// <summary>
        /// A required field, indicating the end time of training data, which should be
        /// date-time of ISO 8601 format.
        /// </summary>
        public DateTimeOffset EndTime { get; set; }
        /// <summary>
        /// An optional field. The display name of the model whose maximum length is 24
        /// characters.
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// An optional field, indicating how many previous timestamps will be used to
        /// detect whether the timestamp is anomaly or not.
        /// </summary>
        public int? SlidingWindow { get; set; }
        /// <summary> An optional field, indicating the manner to align multiple variables. </summary>
        public AlignPolicy AlignPolicy { get; set; }
        /// <summary> Model status. One of CREATED, RUNNING, READY, and FAILED. </summary>
        public ModelStatus? Status { get; set; }
        /// <summary> Error messages when failed to create a model. </summary>
        public IReadOnlyList<ErrorResponse> Errors { get; }
        /// <summary> Diagnostics information to help inspect the states of model or variable. </summary>
        public DiagnosticsInfo DiagnosticsInfo { get; set; }
    }
}
