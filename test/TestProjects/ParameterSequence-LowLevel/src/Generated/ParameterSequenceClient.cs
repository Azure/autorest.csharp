// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace ParameterSequence_LowLevel
{
    // Data plane generated client.
    /// <summary> The ParameterSequence service client. </summary>
    public partial class ParameterSequenceClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ParameterSequenceClient for mocking. </summary>
        protected ParameterSequenceClient()
        {
        }

        /// <summary> Initializes a new instance of ParameterSequenceClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public ParameterSequenceClient(AzureKeyCredential credential) : this(credential, new Uri("http://localhost:3000"), new ParameterSequenceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ParameterSequenceClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public ParameterSequenceClient(AzureKeyCredential credential, Uri endpoint, ParameterSequenceClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new ParameterSequenceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary>
        /// [Protocol Method] Get Item
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="itemName"> item name. </param>
        /// <param name="origin"> The String to use. </param>
        /// <param name="version"> version of the item. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="itemName"/> or <paramref name="origin"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="itemName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParameterSequenceClient.xml" path="doc/members/member[@name='GetItemAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetItemAsync(string itemName, string origin, string version, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(itemName, nameof(itemName));
            Argument.AssertNotNull(origin, nameof(origin));

            using var scope = ClientDiagnostics.CreateScope("ParameterSequenceClient.GetItem");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetItemRequest(itemName, origin, version, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get Item
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="itemName"> item name. </param>
        /// <param name="origin"> The String to use. </param>
        /// <param name="version"> version of the item. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="itemName"/> or <paramref name="origin"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="itemName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParameterSequenceClient.xml" path="doc/members/member[@name='GetItem(string,string,string,RequestContext)']/*" />
        public virtual Response GetItem(string itemName, string origin, string version, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(itemName, nameof(itemName));
            Argument.AssertNotNull(origin, nameof(origin));

            using var scope = ClientDiagnostics.CreateScope("ParameterSequenceClient.GetItem");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetItemRequest(itemName, origin, version, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Select Item
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="itemName"> item name. </param>
        /// <param name="origin"> The String to use. </param>
        /// <param name="version"> version of the item. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="itemName"/> or <paramref name="origin"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="itemName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParameterSequenceClient.xml" path="doc/members/member[@name='SelectItemAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> SelectItemAsync(string itemName, string origin, string version, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(itemName, nameof(itemName));
            Argument.AssertNotNull(origin, nameof(origin));

            using var scope = ClientDiagnostics.CreateScope("ParameterSequenceClient.SelectItem");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSelectItemRequest(itemName, origin, version, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Select Item
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="itemName"> item name. </param>
        /// <param name="origin"> The String to use. </param>
        /// <param name="version"> version of the item. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="itemName"/> or <paramref name="origin"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="itemName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/ParameterSequenceClient.xml" path="doc/members/member[@name='SelectItem(string,string,string,RequestContext)']/*" />
        public virtual Response SelectItem(string itemName, string origin, string version, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(itemName, nameof(itemName));
            Argument.AssertNotNull(origin, nameof(origin));

            using var scope = ClientDiagnostics.CreateScope("ParameterSequenceClient.SelectItem");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSelectItemRequest(itemName, origin, version, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetItemRequest(string itemName, string origin, string version, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(itemName, true);
            uri.AppendQuery("origin", origin, true);
            request.Uri = uri;
            if (version != null)
            {
                request.Headers.Add("version", version);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateSelectItemRequest(string itemName, string origin, string version, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/select/", false);
            uri.AppendPath(itemName, true);
            uri.AppendQuery("origin", origin, true);
            request.Uri = uri;
            if (version != null)
            {
                request.Headers.Add("version", version);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
