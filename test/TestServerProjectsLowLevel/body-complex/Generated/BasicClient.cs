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
    /// <summary> The Basic service client. </summary>
    public partial class BasicClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get; }
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private Uri endpoint;
        private readonly string apiVersion;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Initializes a new instance of BasicClient for mocking. </summary>
        protected BasicClient()
        {
        }

        /// <summary> Initializes a new instance of BasicClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public BasicClient(AzureKeyCredential credential, Uri endpoint = null, AutoRestComplexTestServiceClientOptions options = null)
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

        /// <summary> Get complex type {id: 2, name: &apos;abc&apos;, color: &apos;YELLOW&apos;}. </summary>
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
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Get complex type {id: 2, name: &apos;abc&apos;, color: &apos;YELLOW&apos;}. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual Response GetValid(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetValidRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            Pipeline.Send(message, requestOptions?.CancellationToken ?? System.Threading.CancellationToken.None);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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
            uri.AppendPath("/complex/basic/valid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </summary>
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
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Please put {id: 2, name: &apos;abc&apos;, color: &apos;Magenta&apos;}. </summary>
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
            Pipeline.Send(message, requestOptions?.CancellationToken ?? System.Threading.CancellationToken.None);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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
            uri.AppendPath("/complex/basic/valid", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = requestBody;
            return message;
        }

        /// <summary> Get a basic complex type that is invalid for the local strong type. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual async Task<Response> GetInvalidAsync(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetInvalidRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            await Pipeline.SendAsync(message, requestOptions.CancellationToken).ConfigureAwait(false);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Get a basic complex type that is invalid for the local strong type. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual Response GetInvalid(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetInvalidRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            Pipeline.Send(message, requestOptions?.CancellationToken ?? System.Threading.CancellationToken.None);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Create Request for <see cref="GetInvalid"/> and <see cref="GetInvalidAsync"/> operations. </summary>
        /// <param name="requestOptions"> The request options. </param>
        private HttpMessage CreateGetInvalidRequest(RequestOptions requestOptions = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/basic/invalid", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a basic complex type that is empty. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual async Task<Response> GetEmptyAsync(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetEmptyRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            await Pipeline.SendAsync(message, requestOptions.CancellationToken).ConfigureAwait(false);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Get a basic complex type that is empty. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual Response GetEmpty(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetEmptyRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            Pipeline.Send(message, requestOptions?.CancellationToken ?? System.Threading.CancellationToken.None);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Create Request for <see cref="GetEmpty"/> and <see cref="GetEmptyAsync"/> operations. </summary>
        /// <param name="requestOptions"> The request options. </param>
        private HttpMessage CreateGetEmptyRequest(RequestOptions requestOptions = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/basic/empty", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a basic complex type whose properties are null. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual async Task<Response> GetNullAsync(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetNullRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            await Pipeline.SendAsync(message, requestOptions.CancellationToken).ConfigureAwait(false);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Get a basic complex type whose properties are null. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual Response GetNull(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetNullRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            Pipeline.Send(message, requestOptions?.CancellationToken ?? System.Threading.CancellationToken.None);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Create Request for <see cref="GetNull"/> and <see cref="GetNullAsync"/> operations. </summary>
        /// <param name="requestOptions"> The request options. </param>
        private HttpMessage CreateGetNullRequest(RequestOptions requestOptions = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/basic/null", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a basic complex type while the server doesn&apos;t provide a response payload. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual async Task<Response> GetNotProvidedAsync(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetNotProvidedRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            await Pipeline.SendAsync(message, requestOptions.CancellationToken).ConfigureAwait(false);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Get a basic complex type while the server doesn&apos;t provide a response payload. </summary>
        /// <param name="requestOptions"> The request options. </param>
        public virtual Response GetNotProvided(RequestOptions requestOptions = null)
        {
            requestOptions ??= new RequestOptions();
            HttpMessage message = CreateGetNotProvidedRequest(requestOptions);
            if (requestOptions.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", requestOptions.PerCallPolicy);
            }
            Pipeline.Send(message, requestOptions?.CancellationToken ?? System.Threading.CancellationToken.None);
            ResponseStatusOption statusOption = requestOptions?.StatusOption ?? ResponseStatusOption.Default;
            if (statusOption == ResponseStatusOption.Default)
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

        /// <summary> Create Request for <see cref="GetNotProvided"/> and <see cref="GetNotProvidedAsync"/> operations. </summary>
        /// <param name="requestOptions"> The request options. </param>
        private HttpMessage CreateGetNotProvidedRequest(RequestOptions requestOptions = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/complex/basic/notprovided", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }
    }
}
