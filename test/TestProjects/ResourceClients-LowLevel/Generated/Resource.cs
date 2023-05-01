// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace ResourceClients_LowLevel
{
    // Data plane generated sub-client.
    /// <summary> The Resource sub-client. </summary>
    public partial class Resource
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> Group identifier. </summary>
        public string GroupId { get; }

        /// <summary> Item identifier. </summary>
        public string ItemId { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Resource for mocking. </summary>
        protected Resource()
        {
        }

        /// <summary> Initializes a new instance of Resource. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="groupId"> Group identifier. </param>
        /// <param name="itemId"> Item identifier. </param>
        /// <param name="endpoint"> server parameter. </param>
        internal Resource(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, AzureKeyCredential keyCredential, string groupId, string itemId, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            GroupId = groupId;
            ItemId = itemId;
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method]Get an item. Method should stay in `Item` subclient.
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Resource.xml" path="doc/members/member[@name='GetItemAsync(RequestContext)']/*" />
        public virtual async Task<Response> GetItemAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Resource.GetItem");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetItemRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]Get an item. Method should stay in `Item` subclient.
        /// <list type="bullet">
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Resource.xml" path="doc/members/member[@name='GetItem(RequestContext)']/*" />
        public virtual Response GetItem(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Resource.GetItem");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetItemRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetItemRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/items/", false);
            uri.AppendPath(GroupId, true);
            uri.AppendPath("/", false);
            uri.AppendPath(ItemId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
