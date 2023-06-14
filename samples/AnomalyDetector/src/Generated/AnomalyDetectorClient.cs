// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using AnomalyDetector.Models;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AnomalyDetector
{
    // Data plane generated client.
    /// <summary> The AnomalyDetector service client. </summary>
    public partial class AnomalyDetectorClient
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

        /// <summary> Initializes a new instance of AnomalyDetectorClient for mocking. </summary>
        protected AnomalyDetectorClient()
        {
        }

        /// <summary> Initializes a new instance of AnomalyDetectorClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus2.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public AnomalyDetectorClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new AnomalyDetectorClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AnomalyDetectorClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus2.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public AnomalyDetectorClient(Uri endpoint, AzureKeyCredential credential, AnomalyDetectorClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AnomalyDetectorClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Detect anomalies for the entire series in batch. </summary>
        /// <param name="options"> Method of univariate anomaly detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <remarks>
        /// This operation generates a model with an entire series, each point is detected
        /// with the same model. With this method, points before and after a certain point
        /// are used to determine whether it is an anomaly. The entire detection can give
        /// user an overall status of the time series.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateEntireSeriesAsync(UnivariateDetectionOptions,CancellationToken)']/*" />
        public virtual async Task<Response<UnivariateEntireDetectionResult>> DetectUnivariateEntireSeriesAsync(UnivariateDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await DetectUnivariateEntireSeriesAsync(options.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(UnivariateEntireDetectionResult.FromResponse(response), response);
        }

        /// <summary> Detect anomalies for the entire series in batch. </summary>
        /// <param name="options"> Method of univariate anomaly detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <remarks>
        /// This operation generates a model with an entire series, each point is detected
        /// with the same model. With this method, points before and after a certain point
        /// are used to determine whether it is an anomaly. The entire detection can give
        /// user an overall status of the time series.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateEntireSeries(UnivariateDetectionOptions,CancellationToken)']/*" />
        public virtual Response<UnivariateEntireDetectionResult> DetectUnivariateEntireSeries(UnivariateDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = DetectUnivariateEntireSeries(options.ToRequestContent(), context);
            return Response.FromValue(UnivariateEntireDetectionResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Detect anomalies for the entire series in batch.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectUnivariateEntireSeriesAsync(UnivariateDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateEntireSeriesAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> DetectUnivariateEntireSeriesAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectUnivariateEntireSeries");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectUnivariateEntireSeriesRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Detect anomalies for the entire series in batch.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectUnivariateEntireSeries(UnivariateDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateEntireSeries(RequestContent,RequestContext)']/*" />
        public virtual Response DetectUnivariateEntireSeries(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectUnivariateEntireSeries");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectUnivariateEntireSeriesRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Detect anomaly status of the latest point in time series. </summary>
        /// <param name="options"> Method of univariate anomaly detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <remarks>
        /// This operation generates a model using the points that you sent into the API,
        /// and based on all data to determine whether the last point is anomalous.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateLastPointAsync(UnivariateDetectionOptions,CancellationToken)']/*" />
        public virtual async Task<Response<UnivariateLastDetectionResult>> DetectUnivariateLastPointAsync(UnivariateDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await DetectUnivariateLastPointAsync(options.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(UnivariateLastDetectionResult.FromResponse(response), response);
        }

        /// <summary> Detect anomaly status of the latest point in time series. </summary>
        /// <param name="options"> Method of univariate anomaly detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <remarks>
        /// This operation generates a model using the points that you sent into the API,
        /// and based on all data to determine whether the last point is anomalous.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateLastPoint(UnivariateDetectionOptions,CancellationToken)']/*" />
        public virtual Response<UnivariateLastDetectionResult> DetectUnivariateLastPoint(UnivariateDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = DetectUnivariateLastPoint(options.ToRequestContent(), context);
            return Response.FromValue(UnivariateLastDetectionResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Detect anomaly status of the latest point in time series.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectUnivariateLastPointAsync(UnivariateDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateLastPointAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> DetectUnivariateLastPointAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectUnivariateLastPoint");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectUnivariateLastPointRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Detect anomaly status of the latest point in time series.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectUnivariateLastPoint(UnivariateDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateLastPoint(RequestContent,RequestContext)']/*" />
        public virtual Response DetectUnivariateLastPoint(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectUnivariateLastPoint");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectUnivariateLastPointRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Detect change point for the entire series. </summary>
        /// <param name="options"> Method of univariate anomaly detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <remarks> Evaluate change point score of every series point. </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateChangePointAsync(UnivariateChangePointDetectionOptions,CancellationToken)']/*" />
        public virtual async Task<Response<UnivariateChangePointDetectionResult>> DetectUnivariateChangePointAsync(UnivariateChangePointDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await DetectUnivariateChangePointAsync(options.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(UnivariateChangePointDetectionResult.FromResponse(response), response);
        }

        /// <summary> Detect change point for the entire series. </summary>
        /// <param name="options"> Method of univariate anomaly detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <remarks> Evaluate change point score of every series point. </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateChangePoint(UnivariateChangePointDetectionOptions,CancellationToken)']/*" />
        public virtual Response<UnivariateChangePointDetectionResult> DetectUnivariateChangePoint(UnivariateChangePointDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = DetectUnivariateChangePoint(options.ToRequestContent(), context);
            return Response.FromValue(UnivariateChangePointDetectionResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Detect change point for the entire series
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectUnivariateChangePointAsync(UnivariateChangePointDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateChangePointAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> DetectUnivariateChangePointAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectUnivariateChangePoint");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectUnivariateChangePointRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Detect change point for the entire series
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectUnivariateChangePoint(UnivariateChangePointDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectUnivariateChangePoint(RequestContent,RequestContext)']/*" />
        public virtual Response DetectUnivariateChangePoint(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectUnivariateChangePoint");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectUnivariateChangePointRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get Multivariate Anomaly Detection Result. </summary>
        /// <param name="resultId"> ID of a batch detection result. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// For asynchronous inference, get multivariate anomaly detection result based on
        /// resultId returned by the BatchDetectAnomaly api.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateBatchDetectionResultAsync(Guid,CancellationToken)']/*" />
        public virtual async Task<Response<MultivariateDetectionResult>> GetMultivariateBatchDetectionResultAsync(Guid resultId, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetMultivariateBatchDetectionResultAsync(resultId, context).ConfigureAwait(false);
            return Response.FromValue(MultivariateDetectionResult.FromResponse(response), response);
        }

        /// <summary> Get Multivariate Anomaly Detection Result. </summary>
        /// <param name="resultId"> ID of a batch detection result. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// For asynchronous inference, get multivariate anomaly detection result based on
        /// resultId returned by the BatchDetectAnomaly api.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateBatchDetectionResult(Guid,CancellationToken)']/*" />
        public virtual Response<MultivariateDetectionResult> GetMultivariateBatchDetectionResult(Guid resultId, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetMultivariateBatchDetectionResult(resultId, context);
            return Response.FromValue(MultivariateDetectionResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Get Multivariate Anomaly Detection Result
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetMultivariateBatchDetectionResultAsync(Guid,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resultId"> ID of a batch detection result. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateBatchDetectionResultAsync(Guid,RequestContext)']/*" />
        public virtual async Task<Response> GetMultivariateBatchDetectionResultAsync(Guid resultId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.GetMultivariateBatchDetectionResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetMultivariateBatchDetectionResultRequest(resultId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get Multivariate Anomaly Detection Result
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetMultivariateBatchDetectionResult(Guid,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resultId"> ID of a batch detection result. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateBatchDetectionResult(Guid,RequestContext)']/*" />
        public virtual Response GetMultivariateBatchDetectionResult(Guid resultId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.GetMultivariateBatchDetectionResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetMultivariateBatchDetectionResultRequest(resultId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Train a Multivariate Anomaly Detection Model. </summary>
        /// <param name="modelInfo"> Model information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelInfo"/> is null. </exception>
        /// <remarks>
        /// Create and train a multivariate anomaly detection model. The request must
        /// include a source parameter to indicate an externally accessible Azure blob
        /// storage URI.There are two types of data input: An URI pointed to an Azure blob
        /// storage folder which contains multiple CSV files, and each CSV file contains
        /// two columns, timestamp and variable. Another type of input is an URI pointed to
        /// a CSV file in Azure blob storage, which contains all the variables and a
        /// timestamp column.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='TrainMultivariateModelAsync(ModelInfo,CancellationToken)']/*" />
        public virtual async Task<Response<AnomalyDetectionModel>> TrainMultivariateModelAsync(ModelInfo modelInfo, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(modelInfo, nameof(modelInfo));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await TrainMultivariateModelAsync(modelInfo.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(AnomalyDetectionModel.FromResponse(response), response);
        }

        /// <summary> Train a Multivariate Anomaly Detection Model. </summary>
        /// <param name="modelInfo"> Model information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelInfo"/> is null. </exception>
        /// <remarks>
        /// Create and train a multivariate anomaly detection model. The request must
        /// include a source parameter to indicate an externally accessible Azure blob
        /// storage URI.There are two types of data input: An URI pointed to an Azure blob
        /// storage folder which contains multiple CSV files, and each CSV file contains
        /// two columns, timestamp and variable. Another type of input is an URI pointed to
        /// a CSV file in Azure blob storage, which contains all the variables and a
        /// timestamp column.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='TrainMultivariateModel(ModelInfo,CancellationToken)']/*" />
        public virtual Response<AnomalyDetectionModel> TrainMultivariateModel(ModelInfo modelInfo, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(modelInfo, nameof(modelInfo));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = TrainMultivariateModel(modelInfo.ToRequestContent(), context);
            return Response.FromValue(AnomalyDetectionModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Train a Multivariate Anomaly Detection Model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="TrainMultivariateModelAsync(ModelInfo,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='TrainMultivariateModelAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> TrainMultivariateModelAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.TrainMultivariateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTrainMultivariateModelRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Train a Multivariate Anomaly Detection Model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="TrainMultivariateModel(ModelInfo,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='TrainMultivariateModel(RequestContent,RequestContext)']/*" />
        public virtual Response TrainMultivariateModel(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.TrainMultivariateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTrainMultivariateModelRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Delete Multivariate Model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DeleteMultivariateModelAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> DeleteMultivariateModelAsync(string modelId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DeleteMultivariateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteMultivariateModelRequest(modelId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Delete Multivariate Model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DeleteMultivariateModel(string,RequestContext)']/*" />
        public virtual Response DeleteMultivariateModel(string modelId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DeleteMultivariateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteMultivariateModelRequest(modelId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get Multivariate Model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// Get detailed information of multivariate model, including the training status
        /// and variables used in the model.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateModelAsync(string,CancellationToken)']/*" />
        public virtual async Task<Response<AnomalyDetectionModel>> GetMultivariateModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetMultivariateModelAsync(modelId, context).ConfigureAwait(false);
            return Response.FromValue(AnomalyDetectionModel.FromResponse(response), response);
        }

        /// <summary> Get Multivariate Model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// Get detailed information of multivariate model, including the training status
        /// and variables used in the model.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateModel(string,CancellationToken)']/*" />
        public virtual Response<AnomalyDetectionModel> GetMultivariateModel(string modelId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetMultivariateModel(modelId, context);
            return Response.FromValue(AnomalyDetectionModel.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Get Multivariate Model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetMultivariateModelAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateModelAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> GetMultivariateModelAsync(string modelId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.GetMultivariateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetMultivariateModelRequest(modelId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get Multivariate Model
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetMultivariateModel(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateModel(string,RequestContext)']/*" />
        public virtual Response GetMultivariateModel(string modelId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.GetMultivariateModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetMultivariateModelRequest(modelId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Detect Multivariate Anomaly. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="options"> Request of multivariate anomaly detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="options"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// Submit multivariate anomaly detection task with the modelId of trained model
        /// and inference data, the input schema should be the same with the training
        /// request. The request will complete asynchronously and return a resultId to
        /// query the detection result.The request should be a source link to indicate an
        /// externally accessible Azure storage Uri, either pointed to an Azure blob
        /// storage folder, or pointed to a CSV file in Azure blob storage.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectMultivariateBatchAnomalyAsync(string,MultivariateBatchDetectionOptions,CancellationToken)']/*" />
        public virtual async Task<Response<MultivariateDetectionResult>> DetectMultivariateBatchAnomalyAsync(string modelId, MultivariateBatchDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await DetectMultivariateBatchAnomalyAsync(modelId, options.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(MultivariateDetectionResult.FromResponse(response), response);
        }

        /// <summary> Detect Multivariate Anomaly. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="options"> Request of multivariate anomaly detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="options"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// Submit multivariate anomaly detection task with the modelId of trained model
        /// and inference data, the input schema should be the same with the training
        /// request. The request will complete asynchronously and return a resultId to
        /// query the detection result.The request should be a source link to indicate an
        /// externally accessible Azure storage Uri, either pointed to an Azure blob
        /// storage folder, or pointed to a CSV file in Azure blob storage.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectMultivariateBatchAnomaly(string,MultivariateBatchDetectionOptions,CancellationToken)']/*" />
        public virtual Response<MultivariateDetectionResult> DetectMultivariateBatchAnomaly(string modelId, MultivariateBatchDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = DetectMultivariateBatchAnomaly(modelId, options.ToRequestContent(), context);
            return Response.FromValue(MultivariateDetectionResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Detect Multivariate Anomaly
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectMultivariateBatchAnomalyAsync(string,MultivariateBatchDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectMultivariateBatchAnomalyAsync(string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> DetectMultivariateBatchAnomalyAsync(string modelId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectMultivariateBatchAnomaly");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectMultivariateBatchAnomalyRequest(modelId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Detect Multivariate Anomaly
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectMultivariateBatchAnomaly(string,MultivariateBatchDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectMultivariateBatchAnomaly(string,RequestContent,RequestContext)']/*" />
        public virtual Response DetectMultivariateBatchAnomaly(string modelId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectMultivariateBatchAnomaly");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectMultivariateBatchAnomalyRequest(modelId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Detect anomalies in the last point of the request body. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="options"> Request of last detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="options"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// Submit multivariate anomaly detection task with the modelId of trained model
        /// and inference data, and the inference data should be put into request body in a
        /// JSON format. The request will complete synchronously and return the detection
        /// immediately in the response body.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectMultivariateLastAnomalyAsync(string,MultivariateLastDetectionOptions,CancellationToken)']/*" />
        public virtual async Task<Response<MultivariateLastDetectionResult>> DetectMultivariateLastAnomalyAsync(string modelId, MultivariateLastDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await DetectMultivariateLastAnomalyAsync(modelId, options.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(MultivariateLastDetectionResult.FromResponse(response), response);
        }

        /// <summary> Detect anomalies in the last point of the request body. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="options"> Request of last detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="options"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// Submit multivariate anomaly detection task with the modelId of trained model
        /// and inference data, and the inference data should be put into request body in a
        /// JSON format. The request will complete synchronously and return the detection
        /// immediately in the response body.
        /// </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectMultivariateLastAnomaly(string,MultivariateLastDetectionOptions,CancellationToken)']/*" />
        public virtual Response<MultivariateLastDetectionResult> DetectMultivariateLastAnomaly(string modelId, MultivariateLastDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = DetectMultivariateLastAnomaly(modelId, options.ToRequestContent(), context);
            return Response.FromValue(MultivariateLastDetectionResult.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Detect anomalies in the last point of the request body
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectMultivariateLastAnomalyAsync(string,MultivariateLastDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectMultivariateLastAnomalyAsync(string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> DetectMultivariateLastAnomalyAsync(string modelId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectMultivariateLastAnomaly");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectMultivariateLastAnomalyRequest(modelId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Detect anomalies in the last point of the request body
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DetectMultivariateLastAnomaly(string,MultivariateLastDetectionOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='DetectMultivariateLastAnomaly(string,RequestContent,RequestContext)']/*" />
        public virtual Response DetectMultivariateLastAnomaly(string modelId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AnomalyDetectorClient.DetectMultivariateLastAnomaly");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDetectMultivariateLastAnomalyRequest(modelId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List Multivariate Models. </summary>
        /// <param name="skip"> Skip indicates how many models will be skipped. </param>
        /// <param name="maxCount"> Top indicates how many models will be fetched. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> List models of a resource. </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateModelsAsync(int?,int?,CancellationToken)']/*" />
        public virtual AsyncPageable<AnomalyDetectionModel> GetMultivariateModelsAsync(int? skip = null, int? maxCount = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultivariateModelsRequest(skip, maxCount, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultivariateModelsNextPageRequest(nextLink, skip, maxCount, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, AnomalyDetectionModel.DeserializeAnomalyDetectionModel, ClientDiagnostics, _pipeline, "AnomalyDetectorClient.GetMultivariateModels", "models", "nextLink", context);
        }

        /// <summary> List Multivariate Models. </summary>
        /// <param name="skip"> Skip indicates how many models will be skipped. </param>
        /// <param name="maxCount"> Top indicates how many models will be fetched. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> List models of a resource. </remarks>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateModels(int?,int?,CancellationToken)']/*" />
        public virtual Pageable<AnomalyDetectionModel> GetMultivariateModels(int? skip = null, int? maxCount = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultivariateModelsRequest(skip, maxCount, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultivariateModelsNextPageRequest(nextLink, skip, maxCount, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, AnomalyDetectionModel.DeserializeAnomalyDetectionModel, ClientDiagnostics, _pipeline, "AnomalyDetectorClient.GetMultivariateModels", "models", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] List Multivariate Models
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetMultivariateModelsAsync(int?,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Skip indicates how many models will be skipped. </param>
        /// <param name="maxCount"> Top indicates how many models will be fetched. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateModelsAsync(int?,int?,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetMultivariateModelsAsync(int? skip, int? maxCount, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultivariateModelsRequest(skip, maxCount, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultivariateModelsNextPageRequest(nextLink, skip, maxCount, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AnomalyDetectorClient.GetMultivariateModels", "models", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] List Multivariate Models
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetMultivariateModels(int?,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skip"> Skip indicates how many models will be skipped. </param>
        /// <param name="maxCount"> Top indicates how many models will be fetched. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AnomalyDetectorClient.xml" path="doc/members/member[@name='GetMultivariateModels(int?,int?,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetMultivariateModels(int? skip, int? maxCount, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetMultivariateModelsRequest(skip, maxCount, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetMultivariateModelsNextPageRequest(nextLink, skip, maxCount, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AnomalyDetectorClient.GetMultivariateModels", "models", "nextLink", context);
        }

        internal HttpMessage CreateDetectUnivariateEntireSeriesRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/timeseries/entire/detect", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDetectUnivariateLastPointRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/timeseries/last/detect", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDetectUnivariateChangePointRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/timeseries/changepoint/detect", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetMultivariateBatchDetectionResultRequest(Guid resultId, RequestContext context)
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

        internal HttpMessage CreateTrainMultivariateModelRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier201);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/multivariate/models", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetMultivariateModelsRequest(int? skip, int? maxCount, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/multivariate/models", false);
            if (skip != null)
            {
                uri.AppendQuery("skip", skip.Value, true);
            }
            if (maxCount != null)
            {
                uri.AppendQuery("top", maxCount.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDeleteMultivariateModelRequest(string modelId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/multivariate/models/", false);
            uri.AppendPath(modelId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetMultivariateModelRequest(string modelId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/multivariate/models/", false);
            uri.AppendPath(modelId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDetectMultivariateBatchAnomalyRequest(string modelId, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/multivariate/models/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath(":detect-batch", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDetectMultivariateLastAnomalyRequest(string modelId, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/multivariate/models/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath(":detect-last", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetMultivariateModelsNextPageRequest(string nextLink, int? skip, int? maxCount, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendRawNextLink(nextLink, false);
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
        private static ResponseClassifier _responseClassifier201;
        private static ResponseClassifier ResponseClassifier201 => _responseClassifier201 ??= new StatusCodeClassifier(stackalloc ushort[] { 201 });
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
        private static ResponseClassifier _responseClassifier202;
        private static ResponseClassifier ResponseClassifier202 => _responseClassifier202 ??= new StatusCodeClassifier(stackalloc ushort[] { 202 });
    }
}
