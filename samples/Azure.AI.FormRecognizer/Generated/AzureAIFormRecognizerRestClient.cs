// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.FormRecognizer
{
    internal partial class AzureAIFormRecognizerRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of AzureAIFormRecognizerRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoints (protocol and hostname, for example: https://westus2.api.cognitive.microsoft.com). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="endpoint"/> is null. </exception>
        public AzureAIFormRecognizerRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        internal HttpMessage CreateTrainCustomModelAsyncRequest(TrainRequest trainRequest)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(trainRequest);
            request.Content = content;
            return message;
        }

        /// <summary> Train Custom Model. </summary>
        /// <param name="trainRequest"> Training request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="trainRequest"/> is null. </exception>
        /// <remarks> Create and train a custom model. The request must include a source parameter that is either an externally accessible Azure storage blob container Uri (preferably a Shared Access Signature Uri) or valid path to a data folder in a locally mounted drive. When local paths are specified, they must follow the Linux/Unix path format and be an absolute path rooted to the input mount configuration setting value e.g., if '{Mounts:Input}' configuration setting value is '/input' then a valid source path would be '/input/contosodataset'. All data to be trained is expected to be under the source folder or sub folders under it. Models are trained using documents that are of the following content type - 'application/pdf', 'image/jpeg', 'image/png', 'image/tiff'. Other type of content is ignored. </remarks>
        public async Task<ResponseWithHeaders<AzureAIFormRecognizerTrainCustomModelAsyncHeaders>> TrainCustomModelAsyncAsync(TrainRequest trainRequest, CancellationToken cancellationToken = default)
        {
            if (trainRequest == null)
            {
                throw new ArgumentNullException(nameof(trainRequest));
            }

            using var message = CreateTrainCustomModelAsyncRequest(trainRequest);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AzureAIFormRecognizerTrainCustomModelAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Train Custom Model. </summary>
        /// <param name="trainRequest"> Training request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="trainRequest"/> is null. </exception>
        /// <remarks> Create and train a custom model. The request must include a source parameter that is either an externally accessible Azure storage blob container Uri (preferably a Shared Access Signature Uri) or valid path to a data folder in a locally mounted drive. When local paths are specified, they must follow the Linux/Unix path format and be an absolute path rooted to the input mount configuration setting value e.g., if '{Mounts:Input}' configuration setting value is '/input' then a valid source path would be '/input/contosodataset'. All data to be trained is expected to be under the source folder or sub folders under it. Models are trained using documents that are of the following content type - 'application/pdf', 'image/jpeg', 'image/png', 'image/tiff'. Other type of content is ignored. </remarks>
        public ResponseWithHeaders<AzureAIFormRecognizerTrainCustomModelAsyncHeaders> TrainCustomModelAsync(TrainRequest trainRequest, CancellationToken cancellationToken = default)
        {
            if (trainRequest == null)
            {
                throw new ArgumentNullException(nameof(trainRequest));
            }

            using var message = CreateTrainCustomModelAsyncRequest(trainRequest);
            _pipeline.Send(message, cancellationToken);
            var headers = new AzureAIFormRecognizerTrainCustomModelAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetCustomModelRequest(Guid modelId, bool? includeKeys)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            if (includeKeys != null)
            {
                uri.AppendQuery("includeKeys", includeKeys.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get Custom Model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="includeKeys"> Include list of extracted keys in model information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get detailed information about a custom model. </remarks>
        public async Task<Response<Model>> GetCustomModelAsync(Guid modelId, bool? includeKeys = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetCustomModelRequest(modelId, includeKeys);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Model value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Model.DeserializeModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get Custom Model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="includeKeys"> Include list of extracted keys in model information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get detailed information about a custom model. </remarks>
        public Response<Model> GetCustomModel(Guid modelId, bool? includeKeys = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetCustomModelRequest(modelId, includeKeys);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Model value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Model.DeserializeModel(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteCustomModelRequest(Guid modelId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Delete Custom Model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Mark model for deletion. Model artifacts will be permanently removed within a predetermined period. </remarks>
        public async Task<Response> DeleteCustomModelAsync(Guid modelId, CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteCustomModelRequest(modelId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete Custom Model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Mark model for deletion. Model artifacts will be permanently removed within a predetermined period. </remarks>
        public Response DeleteCustomModel(Guid modelId, CancellationToken cancellationToken = default)
        {
            using var message = CreateDeleteCustomModelRequest(modelId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAnalyzeWithCustomModelRequest(Guid modelId, Models.ContentType contentType, bool? includeTextDetails, Stream fileStream)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyze", false);
            if (includeTextDetails != null)
            {
                uri.AppendQuery("includeTextDetails", includeTextDetails.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (fileStream != null)
            {
                request.Headers.Add("Content-Type", contentType.ToSerialString());
                request.Content = RequestContent.Create(fileStream);
            }
            return message;
        }

        /// <summary> Analyze Form. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract key-value pairs, tables, and semantic values from a given document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public async Task<ResponseWithHeaders<AzureAIFormRecognizerAnalyzeWithCustomModelHeaders>> AnalyzeWithCustomModelAsync(Guid modelId, Models.ContentType contentType, bool? includeTextDetails = null, Stream fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeWithCustomModelRequest(modelId, contentType, includeTextDetails, fileStream);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AzureAIFormRecognizerAnalyzeWithCustomModelHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Analyze Form. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract key-value pairs, tables, and semantic values from a given document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public ResponseWithHeaders<AzureAIFormRecognizerAnalyzeWithCustomModelHeaders> AnalyzeWithCustomModel(Guid modelId, Models.ContentType contentType, bool? includeTextDetails = null, Stream fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeWithCustomModelRequest(modelId, contentType, includeTextDetails, fileStream);
            _pipeline.Send(message, cancellationToken);
            var headers = new AzureAIFormRecognizerAnalyzeWithCustomModelHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAnalyzeWithCustomModelRequest(Guid modelId, bool? includeTextDetails, SourcePath fileStream)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyze", false);
            if (includeTextDetails != null)
            {
                uri.AppendQuery("includeTextDetails", includeTextDetails.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (fileStream != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(fileStream);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Analyze Form. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract key-value pairs, tables, and semantic values from a given document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public async Task<ResponseWithHeaders<AzureAIFormRecognizerAnalyzeWithCustomModelHeaders>> AnalyzeWithCustomModelAsync(Guid modelId, bool? includeTextDetails = null, SourcePath fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeWithCustomModelRequest(modelId, includeTextDetails, fileStream);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AzureAIFormRecognizerAnalyzeWithCustomModelHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Analyze Form. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract key-value pairs, tables, and semantic values from a given document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public ResponseWithHeaders<AzureAIFormRecognizerAnalyzeWithCustomModelHeaders> AnalyzeWithCustomModel(Guid modelId, bool? includeTextDetails = null, SourcePath fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeWithCustomModelRequest(modelId, includeTextDetails, fileStream);
            _pipeline.Send(message, cancellationToken);
            var headers = new AzureAIFormRecognizerAnalyzeWithCustomModelHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetAnalyzeFormResultRequest(Guid modelId, Guid resultId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyzeResults/", false);
            uri.AppendPath(resultId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get Analyze Form Result. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Obtain current status and the result of the analyze form operation. </remarks>
        public async Task<Response<AnalyzeOperationResult>> GetAnalyzeFormResultAsync(Guid modelId, Guid resultId, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAnalyzeFormResultRequest(modelId, resultId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AnalyzeOperationResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get Analyze Form Result. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Obtain current status and the result of the analyze form operation. </remarks>
        public Response<AnalyzeOperationResult> GetAnalyzeFormResult(Guid modelId, Guid resultId, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAnalyzeFormResultRequest(modelId, resultId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AnalyzeOperationResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCopyCustomModelRequest(Guid modelId, CopyRequest copyRequest)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/copy", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(copyRequest);
            request.Content = content;
            return message;
        }

        /// <summary> Copy Custom Model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="copyRequest"> Copy request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="copyRequest"/> is null. </exception>
        /// <remarks> Copy custom model stored in this resource (the source) to user specified target Form Recognizer resource. </remarks>
        public async Task<ResponseWithHeaders<AzureAIFormRecognizerCopyCustomModelHeaders>> CopyCustomModelAsync(Guid modelId, CopyRequest copyRequest, CancellationToken cancellationToken = default)
        {
            if (copyRequest == null)
            {
                throw new ArgumentNullException(nameof(copyRequest));
            }

            using var message = CreateCopyCustomModelRequest(modelId, copyRequest);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AzureAIFormRecognizerCopyCustomModelHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Copy Custom Model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="copyRequest"> Copy request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="copyRequest"/> is null. </exception>
        /// <remarks> Copy custom model stored in this resource (the source) to user specified target Form Recognizer resource. </remarks>
        public ResponseWithHeaders<AzureAIFormRecognizerCopyCustomModelHeaders> CopyCustomModel(Guid modelId, CopyRequest copyRequest, CancellationToken cancellationToken = default)
        {
            if (copyRequest == null)
            {
                throw new ArgumentNullException(nameof(copyRequest));
            }

            using var message = CreateCopyCustomModelRequest(modelId, copyRequest);
            _pipeline.Send(message, cancellationToken);
            var headers = new AzureAIFormRecognizerCopyCustomModelHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetCustomModelCopyResultRequest(Guid modelId, Guid resultId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/copyResults/", false);
            uri.AppendPath(resultId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get Custom Model Copy Result. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="resultId"> Copy operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Obtain current status and the result of a custom model copy operation. </remarks>
        public async Task<Response<CopyOperationResult>> GetCustomModelCopyResultAsync(Guid modelId, Guid resultId, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetCustomModelCopyResultRequest(modelId, resultId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CopyOperationResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CopyOperationResult.DeserializeCopyOperationResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get Custom Model Copy Result. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="resultId"> Copy operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Obtain current status and the result of a custom model copy operation. </remarks>
        public Response<CopyOperationResult> GetCustomModelCopyResult(Guid modelId, Guid resultId, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetCustomModelCopyResultRequest(modelId, resultId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CopyOperationResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CopyOperationResult.DeserializeCopyOperationResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGenerateModelCopyAuthorizationRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/copyAuthorization", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Generate Copy Authorization. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Generate authorization to copy a model into the target Form Recognizer resource. </remarks>
        public async Task<ResponseWithHeaders<CopyAuthorizationResult, AzureAIFormRecognizerGenerateModelCopyAuthorizationHeaders>> GenerateModelCopyAuthorizationAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGenerateModelCopyAuthorizationRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AzureAIFormRecognizerGenerateModelCopyAuthorizationHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        CopyAuthorizationResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CopyAuthorizationResult.DeserializeCopyAuthorizationResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Generate Copy Authorization. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Generate authorization to copy a model into the target Form Recognizer resource. </remarks>
        public ResponseWithHeaders<CopyAuthorizationResult, AzureAIFormRecognizerGenerateModelCopyAuthorizationHeaders> GenerateModelCopyAuthorization(CancellationToken cancellationToken = default)
        {
            using var message = CreateGenerateModelCopyAuthorizationRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new AzureAIFormRecognizerGenerateModelCopyAuthorizationHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        CopyAuthorizationResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CopyAuthorizationResult.DeserializeCopyAuthorizationResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAnalyzeReceiptAsyncRequest(Models.ContentType contentType, bool? includeTextDetails, Stream fileStream)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/prebuilt/receipt/analyze", false);
            if (includeTextDetails != null)
            {
                uri.AppendQuery("includeTextDetails", includeTextDetails.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (fileStream != null)
            {
                request.Headers.Add("Content-Type", contentType.ToSerialString());
                request.Content = RequestContent.Create(fileStream);
            }
            return message;
        }

        /// <summary> Analyze Receipt. </summary>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract field text and semantic values from a given receipt document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public async Task<ResponseWithHeaders<AzureAIFormRecognizerAnalyzeReceiptAsyncHeaders>> AnalyzeReceiptAsyncAsync(Models.ContentType contentType, bool? includeTextDetails = null, Stream fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeReceiptAsyncRequest(contentType, includeTextDetails, fileStream);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AzureAIFormRecognizerAnalyzeReceiptAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Analyze Receipt. </summary>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract field text and semantic values from a given receipt document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public ResponseWithHeaders<AzureAIFormRecognizerAnalyzeReceiptAsyncHeaders> AnalyzeReceiptAsync(Models.ContentType contentType, bool? includeTextDetails = null, Stream fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeReceiptAsyncRequest(contentType, includeTextDetails, fileStream);
            _pipeline.Send(message, cancellationToken);
            var headers = new AzureAIFormRecognizerAnalyzeReceiptAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAnalyzeReceiptAsyncRequest(bool? includeTextDetails, SourcePath fileStream)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/prebuilt/receipt/analyze", false);
            if (includeTextDetails != null)
            {
                uri.AppendQuery("includeTextDetails", includeTextDetails.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (fileStream != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(fileStream);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Analyze Receipt. </summary>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract field text and semantic values from a given receipt document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public async Task<ResponseWithHeaders<AzureAIFormRecognizerAnalyzeReceiptAsyncHeaders>> AnalyzeReceiptAsyncAsync(bool? includeTextDetails = null, SourcePath fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeReceiptAsyncRequest(includeTextDetails, fileStream);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AzureAIFormRecognizerAnalyzeReceiptAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Analyze Receipt. </summary>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract field text and semantic values from a given receipt document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public ResponseWithHeaders<AzureAIFormRecognizerAnalyzeReceiptAsyncHeaders> AnalyzeReceiptAsync(bool? includeTextDetails = null, SourcePath fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeReceiptAsyncRequest(includeTextDetails, fileStream);
            _pipeline.Send(message, cancellationToken);
            var headers = new AzureAIFormRecognizerAnalyzeReceiptAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetAnalyzeReceiptResultRequest(Guid resultId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/prebuilt/receipt/analyzeResults/", false);
            uri.AppendPath(resultId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get Analyze Receipt Result. </summary>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Track the progress and obtain the result of the analyze receipt operation. </remarks>
        public async Task<Response<AnalyzeOperationResult>> GetAnalyzeReceiptResultAsync(Guid resultId, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAnalyzeReceiptResultRequest(resultId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AnalyzeOperationResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get Analyze Receipt Result. </summary>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Track the progress and obtain the result of the analyze receipt operation. </remarks>
        public Response<AnalyzeOperationResult> GetAnalyzeReceiptResult(Guid resultId, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAnalyzeReceiptResultRequest(resultId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AnalyzeOperationResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAnalyzeLayoutAsyncRequest(Models.ContentType contentType, Stream fileStream)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/layout/analyze", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (fileStream != null)
            {
                request.Headers.Add("Content-Type", contentType.ToSerialString());
                request.Content = RequestContent.Create(fileStream);
            }
            return message;
        }

        /// <summary> Analyze Layout. </summary>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract text and layout information from a given document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public async Task<ResponseWithHeaders<AzureAIFormRecognizerAnalyzeLayoutAsyncHeaders>> AnalyzeLayoutAsyncAsync(Models.ContentType contentType, Stream fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeLayoutAsyncRequest(contentType, fileStream);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AzureAIFormRecognizerAnalyzeLayoutAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Analyze Layout. </summary>
        /// <param name="contentType"> Upload file type. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract text and layout information from a given document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public ResponseWithHeaders<AzureAIFormRecognizerAnalyzeLayoutAsyncHeaders> AnalyzeLayoutAsync(Models.ContentType contentType, Stream fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeLayoutAsyncRequest(contentType, fileStream);
            _pipeline.Send(message, cancellationToken);
            var headers = new AzureAIFormRecognizerAnalyzeLayoutAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAnalyzeLayoutAsyncRequest(SourcePath fileStream)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/layout/analyze", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (fileStream != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(fileStream);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Analyze Layout. </summary>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract text and layout information from a given document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public async Task<ResponseWithHeaders<AzureAIFormRecognizerAnalyzeLayoutAsyncHeaders>> AnalyzeLayoutAsyncAsync(SourcePath fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeLayoutAsyncRequest(fileStream);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AzureAIFormRecognizerAnalyzeLayoutAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Analyze Layout. </summary>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Extract text and layout information from a given document. The input document must be of one of the supported content types - 'application/pdf', 'image/jpeg', 'image/png' or 'image/tiff'. Alternatively, use 'application/json' type to specify the location (Uri or local path) of the document to be analyzed. </remarks>
        public ResponseWithHeaders<AzureAIFormRecognizerAnalyzeLayoutAsyncHeaders> AnalyzeLayoutAsync(SourcePath fileStream = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateAnalyzeLayoutAsyncRequest(fileStream);
            _pipeline.Send(message, cancellationToken);
            var headers = new AzureAIFormRecognizerAnalyzeLayoutAsyncHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetAnalyzeLayoutResultRequest(Guid resultId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/layout/analyzeResults/", false);
            uri.AppendPath(resultId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get Analyze Layout Result. </summary>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Track the progress and obtain the result of the analyze layout operation. </remarks>
        public async Task<Response<AnalyzeOperationResult>> GetAnalyzeLayoutResultAsync(Guid resultId, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAnalyzeLayoutResultRequest(resultId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AnalyzeOperationResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get Analyze Layout Result. </summary>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Track the progress and obtain the result of the analyze layout operation. </remarks>
        public Response<AnalyzeOperationResult> GetAnalyzeLayoutResult(Guid resultId, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAnalyzeLayoutResultRequest(resultId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AnalyzeOperationResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListCustomModelsRequest(Enum1 op)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models", false);
            uri.AppendQuery("op", op.ToString(), true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> List Custom Models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get information about all custom models. </remarks>
        public async Task<Response<Models.Models>> ListCustomModelsAsync(Enum1 op, CancellationToken cancellationToken = default)
        {
            using var message = CreateListCustomModelsRequest(op);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Models.Models value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Models.Models.DeserializeModels(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> List Custom Models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get information about all custom models. </remarks>
        public Response<Models.Models> ListCustomModels(Enum1 op, CancellationToken cancellationToken = default)
        {
            using var message = CreateListCustomModelsRequest(op);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Models.Models value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Models.Models.DeserializeModels(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetCustomModelsRequest(Enum2 op)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models", false);
            uri.AppendQuery("op", op.ToString(), true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get Custom Models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get information about all custom models. </remarks>
        public async Task<Response<Models.Models>> GetCustomModelsAsync(Enum2 op, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetCustomModelsRequest(op);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Models.Models value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Models.Models.DeserializeModels(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get Custom Models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Get information about all custom models. </remarks>
        public Response<Models.Models> GetCustomModels(Enum2 op, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetCustomModelsRequest(op);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Models.Models value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Models.Models.DeserializeModels(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListCustomModelsNextPageRequest(string nextLink, Enum1 op)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> List Custom Models. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        /// <remarks> Get information about all custom models. </remarks>
        public async Task<Response<Models.Models>> ListCustomModelsNextPageAsync(string nextLink, Enum1 op, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateListCustomModelsNextPageRequest(nextLink, op);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Models.Models value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Models.Models.DeserializeModels(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> List Custom Models. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        /// <remarks> Get information about all custom models. </remarks>
        public Response<Models.Models> ListCustomModelsNextPage(string nextLink, Enum1 op, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateListCustomModelsNextPageRequest(nextLink, op);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Models.Models value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Models.Models.DeserializeModels(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
