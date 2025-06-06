import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.Core;

namespace AnomalyDetector.Multivariate;

@doc("An optional field, indicating how missing values will be filled. One of Previous, Subsequent, Linear, Zero, Fixed.")
union FillNAMethod {
  string,
  "Previous",
  "Subsequent",
  "Linear",
  "Zero",
  "Fixed",
}

@doc("The batch detection status.")
enum MultivariateBatchDetectionStatus {
  Created: "CREATED",
  Running: "RUNNING",
  Ready: "READY",
  Failed: "FAILED",
}

@doc("Data schema of input data source: OneTable or MultiTable. The default DataSchema is OneTable.")
union DataSchema {
  string,
  @doc("OneTable means that your input data are all in one CSV file, which contains one 'timestamp' column and several variable columns. The default DataSchema is OneTable.")
  "OneTable",
  @doc("MultiTable means that your input data are separated in multiple CSV files, in each file containing one 'timestamp' column and one 'variable' column, and the CSV file name should indicate the name of the variable. The default DataSchema is OneTable.")
  "MultiTable",
}

@doc("The alignment mode.")
enum AlignMode {
  "Inner",
  "Outer",
}

@doc("the model status.")
enum ModelStatus {
  Created: "CREATED",
  Running: "RUNNING",
  Ready: "READY",
  Failed: "FAILED",
}

@doc("Detection results for the given resultId.")
@resource("multivariate/detect-batch")
model MultivariateDetectionResult {
  @doc("Result identifier, which is used to fetch the results of an inference call.")
  @key
  @visibility(Lifecycle.Read)
  resultId: uuid;

  @doc("Multivariate anomaly detection status.")
  summary: MultivariateBatchDetectionResultSummary;

  @doc("Detection result for each timestamp.")
  results: AnomalyState[];
}

@doc("Multivariate anomaly detection status.")
model MultivariateBatchDetectionResultSummary {
  @doc("Status of detection results. One of CREATED, RUNNING, READY, and FAILED.")
  status: MultivariateBatchDetectionStatus;

  @doc("Error message when detection is failed.")
  errors?: ErrorResponse[];
  @doc("Variable Status.")
  variableStates?: VariableState[];

  @doc("""
Detection request for batch inference. This is an asynchronous inference which
will need another API to get detection results.
""")
  setupInfo: MultivariateBatchDetectionOptions;
}

@doc("ErrorResponse contains code and message that shows the error information.")
@error
model ErrorResponse {

  @doc("The error code.")
  code: string;

  @doc("The message explaining the error reported by the service.")
  message: string;
}

@doc("Variable Status.")
model VariableState {
  @doc("Variable name in variable states.")
  variable?: string;

  @doc("Proportion of missing values that need to be filled by fillNAMethod.")
  @minValue(0.0)
  @maxValue(1.0)
  filledNARatio?: float32;

  @doc("Number of effective data points before applying fillNAMethod.")
  effectiveCount?: int32;

  @doc("First valid timestamp with value of input data.")
  firstTimestamp?: utcDateTime;

  @doc("Last valid timestamp with value of input data.")
  lastTimestamp?: utcDateTime;
}

@doc("""
Detection request for batch inference. This is an asynchronous inference which
will need another API to get detection results.
""")
model MultivariateBatchDetectionOptions {
  @doc("""
Source link to the input data to indicate an accessible Azure storage Uri,
either pointed to an Azure blob storage folder, or pointed to a CSV file in
Azure blob storage based on you data schema selection. The data schema should
be exactly the same with those used in the training phase.
""")
  dataSource: url;

  @doc("""
An optional field, which is used to specify the number of top contributed
variables for one anomalous timestamp in the response. The default number is
10.
""")
  topContributorCount: int32;

  @doc("""
A required field, indicating the start time of data for detection, which should
be date-time of ISO 8601 format.
""")
  startTime: utcDateTime;

  @doc("""
A required field, indicating the end time of data for detection, which should
be date-time of ISO 8601 format.
""")
  endTime: utcDateTime;
}

@doc("Anomaly status and information.")
model AnomalyState {
  @doc("The timestamp for this anomaly.")
  timestamp: utcDateTime;
  @doc("The detailed value of this anomalous timestamp.")
  value?: AnomalyValue;

  @doc("Error message for the current timestamp.")
  errors?: ErrorResponse[];
}

@doc("Detailed information of the anomalous timestamp.")
model AnomalyValue {
  @doc("True if an anomaly is detected at the current timestamp.")
  isAnomaly: boolean;

  @doc("""
Indicates the significance of the anomaly. The higher the severity, the more
significant the anomaly is.
""")
  @minValue(0.0)
  @maxValue(1.0)
  severity: float32;

  @doc("""
Raw anomaly score of severity, will help indicate the degree of abnormality as
well.
""")
  @minValue(0.0)
  @maxValue(2.0)
  score: float32;
  @doc("Interpretation of this anomalous timestamp.")
  interpretation?: AnomalyInterpretation[];
}

@doc("Interpretation of the anomalous timestamp.")
model AnomalyInterpretation {
  @doc("Variable.")
  variable?: string;

  @doc("""
This score shows the percentage contributing to the anomalous timestamp. A
number between 0 and 1.
""")
  contributionScore?: float32;
  @doc("Correlation changes among the anomalous variables")
  correlationChanges?: CorrelationChanges;
}

@doc("Correlation changes among the anomalous variables")
model CorrelationChanges {
  @doc("The correlated variables that have correlation changes under an anomaly.")
  changedVariables?: string[];
}

@doc("""
Training result of a model including its status, errors and diagnostics
information.
""")
model ModelInfo {
  @doc("""
Source link to the input data to indicate an accessible Azure storage Uri,
either pointed to an Azure blob storage folder, or pointed to a CSV file in
Azure blob storage based on you data schema selection. 
""")
  dataSource: string;

  @doc("""
Data schema of input data source: OneTable or MultiTable. The default
DataSchema is OneTable.
""")
  dataSchema?: DataSchema;

  @doc("""
A required field, indicating the start time of training data, which should be
date-time of ISO 8601 format.
""")
  startTime: utcDateTime;

  @doc("""
A required field, indicating the end time of training data, which should be
date-time of ISO 8601 format.
""")
  endTime: utcDateTime;

  @doc("""
An optional field. The display name of the model whose maximum length is 24
characters.
""")
  @maxLength(24)
  displayName?: string;

  @doc("""
An optional field, indicating how many previous timestamps will be used to
detect whether the timestamp is anomaly or not. 
""")
  slidingWindow?: int32;

  @doc("An optional field, indicating the manner to align multiple variables.")
  alignPolicy?: AlignPolicy;

  @doc("Model status. One of CREATED, RUNNING, READY, and FAILED.")
  status?: ModelStatus;

  @visibility(Lifecycle.Read)
  @doc("Error messages when failed to create a model.")
  errors?: ErrorResponse[];

  @doc("Diagnostics information to help inspect the states of model or variable.")
  diagnosticsInfo?: DiagnosticsInfo;
}

@doc("An optional field, indicating the manner to align multiple variables.")
model AlignPolicy {
  @doc("""
An optional field, indicating how to align different variables to the same
time-range. Either Inner or Outer. 
""")
  alignMode?: AlignMode;

  @doc("""
An optional field, indicating how missing values will be filled. One of
Previous, Subsequent, Linear, Zero, Fixed.
""")
  fillNAMethod?: FillNAMethod;

  @doc("An optional field. Required when fillNAMethod is Fixed.")
  paddingValue?: float32;
}

@doc("Diagnostics information to help inspect the states of model or variable.")
model DiagnosticsInfo {
  @doc("Model status.")
  modelState?: ModelState;
  @doc("Variable Status.")
  variableStates?: VariableState[];
}

@doc("Model status.")
model ModelState {
  @doc("""
This indicates the number of passes of the entire training dataset the
algorithm has completed.
""")
  epochIds?: int32[];

  @doc("""
List of metrics used to assess how the model fits the training data for each
epoch.
""")
  trainLosses?: float32[];

  @doc("""
List of metrics used to assess how the model fits the validation set for each
epoch.
""")
  validationLosses?: float32[];

  @doc("Latency for each epoch. ")
  latenciesInSeconds?: float32[];
}

@doc("Response of getting a model.")
@resource("multivariate/models")
model AnomalyDetectionModel {
  @doc("Model identifier.")
  @key
  @visibility(Lifecycle.Read)
  modelId: uuid;

  @doc("Date and time (UTC) when the model was created.")
  createdTime: utcDateTime;

  @doc("Date and time (UTC) when the model was last updated.")
  lastUpdatedTime: utcDateTime;

  @doc("""
Training result of a model including its status, errors and diagnostics
information.
""")
  modelInfo?: ModelInfo;
}

@doc("Response of listing models.")
@pagedResult
model ModelList {
  @doc("List of models.")
  @items
  models: AnomalyDetectionModel[];

  @doc("Number of trained multivariate models.")
  currentCount: int32;

  @doc("Maximum number of models that can be trained for this Anomaly Detector resource.")
  maxCount: int32;

  @doc("The link to fetch more models.")
  @nextLink
  nextLink?: string;
}

@doc("Request of last detection.")
model MultivariateLastDetectionOptions {
  @doc("""
This contains the inference data, including the name, timestamps(ISO 8601) and
values of variables.
""")
  variables: VariableValues[];

  @doc("""
An optional field, which is used to specify the number of top contributed
variables for one anomalous timestamp in the response. The default number is
10.
""")
  topContributorCount: int32;
}

@doc("Variable values.")
model VariableValues {
  @doc("Variable name of last detection request.")
  variable: string;

  @doc("Timestamps of last detection request")
  timestamps: string[];

  @doc("Values of variables.")
  values: float32[];
}


@doc("Results of last detection.")
model MultivariateLastDetectionResult {
  @doc("Variable Status.")
  variableStates?: VariableState[];
  @doc("Anomaly status and information.")
  results?: AnomalyState[];
}

@doc("Error response")
@error
model ResponseError {
  @header
  @doc("Error code.")
  "x-ms-error-code"?: string,
  ...ErrorResponse
}
