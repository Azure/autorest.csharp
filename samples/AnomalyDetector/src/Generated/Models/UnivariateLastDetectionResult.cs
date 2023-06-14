// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace AnomalyDetector.Models
{
    /// <summary> The response of last anomaly detection. </summary>
    public partial class UnivariateLastDetectionResult
    {
        /// <summary> Initializes a new instance of UnivariateLastDetectionResult. </summary>
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
        internal UnivariateLastDetectionResult(int period, int suggestedWindow, float expectedValue, float upperMargin, float lowerMargin, bool isAnomaly, bool isNegativeAnomaly, bool isPositiveAnomaly)
        {
            Period = period;
            SuggestedWindow = suggestedWindow;
            ExpectedValue = expectedValue;
            UpperMargin = upperMargin;
            LowerMargin = lowerMargin;
            IsAnomaly = isAnomaly;
            IsNegativeAnomaly = isNegativeAnomaly;
            IsPositiveAnomaly = isPositiveAnomaly;
        }

        /// <summary> Initializes a new instance of UnivariateLastDetectionResult. </summary>
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
        internal UnivariateLastDetectionResult(int period, int suggestedWindow, float expectedValue, float upperMargin, float lowerMargin, bool isAnomaly, bool isNegativeAnomaly, bool isPositiveAnomaly, float? severity)
        {
            Period = period;
            SuggestedWindow = suggestedWindow;
            ExpectedValue = expectedValue;
            UpperMargin = upperMargin;
            LowerMargin = lowerMargin;
            IsAnomaly = isAnomaly;
            IsNegativeAnomaly = isNegativeAnomaly;
            IsPositiveAnomaly = isPositiveAnomaly;
            Severity = severity;
        }

        /// <summary>
        /// Frequency extracted from the series, zero means no recurrent pattern has been
        /// found.
        /// </summary>
        public int Period { get; }
        /// <summary> Suggested input series points needed for detecting the latest point. </summary>
        public int SuggestedWindow { get; }
        /// <summary> Expected value of the latest point. </summary>
        public float ExpectedValue { get; }
        /// <summary>
        /// Upper margin of the latest point. UpperMargin is used to calculate
        /// upperBoundary, which equals to expectedValue + (100 - marginScale)*upperMargin.
        /// If the value of latest point is between upperBoundary and lowerBoundary, it
        /// should be treated as normal value. By adjusting marginScale value, anomaly
        /// status of latest point can be changed.
        /// </summary>
        public float UpperMargin { get; }
        /// <summary>
        /// Lower margin of the latest point. LowerMargin is used to calculate
        /// lowerBoundary, which equals to expectedValue - (100 - marginScale)*lowerMargin.
        ///
        /// </summary>
        public float LowerMargin { get; }
        /// <summary>
        /// Anomaly status of the latest point, true means the latest point is an anomaly
        /// either in negative direction or positive direction.
        /// </summary>
        public bool IsAnomaly { get; }
        /// <summary>
        /// Anomaly status in negative direction of the latest point. True means the latest
        /// point is an anomaly and its real value is smaller than the expected one.
        /// </summary>
        public bool IsNegativeAnomaly { get; }
        /// <summary>
        /// Anomaly status in positive direction of the latest point. True means the latest
        /// point is an anomaly and its real value is larger than the expected one.
        /// </summary>
        public bool IsPositiveAnomaly { get; }
        /// <summary>
        /// The severity score for the last input point. The larger the value is, the more
        /// sever the anomaly is. For normal points, the "severity" is always 0.
        /// </summary>
        public float? Severity { get; }
    }
}
