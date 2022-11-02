// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Authentication.ApiKey
{
    // Data plane generated client. Illustrates clients generated with ApiKey authentication.
    /// <summary> Illustrates clients generated with ApiKey authentication. </summary>
    public partial class ApiKeyClient
    {
        private const string AuthorizationHeader = "x-ms-api-key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ApiKeyClient for mocking. </summary>
        protected ApiKeyClient()
        {
        }

        /// <summary> Initializes a new instance of ApiKeyClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public ApiKeyClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new ApiKeyClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ApiKeyClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public ApiKeyClient(AzureKeyCredential credential, Uri endpoint, ApiKeyClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ApiKeyClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Check whether client is authenticated. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ApiKeyClient.xml" path="doc/members/member[@name='ValidAsync(RequestContext)']/*" />
        public virtual async Task<Response> ValidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ApiKeyClient.Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateValidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Check whether client is authenticated. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ApiKeyClient.xml" path="doc/members/member[@name='Valid(RequestContext)']/*" />
        public virtual Response Valid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ApiKeyClient.Valid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateValidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Check whether client is authenticated. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ApiKeyClient.xml" path="doc/members/member[@name='InvalidAsync(RequestContext)']/*" />
        public virtual async Task<Response> InvalidAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ApiKeyClient.Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInvalidRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Check whether client is authenticated. </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ApiKeyClient.xml" path="doc/members/member[@name='Invalid(RequestContext)']/*" />
        public virtual Response Invalid(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ApiKeyClient.Invalid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateInvalidRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateValidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/authentication/api-key/valid", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateInvalidRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/authentication/api-key/invalid", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
