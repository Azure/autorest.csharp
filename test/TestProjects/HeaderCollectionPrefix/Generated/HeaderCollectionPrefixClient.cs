// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace HeaderCollectionPrefix
{
    /// <summary> The HeaderCollectionPrefix service client. </summary>
    public partial class HeaderCollectionPrefixClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal HeaderCollectionPrefixRestClient RestClient { get; }

        /// <summary> Initializes a new instance of HeaderCollectionPrefixClient for mocking. </summary>
        protected HeaderCollectionPrefixClient()
        {
        }

        /// <summary> Initializes a new instance of HeaderCollectionPrefixClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal HeaderCollectionPrefixClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new HeaderCollectionPrefixRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <param name="metadata"> Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> OperationAsync(IDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderCollectionPrefixClient.Operation");
            scope.Start();
            try
            {
                return (await RestClient.OperationAsync(metadata, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="metadata"> Optional. Include this parameter to specify that the queue's metadata be returned as part of the response body. Note that metadata requested with this parameter must be stored in accordance with the naming restrictions imposed by the 2009-09-19 version of the Queue service. Beginning with this version, all metadata names must adhere to the naming conventions for C# identifiers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Operation(IDictionary<string, string> metadata = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("HeaderCollectionPrefixClient.Operation");
            scope.Start();
            try
            {
                return RestClient.Operation(metadata, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
