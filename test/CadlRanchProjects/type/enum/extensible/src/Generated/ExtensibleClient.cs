// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using _Type._Enum.Extensible.Models;

namespace _Type._Enum.Extensible
{
    // Data plane generated client.
    /// <summary> The Extensible service client. </summary>
    public partial class ExtensibleClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ExtensibleClient. </summary>
        public ExtensibleClient() : this(new Uri("http://localhost:3000"), new ExtensibleClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ExtensibleClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public ExtensibleClient(Uri endpoint, ExtensibleClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ExtensibleClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='GetKnownValueAsync(CancellationToken)']/*" />
        public virtual async Task<Response<DaysOfWeekExtensibleEnum>> GetKnownValueAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetKnownValueAsync(context).ConfigureAwait(false);
            return Response.FromValue(new DaysOfWeekExtensibleEnum(response.Content.ToObjectFromJson<string>()), response);
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='GetKnownValue(CancellationToken)']/*" />
        public virtual Response<DaysOfWeekExtensibleEnum> GetKnownValue(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetKnownValue(context);
            return Response.FromValue(new DaysOfWeekExtensibleEnum(response.Content.ToObjectFromJson<string>()), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetKnownValueAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='GetKnownValueAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetKnownValueAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ExtensibleClient.GetKnownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetKnownValueRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetKnownValue(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='GetKnownValue(RequestContext)']/*" />
        public virtual Response GetKnownValue(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ExtensibleClient.GetKnownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetKnownValueRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='GetUnknownValueAsync(CancellationToken)']/*" />
        public virtual async Task<Response<DaysOfWeekExtensibleEnum>> GetUnknownValueAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetUnknownValueAsync(context).ConfigureAwait(false);
            return Response.FromValue(new DaysOfWeekExtensibleEnum(response.Content.ToObjectFromJson<string>()), response);
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='GetUnknownValue(CancellationToken)']/*" />
        public virtual Response<DaysOfWeekExtensibleEnum> GetUnknownValue(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetUnknownValue(context);
            return Response.FromValue(new DaysOfWeekExtensibleEnum(response.Content.ToObjectFromJson<string>()), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUnknownValueAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='GetUnknownValueAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetUnknownValueAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ExtensibleClient.GetUnknownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUnknownValueRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUnknownValue(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='GetUnknownValue(RequestContext)']/*" />
        public virtual Response GetUnknownValue(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("ExtensibleClient.GetUnknownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUnknownValueRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The DaysOfWeekExtensibleEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='PutKnownValueAsync(DaysOfWeekExtensibleEnum,CancellationToken)']/*" />
        public virtual async Task<Response> PutKnownValueAsync(DaysOfWeekExtensibleEnum body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PutKnownValueAsync(BinaryData.FromObjectAsJson(body.ToString()), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="body"> The DaysOfWeekExtensibleEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='PutKnownValue(DaysOfWeekExtensibleEnum,CancellationToken)']/*" />
        public virtual Response PutKnownValue(DaysOfWeekExtensibleEnum body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = PutKnownValue(BinaryData.FromObjectAsJson(body.ToString()), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PutKnownValueAsync(DaysOfWeekExtensibleEnum,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='PutKnownValueAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> PutKnownValueAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ExtensibleClient.PutKnownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutKnownValueRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PutKnownValue(DaysOfWeekExtensibleEnum,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='PutKnownValue(RequestContent,RequestContext)']/*" />
        public virtual Response PutKnownValue(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ExtensibleClient.PutKnownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutKnownValueRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The DaysOfWeekExtensibleEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='PutUnknownValueAsync(DaysOfWeekExtensibleEnum,CancellationToken)']/*" />
        public virtual async Task<Response> PutUnknownValueAsync(DaysOfWeekExtensibleEnum body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PutUnknownValueAsync(BinaryData.FromObjectAsJson(body.ToString()), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="body"> The DaysOfWeekExtensibleEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='PutUnknownValue(DaysOfWeekExtensibleEnum,CancellationToken)']/*" />
        public virtual Response PutUnknownValue(DaysOfWeekExtensibleEnum body, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = PutUnknownValue(BinaryData.FromObjectAsJson(body.ToString()), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PutUnknownValueAsync(DaysOfWeekExtensibleEnum,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='PutUnknownValueAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> PutUnknownValueAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ExtensibleClient.PutUnknownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutUnknownValueRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PutUnknownValue(DaysOfWeekExtensibleEnum,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ExtensibleClient.xml" path="doc/members/member[@name='PutUnknownValue(RequestContent,RequestContext)']/*" />
        public virtual Response PutUnknownValue(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ExtensibleClient.PutUnknownValue");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutUnknownValueRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetKnownValueRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/enum/extensible/string/known-value", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetUnknownValueRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/enum/extensible/string/unknown-value", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePutKnownValueRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/enum/extensible/string/known-value", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePutUnknownValueRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/enum/extensible/string/unknown-value", false);
            uri.AppendQuery("api-version", _apiVersion, true);
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
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
