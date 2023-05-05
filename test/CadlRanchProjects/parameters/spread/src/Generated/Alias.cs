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
using Parameters.Spread.Models;

namespace Parameters.Spread
{
    // Data plane generated sub-client.
    /// <summary> The Alias sub-client. </summary>
    public partial class Alias
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Alias for mocking. </summary>
        protected Alias()
        {
        }

        /// <summary> Initializes a new instance of Alias. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="apiVersion"> The String to use. </param>
        internal Alias(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <param name="name"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadAsRequestBodyAsync(string,global::System.Threading.CancellationToken)']/*" />
        public virtual async Task<Response> SpreadAsRequestBodyAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAsRequestBodyRequest spreadAsRequestBodyRequest = new SpreadAsRequestBodyRequest(name);
            Response response = await SpreadAsRequestBodyAsync(spreadAsRequestBodyRequest.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="name"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadAsRequestBody(string,global::System.Threading.CancellationToken)']/*" />
        public virtual Response SpreadAsRequestBody(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAsRequestBodyRequest spreadAsRequestBodyRequest = new SpreadAsRequestBodyRequest(name);
            Response response = SpreadAsRequestBody(spreadAsRequestBodyRequest.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] 
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestBodyAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadAsRequestBodyAsync(global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> SpreadAsRequestBodyAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Alias.SpreadAsRequestBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAsRequestBodyRequest(content, context);
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
        /// Please try the simpler <see cref="SpreadAsRequestBody(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadAsRequestBody(global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual Response SpreadAsRequestBody(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Alias.SpreadAsRequestBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAsRequestBodyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="id"> The String to use. </param>
        /// <param name="xMsTestHeader"> The String to use. </param>
        /// <param name="name"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadAsRequestParameterAsync(string,string,string,global::System.Threading.CancellationToken)']/*" />
        public virtual async Task<Response> SpreadAsRequestParameterAsync(string id, string xMsTestHeader, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAsRequestParameterRequest spreadAsRequestParameterRequest = new SpreadAsRequestParameterRequest(name);
            Response response = await SpreadAsRequestParameterAsync(id, xMsTestHeader, spreadAsRequestParameterRequest.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="id"> The String to use. </param>
        /// <param name="xMsTestHeader"> The String to use. </param>
        /// <param name="name"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadAsRequestParameter(string,string,string,global::System.Threading.CancellationToken)']/*" />
        public virtual Response SpreadAsRequestParameter(string id, string xMsTestHeader, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAsRequestParameterRequest spreadAsRequestParameterRequest = new SpreadAsRequestParameterRequest(name);
            Response response = SpreadAsRequestParameter(id, xMsTestHeader, spreadAsRequestParameterRequest.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] 
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAsRequestParameterAsync(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="xMsTestHeader"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadAsRequestParameterAsync(string,string,global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> SpreadAsRequestParameterAsync(string id, string xMsTestHeader, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Alias.SpreadAsRequestParameter");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAsRequestParameterRequest(id, xMsTestHeader, content, context);
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
        /// Please try the simpler <see cref="SpreadAsRequestParameter(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="xMsTestHeader"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadAsRequestParameter(string,string,global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual Response SpreadAsRequestParameter(string id, string xMsTestHeader, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Alias.SpreadAsRequestParameter");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAsRequestParameterRequest(id, xMsTestHeader, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="id"> The String to use. </param>
        /// <param name="xMsTestHeader"> The String to use. </param>
        /// <param name="prop1"></param>
        /// <param name="prop2"></param>
        /// <param name="prop3"></param>
        /// <param name="prop4"></param>
        /// <param name="prop5"></param>
        /// <param name="prop6"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/>, <paramref name="prop1"/>, <paramref name="prop2"/>, <paramref name="prop3"/>, <paramref name="prop4"/>, <paramref name="prop5"/> or <paramref name="prop6"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadWithMultipleParametersAsync(string,string,string,string,string,string,string,string,global::System.Threading.CancellationToken)']/*" />
        public virtual async Task<Response> SpreadWithMultipleParametersAsync(string id, string xMsTestHeader, string prop1, string prop2, string prop3, string prop4, string prop5, string prop6, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(prop1, nameof(prop1));
            Argument.AssertNotNull(prop2, nameof(prop2));
            Argument.AssertNotNull(prop3, nameof(prop3));
            Argument.AssertNotNull(prop4, nameof(prop4));
            Argument.AssertNotNull(prop5, nameof(prop5));
            Argument.AssertNotNull(prop6, nameof(prop6));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadWithMultipleParametersRequest spreadWithMultipleParametersRequest = new SpreadWithMultipleParametersRequest(prop1, prop2, prop3, prop4, prop5, prop6);
            Response response = await SpreadWithMultipleParametersAsync(id, xMsTestHeader, spreadWithMultipleParametersRequest.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <param name="id"> The String to use. </param>
        /// <param name="xMsTestHeader"> The String to use. </param>
        /// <param name="prop1"></param>
        /// <param name="prop2"></param>
        /// <param name="prop3"></param>
        /// <param name="prop4"></param>
        /// <param name="prop5"></param>
        /// <param name="prop6"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/>, <paramref name="prop1"/>, <paramref name="prop2"/>, <paramref name="prop3"/>, <paramref name="prop4"/>, <paramref name="prop5"/> or <paramref name="prop6"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadWithMultipleParameters(string,string,string,string,string,string,string,string,global::System.Threading.CancellationToken)']/*" />
        public virtual Response SpreadWithMultipleParameters(string id, string xMsTestHeader, string prop1, string prop2, string prop3, string prop4, string prop5, string prop6, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(prop1, nameof(prop1));
            Argument.AssertNotNull(prop2, nameof(prop2));
            Argument.AssertNotNull(prop3, nameof(prop3));
            Argument.AssertNotNull(prop4, nameof(prop4));
            Argument.AssertNotNull(prop5, nameof(prop5));
            Argument.AssertNotNull(prop6, nameof(prop6));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadWithMultipleParametersRequest spreadWithMultipleParametersRequest = new SpreadWithMultipleParametersRequest(prop1, prop2, prop3, prop4, prop5, prop6);
            Response response = SpreadWithMultipleParameters(id, xMsTestHeader, spreadWithMultipleParametersRequest.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] 
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadWithMultipleParametersAsync(string,string,string,string,string,string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="xMsTestHeader"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadWithMultipleParametersAsync(string,string,global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> SpreadWithMultipleParametersAsync(string id, string xMsTestHeader, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Alias.SpreadWithMultipleParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadWithMultipleParametersRequest(id, xMsTestHeader, content, context);
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
        /// Please try the simpler <see cref="SpreadWithMultipleParameters(string,string,string,string,string,string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="xMsTestHeader"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="xMsTestHeader"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Alias.xml" path="doc/members/member[@name='SpreadWithMultipleParameters(string,string,global::Azure.Core.RequestContent,global::Azure.RequestContext)']/*" />
        public virtual Response SpreadWithMultipleParameters(string id, string xMsTestHeader, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(xMsTestHeader, nameof(xMsTestHeader));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Alias.SpreadWithMultipleParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadWithMultipleParametersRequest(id, xMsTestHeader, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateSpreadAsRequestBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/alias/request-body", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadAsRequestParameterRequest(string id, string xMsTestHeader, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/alias/request-parameter/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("x-ms-test-header", xMsTestHeader);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadWithMultipleParametersRequest(string id, string xMsTestHeader, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameters/spread/alias/multiple-parameters/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("x-ms-test-header", xMsTestHeader);
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

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
