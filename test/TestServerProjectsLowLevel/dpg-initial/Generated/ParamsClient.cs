// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace dpg_initial_LowLevel
{
    // Data plane generated client. The Params service client.
    /// <summary> The Params service client. </summary>
    public partial class ParamsClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ParamsClient for mocking. </summary>
        protected ParamsClient()
        {
        }

        /// <summary> Initializes a new instance of ParamsClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public ParamsClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new ParamsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ParamsClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public ParamsClient(AzureKeyCredential credential, Uri endpoint, ParamsClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ParamsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// Head request, no params.
        ///  Initially has no query parameters. After evolution, a new optional query parameter is added
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='HeadNoParamsAsync(RequestContext)']/*" />
        public virtual async Task<Response> HeadNoParamsAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParamsClient.HeadNoParams");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHeadNoParamsRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Head request, no params.
        ///  Initially has no query parameters. After evolution, a new optional query parameter is added
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='HeadNoParams(RequestContext)']/*" />
        public virtual Response HeadNoParams(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParamsClient.HeadNoParams");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHeadNoParamsRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get true Boolean value on path.
        ///  Initially only has one required Query Parameter. After evolution, a new optional query parameter is added
        /// </summary>
        /// <param name="parameter"> I am a required parameter. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameter"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='GetRequiredAsync(String,RequestContext)']/*" />
        public virtual async Task<Response> GetRequiredAsync(string parameter, RequestContext context = null)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.GetRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequiredRequest(parameter, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get true Boolean value on path.
        ///  Initially only has one required Query Parameter. After evolution, a new optional query parameter is added
        /// </summary>
        /// <param name="parameter"> I am a required parameter. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameter"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='GetRequired(String,RequestContext)']/*" />
        public virtual Response GetRequired(string parameter, RequestContext context = null)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.GetRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequiredRequest(parameter, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initially has one required query parameter and one optional query parameter.  After evolution, a new optional query parameter is added. </summary>
        /// <param name="requiredParam"> I am a required parameter. </param>
        /// <param name="optionalParam"> I am an optional parameter. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredParam"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='PutRequiredOptionalAsync(String,String,RequestContext)']/*" />
        public virtual async Task<Response> PutRequiredOptionalAsync(string requiredParam, string optionalParam = null, RequestContext context = null)
        {
            Argument.AssertNotNull(requiredParam, nameof(requiredParam));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.PutRequiredOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutRequiredOptionalRequest(requiredParam, optionalParam, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initially has one required query parameter and one optional query parameter.  After evolution, a new optional query parameter is added. </summary>
        /// <param name="requiredParam"> I am a required parameter. </param>
        /// <param name="optionalParam"> I am an optional parameter. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredParam"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='PutRequiredOptional(String,String,RequestContext)']/*" />
        public virtual Response PutRequiredOptional(string requiredParam, string optionalParam = null, RequestContext context = null)
        {
            Argument.AssertNotNull(requiredParam, nameof(requiredParam));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.PutRequiredOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutRequiredOptionalRequest(requiredParam, optionalParam, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST a JSON. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='PostParametersAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> PostParametersAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.PostParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostParametersRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST a JSON. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='PostParameters(RequestContent,RequestContext)']/*" />
        public virtual Response PostParameters(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.PostParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostParametersRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get true Boolean value on path.
        ///  Initially has one optional query parameter. After evolution, a new optional query parameter is added
        /// </summary>
        /// <param name="optionalParam"> I am an optional parameter. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='GetOptionalAsync(String,RequestContext)']/*" />
        public virtual async Task<Response> GetOptionalAsync(string optionalParam = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParamsClient.GetOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetOptionalRequest(optionalParam, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get true Boolean value on path.
        ///  Initially has one optional query parameter. After evolution, a new optional query parameter is added
        /// </summary>
        /// <param name="optionalParam"> I am an optional parameter. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParamsClient.xml" path="doc/members/member[@name='GetOptional(String,RequestContext)']/*" />
        public virtual Response GetOptional(string optionalParam = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParamsClient.GetOptional");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetOptionalRequest(optionalParam, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateHeadNoParamsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/serviceDriven/parameters", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetRequiredRequest(string parameter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/serviceDriven/parameters", false);
            uri.AppendQuery("parameter", parameter, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePutRequiredOptionalRequest(string requiredParam, string optionalParam, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/serviceDriven/parameters", false);
            uri.AppendQuery("requiredParam", requiredParam, true);
            if (optionalParam != null)
            {
                uri.AppendQuery("optionalParam", optionalParam, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreatePostParametersRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/serviceDriven/parameters", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetOptionalRequest(string optionalParam, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/serviceDriven/moreParameters", false);
            if (optionalParam != null)
            {
                uri.AppendQuery("optionalParam", optionalParam, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
