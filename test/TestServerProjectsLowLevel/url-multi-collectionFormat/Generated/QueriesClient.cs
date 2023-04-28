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
    // Data plane generated client.
    /// <summary> The Queries service client. </summary>
    public partial class QueriesClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of QueriesClient for mocking. </summary>
        protected QueriesClient()
        {
        }

        /// <summary> Initializes a new instance of QueriesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public QueriesClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new QueriesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of QueriesClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public QueriesClient(AzureKeyCredential credential, Uri endpoint, QueriesClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new QueriesClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method]Get a null array of string using the multi-array format
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> a null array of string using the multi-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringMultiNullAsync(global::System.Collections.Generic.IEnumerable{string},global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringMultiNullAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringMultiNullRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]Get a null array of string using the multi-array format
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> a null array of string using the multi-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringMultiNull(global::System.Collections.Generic.IEnumerable{string},global::Azure.RequestContext)']/*" />
        public virtual Response ArrayStringMultiNull(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiNull");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringMultiNullRequest(arrayQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]Get an empty array [] of string using the multi-array format
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringMultiEmptyAsync(global::System.Collections.Generic.IEnumerable{string},global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringMultiEmptyAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringMultiEmptyRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]Get an empty array [] of string using the multi-array format
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an empty array [] of string using the multi-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringMultiEmpty(global::System.Collections.Generic.IEnumerable{string},global::Azure.RequestContext)']/*" />
        public virtual Response ArrayStringMultiEmpty(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringMultiEmptyRequest(arrayQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringMultiValidAsync(global::System.Collections.Generic.IEnumerable{string},global::Azure.RequestContext)']/*" />
        public virtual async Task<Response> ArrayStringMultiValidAsync(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringMultiValidRequest(arrayQuery, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]Get an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="arrayQuery"> an array of string [&apos;ArrayQuery1&apos;, &apos;begin!*&apos;();:@ &amp;=+$,/?#[]end&apos; , null, &apos;&apos;] using the mult-array format. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/QueriesClient.xml" path="doc/members/member[@name='ArrayStringMultiValid(global::System.Collections.Generic.IEnumerable{string},global::Azure.RequestContext)']/*" />
        public virtual Response ArrayStringMultiValid(IEnumerable<string> arrayQuery = null, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("QueriesClient.ArrayStringMultiValid");
            scope.Start();
            try
            {
                using HttpMessage message = CreateArrayStringMultiValidRequest(arrayQuery, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateArrayStringMultiNullRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/multi/string/null", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                foreach (var param in arrayQuery)
                {
                    uri.AppendQuery("arrayQuery", param, true);
                }
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayStringMultiEmptyRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/multi/string/empty", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                foreach (var param in arrayQuery)
                {
                    uri.AppendQuery("arrayQuery", param, true);
                }
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateArrayStringMultiValidRequest(IEnumerable<string> arrayQuery, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queries/array/multi/string/valid", false);
            if (arrayQuery != null && Optional.IsCollectionDefined(arrayQuery))
            {
                foreach (var param in arrayQuery)
                {
                    uri.AppendQuery("arrayQuery", param, true);
                }
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
