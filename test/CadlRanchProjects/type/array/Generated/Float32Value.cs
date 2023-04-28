// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace _Type._Array
{
    // Data plane generated sub-client.
    /// <summary> Array of float values. </summary>
    public partial class Float32Value
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Float32Value for mocking. </summary>
        protected Float32Value()
        {
        }

        /// <summary> Initializes a new instance of Float32Value. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="apiVersion"> The String to use. </param>
        internal Float32Value(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Float32Value.xml" path="doc/members/member[@name='GetFloat32ValueAsync(global::System.Threading.CancellationToken)']/*" />
        public virtual async Task<Response<IReadOnlyList<float>>> GetFloat32ValueAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetFloat32ValueAsync(context).ConfigureAwait(false);
            IReadOnlyList<float> value = default;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            List<float> array = new List<float>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(item.GetSingle());
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Float32Value.xml" path="doc/members/member[@name='GetFloat32Value(global::System.Threading.CancellationToken)']/*" />
        public virtual Response<IReadOnlyList<float>> GetFloat32Value(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetFloat32Value(context);
            IReadOnlyList<float> value = default;
            using var document = JsonDocument.Parse(response.ContentStream);
            List<float> array = new List<float>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(item.GetSingle());
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Float32Value.xml" path="doc/members/member[@name='GetFloat32ValueAsync(global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> GetFloat32ValueAsync(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Float32Value.GetFloat32Value");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetFloat32ValueRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Float32Value.xml" path="doc/members/member[@name='GetFloat32Value(global::Azure.RequestContext)']/*" />
        public virtual Response GetFloat32Value(RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Float32Value.GetFloat32Value");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetFloat32ValueRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="body"> The Array to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/Float32Value.xml" path="doc/members/member[@name='PutAsync(object,global::System.Threading.CancellationToken)']/*" />
        public virtual async Task<Response> PutAsync(object body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PutAsync(RequestContent.Create(body), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="body"> The Array to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <include file="Docs/Float32Value.xml" path="doc/members/member[@name='Put(object,global::System.Threading.CancellationToken)']/*" />
        public virtual Response Put(object body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Put(RequestContent.Create(body), context);
            return response;
        }

        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Float32Value.xml" path="doc/members/member[@name='PutAsync(global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> PutAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Float32Value.Put");
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

        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Float32Value.xml" path="doc/members/member[@name='Put(global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual Response Put(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Float32Value.Put");
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

        internal HttpMessage CreateGetFloat32ValueRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/array/float32", false);
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
            uri.AppendPath("/type/array/float32", false);
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
