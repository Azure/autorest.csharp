// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace url_multi_collectionFormat_LowLevel
{
    /// <summary> The Queries service client. </summary>
    public partial class QueriesClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get; }
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private Uri endpoint;
        private readonly string apiVersion;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Initializes a new instance of QueriesClient for mocking. </summary>
        protected QueriesClient()
        {
        }

        /// <summary> Initializes a new instance of QueriesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public QueriesClient(AzureKeyCredential credential, Uri endpoint = null, AutoRestUrlMutliCollectionFormatTestServiceClientOptions options = null)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("http://localhost:3000");

            options ??= new AutoRestUrlMutliCollectionFormatTestServiceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            var authPolicy = new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader);
            Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            this.endpoint = endpoint;
            apiVersion = options.Version;
        }

        /// <summary> Get a null array of string using the multi-array format. </summary>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <pre><c>
        /// {
        ///   "status": "number",
        ///   "message": "string"
        /// }
        /// </c></pre>
        /// 
        /// </remarks>
        /// <param name="arrayQuery"> a null array of string using the multi-array format. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> ArrayStringMultiNullAsync(IEnumerable<string> arrayQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            HttpMessage message = CreateArrayStringMultiNullRequest(arrayQuery, options);
            if (options.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", options.PerCallPolicy);
            }
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiNull");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
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
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a null array of string using the multi-array format. </summary>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <pre><c>
        /// {
        ///   "status": "number",
        ///   "message": "string"
        /// }
        /// </c></pre>
        /// 
        /// </remarks>
        /// <param name="arrayQuery"> a null array of string using the multi-array format. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response ArrayStringMultiNull(IEnumerable<string> arrayQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            HttpMessage message = CreateArrayStringMultiNullRequest(arrayQuery, options);
            if (options.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", options.PerCallPolicy);
            }
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiNull");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
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
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create Request for <see cref="ArrayStringMultiNull"/> and <see cref="ArrayStringMultiNullAsync"/> operations. </summary>
        /// <param name="arrayQuery"> a null array of string using the multi-array format. </param>
        /// <param name="options"> The request options. </param>
        private HttpMessage CreateArrayStringMultiNullRequest(IEnumerable<string> arrayQuery = null, RequestOptions options = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/queries/array/multi/string/null", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an empty array [] of string using the multi-array format. </summary>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <pre><c>
        /// {
        ///   "status": "number",
        ///   "message": "string"
        /// }
        /// </c></pre>
        /// 
        /// </remarks>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> ArrayStringMultiEmptyAsync(IEnumerable<string> arrayQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            HttpMessage message = CreateArrayStringMultiEmptyRequest(arrayQuery, options);
            if (options.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", options.PerCallPolicy);
            }
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiEmpty");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
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
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an empty array [] of string using the multi-array format. </summary>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <pre><c>
        /// {
        ///   "status": "number",
        ///   "message": "string"
        /// }
        /// </c></pre>
        /// 
        /// </remarks>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response ArrayStringMultiEmpty(IEnumerable<string> arrayQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            HttpMessage message = CreateArrayStringMultiEmptyRequest(arrayQuery, options);
            if (options.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", options.PerCallPolicy);
            }
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiEmpty");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
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
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create Request for <see cref="ArrayStringMultiEmpty"/> and <see cref="ArrayStringMultiEmptyAsync"/> operations. </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="options"> The request options. </param>
        private HttpMessage CreateArrayStringMultiEmptyRequest(IEnumerable<string> arrayQuery = null, RequestOptions options = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/queries/array/multi/string/empty", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </summary>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <pre><c>
        /// {
        ///   "status": "number",
        ///   "message": "string"
        /// }
        /// </c></pre>
        /// 
        /// </remarks>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> ArrayStringMultiValidAsync(IEnumerable<string> arrayQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            HttpMessage message = CreateArrayStringMultiValidRequest(arrayQuery, options);
            if (options.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", options.PerCallPolicy);
            }
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiValid");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
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
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </summary>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <pre><c>
        /// {
        ///   "status": "number",
        ///   "message": "string"
        /// }
        /// </c></pre>
        /// 
        /// </remarks>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response ArrayStringMultiValid(IEnumerable<string> arrayQuery = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            HttpMessage message = CreateArrayStringMultiValidRequest(arrayQuery, options);
            if (options.PerCallPolicy != null)
            {
                message.SetProperty("RequestOptionsPerCallPolicyCallback", options.PerCallPolicy);
            }
            using var scope = _clientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiValid");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
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
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create Request for <see cref="ArrayStringMultiValid"/> and <see cref="ArrayStringMultiValidAsync"/> operations. </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </param>
        /// <param name="options"> The request options. </param>
        private HttpMessage CreateArrayStringMultiValidRequest(IEnumerable<string> arrayQuery = null, RequestOptions options = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/queries/array/multi/string/valid", false);
            if (arrayQuery != null)
            {
                uri.AppendQueryDelimited("arrayQuery", arrayQuery, ",", true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }
    }
}
