// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace SecurityDefinition_LowLevel
{
    /// <summary> The SecurityDefinition service client. </summary>
    public partial class SecurityDefinitionClient
    {
        private static readonly string[] AuthorizationScopes = new string[] { "user_impersonation" };
        private readonly TokenCredential _tokenCredential;
        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of SecurityDefinitionClient for mocking. </summary>
        protected SecurityDefinitionClient()
        {
        }

        /// <summary> Initializes a new instance of SecurityDefinitionClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public SecurityDefinitionClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new SecurityDefinitionClientOptions())
        {
        }

        /// <summary> Initializes a new instance of SecurityDefinitionClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public SecurityDefinitionClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new SecurityDefinitionClientOptions())
        {
        }

        /// <summary> Initializes a new instance of SecurityDefinitionClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public SecurityDefinitionClient(Uri endpoint, TokenCredential credential, SecurityDefinitionClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new SecurityDefinitionClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of SecurityDefinitionClient. </summary>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public SecurityDefinitionClient(Uri endpoint, AzureKeyCredential credential, SecurityDefinitionClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new SecurityDefinitionClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   Code: string, # Optional.
        ///   Status: string, # Optional.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> OperationAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SecurityDefinitionClient.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Below is the JSON schema for the request and response payloads.
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   Code: string, # Optional.
        ///   Status: string, # Optional.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response Operation(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SecurityDefinitionClient.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateOperationRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/securitydefinition/1.0.0", false);
            uri.AppendPath("/op", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
