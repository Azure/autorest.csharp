// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace CadlFirstTest
{
    // Data plane generated client. The Demo2 service client.
    /// <summary> The Demo2 service client. </summary>
    public partial class Demo2Client
    {
        private const string AuthorizationHeader = "x-ms-api-key";
        private readonly AzureKeyCredential _keyCredential;
        private static readonly string[] AuthorizationScopes = new string[] { "https://api.example.com/.default" };
        private readonly TokenCredential _tokenCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Demo2Client for mocking. </summary>
        protected Demo2Client()
        {
        }

        /// <summary> Initializes a new instance of Demo2Client. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public Demo2Client(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:300"), new CadlFirstTestClientOptions())
        {
        }

        /// <summary> Initializes a new instance of Demo2Client. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public Demo2Client(TokenCredential credential) : this(credential, new Uri("http://localhost:300"), new CadlFirstTestClientOptions())
        {
        }

        /// <summary> Initializes a new instance of Demo2Client. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> Endpoint Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public Demo2Client(AzureKeyCredential credential, Uri endpoint, CadlFirstTestClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new CadlFirstTestClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of Demo2Client. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> Endpoint Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public Demo2Client(TokenCredential credential, Uri endpoint, CadlFirstTestClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new CadlFirstTestClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Return hi again. </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Demo2Client.xml" path="doc/members/member[@name='HelloAgainAsync(String,String,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> HelloAgainAsync(string p2, string p1, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Demo2Client.HelloAgain");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloAgainRequest(p2, p1, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi again. </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Demo2Client.xml" path="doc/members/member[@name='HelloAgain(String,String,RequestContent,RequestContext)']/*" />
        public virtual Response HelloAgain(string p2, string p1, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Demo2Client.HelloAgain");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloAgainRequest(p2, p1, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi again. </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Demo2Client.xml" path="doc/members/member[@name='NoContentTypeAsync(String,String,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> NoContentTypeAsync(string p2, string p1, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Demo2Client.NoContentType");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoContentTypeRequest(p2, p1, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi again. </summary>
        /// <param name="p2"> The String to use. </param>
        /// <param name="p1"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="p2"/>, <paramref name="p1"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="p2"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Demo2Client.xml" path="doc/members/member[@name='NoContentType(String,String,RequestContent,RequestContext)']/*" />
        public virtual Response NoContentType(string p2, string p1, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(p2, nameof(p2));
            Argument.AssertNotNull(p1, nameof(p1));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Demo2Client.NoContentType");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoContentTypeRequest(p2, p1, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi in demo2. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Demo2Client.xml" path="doc/members/member[@name='HelloDemo2Async(RequestContext)']/*" />
        public virtual async Task<Response> HelloDemo2Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Demo2Client.HelloDemo2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloDemo2Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return hi in demo2. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <include file="Docs/Demo2Client.xml" path="doc/members/member[@name='HelloDemo2(RequestContext)']/*" />
        public virtual Response HelloDemo2(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Demo2Client.HelloDemo2");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHelloDemo2Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateHelloAgainRequest(string p2, string p1, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/againHi/", false);
            uri.AppendPath(p2, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("p1", p1);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("content-type", "text/plain");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateNoContentTypeRequest(string p2, string p1, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/noContentType/", false);
            uri.AppendPath(p2, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("p1", p1);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateHelloDemo2Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/demoHi", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
