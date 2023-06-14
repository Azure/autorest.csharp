// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace custom_baseUrl_more_options
{
    /// <summary> The Paths service client. </summary>
    public partial class PathsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal PathsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of PathsClient for mocking. </summary>
        protected PathsClient()
        {
        }

        /// <summary> Initializes a new instance of PathsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> The subscription id with value 'test12'. </param>
        /// <param name="dnsSuffix"> A string value that is used as a global part of the parameterized host. Default value 'host'. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="subscriptionId"/> or <paramref name="dnsSuffix"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        internal PathsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, string dnsSuffix = "host")
        {
            RestClient = new PathsRestClient(clientDiagnostics, pipeline, subscriptionId, dnsSuffix);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get a 200 to test a valid base uri. </summary>
        /// <param name="vault"> The vault name, e.g. https://myvault. </param>
        /// <param name="secret"> Secret value. </param>
        /// <param name="keyName"> The key name with value 'key1'. </param>
        /// <param name="keyVersion"> The key version. Default value 'v1'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetEmptyAsync(string vault, string secret, string keyName, string keyVersion = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PathsClient.GetEmpty");
            scope.Start();
            try
            {
                return await RestClient.GetEmptyAsync(vault, secret, keyName, keyVersion, cancellationToken).ConfigureAwait(false);
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
        /// <param name="keyName"> The key name with value 'key1'. </param>
        /// <param name="keyVersion"> The key version. Default value 'v1'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetEmpty(string vault, string secret, string keyName, string keyVersion = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PathsClient.GetEmpty");
            scope.Start();
            try
            {
                return RestClient.GetEmpty(vault, secret, keyName, keyVersion, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
