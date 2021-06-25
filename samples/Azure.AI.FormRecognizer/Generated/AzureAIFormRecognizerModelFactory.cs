// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class AzureAIFormRecognizerModelFactory
    {
        /// <summary> Initializes a new instance of ErrorInformation. </summary>
        /// <param name="code"> . </param>
        /// <param name="message"> . </param>
        /// <returns> A new <see cref="Models.ErrorInformation"/> instance for mocking. </returns>
        public static ErrorInformation ErrorInformation(string code = null, string message = null)
        {
            return new ErrorInformation(code, message);
        }

        /// <summary> Initializes a new instance of Model. </summary>
        /// <param name="modelInfo"> Basic custom model information. </param>
        /// <param name="keys"> Keys extracted by the custom model. </param>
        /// <param name="trainResult"> Custom model training result. </param>
        /// <returns> A new <see cref="Models.Model"/> instance for mocking. </returns>
        public static Model Model(ModelInfo modelInfo = null, KeysResult keys = null, TrainResult trainResult = null)
        {
            return new Model(modelInfo, keys, trainResult);
        }

        /// <summary> Initializes a new instance of ModelInfo. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="status"> Status of the model. </param>
        /// <param name="createdDateTime"> Date and time (UTC) when the model was created. </param>
        /// <param name="lastUpdatedDateTime"> Date and time (UTC) when the status was last updated. </param>
        /// <returns> A new <see cref="Models.ModelInfo"/> instance for mocking. </returns>
        public static ModelInfo ModelInfo(Guid modelId = new Guid(), ModelStatus status = new ModelStatus(), DateTimeOffset createdDateTime = new DateTimeOffset(), DateTimeOffset lastUpdatedDateTime = new DateTimeOffset())
        {
            return new ModelInfo(modelId, status, createdDateTime, lastUpdatedDateTime);
        }

        /// <summary> Initializes a new instance of KeysResult. </summary>
        /// <param name="clusters"> Object mapping clusterIds to a list of keys. </param>
        /// <returns> A new <see cref="Models.KeysResult"/> instance for mocking. </returns>
        public static KeysResult KeysResult(IReadOnlyDictionary<string, IList<string>> clusters = null)
        {
            return new KeysResult(clusters);
        }

        /// <summary> Initializes a new instance of TrainResult. </summary>
        /// <param name="trainingDocuments"> List of the documents used to train the model and any errors reported in each document. </param>
        /// <param name="fields"> List of fields used to train the model and the train operation error reported by each. </param>
        /// <param name="averageModelAccuracy"> Average accuracy. </param>
        /// <param name="errors"> Errors returned during the training operation. </param>
        /// <returns> A new <see cref="Models.TrainResult"/> instance for mocking. </returns>
        public static TrainResult TrainResult(IEnumerable<TrainingDocumentInfo> trainingDocuments = null, IEnumerable<FormFieldsReport> fields = null, float? averageModelAccuracy = null, IEnumerable<ErrorInformation> errors = null)
        {
            return new TrainResult(trainingDocuments?.ToList(), fields?.ToList(), averageModelAccuracy, errors?.ToList());
        }

        /// <summary> Initializes a new instance of TrainingDocumentInfo. </summary>
        /// <param name="documentName"> Training document name. </param>
        /// <param name="pages"> Total number of pages trained. </param>
        /// <param name="errors"> List of errors. </param>
        /// <param name="status"> Status of the training operation. </param>
        /// <returns> A new <see cref="Models.TrainingDocumentInfo"/> instance for mocking. </returns>
        public static TrainingDocumentInfo TrainingDocumentInfo(string documentName = null, int pages = new int(), IEnumerable<ErrorInformation> errors = null, TrainStatus status = new TrainStatus())
        {
            return new TrainingDocumentInfo(documentName, pages, errors?.ToList(), status);
        }

        /// <summary> Initializes a new instance of FormFieldsReport. </summary>
        /// <param name="fieldName"> Training field name. </param>
        /// <param name="accuracy"> Estimated extraction accuracy for this field. </param>
        /// <returns> A new <see cref="Models.FormFieldsReport"/> instance for mocking. </returns>
        public static FormFieldsReport FormFieldsReport(string fieldName = null, float accuracy = new float())
        {
            return new FormFieldsReport(fieldName, accuracy);
        }

        /// <summary> Initializes a new instance of AnalyzeOperationResult. </summary>
        /// <param name="status"> Operation status. </param>
        /// <param name="createdDateTime"> Date and time (UTC) when the analyze operation was submitted. </param>
        /// <param name="lastUpdatedDateTime"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="analyzeResult"> Results of the analyze operation. </param>
        /// <returns> A new <see cref="Models.AnalyzeOperationResult"/> instance for mocking. </returns>
        public static AnalyzeOperationResult AnalyzeOperationResult(OperationStatus status = new OperationStatus(), DateTimeOffset createdDateTime = new DateTimeOffset(), DateTimeOffset lastUpdatedDateTime = new DateTimeOffset(), AnalyzeResult analyzeResult = null)
        {
            return new AnalyzeOperationResult(status, createdDateTime, lastUpdatedDateTime, analyzeResult);
        }

        /// <summary> Initializes a new instance of AnalyzeResult. </summary>
        /// <param name="version"> Version of schema used for this result. </param>
        /// <param name="readResults"> Text extracted from the input. </param>
        /// <param name="pageResults"> Page-level information extracted from the input. </param>
        /// <param name="documentResults"> Document-level information extracted from the input. </param>
        /// <param name="errors"> List of errors reported during the analyze operation. </param>
        /// <returns> A new <see cref="Models.AnalyzeResult"/> instance for mocking. </returns>
        public static AnalyzeResult AnalyzeResult(string version = null, IEnumerable<ReadResult> readResults = null, IEnumerable<PageResult> pageResults = null, IEnumerable<DocumentResult> documentResults = null, IEnumerable<ErrorInformation> errors = null)
        {
            return new AnalyzeResult(version, readResults?.ToList(), pageResults?.ToList(), documentResults?.ToList(), errors?.ToList());
        }

        /// <summary> Initializes a new instance of ReadResult. </summary>
        /// <param name="page"> The 1-based page number in the input document. </param>
        /// <param name="angle"> The general orientation of the text in clockwise direction, measured in degrees between (-180, 180]. </param>
        /// <param name="width"> The width of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="height"> The height of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="unit"> The unit used by the width, height and boundingBox properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;. </param>
        /// <param name="language"> The detected language on the page overall. </param>
        /// <param name="lines"> When includeTextDetails is set to true, a list of recognized text lines. The maximum number of lines returned is 300 per page. The lines are sorted top to bottom, left to right, although in certain cases proximity is treated with higher priority. As the sorting order depends on the detected text, it may change across images and OCR version updates. Thus, business logic should be built upon the actual line location instead of order. </param>
        /// <returns> A new <see cref="Models.ReadResult"/> instance for mocking. </returns>
        public static ReadResult ReadResult(int page = new int(), float angle = new float(), float width = new float(), float height = new float(), LengthUnit unit = new LengthUnit(), Language? language = null, IEnumerable<TextLine> lines = null)
        {
            return new ReadResult(page, angle, width, height, unit, language, lines?.ToList());
        }

        /// <summary> Initializes a new instance of TextLine. </summary>
        /// <param name="text"> The text content of the line. </param>
        /// <param name="boundingBox"> Bounding box of an extracted line. </param>
        /// <param name="language"> The detected language of this line, if different from the overall page language. </param>
        /// <param name="words"> List of words in the text line. </param>
        /// <returns> A new <see cref="Models.TextLine"/> instance for mocking. </returns>
        public static TextLine TextLine(string text = null, IEnumerable<float> boundingBox = null, Language? language = null, IEnumerable<TextWord> words = null)
        {
            return new TextLine(text, boundingBox?.ToList(), language, words?.ToList());
        }

        /// <summary> Initializes a new instance of TextWord. </summary>
        /// <param name="text"> The text content of the word. </param>
        /// <param name="boundingBox"> Bounding box of an extracted word. </param>
        /// <param name="confidence"> Confidence value. </param>
        /// <returns> A new <see cref="Models.TextWord"/> instance for mocking. </returns>
        public static TextWord TextWord(string text = null, IEnumerable<float> boundingBox = null, float? confidence = null)
        {
            return new TextWord(text, boundingBox?.ToList(), confidence);
        }

        /// <summary> Initializes a new instance of PageResult. </summary>
        /// <param name="page"> Page number. </param>
        /// <param name="clusterId"> Cluster identifier. </param>
        /// <param name="keyValuePairs"> List of key-value pairs extracted from the page. </param>
        /// <param name="tables"> List of data tables extracted from the page. </param>
        /// <returns> A new <see cref="Models.PageResult"/> instance for mocking. </returns>
        public static PageResult PageResult(int page = new int(), int? clusterId = null, IEnumerable<Models.KeyValuePair> keyValuePairs = null, IEnumerable<DataTable> tables = null)
        {
            return new PageResult(page, clusterId, keyValuePairs?.ToList(), tables?.ToList());
        }

        /// <summary> Initializes a new instance of KeyValuePair. </summary>
        /// <param name="label"> A user defined label for the key/value pair entry. </param>
        /// <param name="key"> Information about the extracted key in a key-value pair. </param>
        /// <param name="value"> Information about the extracted value in a key-value pair. </param>
        /// <param name="confidence"> Confidence value. </param>
        /// <returns> A new <see cref="Models.KeyValuePair"/> instance for mocking. </returns>
        public static Models.KeyValuePair KeyValuePair(string label = null, KeyValueElement key = null, KeyValueElement value = null, float confidence = new float())
        {
            return new Models.KeyValuePair(label, key, value, confidence);
        }

        /// <summary> Initializes a new instance of KeyValueElement. </summary>
        /// <param name="text"> The text content of the key or value. </param>
        /// <param name="boundingBox"> Bounding box of the key or value. </param>
        /// <param name="elements"> When includeTextDetails is set to true, a list of references to the text elements constituting this key or value. </param>
        /// <returns> A new <see cref="Models.KeyValueElement"/> instance for mocking. </returns>
        public static KeyValueElement KeyValueElement(string text = null, IEnumerable<float> boundingBox = null, IEnumerable<string> elements = null)
        {
            return new KeyValueElement(text, boundingBox?.ToList(), elements?.ToList());
        }

        /// <summary> Initializes a new instance of DataTable. </summary>
        /// <param name="rows"> Number of rows. </param>
        /// <param name="columns"> Number of columns. </param>
        /// <param name="cells"> List of cells contained in the table. </param>
        /// <returns> A new <see cref="Models.DataTable"/> instance for mocking. </returns>
        public static DataTable DataTable(int rows = new int(), int columns = new int(), IEnumerable<DataTableCell> cells = null)
        {
            return new DataTable(rows, columns, cells?.ToList());
        }

        /// <summary> Initializes a new instance of DataTableCell. </summary>
        /// <param name="rowIndex"> Row index of the cell. </param>
        /// <param name="columnIndex"> Column index of the cell. </param>
        /// <param name="rowSpan"> Number of rows spanned by this cell. </param>
        /// <param name="columnSpan"> Number of columns spanned by this cell. </param>
        /// <param name="text"> Text content of the cell. </param>
        /// <param name="boundingBox"> Bounding box of the cell. </param>
        /// <param name="confidence"> Confidence value. </param>
        /// <param name="elements"> When includeTextDetails is set to true, a list of references to the text elements constituting this table cell. </param>
        /// <param name="isHeader"> Is the current cell a header cell?. </param>
        /// <param name="isFooter"> Is the current cell a footer cell?. </param>
        /// <returns> A new <see cref="Models.DataTableCell"/> instance for mocking. </returns>
        public static DataTableCell DataTableCell(int rowIndex = new int(), int columnIndex = new int(), int? rowSpan = null, int? columnSpan = null, string text = null, IEnumerable<float> boundingBox = null, float confidence = new float(), IEnumerable<string> elements = null, bool? isHeader = null, bool? isFooter = null)
        {
            return new DataTableCell(rowIndex, columnIndex, rowSpan, columnSpan, text, boundingBox?.ToList(), confidence, elements?.ToList(), isHeader, isFooter);
        }

        /// <summary> Initializes a new instance of DocumentResult. </summary>
        /// <param name="docType"> Document type. </param>
        /// <param name="pageRange"> First and last page number where the document is found. </param>
        /// <param name="fields"> Dictionary of named field values. </param>
        /// <returns> A new <see cref="Models.DocumentResult"/> instance for mocking. </returns>
        public static DocumentResult DocumentResult(string docType = null, IEnumerable<int> pageRange = null, IReadOnlyDictionary<string, FieldValue> fields = null)
        {
            return new DocumentResult(docType, pageRange?.ToList(), fields);
        }

        /// <summary> Initializes a new instance of FieldValue. </summary>
        /// <param name="type"> Type of field value. </param>
        /// <param name="valueString"> String value. </param>
        /// <param name="valueDate"> Date value. </param>
        /// <param name="valueTime"> Time value. </param>
        /// <param name="valuePhoneNumber"> Phone number value. </param>
        /// <param name="valueNumber"> Floating point value. </param>
        /// <param name="valueInteger"> Integer value. </param>
        /// <param name="valueArray"> Array of field values. </param>
        /// <param name="valueObject"> Dictionary of named field values. </param>
        /// <param name="text"> Text content of the extracted field. </param>
        /// <param name="boundingBox"> Bounding box of the field value, if appropriate. </param>
        /// <param name="confidence"> Confidence score. </param>
        /// <param name="elements"> When includeTextDetails is set to true, a list of references to the text elements constituting this field. </param>
        /// <param name="page"> The 1-based page number in the input document. </param>
        /// <returns> A new <see cref="Models.FieldValue"/> instance for mocking. </returns>
        public static FieldValue FieldValue(FieldValueType type = new FieldValueType(), string valueString = null, DateTimeOffset? valueDate = null, TimeSpan? valueTime = null, string valuePhoneNumber = null, float? valueNumber = null, int? valueInteger = null, IEnumerable<FieldValue> valueArray = null, IReadOnlyDictionary<string, FieldValue> valueObject = null, string text = null, IEnumerable<float> boundingBox = null, float? confidence = null, IEnumerable<string> elements = null, int? page = null)
        {
            return new FieldValue(type, valueString, valueDate, valueTime, valuePhoneNumber, valueNumber, valueInteger, valueArray?.ToList(), valueObject, text, boundingBox?.ToList(), confidence, elements?.ToList(), page);
        }

        /// <summary> Initializes a new instance of CopyOperationResult. </summary>
        /// <param name="status"> Operation status. </param>
        /// <param name="createdDateTime"> Date and time (UTC) when the copy operation was submitted. </param>
        /// <param name="lastUpdatedDateTime"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="copyResult"> Results of the copy operation. </param>
        /// <returns> A new <see cref="Models.CopyOperationResult"/> instance for mocking. </returns>
        public static CopyOperationResult CopyOperationResult(OperationStatus status = new OperationStatus(), DateTimeOffset createdDateTime = new DateTimeOffset(), DateTimeOffset lastUpdatedDateTime = new DateTimeOffset(), CopyResult copyResult = null)
        {
            return new CopyOperationResult(status, createdDateTime, lastUpdatedDateTime, copyResult);
        }

        /// <summary> Initializes a new instance of CopyResult. </summary>
        /// <param name="modelId"> Identifier of the target model. </param>
        /// <param name="errors"> Errors returned during the copy operation. </param>
        /// <returns> A new <see cref="Models.CopyResult"/> instance for mocking. </returns>
        public static CopyResult CopyResult(Guid modelId = new Guid(), IEnumerable<ErrorInformation> errors = null)
        {
            return new CopyResult(modelId, errors?.ToList());
        }

        /// <summary> Initializes a new instance of Models. </summary>
        /// <param name="summary"> Summary of all trained custom models. </param>
        /// <param name="modelList"> Collection of trained custom models. </param>
        /// <param name="nextLink"> Link to the next page of custom models. </param>
        /// <returns> A new <see cref="Models.Models"/> instance for mocking. </returns>
        public static Models.Models Models(ModelsSummary summary = null, IEnumerable<ModelInfo> modelList = null, string nextLink = null)
        {
            return new Models.Models(summary, modelList?.ToList(), nextLink);
        }

        /// <summary> Initializes a new instance of ModelsSummary. </summary>
        /// <param name="count"> Current count of trained custom models. </param>
        /// <param name="limit"> Max number of models that can be trained for this account. </param>
        /// <param name="lastUpdatedDateTime"> Date and time (UTC) when the summary was last updated. </param>
        /// <returns> A new <see cref="Models.ModelsSummary"/> instance for mocking. </returns>
        public static ModelsSummary ModelsSummary(int count = new int(), int limit = new int(), DateTimeOffset lastUpdatedDateTime = new DateTimeOffset())
        {
            return new ModelsSummary(count, limit, lastUpdatedDateTime);
        }
    }
}
