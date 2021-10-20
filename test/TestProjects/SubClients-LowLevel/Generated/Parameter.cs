// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace SubClients_LowLevel
{
    /// <summary> The Parameter service client. </summary>
    public partial class Parameter
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Parameter for mocking. </summary>
        protected Parameter()
        {
        }

        /// <summary> Initializes a new instance of Parameter. </summary>
        /// <param name="clientDiagnostics"> The ClientDiagnostics instance to use. </param>
        /// <param name="pipeline"> The pipeline instance to use. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal Parameter(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, Uri endpoint = null)
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

        /// <param name="subParameter"> The String to use. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParameter"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetSubParameterAsync(string subParameter, RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("Parameter.GetSubParameter");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSubParameterRequest(subParameter);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, options).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="subParameter"> The String to use. </param>
        /// <param name="options"> The request options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subParameter"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual Response GetSubParameter(string subParameter, RequestOptions options)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("Parameter.GetSubParameter");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSubParameterRequest(subParameter);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, options);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetSubParameterRequest(string subParameter)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/parameter/", false);
            uri.AppendPath(subParameter, true);
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
