// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace body_complex_LowLevel
{
    /// <summary> The Polymorphicrecursive service client. </summary>
    public partial class PolymorphicrecursiveClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get; }
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private Uri endpoint;
        private readonly string apiVersion;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Initializes a new instance of PolymorphicrecursiveClient for mocking. </summary>
        protected PolymorphicrecursiveClient()
        {
        }

        /// <summary> Initializes a new instance of PolymorphicrecursiveClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PolymorphicrecursiveClient(AzureKeyCredential credential, Uri endpoint = null, AutoRestComplexTestServiceClientOptions options = null)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new AutoRestComplexTestServiceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            var authPolicy = new AzureKeyCredentialPolicy(credential, AuthorizationHeader);
            Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { authPolicy, new LowLevelCallbackPolicy() });
            this.endpoint = endpoint;
            apiVersion = options.Version;
        }

        /// <summary> Get complex types that are polymorphic and have recursive references. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual async Task<Response> GetValidAsync(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetValidRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            await Pipeline.SendAsync(message, requestOptions.CancellationToken).ConfigureAwait(false);
            if (requestOptions.StatusOption == ResponseStatusOption.Default)
            {
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            else
            {
                return message.Response;
            }
        }

        /// <summary> Get complex types that are polymorphic and have recursive references. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual Response GetValid(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetValidRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            Pipeline.Send(message, requestOptions.CancellationToken);
            if (requestOptions.StatusOption == ResponseStatusOption.Default)
            {
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            else
            {
                return message.Response;
            }
        }

        /// <summary> Create Request for <see cref="GetValid"/> and <see cref="GetValidAsync"/> operations. </summary>
        /// <param name="requestOptions"> The request options. </param>
        private HttpMessage CreateGetValidRequest(RequestOptions requestOptions = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphicrecursive/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Put complex types that are polymorphic and have recursive references. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="requestOptions"> The request options. </param>
        public virtual async Task<Response> PutValidAsync(RequestContent requestBody, RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreatePutValidRequest(requestBody, requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            await Pipeline.SendAsync(message, requestOptions.CancellationToken).ConfigureAwait(false);
            if (requestOptions.StatusOption == ResponseStatusOption.Default)
            {
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            else
            {
                return message.Response;
            }
        }

        /// <summary> Put complex types that are polymorphic and have recursive references. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="requestOptions"> The request options. </param>
        public virtual Response PutValid(RequestContent requestBody, RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreatePutValidRequest(requestBody, requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            Pipeline.Send(message, requestOptions.CancellationToken);
            if (requestOptions.StatusOption == ResponseStatusOption.Default)
            {
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            else
            {
                return message.Response;
            }
        }

        /// <summary> Create Request for <see cref="PutValid"/> and <see cref="PutValidAsync"/> operations. </summary>
        /// <param name="requestBody"> The request body. </param>
        /// <param name="requestOptions"> The request options. </param>
        private HttpMessage CreatePutValidRequest(RequestContent requestBody, RequestOptions requestOptions = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/polymorphicrecursive/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return message;
        }
    }
}
