// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace custom_baseUrl_more_options_LowLevel
{
    /// <summary> The Paths service client. </summary>
    public partial class PathsClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly string _subscriptionId;
        private readonly string _dnsSuffix;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PathsClient for mocking. </summary>
        protected PathsClient()
        {
        }

        /// <summary> Initializes a new instance of PathsClient. </summary>
        /// <param name="subscriptionId"> The subscription id with value &apos;test12&apos;. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public PathsClient(string subscriptionId, AzureKeyCredential credential) : this(subscriptionId, credential, "host", new PathsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of PathsClient. </summary>
        /// <param name="subscriptionId"> The subscription id with value &apos;test12&apos;. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="dnsSuffix"> A string value that is used as a global part of the parameterized host. Default value &apos;host&apos;. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="credential"/> or <paramref name="dnsSuffix"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public PathsClient(string subscriptionId, AzureKeyCredential credential, string dnsSuffix, PathsClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(dnsSuffix, nameof(dnsSuffix));
            options ??= new PathsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _subscriptionId = subscriptionId;
            _dnsSuffix = dnsSuffix;
        }

        /// <summary> Get a 200 to test a valid base uri. </summary>
        /// <param name="vault"> The vault name, e.g. https://myvault. </param>
        /// <param name="secret"> Secret value. </param>
        /// <param name="keyName"> The key name with value &apos;key1&apos;. </param>
        /// <param name="keyVersion"> The key version. Default value &apos;v1&apos;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vault"/>, <paramref name="secret"/> or <paramref name="keyName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <response> The response returned from the service. Details of the request body schema are in the Remarks section below. </response>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> GetEmptyAsync(string vault, string secret, string keyName, string keyVersion = null, RequestContext context = null)
        {
            Argument.AssertNotNull(vault, nameof(vault));
            Argument.AssertNotNull(secret, nameof(secret));
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEmptyRequest(vault, secret, keyName, keyVersion, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a 200 to test a valid base uri. </summary>
        /// <param name="vault"> The vault name, e.g. https://myvault. </param>
        /// <param name="secret"> Secret value. </param>
        /// <param name="keyName"> The key name with value &apos;key1&apos;. </param>
        /// <param name="keyVersion"> The key version. Default value &apos;v1&apos;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vault"/>, <paramref name="secret"/> or <paramref name="keyName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <response> The response returned from the service. Details of the request body schema are in the Remarks section below. </response>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response GetEmpty(string vault, string secret, string keyName, string keyVersion = null, RequestContext context = null)
        {
            Argument.AssertNotNull(vault, nameof(vault));
            Argument.AssertNotNull(secret, nameof(secret));
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = ClientDiagnostics.CreateScope("PathsClient.GetEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEmptyRequest(vault, secret, keyName, keyVersion, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetEmptyRequest(string vault, string secret, string keyName, string keyVersion, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(vault, false);
            uri.AppendRaw(secret, false);
            uri.AppendRaw(_dnsSuffix, false);
            uri.AppendPath("/customuri/", false);
            uri.AppendPath(_subscriptionId, true);
            uri.AppendPath("/", false);
            uri.AppendPath(keyName, true);
            if (keyVersion != null)
            {
                uri.AppendQuery("keyVersion", keyVersion, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
