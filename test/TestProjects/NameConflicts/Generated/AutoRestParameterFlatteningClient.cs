// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using NameConflicts.Models;

namespace NameConflicts
{
    /// <summary> The AutoRestParameterFlattening service client. </summary>
    public partial class AutoRestParameterFlatteningClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal AutoRestParameterFlatteningRestClient RestClient { get; }

        /// <summary> Initializes a new instance of AutoRestParameterFlatteningClient for mocking. </summary>
        protected AutoRestParameterFlatteningClient()
        {
        }

        /// <summary> Initializes a new instance of AutoRestParameterFlatteningClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal AutoRestParameterFlatteningClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new AutoRestParameterFlatteningRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="request"> The String to use. </param>
        /// <param name="message"> The String to use. </param>
        /// <param name="scope"> The String to use. </param>
        /// <param name="uri"> The String to use. </param>
        /// <param name="pipeline"> The String to use. </param>
        /// <param name="clientDiagnostics"> The String to use. </param>
        /// <param name="class"> The <see cref="Class"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Struct>> OperationAsync(string request, string message, string scope, string uri, string pipeline, string clientDiagnostics, Class @class, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.Operation");
            scope0.Start();
            try
            {
                return await RestClient.OperationAsync(request, message, scope, uri, pipeline, clientDiagnostics, @class, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <param name="request"> The String to use. </param>
        /// <param name="message"> The String to use. </param>
        /// <param name="scope"> The String to use. </param>
        /// <param name="uri"> The String to use. </param>
        /// <param name="pipeline"> The String to use. </param>
        /// <param name="clientDiagnostics"> The String to use. </param>
        /// <param name="class"> The <see cref="Class"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Struct> Operation(string request, string message, string scope, string uri, string pipeline, string clientDiagnostics, Class @class, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.Operation");
            scope0.Start();
            try
            {
                return RestClient.Operation(request, message, scope, uri, pipeline, clientDiagnostics, @class, cancellationToken);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <param name="httpMessage"> The <see cref="HttpMessage"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<HttpMessage>> HttpMessageAsync(HttpMessage httpMessage = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.HttpMessage");
            scope0.Start();
            try
            {
                return await RestClient.HttpMessageAsync(httpMessage, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <param name="httpMessage"> The <see cref="HttpMessage"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<HttpMessage> HttpMessage(HttpMessage httpMessage = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.HttpMessage");
            scope0.Start();
            try
            {
                return RestClient.HttpMessage(httpMessage, cancellationToken);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <param name="request"> The <see cref="Request"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Request>> RequestAsync(Request request = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.Request");
            scope0.Start();
            try
            {
                return await RestClient.RequestAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <param name="request"> The <see cref="Request"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Request> Request(Request request = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.Request");
            scope0.Start();
            try
            {
                return RestClient.Request(request, cancellationToken);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <param name="response"> The <see cref="Response"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.Response>> ResponseAsync(Models.Response response = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.Response");
            scope0.Start();
            try
            {
                return await RestClient.ResponseAsync(response, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <param name="response"> The <see cref="Response"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.Response> Response(Models.Response response = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.Response");
            scope0.Start();
            try
            {
                return RestClient.Response(response, cancellationToken);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="stringBody"> The binary to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<AutoRestParameterFlatteningAnalyzeBodyOperation> StartAnalyzeBodyAsync(Stream stringBody = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.StartAnalyzeBody");
            scope0.Start();
            try
            {
                var originalResponse = await RestClient.AnalyzeBodyAsync(stringBody, cancellationToken).ConfigureAwait(false);
                return new AutoRestParameterFlatteningAnalyzeBodyOperation(_clientDiagnostics, _pipeline, RestClient.CreateAnalyzeBodyRequest(stringBody).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="stringBody"> The binary to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AutoRestParameterFlatteningAnalyzeBodyOperation StartAnalyzeBody(Stream stringBody = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.StartAnalyzeBody");
            scope0.Start();
            try
            {
                var originalResponse = RestClient.AnalyzeBody(stringBody, cancellationToken);
                return new AutoRestParameterFlatteningAnalyzeBodyOperation(_clientDiagnostics, _pipeline, RestClient.CreateAnalyzeBodyRequest(stringBody).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="stringBody"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<AutoRestParameterFlatteningAnalyzeBodyOperation> StartAnalyzeBodyAsync(string stringBody = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.StartAnalyzeBody");
            scope0.Start();
            try
            {
                var originalResponse = await RestClient.AnalyzeBodyAsync(stringBody, cancellationToken).ConfigureAwait(false);
                return new AutoRestParameterFlatteningAnalyzeBodyOperation(_clientDiagnostics, _pipeline, RestClient.CreateAnalyzeBodyRequest(stringBody).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> Analyze body, that could be different media types. </summary>
        /// <param name="stringBody"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AutoRestParameterFlatteningAnalyzeBodyOperation StartAnalyzeBody(string stringBody = null, CancellationToken cancellationToken = default)
        {
            using var scope0 = _clientDiagnostics.CreateScope("AutoRestParameterFlatteningClient.StartAnalyzeBody");
            scope0.Start();
            try
            {
                var originalResponse = RestClient.AnalyzeBody(stringBody, cancellationToken);
                return new AutoRestParameterFlatteningAnalyzeBodyOperation(_clientDiagnostics, _pipeline, RestClient.CreateAnalyzeBodyRequest(stringBody).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }
    }
}
