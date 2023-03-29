// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Models.Property.Optional.Models;

namespace Models.Property.Optional
{
    // Data plane generated sub-client.
    /// <summary> The Duration sub-client. </summary>
    public partial class Duration
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Duration for mocking. </summary>
        protected Duration()
        {
        }

        /// <summary> Initializes a new instance of Duration. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="apiVersion"> The String to use. </param>
        internal Duration(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary> Get models that will return all properties in the model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DurationProperty>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAllAsync(context).ConfigureAwait(false);
            return Response.FromValue(DurationProperty.FromResponse(response), response);
        }

        /// <summary> Get models that will return all properties in the model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DurationProperty> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAll(context);
            return Response.FromValue(DurationProperty.FromResponse(response), response);
        }

        /// <summary> Get models that will return all properties in the model. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="context"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Duration.xml" path="doc/members/member[@name='GetAllAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetAllAsync(RequestContext context)
        {
            Argument.AssertNotNull(context, nameof(context));

            using var scope = ClientDiagnostics.CreateScope("Duration.GetAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAllRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get models that will return all properties in the model. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="context"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Duration.xml" path="doc/members/member[@name='GetAll(RequestContext)']/*" />
        public virtual Response GetAll(RequestContext context)
        {
            Argument.AssertNotNull(context, nameof(context));

            using var scope = ClientDiagnostics.CreateScope("Duration.GetAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAllRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get models that will return the default object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DurationProperty>> GetDefaultAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDefaultAsync(context).ConfigureAwait(false);
            return Response.FromValue(DurationProperty.FromResponse(response), response);
        }

        /// <summary> Get models that will return the default object. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DurationProperty> GetDefault(CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDefault(context);
            return Response.FromValue(DurationProperty.FromResponse(response), response);
        }

        /// <summary> Get models that will return the default object. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="context"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Duration.xml" path="doc/members/member[@name='GetDefaultAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetDefaultAsync(RequestContext context)
        {
            Argument.AssertNotNull(context, nameof(context));

            using var scope = ClientDiagnostics.CreateScope("Duration.GetDefault");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get models that will return the default object. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="context"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Duration.xml" path="doc/members/member[@name='GetDefault(RequestContext)']/*" />
        public virtual Response GetDefault(RequestContext context)
        {
            Argument.AssertNotNull(context, nameof(context));

            using var scope = ClientDiagnostics.CreateScope("Duration.GetDefault");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDefaultRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a body with all properties present. </summary>
        /// <param name="body"> The DurationProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Response> PutAllAsync(DurationProperty body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PutAllAsync(body.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Put a body with all properties present. </summary>
        /// <param name="body"> The DurationProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Response PutAll(DurationProperty body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = PutAll(body.ToRequestContent(), context);
            return response;
        }

        /// <summary> Put a body with all properties present. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Duration.xml" path="doc/members/member[@name='PutAllAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> PutAllAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Duration.PutAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutAllRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a body with all properties present. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Duration.xml" path="doc/members/member[@name='PutAll(RequestContent,RequestContext)']/*" />
        public virtual Response PutAll(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Duration.PutAll");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutAllRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a body with default properties. </summary>
        /// <param name="body"> The DurationProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Response> PutDefaultAsync(DurationProperty body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await PutDefaultAsync(body.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Put a body with default properties. </summary>
        /// <param name="body"> The DurationProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Response PutDefault(DurationProperty body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = PutDefault(body.ToRequestContent(), context);
            return response;
        }

        /// <summary> Put a body with default properties. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Duration.xml" path="doc/members/member[@name='PutDefaultAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> PutDefaultAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Duration.PutDefault");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutDefaultRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a body with default properties. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Duration.xml" path="doc/members/member[@name='PutDefault(RequestContent,RequestContext)']/*" />
        public virtual Response PutDefault(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Duration.PutDefault");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutDefaultRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetAllRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/optional/duration/all", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDefaultRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/optional/duration/default", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePutAllRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/optional/duration/all", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreatePutDefaultRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/models/properties/optional/duration/default", false);
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
