// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
    // Data plane generated sub-client.
    /// <summary> The Univariate sub-client. </summary>
    public partial class Univariate
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

        /// <summary> Initializes a new instance of Univariate for mocking. </summary>
        protected Univariate()
        {
        }

        /// <summary> Initializes a new instance of Univariate. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus2.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="apiVersion"> Api Version. Allowed values: "v1.1". </param>
        internal Univariate(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateEntireSeriesAsync(UnivariateDetectionOptions,CancellationToken)']/*" />
        public virtual async Task<Response<UnivariateEntireDetectionResult>> DetectUnivariateEntireSeriesAsync(UnivariateDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = options.ToRequestContent();
            Response response = await DetectUnivariateEntireSeriesAsync(content, context).ConfigureAwait(false);
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateEntireSeries(UnivariateDetectionOptions,CancellationToken)']/*" />
        public virtual Response<UnivariateEntireDetectionResult> DetectUnivariateEntireSeries(UnivariateDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = options.ToRequestContent();
            Response response = DetectUnivariateEntireSeries(content, context);
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateEntireSeriesAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> DetectUnivariateEntireSeriesAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Univariate.DetectUnivariateEntireSeries");
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateEntireSeries(RequestContent,RequestContext)']/*" />
        public virtual Response DetectUnivariateEntireSeries(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Univariate.DetectUnivariateEntireSeries");
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateLastPointAsync(UnivariateDetectionOptions,CancellationToken)']/*" />
        public virtual async Task<Response<UnivariateLastDetectionResult>> DetectUnivariateLastPointAsync(UnivariateDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = options.ToRequestContent();
            Response response = await DetectUnivariateLastPointAsync(content, context).ConfigureAwait(false);
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateLastPoint(UnivariateDetectionOptions,CancellationToken)']/*" />
        public virtual Response<UnivariateLastDetectionResult> DetectUnivariateLastPoint(UnivariateDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = options.ToRequestContent();
            Response response = DetectUnivariateLastPoint(content, context);
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateLastPointAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> DetectUnivariateLastPointAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Univariate.DetectUnivariateLastPoint");
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateLastPoint(RequestContent,RequestContext)']/*" />
        public virtual Response DetectUnivariateLastPoint(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Univariate.DetectUnivariateLastPoint");
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateChangePointAsync(UnivariateChangePointDetectionOptions,CancellationToken)']/*" />
        public virtual async Task<Response<UnivariateChangePointDetectionResult>> DetectUnivariateChangePointAsync(UnivariateChangePointDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = options.ToRequestContent();
            Response response = await DetectUnivariateChangePointAsync(content, context).ConfigureAwait(false);
            return Response.FromValue(UnivariateChangePointDetectionResult.FromResponse(response), response);
        }

        /// <summary> Detect change point for the entire series. </summary>
        /// <param name="options"> Method of univariate anomaly detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <remarks> Evaluate change point score of every series point. </remarks>
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateChangePoint(UnivariateChangePointDetectionOptions,CancellationToken)']/*" />
        public virtual Response<UnivariateChangePointDetectionResult> DetectUnivariateChangePoint(UnivariateChangePointDetectionOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = options.ToRequestContent();
            Response response = DetectUnivariateChangePoint(content, context);
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateChangePointAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> DetectUnivariateChangePointAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Univariate.DetectUnivariateChangePoint");
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
        /// <include file="Docs/Univariate.xml" path="doc/members/member[@name='DetectUnivariateChangePoint(RequestContent,RequestContext)']/*" />
        public virtual Response DetectUnivariateChangePoint(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Univariate.DetectUnivariateChangePoint");
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

        internal RequestUriBuilder CreateDetectUnivariateEntireSeriesRequestUri(RequestContent content, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/timeseries/entire/detect", false);
            return uri;
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

        internal RequestUriBuilder CreateDetectUnivariateLastPointRequestUri(RequestContent content, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/timeseries/last/detect", false);
            return uri;
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

        internal RequestUriBuilder CreateDetectUnivariateChangePointRequestUri(RequestContent content, RequestContext context)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/anomalydetector/", false);
            uri.AppendRaw(_apiVersion, true);
            uri.AppendPath("/timeseries/changepoint/detect", false);
            return uri;
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
