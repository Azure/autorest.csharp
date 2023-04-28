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

namespace SubClients_LowLevel
{
    // Data plane generated client.
    /// <summary> The Root service client. </summary>
    public partial class RootClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly string _cachedParameter;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of RootClient for mocking. </summary>
        protected RootClient()
        {
        }

        /// <summary> Initializes a new instance of RootClient. </summary>
        /// <param name="cachedParameter"> The String to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cachedParameter"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="cachedParameter"/> is an empty string, and was expected to be non-empty. </exception>
        public RootClient(string cachedParameter, AzureKeyCredential credential) : this(cachedParameter, credential, new Uri("http://localhost:3000"), new RootClientOptions())
        {
        }

        /// <summary> Initializes a new instance of RootClient. </summary>
        /// <param name="cachedParameter"> The String to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cachedParameter"/>, <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="cachedParameter"/> is an empty string, and was expected to be non-empty. </exception>
        public RootClient(string cachedParameter, AzureKeyCredential credential, Uri endpoint, RootClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(cachedParameter, nameof(cachedParameter));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new RootClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _cachedParameter = cachedParameter;
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RootClient.xml" path="doc/members/member[@name='GetCachedParameterAsync(global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> GetCachedParameterAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RootClient.GetCachedParameter");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCachedParameterRequest(context);
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
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/RootClient.xml" path="doc/members/member[@name='GetCachedParameter(global::Azure.RequestContext)']/*" />
        public virtual Response GetCachedParameter(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RootClient.GetCachedParameter");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetCachedParameterRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Parameter _cachedParameter0;

        /// <summary> Initializes a new instance of Parameter. </summary>
        public virtual Parameter GetParameterClient()
        {
            return Volatile.Read(ref _cachedParameter0) ?? Interlocked.CompareExchange(ref _cachedParameter0, new Parameter(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedParameter0;
        }

        internal HttpMessage CreateGetCachedParameterRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/root/", false);
            uri.AppendPath(_cachedParameter, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
