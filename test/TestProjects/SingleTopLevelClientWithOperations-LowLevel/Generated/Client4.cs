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
    /// <summary> The Client4 service client. </summary>
    public partial class Client4
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _endpoint;

        /// <summary> The String to use. </summary>
        public virtual string ClientParameter { get; }
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Client4 for mocking. </summary>
        protected Client4()
        {
        }

        /// <summary> Initializes a new instance of Client4. </summary>
        /// <param name="clientDiagnostics"> The ClientDiagnostics instance to use. </param>
        /// <param name="pipeline"> The pipeline instance to use. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="clientParameter"> The String to use. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, or <paramref name="clientParameter"/> is null. </exception>
        internal Client4(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, string clientParameter, Uri endpoint = null)
        {
            if (clientDiagnostics == null)
            {
                throw new ArgumentNullException(nameof(clientDiagnostics));
            }
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            if (clientParameter == null)
            {
                throw new ArgumentNullException(nameof(clientParameter));
            }
            endpoint ??= new Uri("http://localhost:3000");

            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            ClientParameter = clientParameter;
            _endpoint = endpoint;
        }

        /// <summary> Operation has a parameter with `x-ms-resource-identifier: true`, hence `Client4` will be codegen&apos;ed as a resource client. </summary>
        /// <param name="filter"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual async Task<Response> PatchAsync(string filter, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("Client4.Patch");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatchRequest(filter, context);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Operation has a parameter with `x-ms-resource-identifier: true`, hence `Client4` will be codegen&apos;ed as a resource client. </summary>
        /// <param name="filter"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual Response Patch(string filter, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("Client4.Patch");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePatchRequest(filter, context);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreatePatchRequest(string filter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/client4", false);
            uri.AppendQuery("filter", filter, true);
            uri.AppendQuery("clientParameter", ClientParameter, true);
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
