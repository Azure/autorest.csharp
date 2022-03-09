// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace RequestContextAllOptional_LowLevel
{
    /// <summary> The RequestContextAllOptional service client. </summary>
    public partial class RequestContextAllOptionalClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of RequestContextAllOptionalClient for mocking. </summary>
        protected RequestContextAllOptionalClient()
        {
        }

        /// <summary> Initializes a new instance of RequestContextAllOptionalClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public RequestContextAllOptionalClient(AzureKeyCredential credential, Uri endpoint = null, RequestContextAllOptionalClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            endpoint ??= new Uri("http://localhost:3000");
            options ??= new RequestContextAllOptionalClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> No RequestBody and ResponseBody. </summary>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="top"> Query parameter top. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="status"> Query parameter status. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual async Task<Response> NoRequestBodyResponseBodyAsync(int id, int? top = null, int skip = 12, string status = "start", RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.NoRequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoRequestBodyResponseBodyRequest(id, top, skip, status, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> No RequestBody and ResponseBody. </summary>
        /// <param name="id"> Query parameter Id. </param>
        /// <param name="top"> Query parameter top. </param>
        /// <param name="skip"> Query parameter skip. </param>
        /// <param name="status"> Query parameter status. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual Response NoRequestBodyResponseBody(int id, int? top = null, int skip = 12, string status = "start", RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.NoRequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoRequestBodyResponseBodyRequest(id, top, skip, status, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> RequestBody and ResponseBody. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   Code: string,
        ///   Status: string
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   Code: string,
        ///   Status: string
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> RequestBodyResponseBodyAsync(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.RequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequestBodyResponseBodyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> RequestBody and ResponseBody. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   Code: string,
        ///   Status: string
        /// }
        /// </code>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   Code: string,
        ///   Status: string
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response RequestBodyResponseBody(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.RequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequestBodyResponseBodyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete. </summary>
        /// <param name="resourceName"> name. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        public virtual async Task<Response> DeleteNoRequestBodyResponseBodyAsync(string resourceName, RequestContext context = null)
        {
            Argument.AssertNotNull(resourceName, nameof(resourceName));

            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.DeleteNoRequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteNoRequestBodyResponseBodyRequest(resourceName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete. </summary>
        /// <param name="resourceName"> name. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        public virtual Response DeleteNoRequestBodyResponseBody(string resourceName, RequestContext context = null)
        {
            Argument.AssertNotNull(resourceName, nameof(resourceName));

            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.DeleteNoRequestBodyResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteNoRequestBodyResponseBodyRequest(resourceName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> No RequestBody and No ResponseBody. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual async Task<Response> NoRequestBodyNoResponseBodyAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.NoRequestBodyNoResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoRequestBodyNoResponseBodyRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> No RequestBody and No ResponseBody. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual Response NoRequestBodyNoResponseBody(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.NoRequestBodyNoResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateNoRequestBodyNoResponseBodyRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> RequestBody and No ResponseBody. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual async Task<Response> RequestBodyNoResponseBodyAsync(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.RequestBodyNoResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequestBodyNoResponseBodyRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> RequestBody and No ResponseBody. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual Response RequestBodyNoResponseBody(RequestContent content, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("RequestContextAllOptionalClient.RequestBodyNoResponseBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRequestBodyNoResponseBodyRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateNoRequestBodyResponseBodyRequest(int id, int? top, int skip, string status, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test1", false);
            uri.AppendQuery("id", id, true);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            uri.AppendQuery("skip", skip, true);
            if (status != null)
            {
                uri.AppendQuery("status", status, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateRequestBodyResponseBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test1", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDeleteNoRequestBodyResponseBodyRequest(string resourceName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test1", false);
            uri.AppendQuery("resourceName", resourceName, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateNoRequestBodyNoResponseBodyRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test2", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateRequestBodyNoResponseBodyRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/test2", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
