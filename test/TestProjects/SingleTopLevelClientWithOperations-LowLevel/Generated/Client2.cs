// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace SingleTopLevelClientWithOperations_LowLevel
{
    /// <summary> The Client2 service client. </summary>
    public partial class Client2
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Client2 for mocking. </summary>
        protected Client2()
        {
        }

        /// <summary> Initializes a new instance of Client2. </summary>
        /// <param name="clientDiagnostics"> The ClientDiagnostics instance to use. </param>
        /// <param name="pipeline"> The pipeline instance to use. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal Client2(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, Uri endpoint = null)
        {
            if (clientDiagnostics == null)
            {
                throw new ArgumentNullException(nameof(clientDiagnostics));
            }
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            endpoint ??= new Uri("http://localhost:3000");

            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> OperationAsync(RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("Client2.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(context);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, context).ConfigureAwait(false);
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
            using var scope = _clientDiagnostics.CreateScope("Client2.Operation");
            scope.Start();
            try
            {
                using HttpMessage message = CreateOperationRequest(context);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateOperationRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client2", false);
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
