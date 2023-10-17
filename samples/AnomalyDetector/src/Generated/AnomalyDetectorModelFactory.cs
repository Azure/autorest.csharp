// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace AnomalyDetector.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AnomalyDetectorModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.TimeSeriesPoint"/>. </summary>
        /// <param name="timestamp"> Optional argument, timestamp of a data point (ISO8601 format). </param>
        /// <param name="value"> The measurement of that point, should be float. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.TimeSeriesPoint"/> instance for mocking. </returns>
        public static TimeSeriesPoint TimeSeriesPoint(DateTimeOffset? timestamp = null, float value = default, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new TimeSeriesPoint(timestamp, value, serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.UnivariateEntireDetectionResult"/>. </summary>
        /// <param name="period">
        /// Frequency extracted from the series, zero means no recurrent pattern has been
        /// found.
        /// </param>
        /// <param name="expectedValues">
        /// ExpectedValues contain expected value for each input point. The index of the
        /// array is consistent with the input series.
        /// </param>
        /// <param name="upperMargins">
        /// UpperMargins contain upper margin of each input point. UpperMargin is used to
        /// calculate upperBoundary, which equals to expectedValue + (100 -
        /// marginScale)*upperMargin. Anomalies in response can be filtered by
        /// upperBoundary and lowerBoundary. By adjusting marginScale value, less
        /// significant anomalies can be filtered in client side. The index of the array is
        /// consistent with the input series.
        /// </param>
        /// <param name="lowerMargins">
        /// LowerMargins contain lower margin of each input point. LowerMargin is used to
        /// calculate lowerBoundary, which equals to expectedValue - (100 -
        /// marginScale)*lowerMargin. Points between the boundary can be marked as normal
        /// ones in client side. The index of the array is consistent with the input
        /// series.
        /// </param>
        /// <param name="isAnomaly">
        /// IsAnomaly contains anomaly properties for each input point. True means an
        /// anomaly either negative or positive has been detected. The index of the array
        /// is consistent with the input series.
        /// </param>
        /// <param name="isNegativeAnomaly">
        /// IsNegativeAnomaly contains anomaly status in negative direction for each input
        /// point. True means a negative anomaly has been detected. A negative anomaly
        /// means the point is detected as an anomaly and its real value is smaller than
        /// the expected one. The index of the array is consistent with the input series.
        /// </param>
        /// <param name="isPositiveAnomaly">
        /// IsPositiveAnomaly contain anomaly status in positive direction for each input
        /// point. True means a positive anomaly has been detected. A positive anomaly
        /// means the point is detected as an anomaly and its real value is larger than the
        /// expected one. The index of the array is consistent with the input series.
        /// </param>
        /// <param name="severity">
        /// The severity score for each input point. The larger the value is, the more
        /// sever the anomaly is. For normal points, the "severity" is always 0.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.UnivariateEntireDetectionResult"/> instance for mocking. </returns>
        public static UnivariateEntireDetectionResult UnivariateEntireDetectionResult(int period = default, IEnumerable<float> expectedValues = null, IEnumerable<float> upperMargins = null, IEnumerable<float> lowerMargins = null, IEnumerable<bool> isAnomaly = null, IEnumerable<bool> isNegativeAnomaly = null, IEnumerable<bool> isPositiveAnomaly = null, IEnumerable<float> severity = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            expectedValues ??= new List<float>();
            upperMargins ??= new List<float>();
            lowerMargins ??= new List<float>();
            isAnomaly ??= new List<bool>();
            isNegativeAnomaly ??= new List<bool>();
            isPositiveAnomaly ??= new List<bool>();
            severity ??= new List<float>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new UnivariateEntireDetectionResult(period, expectedValues?.ToList(), upperMargins?.ToList(), lowerMargins?.ToList(), isAnomaly?.ToList(), isNegativeAnomaly?.ToList(), isPositiveAnomaly?.ToList(), severity?.ToList(), serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.UnivariateLastDetectionResult"/>. </summary>
        /// <param name="period">
        /// Frequency extracted from the series, zero means no recurrent pattern has been
        /// found.
        /// </param>
        /// <param name="suggestedWindow"> Suggested input series points needed for detecting the latest point. </param>
        /// <param name="expectedValue"> Expected value of the latest point. </param>
        /// <param name="upperMargin">
        /// Upper margin of the latest point. UpperMargin is used to calculate
        /// upperBoundary, which equals to expectedValue + (100 - marginScale)*upperMargin.
        /// If the value of latest point is between upperBoundary and lowerBoundary, it
        /// should be treated as normal value. By adjusting marginScale value, anomaly
        /// status of latest point can be changed.
        /// </param>
        /// <param name="lowerMargin">
        /// Lower margin of the latest point. LowerMargin is used to calculate
        /// lowerBoundary, which equals to expectedValue - (100 - marginScale)*lowerMargin.
        ///
        /// </param>
        /// <param name="isAnomaly">
        /// Anomaly status of the latest point, true means the latest point is an anomaly
        /// either in negative direction or positive direction.
        /// </param>
        /// <param name="isNegativeAnomaly">
        /// Anomaly status in negative direction of the latest point. True means the latest
        /// point is an anomaly and its real value is smaller than the expected one.
        /// </param>
        /// <param name="isPositiveAnomaly">
        /// Anomaly status in positive direction of the latest point. True means the latest
        /// point is an anomaly and its real value is larger than the expected one.
        /// </param>
        /// <param name="severity">
        /// The severity score for the last input point. The larger the value is, the more
        /// sever the anomaly is. For normal points, the "severity" is always 0.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.UnivariateLastDetectionResult"/> instance for mocking. </returns>
        public static UnivariateLastDetectionResult UnivariateLastDetectionResult(int period = default, int suggestedWindow = default, float expectedValue = default, float upperMargin = default, float lowerMargin = default, bool isAnomaly = default, bool isNegativeAnomaly = default, bool isPositiveAnomaly = default, float? severity = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new UnivariateLastDetectionResult(period, suggestedWindow, expectedValue, upperMargin, lowerMargin, isAnomaly, isNegativeAnomaly, isPositiveAnomaly, severity, serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.UnivariateChangePointDetectionOptions"/>. </summary>
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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.UnivariateChangePointDetectionOptions"/> instance for mocking. </returns>
        public static UnivariateChangePointDetectionOptions UnivariateChangePointDetectionOptions(IEnumerable<TimeSeriesPoint> series = null, TimeGranularity granularity = default, int? customInterval = null, int? period = null, int? stableTrendWindow = null, float? threshold = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            series ??= new List<TimeSeriesPoint>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new UnivariateChangePointDetectionOptions(series?.ToList(), granularity, customInterval, period, stableTrendWindow, threshold, serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.UnivariateChangePointDetectionResult"/>. </summary>
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
        /// <returns> A new <see cref="Models.UnivariateChangePointDetectionResult"/> instance for mocking. </returns>
        public static UnivariateChangePointDetectionResult UnivariateChangePointDetectionResult(int? period = null, IEnumerable<bool> isChangePoint = null, IEnumerable<float> confidenceScores = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            isChangePoint ??= new List<bool>();
            confidenceScores ??= new List<float>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new UnivariateChangePointDetectionResult(period, isChangePoint?.ToList(), confidenceScores?.ToList(), serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MultivariateDetectionResult"/>. </summary>
        /// <param name="resultId"> Result identifier, which is used to fetch the results of an inference call. </param>
        /// <param name="summary"> Multivariate anomaly detection status. </param>
        /// <param name="results"> Detection result for each timestamp. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.MultivariateDetectionResult"/> instance for mocking. </returns>
        public static MultivariateDetectionResult MultivariateDetectionResult(Guid resultId = default, MultivariateBatchDetectionResultSummary summary = null, IEnumerable<AnomalyState> results = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            results ??= new List<AnomalyState>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new MultivariateDetectionResult(resultId, summary, results?.ToList(), serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MultivariateBatchDetectionResultSummary"/>. </summary>
        /// <param name="status"> Status of detection results. One of CREATED, RUNNING, READY, and FAILED. </param>
        /// <param name="errors"> Error message when detection is failed. </param>
        /// <param name="variableStates"> Variable Status. </param>
        /// <param name="setupInfo">
        /// Detection request for batch inference. This is an asynchronous inference which
        /// will need another API to get detection results.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.MultivariateBatchDetectionResultSummary"/> instance for mocking. </returns>
        public static MultivariateBatchDetectionResultSummary MultivariateBatchDetectionResultSummary(MultivariateBatchDetectionStatus status = default, IEnumerable<ErrorResponse> errors = null, IEnumerable<VariableState> variableStates = null, MultivariateBatchDetectionOptions setupInfo = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            errors ??= new List<ErrorResponse>();
            variableStates ??= new List<VariableState>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new MultivariateBatchDetectionResultSummary(status, errors?.ToList(), variableStates?.ToList(), setupInfo, serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AnomalyState"/>. </summary>
        /// <param name="timestamp"> The timestamp for this anomaly. </param>
        /// <param name="value"> The detailed value of this anomalous timestamp. </param>
        /// <param name="errors"> Error message for the current timestamp. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.AnomalyState"/> instance for mocking. </returns>
        public static AnomalyState AnomalyState(DateTimeOffset timestamp = default, AnomalyValue value = null, IEnumerable<ErrorResponse> errors = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            errors ??= new List<ErrorResponse>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new AnomalyState(timestamp, value, errors?.ToList(), serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AnomalyValue"/>. </summary>
        /// <param name="isAnomaly"> True if an anomaly is detected at the current timestamp. </param>
        /// <param name="severity">
        /// Indicates the significance of the anomaly. The higher the severity, the more
        /// significant the anomaly is.
        /// </param>
        /// <param name="score">
        /// Raw anomaly score of severity, will help indicate the degree of abnormality as
        /// well.
        /// </param>
        /// <param name="interpretation"> Interpretation of this anomalous timestamp. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.AnomalyValue"/> instance for mocking. </returns>
        public static AnomalyValue AnomalyValue(bool isAnomaly = default, float severity = default, float score = default, IEnumerable<AnomalyInterpretation> interpretation = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            interpretation ??= new List<AnomalyInterpretation>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new AnomalyValue(isAnomaly, severity, score, interpretation?.ToList(), serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AnomalyInterpretation"/>. </summary>
        /// <param name="variable"> Variable. </param>
        /// <param name="contributionScore">
        /// This score shows the percentage contributing to the anomalous timestamp. A
        /// number between 0 and 1.
        /// </param>
        /// <param name="correlationChanges"> Correlation changes among the anomalous variables. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.AnomalyInterpretation"/> instance for mocking. </returns>
        public static AnomalyInterpretation AnomalyInterpretation(string variable = null, float? contributionScore = null, CorrelationChanges correlationChanges = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new AnomalyInterpretation(variable, contributionScore, correlationChanges, serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CorrelationChanges"/>. </summary>
        /// <param name="changedVariables"> The correlated variables that have correlation changes under an anomaly. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.CorrelationChanges"/> instance for mocking. </returns>
        public static CorrelationChanges CorrelationChanges(IEnumerable<string> changedVariables = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            changedVariables ??= new List<string>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new CorrelationChanges(changedVariables?.ToList(), serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ModelInfo"/>. </summary>
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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.ModelInfo"/> instance for mocking. </returns>
        public static ModelInfo ModelInfo(string dataSource = null, DataSchema? dataSchema = null, DateTimeOffset startTime = default, DateTimeOffset endTime = default, string displayName = null, int? slidingWindow = null, AlignPolicy alignPolicy = null, ModelStatus? status = null, IEnumerable<ErrorResponse> errors = null, DiagnosticsInfo diagnosticsInfo = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            errors ??= new List<ErrorResponse>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new ModelInfo(dataSource, dataSchema, startTime, endTime, displayName, slidingWindow, alignPolicy, status, errors?.ToList(), diagnosticsInfo, serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AnomalyDetectionModel"/>. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="createdTime"> Date and time (UTC) when the model was created. </param>
        /// <param name="lastUpdatedTime"> Date and time (UTC) when the model was last updated. </param>
        /// <param name="modelInfo">
        /// Training result of a model including its status, errors and diagnostics
        /// information.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.AnomalyDetectionModel"/> instance for mocking. </returns>
        public static AnomalyDetectionModel AnomalyDetectionModel(Guid modelId = default, DateTimeOffset createdTime = default, DateTimeOffset lastUpdatedTime = default, ModelInfo modelInfo = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new AnomalyDetectionModel(modelId, createdTime, lastUpdatedTime, modelInfo, serializedAdditionalRawData);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MultivariateLastDetectionResult"/>. </summary>
        /// <param name="variableStates"> Variable Status. </param>
        /// <param name="results"> Anomaly status and information. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.MultivariateLastDetectionResult"/> instance for mocking. </returns>
        public static MultivariateLastDetectionResult MultivariateLastDetectionResult(IEnumerable<VariableState> variableStates = null, IEnumerable<AnomalyState> results = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            variableStates ??= new List<VariableState>();
            results ??= new List<AnomalyState>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new MultivariateLastDetectionResult(variableStates?.ToList(), results?.ToList(), serializedAdditionalRawData);
        }
    }
}
