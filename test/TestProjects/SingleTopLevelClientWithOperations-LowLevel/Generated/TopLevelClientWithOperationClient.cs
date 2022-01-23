// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace SingleTopLevelClientWithOperations_LowLevel
{
    /// <summary> The TopLevelClientWithOperation service client. </summary>
    public partial class TopLevelClientWithOperationClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        internal ClientDiagnostics ClientDiagnostics { get; }
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of TopLevelClientWithOperationClient for mocking. </summary>
        protected TopLevelClientWithOperationClient()
        {
        }

        /// <summary> Initializes a new instance of TopLevelClientWithOperationClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public TopLevelClientWithOperationClient(AzureKeyCredential credential, Uri endpoint = null, TopLevelClientWithOperationClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            endpoint ??= new Uri("http://localhost:3000");
            options ??= new TopLevelClientWithOperationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> OperationAsync(RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("TopLevelClientWithOperationClient.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(context);
                return await _pipeline.ProcessMessageAsync(message, ClientDiagnostics, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
#pragma warning disable AZC0002
        public virtual Response Operation(RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = ClientDiagnostics.CreateScope("TopLevelClientWithOperationClient.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(context);
                return _pipeline.ProcessMessage(message, ClientDiagnostics, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation defined in resource client, but must be promoted to the top level client because it doesn&apos;t have a parameter with `x-ms-resource-identifier: true`. </summary>
        /// <param name="filter"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual AsyncPageable<BinaryData> GetAllAsync(string filter, RequestContext context = null)
#pragma warning restore AZC0002
        {
            Argument.AssertNotNull(filter, nameof(filter));

            return PageableHelpers.CreateAsyncPageable(CreateEnumerableAsync, ClientDiagnostics, "TopLevelClientWithOperationClient.GetAll");
            async IAsyncEnumerable<Page<BinaryData>> CreateEnumerableAsync(string nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                do
                {
                    var message = string.IsNullOrEmpty(nextLink)
                        ? CreateGetAllRequest(filter, context)
                        : CreateGetAllNextPageRequest(nextLink, filter, context);
                    var page = await LowLevelPageableHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, context, "value", "nextLink", cancellationToken).ConfigureAwait(false);
                    nextLink = page.ContinuationToken;
                    yield return page;
                } while (!string.IsNullOrEmpty(nextLink));
            }
        }

        /// <summary> Operation defined in resource client, but must be promoted to the top level client because it doesn&apos;t have a parameter with `x-ms-resource-identifier: true`. </summary>
        /// <param name="filter"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual Pageable<BinaryData> GetAll(string filter, RequestContext context = null)
#pragma warning restore AZC0002
        {
            Argument.AssertNotNull(filter, nameof(filter));

            return PageableHelpers.CreatePageable(CreateEnumerable, ClientDiagnostics, "TopLevelClientWithOperationClient.GetAll");
            IEnumerable<Page<BinaryData>> CreateEnumerable(string nextLink, int? pageSizeHint)
            {
                do
                {
                    var message = string.IsNullOrEmpty(nextLink)
                        ? CreateGetAllRequest(filter, context)
                        : CreateGetAllNextPageRequest(nextLink, filter, context);
                    var page = LowLevelPageableHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, context, "value", "nextLink");
                    nextLink = page.ContinuationToken;
                    yield return page;
                } while (!string.IsNullOrEmpty(nextLink));
            }
        }

        private Client1 _cachedClient1;
        private Client2 _cachedClient2;

        /// <summary> Initializes a new instance of Client1. </summary>
        public virtual Client1 GetClient1Client()
        {
            return Volatile.Read(ref _cachedClient1) ?? Interlocked.CompareExchange(ref _cachedClient1, new Client1(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedClient1;
        }

        /// <summary> Initializes a new instance of Client2. </summary>
        public virtual Client2 GetClient2Client()
        {
            return Volatile.Read(ref _cachedClient2) ?? Interlocked.CompareExchange(ref _cachedClient2, new Client2(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedClient2;
        }

        /// <summary> Initializes a new instance of Client4. </summary>
        /// <param name="clientParameter"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientParameter"/> is null. </exception>
        public virtual Client4 GetClient4(string clientParameter)
        {
            Argument.AssertNotNull(clientParameter, nameof(clientParameter));

            return new Client4(ClientDiagnostics, _pipeline, _keyCredential, clientParameter, _endpoint);
        }

        internal HttpMessage CreateOperationRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client3", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetAllRequest(string filter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client4", false);
            uri.AppendQuery("filter", filter, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetAllNextPageRequest(string nextLink, string filter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        private sealed class ResponseClassifier200 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier200();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    200 => false,
                    _ => true
                };
            }
        }
    }
}
