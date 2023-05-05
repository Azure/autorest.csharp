// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using ApiVersionInCadl.Models;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace ApiVersionInCadl
{
    // Data plane generated client.
    /// <summary> CADL project to test api versions. </summary>
    public partial class ApiVersionInCadlClient
    {
        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ApiVersionInCadlClient for mocking. </summary>
        protected ApiVersionInCadlClient()
        {
        }

        /// <summary> Initializes a new instance of ApiVersionInCadlClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus2.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ApiVersionInCadlClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new ApiVersionInCadlClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ApiVersionInCadlClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus2.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ApiVersionInCadlClient(Uri endpoint, AzureKeyCredential credential, ApiVersionInCadlClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new ApiVersionInCadlClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Get Multivariate Anomaly Detection Result. </summary>
        /// <param name="resultId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resultId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resultId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// For asynchronous inference, get multivariate anomaly detection result based on
        /// resultId returned by the BatchDetectAnomaly api.
        /// </remarks>
        public virtual async Task<Response<DetectionResult>> GetBatchDetectionResultAsync(string resultId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resultId, nameof(resultId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetBatchDetectionResultAsync(resultId, context).ConfigureAwait(false);
            return Response.FromValue(DetectionResult.FromResponse(response), response);
        }

        /// <summary> Get Multivariate Anomaly Detection Result. </summary>
        /// <param name="resultId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resultId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resultId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// For asynchronous inference, get multivariate anomaly detection result based on
        /// resultId returned by the BatchDetectAnomaly api.
        /// </remarks>
        public virtual Response<DetectionResult> GetBatchDetectionResult(string resultId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resultId, nameof(resultId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetBatchDetectionResult(resultId, context);
            return Response.FromValue(DetectionResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]Get Multivariate Anomaly Detection Result
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// For asynchronous inference, get multivariate anomaly detection result based on
        /// resultId returned by the BatchDetectAnomaly api.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetBatchDetectionResultAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resultId"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resultId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resultId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ApiVersionInCadlClient.xml" path="doc/members/member[@name='GetBatchDetectionResultAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> GetBatchDetectionResultAsync(string resultId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(resultId, nameof(resultId));

            using var scope = ClientDiagnostics.CreateScope("ApiVersionInCadlClient.GetBatchDetectionResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetBatchDetectionResultRequest(resultId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]Get Multivariate Anomaly Detection Result
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// For asynchronous inference, get multivariate anomaly detection result based on
        /// resultId returned by the BatchDetectAnomaly api.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetBatchDetectionResult(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resultId"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resultId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resultId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ApiVersionInCadlClient.xml" path="doc/members/member[@name='GetBatchDetectionResult(string,RequestContext)']/*" />
        public virtual Response GetBatchDetectionResult(string resultId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(resultId, nameof(resultId));

            using var scope = ClientDiagnostics.CreateScope("ApiVersionInCadlClient.GetBatchDetectionResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetBatchDetectionResultRequest(resultId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetBatchDetectionResultRequest(string resultId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/multivariate/detect-batch/", false);
            uri.AppendPath(resultId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
