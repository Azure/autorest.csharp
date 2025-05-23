import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.Core;

namespace AnomalyDetector.Univariate;

@doc("The impute mode.")
union ImputeMode {
  string,
  Auto: "auto",
  Previous: "previous",
  Linear: "linear",
  Fixed: "fixed",
  Zero: "zero",
  NotFill: "notFill",
}

enum AnomalyDetectorErrorCodes {
  "InvalidCustomInterval",
  "BadArgument",
  "InvalidGranularity",
  "InvalidPeriod",
  "InvalidModelArgument",
  "InvalidSeries",
  "InvalidJsonFormat",
  "RequiredGranularity",
  "RequiredSeries",
  "InvalidImputeMode",
  "InvalidImputeFixedValue",
}

@doc("the time granularity of the data points.")
enum TimeGranularity {
  Yearly: "yearly",
  Monthly: "monthly",
  Weekly: "weekly",
  Daily: "daily",
  Hourly: "hourly",
  PerMinute: "minutely",
  PerSecond: "secondly",
  Microsecond: "microsecond",
  None: "none",
}

@doc("The request of entire or last anomaly detection.")
model UnivariateDetectionOptions {
  @doc("""
Time series data points. Points should be sorted by timestamp in ascending
order to match the anomaly detection result. If the data is not sorted
correctly or there is duplicated timestamp, the API will not work. In such
case, an error message will be returned.
""")
  series: TimeSeriesPoint[];

  @doc("""
Optional argument, can be one of yearly, monthly, weekly, daily, hourly,
minutely, secondly, microsecond or none. If granularity is not present, it will
be none by default. If granularity is none, the timestamp property in time
series point can be absent.
""")
  granularity?: TimeGranularity;

  @doc("""
Custom Interval is used to set non-standard time interval, for example, if the
series is 5 minutes, request can be set as {\"granularity\":\"minutely\",
\"customInterval\":5}.
""")
  customInterval?: int32;

  @doc("""
Optional argument, periodic value of a time series. If the value is null or
does not present, the API will determine the period automatically.
""")
  period?: int32;

  @doc("Optional argument, advanced model parameter, max anomaly ratio in a time series.")
  maxAnomalyRatio?: float32;

  @doc("""
Optional argument, advanced model parameter, between 0-99, the lower the value
is, the larger the margin value will be which means less anomalies will be
accepted.
""")
  sensitivity?: int32;

  @doc("""
Used to specify how to deal with missing values in the input series, it's used
when granularity is not \"none\".
""")
  imputeMode?: ImputeMode;

  @doc("""
Used to specify the value to fill, it's used when granularity is not \"none\"
and imputeMode is \"fixed\".
""")
  imputeFixedValue?: float32;
}

@doc("The definition of input timeseries points.")
model TimeSeriesPoint {
  @doc("Optional argument, timestamp of a data point (ISO8601 format).")
  timestamp?: utcDateTime;

  @doc("The measurement of that point, should be float.")
  value: float32;
}

@doc("The response of entire anomaly detection.")
model UnivariateEntireDetectionResult {
  @doc("""
Frequency extracted from the series, zero means no recurrent pattern has been
found.
""")
  period: int32;

  @doc("""
ExpectedValues contain expected value for each input point. The index of the
array is consistent with the input series.
""")
  expectedValues: float32[];

  @doc("""
UpperMargins contain upper margin of each input point. UpperMargin is used to
calculate upperBoundary, which equals to expectedValue + (100 -
marginScale)*upperMargin. Anomalies in response can be filtered by
upperBoundary and lowerBoundary. By adjusting marginScale value, less
significant anomalies can be filtered in client side. The index of the array is
consistent with the input series.
""")
  upperMargins: float32[];

  @doc("""
LowerMargins contain lower margin of each input point. LowerMargin is used to
calculate lowerBoundary, which equals to expectedValue - (100 -
marginScale)*lowerMargin. Points between the boundary can be marked as normal
ones in client side. The index of the array is consistent with the input
series.
""")
  lowerMargins: float32[];

  @doc("""
IsAnomaly contains anomaly properties for each input point. True means an
anomaly either negative or positive has been detected. The index of the array
is consistent with the input series.
""")
  isAnomaly: boolean[];

  @doc("""
IsNegativeAnomaly contains anomaly status in negative direction for each input
point. True means a negative anomaly has been detected. A negative anomaly
means the point is detected as an anomaly and its real value is smaller than
the expected one. The index of the array is consistent with the input series.
""")
  isNegativeAnomaly: boolean[];

  @doc("""
IsPositiveAnomaly contain anomaly status in positive direction for each input
point. True means a positive anomaly has been detected. A positive anomaly
means the point is detected as an anomaly and its real value is larger than the
expected one. The index of the array is consistent with the input series.
""")
  isPositiveAnomaly: boolean[];

  @doc("""
The severity score for each input point. The larger the value is, the more
sever the anomaly is. For normal points, the \"severity\" is always 0.
""")
  severity?: float32[];
}

@doc("Error information returned by the API.")
@error
model AnomalyDetectorError {
  @header
  @doc("Error code.")
  "x-ms-error-code"?: string,

  @doc("The error code.")
  code?: AnomalyDetectorErrorCodes;

  @doc("A message explaining the error reported by the service.")
  message?: string;
}

@doc("The response of last anomaly detection.")
model UnivariateLastDetectionResult {
  @doc("""
Frequency extracted from the series, zero means no recurrent pattern has been
found.
""")
  period: int32;

  @doc("Suggested input series points needed for detecting the latest point.")
  suggestedWindow: int32;

  @doc("Expected value of the latest point.")
  expectedValue: float32;

  @doc("""
Upper margin of the latest point. UpperMargin is used to calculate
upperBoundary, which equals to expectedValue + (100 - marginScale)*upperMargin.
If the value of latest point is between upperBoundary and lowerBoundary, it
should be treated as normal value. By adjusting marginScale value, anomaly
status of latest point can be changed.
""")
  upperMargin: float32;

  @doc("""
Lower margin of the latest point. LowerMargin is used to calculate
lowerBoundary, which equals to expectedValue - (100 - marginScale)*lowerMargin.

""")
  lowerMargin: float32;

  @doc("""
Anomaly status of the latest point, true means the latest point is an anomaly
either in negative direction or positive direction.
""")
  isAnomaly: boolean;

  @doc("""
Anomaly status in negative direction of the latest point. True means the latest
point is an anomaly and its real value is smaller than the expected one.
""")
  isNegativeAnomaly: boolean;

  @doc("""
Anomaly status in positive direction of the latest point. True means the latest
point is an anomaly and its real value is larger than the expected one.
""")
  isPositiveAnomaly: boolean;

  @doc("""
The severity score for the last input point. The larger the value is, the more
sever the anomaly is. For normal points, the \"severity\" is always 0.
""")
  severity?: float32;
}

@doc("The request of change point detection.")
model UnivariateChangePointDetectionOptions {
  @doc("""
Time series data points. Points should be sorted by timestamp in ascending
order to match the change point detection result.
""")
  series: TimeSeriesPoint[];

  @doc("""
Can only be one of yearly, monthly, weekly, daily, hourly, minutely or
secondly. Granularity is used for verify whether input series is valid.
""")
  granularity: TimeGranularity;

  @doc("""
Custom Interval is used to set non-standard time interval, for example, if the
series is 5 minutes, request can be set as {\"granularity\":\"minutely\",
\"customInterval\":5}.
""")
  customInterval?: int32;

  @doc("""
Optional argument, periodic value of a time series. If the value is null or
does not present, the API will determine the period automatically.
""")
  period?: int32;

  @doc("""
Optional argument, advanced model parameter, a default stableTrendWindow will
be used in detection.
""")
  stableTrendWindow?: int32;

  @doc("""
Optional argument, advanced model parameter, between 0.0-1.0, the lower the
value is, the larger the trend error will be which means less change point will
be accepted.
""")
  threshold?: float32;
}

@doc("The response of change point detection.")
model UnivariateChangePointDetectionResult {
  @doc("""
Frequency extracted from the series, zero means no recurrent pattern has been
found.
""")
  @visibility(Lifecycle.Read)
  period?: int32;

  @doc("""
isChangePoint contains change point properties for each input point. True means
an anomaly either negative or positive has been detected. The index of the
array is consistent with the input series.
""")
  isChangePoint?: boolean[];

  @doc("the change point confidence of each point")
  confidenceScores?: float32[];
}
