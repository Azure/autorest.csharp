// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace _Type._Dictionary
{
    // Data plane generated sub-client.
    /// <summary> Dictionary of int32 values. </summary>
    public partial class Int32Value
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Int32Value for mocking. </summary>
        protected Int32Value()
        {
        }

        /// <summary> Initializes a new instance of Int32Value. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="apiVersion"> The String to use. </param>
        internal Int32Value(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Int32Value.xml" path="doc/members/member[@name='GetInt32ValueAsync(CancellationToken)']/*" />
        public virtual async Task<Response<IReadOnlyDictionary<string, int>>> GetInt32ValueAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetInt32ValueAsync(context).ConfigureAwait(false);
            IReadOnlyDictionary<string, int> value = default;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var property in document.RootElement.EnumerateObject())
            {
                dictionary.Add(property.Name, property.Value.GetInt32());
            }
            value = dictionary;
            return Response.FromValue(value, response);
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Int32Value.xml" path="doc/members/member[@name='GetInt32Value(CancellationToken)']/*" />
        public virtual Response<IReadOnlyDictionary<string, int>> GetInt32Value(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetInt32Value(context);
            IReadOnlyDictionary<string, int> value = default;
            using var document = JsonDocument.Parse(response.ContentStream);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var property in document.RootElement.EnumerateObject())
            {
                dictionary.Add(property.Name, property.Value.GetInt32());
            }
            value = dictionary;
            return Response.FromValue(value, response);
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
        /// Please try the simpler <see cref="GetInt32ValueAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Int32Value.xml" path="doc/members/member[@name='GetInt32ValueAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetInt32ValueAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Int32Value.GetInt32Value");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetInt32ValueRequest(context);
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
        /// Please try the simpler <see cref="GetInt32Value(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Int32Value.xml" path="doc/members/member[@name='GetInt32Value(RequestContext)']/*" />
        public virtual Response GetInt32Value(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Int32Value.GetInt32Value");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetInt32ValueRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The Dictionary to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/Int32Value.xml" path="doc/members/member[@name='PutAsync(IDictionary{string,int},CancellationToken)']/*" />
        public virtual async Task<Response> PutAsync(IDictionary<string, int> body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PutAsync(RequestContentHelper.FromDictionary(body), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="body"> The Dictionary to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/Int32Value.xml" path="doc/members/member[@name='Put(IDictionary{string,int},CancellationToken)']/*" />
        public virtual Response Put(IDictionary<string, int> body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Put(RequestContentHelper.FromDictionary(body), context);
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
        /// Please try the simpler <see cref="PutAsync(IDictionary{string,int},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Int32Value.xml" path="doc/members/member[@name='PutAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> PutAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Int32Value.Put");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutRequest(content, context);
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
        /// Please try the simpler <see cref="Put(IDictionary{string,int},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Int32Value.xml" path="doc/members/member[@name='Put(RequestContent,RequestContext)']/*" />
        public virtual Response Put(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Int32Value.Put");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetInt32ValueRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/dictionary/int32", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePutRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/dictionary/int32", false);
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
